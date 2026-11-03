Imports System.IO
Imports System.Text
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft
Imports Newtonsoft.Json
Imports WinItalPascal

Public Class HtmlHelpBuilder2

#Region "Campi privati"


    Private ReadOnly _WebView As WebView2

    Private ReadOnly _HelpFolder As String

    Private ReadOnly _SourceFolder As String

    Private WithEvents _CoreWebView As CoreWebView2

    Private _NavigationAdded As Boolean = False


#End Region

#Region "Costruttore"


    Public Sub New(
        webView As WebView2,
        helpFolder As String,
        sourceFolder As String)

        _WebView = webView

        _HelpFolder = helpFolder

        _SourceFolder = sourceFolder

        IPMessageBox.Show("SOURCE = " & sourceFolder)

    End Sub


#End Region

#Region "Avvio Browser"


    Public Async Function BuildAsync() As Task

        If _WebView Is Nothing Then

            Throw New ArgumentNullException(
                NameOf(_WebView))

        End If


        If Not Directory.Exists(_HelpFolder) Then

            Throw New DirectoryNotFoundException(
                "Cartella Help non trovata: " &
                _HelpFolder)

        End If


        ' Inizializzazione WebView2

        Await _WebView.EnsureCoreWebView2Async()

        _CoreWebView =
            _WebView.CoreWebView2


        AddHandler _CoreWebView.WebMessageReceived,
            AddressOf WebMessageReceived


        ' Percorso browser.html

        Dim indexFile As String =
            Path.Combine(
                _HelpFolder,
                "browser.html")


        If Not File.Exists(indexFile) Then

            Throw New FileNotFoundException(
                "Index.html non trovato",
                indexFile)

        End If


        ' Caricamento pagina

        If Not _NavigationAdded Then

            AddHandler _WebView.NavigationCompleted,
                AddressOf NavigationCompleted

            _NavigationAdded = True

        End If


        _WebView.Source =
            New Uri(indexFile)

    End Function

#End Region

#Region "Altro da vedere"

#End Region

#Region "Directory Tree"

    Private Async Function ShowDirectoryTree() As Task

        ' Dim tb As New TreeBuilder(_SourceFolder)
        ' Dim sourceRoot As String =
        '     Path.Combine(_SourceFolder, "HelpBrowser", "source")

        Dim sourceRoot As String =
            _SourceFolder

        Dim tb As New TreeBuilder(sourceRoot)

        Dim htmlTree As String =
            tb.BuildTree()

        ' Inserisco x verificare il parser

        Dim parser As New VbParser()

        Dim primoFile As String =
            Directory.GetFiles(
                sourceRoot,
                "*.vb",
                SearchOption.AllDirectories).
                FirstOrDefault()

        If primoFile IsNot Nothing Then

            Dim codeFile As VbCodeFile =
                parser.Parse(primoFile)


            For Each elemento In codeFile.RootElements

                PrintNode(
                    elemento,
                    0)

            Next

        End If

        Dim script As String =
            "ShowTree(" &
            Newtonsoft.Json.JsonConvert.SerializeObject(
                htmlTree) &
            ")"


        Await _WebView.CoreWebView2.ExecuteScriptAsync(
            script)

    End Function

    Private Sub PrintNode(
        node As VbCodeElement,
        livello As Integer)

        Dim spazi As String =
            New String(
                " "c,
                livello * 4)

        For Each figlio In node.Children

            PrintNode(
                figlio,
                livello + 1)

        Next

    End Sub

#End Region

#Region "JavaScript"

#End Region

#Region "Navigation"

    Private Async Sub NavigationCompleted(
        sender As Object,
        e As CoreWebView2NavigationCompletedEventArgs)

        Await ShowDirectoryTree()


    End Sub


#End Region

