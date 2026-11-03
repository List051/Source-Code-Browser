
Imports System.IO
' Imports CustomMessageBoxVB  ' Ora in libreria
Imports Microsoft.Web.WebView2.WinForms
Imports WinItalPascal

Public Class Form1

    Private _HelpBuilder As HtmlHelpBuilder2
    ' Public Property SourcePath As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FrmTitolo.CTitolo(Me, "Presentazione Aggiornamento Libreria")
        ScreenUtility.FullScreen(Me)
        Dim imgFreccia As Image = My.Resources.arrows
        PopupHelper.AttachPopup(AvvisoPictBox, vbCrLf & "Hai già Aperto Cartella ?" & vbCrLf & vbCrLf & "Visualizza Dettagli Codice", imgFreccia, Color.Blue, Color.Aquamarine)
        PopupHelper.AttachPopup(SezionePictBox, vbCrLf & "Hai già Aperto Cartella ?" & vbCrLf & vbCrLf & "Seleziona la routine da visualizzare", imgFreccia, Color.Blue, Color.Aquamarine)

        AggiornaPulsanteUltimaCartella()
        LibPresentazione()
    End Sub

    Private Sub RjBtnInt_Click(sender As Object, e As EventArgs) Handles RjBtnInt.Click
        FrmMessBox.Show()
        '    Dim root As VbNode =
        'VbStructureParser.Parse("C:\Users\Utente\Documents\VSC\GdRVideo\HelpBrowser\source\core\TreeBuilder.vb")

        '    Dim txt As String =
        '        VbStructureParser.Dump(root)

        '    MessageBox.Show(txt)
    End Sub



    Private Sub BrnApriCartella_Click(
    sender As Object,
    e As EventArgs) Handles BrnApriCartella.Click

        Using dlg As New FolderBrowserDialog()

            dlg.Description = "Seleziona la cartella del progetto VB.NET"

            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            BrowserSettings.SaveLastFolder(dlg.SelectedPath)
            AggiornaPulsanteUltimaCartella() '

            Dim frm As New FrmWebHelp(dlg.SelectedPath)

            frm.Show()

        End Using

    End Sub

    Private Sub AggiornaPulsanteUltimaCartella()

        Dim lastFolder As String =
        BrowserSettings.LoadLastFolder()

        If String.IsNullOrWhiteSpace(lastFolder) Then

            BtnApreUltimaCartella.Text = "🕘 Apri ultima cartella"
            Exit Sub

        End If

        BtnApreUltimaCartella.Text =
        "🕘 Apri ultima cartella" & vbCrLf & vbCrLf &
        "(" & Path.GetFileName(lastFolder) & ")"

    End Sub

#Region "Colorazione Sintassi Pagina iniziale"

    Sub LibPresentazione() ' Page1 Inizale
        'ColoraRigheConParola(RichTextBox1, "Sub", Color.Blue)
        'ColoraRigheConParola(RichTextBox1, "Report", Color.Red)
        'ColoraRigheConParola(RichTextBox1, "IDCliOrd", Color.Red)
        ' ColoraRiga(RichTextBox1, 0, Color.Red)
        ' crea lista parole da colorare
        Dim lista As New List(Of String) From {"DataBase", "Reports", "Popup", "Grid", "RDLC", "Logging", "Forms", "DataGridView"}
        Dim lista2 As New List(Of String) From {"GridUtility", "DB", "DataGVLoad", "ReportManager", "ReportImpostazioni", "FrameWorkLogger"}
        ColoraParole(RichTextBox1, lista, Color.BlueViolet)
        ColoraParole(RichTextBox1, lista2, Color.Blue)
        ' per i commenti
        'ColoraRigheConComm(RichTextBox1, "'", Color.Green)
        'ColoraRigheConComm(RichTextBox1, "*", Color.Green)
        ' Evidenzia intera riga
        EvidenziaRiga(RichTextBox1, 0, Color.Yellow)
        ColoraRiga(RichTextBox1, 0, Color.Red)

    End Sub

    Private Sub BtnApreUltimaCartella_Click(
    sender As Object,
    e As EventArgs) Handles BtnApreUltimaCartella.Click

        Dim lastFolder As String =
        BrowserSettings.LoadLastFolder()

        If String.IsNullOrWhiteSpace(lastFolder) Then

            IPMessageBox.Show(
            "Non è stata ancora salvata nessuna cartella.",
            "Browser",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

            Exit Sub

        End If

        If Not Directory.Exists(lastFolder) Then

            IPMessageBox.Show(
            "La cartella salvata non esiste più:" &
            vbCrLf & vbCrLf &
            lastFolder,
            "Browser",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Exit Sub

        End If

        Dim frm As New FrmWebHelp(lastFolder)

        frm.Show()

    End Sub

    Private Sub RjBtnCreaAlbero_Click(sender As Object, e As EventArgs) Handles RjBtnCreaAlbero.Click
        '  HtmlTreeTest.CreaAlberoTest()

        ' Aprire Mia PlayList di Youtube
        IPMessageBox.Show("Disabilitato  >> Albero Creato" & vbCrLf & "Quindi Apre la mia PlayList" & vbCrLf & "https://www.youtube.com/@iaoraGo/playlists", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Chiede conferma all'utente
        Dim risposta As DialogResult = IPMessageBox.Show(
            "Hai già un browser aperto ?" & vbCrLf & "Premi Sì per procedere, No per annullare.",
            "Conferma apertura pagina",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If risposta = DialogResult.No Then
            Exit Sub
        End If

        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = "https://www.youtube.com/@iaoraGo/playlists",
                .UseShellExecute = True
            }
            Process.Start(psi)

        Catch ex As Exception
            IPMessageBox.Show(
                "Errore durante l'apertura del browser:" & vbCrLf &
                ex.Message,
                "Errore",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try
    End Sub

    Private Sub RjBtnChiudiApp_Click(sender As Object, e As EventArgs) Handles RjBtnChiudiApp.Click
        Close()
    End Sub

#End Region



End Class