#Region "WebMessage"

    Private Async Sub WebMessageReceived(
    sender As Object,
    e As CoreWebView2WebMessageReceivedEventArgs)

        Dim rawMsg As String = Nothing

        Try
            rawMsg = e.TryGetWebMessageAsString()
        Catch ex As ArgumentException
            Debug.WriteLine("TryGetWebMessageAsString fallita: " & ex.Message)
            Dim prop = e.GetType().GetProperty("WebMessageAsJson")
            If prop IsNot Nothing Then
                rawMsg = TryCast(prop.GetValue(e), String)
            Else
                Return
            End If
        End Try

        Debug.WriteLine("WEBMESSAGE = " & rawMsg)

        If String.IsNullOrWhiteSpace(rawMsg) Then
            Return
        End If

        ' Gestione JSON (azioni)
        If rawMsg.StartsWith("{") OrElse rawMsg.StartsWith("[") Then
            Try
                Dim payload = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawMsg)
                If payload IsNot Nothing AndAlso payload.ContainsKey("action") Then
                    Dim action = If(payload("action") IsNot Nothing, payload("action").ToString(), String.Empty)
                    Select Case action
                        Case "RicercaDiretta"
                            Dim query = If(payload.ContainsKey("query") AndAlso payload("query") IsNot Nothing, payload("query").ToString(), String.Empty)
                            Await EseguiRicerca(query)
                            Return

                        Case "OpenFileAndGoto"
                            Dim path As String = ""
                            Dim lineNum As Integer = 1

                            If payload.ContainsKey("path") AndAlso payload("path") IsNot Nothing Then
                                path = payload("path").ToString()
                            End If

                            If payload.ContainsKey("line") AndAlso payload("line") IsNot Nothing Then
                                Integer.TryParse(payload("line").ToString(), lineNum)
                            End If

                            If String.IsNullOrWhiteSpace(path) Then
                                Return
                            End If

                            If Not File.Exists(path) Then
                                ' Proponi all'utente di selezionare il file se non trovato
                                Using ofd As New OpenFileDialog()
                                    ofd.InitialDirectory = If(Directory.Exists(_SourceFolder), _SourceFolder, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
                                    ofd.FileName = System.IO.Path.GetFileName(path)
                                    ofd.Title = "File non trovato. Seleziona il file corretto:"
                                    If ofd.ShowDialog() = DialogResult.OK Then
                                        path = ofd.FileName
                                    Else
                                        Return
                                    End If
                                End Using
                            End If

                            ' Carico e mostro contenuto come nel flusso esistente
                            Dim codice As String = File.ReadAllText(path)
                            Dim html As String = CodeHighLight.HighlightVBWithLines(codice)
                            Dim codeTree As String = SourceLoader.LoadFile(path)
                            Dim nomeFile As String = System.IO.Path.GetFileName(path)

                            Await ShowSource(html)
                            Await ShowCodeTree(codeTree)
                            Await ShowFileName(nomeFile)

                            ' Chiamo GotoCode sul lato client per posizionare vista sulla riga richiesta
                            Try
                                Await _WebView.CoreWebView2.ExecuteScriptAsync("GotoCode(" & lineNum.ToString() & ");")
                            Catch ex As Exception
                                Debug.WriteLine("Errore eseguendo GotoCode: " & ex.Message)
                            End Try

                            Return

                        Case Else
                            Debug.WriteLine("Azione JSON ignota: " & action)
                            Return
                    End Select
                End If
            Catch ex As Exception
                Debug.WriteLine("Parsing JSON fallito: " & ex.Message)
                ' fallback al comportamento testuale legacy
            End Try
        End If

        ' Comportamento legacy (stringhe plain: RICERCA:, nome file, ecc.)
        If rawMsg.StartsWith("RICERCA:", StringComparison.OrdinalIgnoreCase) Then
            Dim testoRicerca As String = rawMsg.Substring("RICERCA:".Length)
            Await EseguiRicerca(testoRicerca)
            Return
        End If

        If rawMsg = "HtmlHelpBuilder2" Then
            Await _WebView.CoreWebView2.ExecuteScriptAsync("alert('HtmlHelpBuilder2 OK');")
            Return
        End If

        If String.IsNullOrWhiteSpace(rawMsg) Then
            Return
        End If

        If Not File.Exists(rawMsg) Then
            IPMessageBox.Show("File non trovato:" & vbCrLf & rawMsg)
            Return
        End If

        ' Caricamento e visualizzazione file (comportamento esistente)
        Dim codice2 As String = File.ReadAllText(rawMsg)
        Dim html2 As String = CodeHighLight.HighlightVBWithLines(codice2)
        Dim codeTree2 As String = SourceLoader.LoadFile(rawMsg)
        Dim nomeFile2 As String = Path.GetFileName(rawMsg)

        Await ShowSource(html2)
        Await ShowCodeTree(codeTree2)
        Await ShowFileName(nomeFile2)

    End Sub




    'Private Async Sub WebMessageReceived(
    'sender As Object,
    'e As CoreWebView2WebMessageReceivedEventArgs)

    '    Dim rawMsg As String = Nothing

    '    ' Provo a ottenere il messaggio come stringa (TryGetWebMessageAsString può lanciare ArgumentException)
    '    Try
    '        rawMsg = e.TryGetWebMessageAsString()
    '    Catch ex As ArgumentException
    '        'Ins in un messaggio ("TryGetWebMessageAsString fallita: " & ex.Message)
    '        ' ******
    '        Dim prop = e.GetType().GetProperty("WebMessageAsJson")
    '        If prop IsNot Nothing Then
    '            rawMsg = TryCast(prop.GetValue(e), String)
    '        Else
    '            ' Non possiamo leggere il messaggio come stringa/JSON -> esco
    '            Return
    '        End If
    '    End Try

    '    'ins probaile messaggio rawMsg)

    '    If String.IsNullOrWhiteSpace(rawMsg) Then
    '        Return
    '    End If

    '    ' Se è JSON (oggetto), deserializzo e controllo action/query
    '    If rawMsg.StartsWith("{") OrElse rawMsg.StartsWith("[") Then
    '        Try
    '            Dim payload = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(rawMsg)
    '            If payload IsNot Nothing AndAlso payload.ContainsKey("action") Then
    '                Dim action = If(payload("action") IsNot Nothing, payload("action").ToString(), String.Empty)
    '                Select Case action
    '                    Case "RicercaDiretta"
    '                        Dim query = If(payload.ContainsKey("query") AndAlso payload("query") IsNot Nothing, payload("query").ToString(), String.Empty)
    '                        Await EseguiRicerca(query)
    '                        Return
    '                        ' Aggiungi qui altri action handlers se necessari
    '                    Case Else
    '                        'al momento nulla)
    '                        Return
    '                End Select
    '            End If
    '        Catch ex As Exception
    '            'inserire exception)
    '            ' Se fallisce, proseguo
    '        End Try
    '    End If

    '    ' Comportamento attuale basato su stringhe plain
    '    If rawMsg.StartsWith("RICERCA:", StringComparison.OrdinalIgnoreCase) Then
    '        Dim testoRicerca As String = rawMsg.Substring("RICERCA:".Length)
    '        Await EseguiRicerca(testoRicerca)
    '        Return
    '    End If

    '    If rawMsg = "HtmlHelpBuilder2" Then
    '        Await _WebView.CoreWebView2.ExecuteScriptAsync("alert('HtmlHelpBuilder2 OK');")
    '        Return
    '    End If

    '    If String.IsNullOrWhiteSpace(rawMsg) Then
    '        Return
    '    End If

    '    If Not File.Exists(rawMsg) Then
    '        MessageBox.Show("File non trovato:" & vbCrLf & rawMsg)
    '        Return
    '    End If

    '    Dim codice As String = File.ReadAllText(rawMsg)
    '    Dim html As String = CodeHighLight.HighlightVBWithLines(codice)
    '    Dim codeTree As String = SourceLoader.LoadFile(rawMsg)
    '    Dim nomeFile As String = Path.GetFileName(rawMsg)

    '    Await ShowSource(html)
    '    Await ShowCodeTree(codeTree)
    '    Await ShowFileName(nomeFile)



    '    Try

    '    Catch ex As Exception

    '    End Try
    '    ' --- FINE  ---

    'End Sub


#End Region


#Region "Ricerca"

    ' ============================================================
    ' INSERITO PER RICERCA
    '
    ' Esegue la ricerca nei file .vb della cartella progetto.
    '
    ' La ricerca vera e propria viene effettuata dalla classe:
    '
    ' Ricerca.vb
    '
    ' Questa procedura si occupa soltanto del collegamento
    ' tra WebView2 e Ricerca.vb.
    ' ============================================================

    Private Async Function EseguiRicerca(
        testoRicerca As String) As Task

        ' --------------------------------------------------------
        ' Controllo testo
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(testoRicerca) Then

            Await ShowSearchResults(
                "<div>Nessun testo da cercare.</div>")

            Return

        End If

        ' --------------------------------------------------------
        ' Esegue la ricerca
        ' --------------------------------------------------------

        Dim risultati As List(Of Ricerca.Risultato) =
            Ricerca.Cerca(
                _SourceFolder,
                testoRicerca)

        ' --------------------------------------------------------
        ' Costruzione HTML risultati
        ' --------------------------------------------------------

        Dim sb As New StringBuilder()

        If risultati.Count = 0 Then

            sb.Append(
                "<div>Nessun risultato per: <strong>" &
                System.Net.WebUtility.HtmlEncode(
                    testoRicerca) &
                "</strong></div>")
        Else

            sb.Append(
                "<div class=""search-count"">")


            sb.Append(
                risultati.Count.ToString())


            sb.Append(
                " risultato/i per: <strong>")


            sb.Append(
                System.Net.WebUtility.HtmlEncode(
                    testoRicerca))


            sb.Append(
                "</strong></div>")


            sb.Append(
                "<div class=""search-result-list"">")


            For Each risultato As Ricerca.Risultato In risultati

                sb.Append("<div class=""search-result"">")

                ' Determina percorso file reale:
                Dim resultPath As String = risultato.NomeFile

                ' Se NomeFile non è un percorso assoluto, prova a risolverlo rispetto a _SourceFolder
                If Not Path.IsPathRooted(resultPath) Then
                    Dim candidate As String = Path.Combine(_SourceFolder, risultato.NomeFile)
                    If File.Exists(candidate) Then
                        resultPath = candidate
                    Else
                        ' Se la ricerca ha restituito un percorso relativo ma non esiste in _SourceFolder,
                        ' prova a vedere se il risultato contiene una proprietà Percorso/FullPath (se presente)
                        Dim prop = risultato.GetType().GetProperty("FilePath")
                        If prop IsNot Nothing Then
                            Dim v = TryCast(prop.GetValue(risultato), String)
                            If Not String.IsNullOrWhiteSpace(v) Then
                                resultPath = v
                            End If
                        End If
                    End If
                End If

                ' Se alla fine il file non esiste, il link invierà comunque il path (l'host potrà proporre un fallback)
                ' Costruisco il link: uso JsonConvert per escape sicuro del path nella stringa JS
                sb.Append("<div class=""search-result-file"">")
                sb.Append("<a href=""#"" onclick='OpenFileAndGoto(" &
                          JsonConvert.SerializeObject(resultPath) & "," &
                          risultato.NumeroRiga.ToString() &
                          "); return false;'>📄 " &
                          System.Net.WebUtility.HtmlEncode(
                              Path.GetFileName(resultPath)) &
                          "</a>")
                sb.Append("</div>")

                sb.Append("<div class=""search-result-line"">")
                sb.Append("riga ")
                sb.Append(risultato.NumeroRiga.ToString())
                sb.Append(" &nbsp; ")
                sb.Append(System.Net.WebUtility.HtmlEncode(risultato.TestoRiga))
                sb.Append("</div>")

                sb.Append("</div>")

            Next


            sb.Append(
                "</div>")

        End If


        ' --------------------------------------------------------
        ' Invia i risultati alla pagina HTML
        ' --------------------------------------------------------

        Await ShowSearchResults(
            sb.ToString())

    End Function


    ' ============================================================
    ' INSERITO PER RICERCA
    '
    ' Aggiorna il pannello:
    '
    ' #searchResultsContent
    '
    ' presente in browser.html
    ' ============================================================

    Private Async Function ShowSearchResults(
        html As String) As Task


        Dim script As String =
            "ShowSearchResults(" &
            JsonConvert.SerializeObject(html) &
            ")"


        Await _WebView.CoreWebView2.ExecuteScriptAsync(
            script)

    End Function


#End Region

#Region "Show File Name"


    Private Async Function ShowFileName(
        nomeFile As String) As Task


        Dim script As String =
            "ShowFileName(" &
            JsonConvert.SerializeObject(
                nomeFile) &
            ")"


        Await _WebView.CoreWebView2.ExecuteScriptAsync(
            script)

    End Function


#End Region

#Region "Source Viewer"


    Private Async Function ShowSource(
        html As String) As Task


        Dim script As String =
            "ShowSource(" &
            JsonConvert.SerializeObject(
                html) &
            ")"


        Await _WebView.CoreWebView2.ExecuteScriptAsync(
            script)

    End Function


#End Region

#Region "Show Code Tree"


    Private Async Function ShowCodeTree(
        codeTree As String) As Task


        Dim script As String =
            "ShowCodeTree(" &
            JsonConvert.SerializeObject(
                codeTree) &
            ")"


        Await _WebView.CoreWebView2.ExecuteScriptAsync(
            script)

    End Function


#End Region

#Region "Show Source (New Version)"


    Public Sub CaricaFile(
        percorso As String)


        Try

            Dim html As String =
                SourceLoader.LoadFile(
                    percorso)


            Dim script As String =
                "ShowSource(" &
                Newtonsoft.Json.JsonConvert.SerializeObject(
                    html) &
                ");"


            _WebView.CoreWebView2.ExecuteScriptAsync(
                script)


        Catch ex As Exception

            IPMessageBox.Show(
                ex.Message,
                "Errore caricamento file")

        End Try

    End Sub


#End Region

End Class
