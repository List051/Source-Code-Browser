'Imports System.Text
'Imports System.IO

'Public Class HtmlHelpBuilder

'#Region "Variabili"

'    Private ReadOnly SB As New StringBuilder

'#End Region


'#Region "Costruttore"

'    Public Sub New()

'        SB.AppendLine("<!DOCTYPE html>")
'        SB.AppendLine("<html>")
'        SB.AppendLine("<head>")
'        SB.AppendLine("<meta charset='UTF-8'>")

'        SB.AppendLine("<style>")

'        SB.AppendLine("

'body {
'    font-family:'Segoe UI';
'    font-size:11pt;
'    margin:25px;
'    background:white;
'    color:#222;
'}

'h1 {
'    color:#004A8F;
'}

'h2 {
'    color:#0066CC;
'}

'.folder {
'    margin-top:15px;
'    color:#0055AA;
'    font-weight:bold;
'}

'.file {
'    margin-left:30px;
'}

'.text {
'    margin-top:8px;
'}

'.box {

'    padding:10px;
'    margin-top:15px;
'    border-radius:5px;

'}

'.note {

'    background:#EAF4FF;
'    border-left:5px solid #0066CC;

'}


'.info {

'    background:#E8F7FF;
'    border-left:5px solid #00AEEF;

'}


'.success {

'    background:#E8FFE8;
'    border-left:5px solid green;

'}


'.warning {

'    background:#FFF4D8;
'    border-left:5px solid orange;

'}


'.error {

'    background:#FFE8E8;
'    border-left:5px solid red;

'}


'.new {

'    background:#F0E8FF;
'    border-left:5px solid purple;

'}


'.code {

'    background:#F5F5F5;
'    border:1px solid #CCC;
'    padding:10px;
'    font-family:Consolas;
'    white-space:pre;

'}


'img {

'    margin:10px;

'}


'hr {

'    margin-top:20px;
'    margin-bottom:20px;

'}

'")

'        SB.AppendLine("</style>")
'        SB.AppendLine("</head>")
'        SB.AppendLine("<body>")
'        SB.AppendLine("<script>")
'        SB.AppendLine("function openFile(el){")
'        SB.AppendLine(" window.chrome.webview.postMessage(el.dataset.file);")
'        SB.AppendLine("}")
'        SB.AppendLine("</script>")

'    End Sub

'#End Region


'#Region "Titoli e Testo"


'    Public Sub Title(testo As String)

'        SB.AppendLine("<h1>" & Encode(testo) & "</h1>")

'    End Sub



'    Public Sub Subtitle(testo As String)

'        SB.AppendLine("<h2>" & Encode(testo) & "</h2>")

'    End Sub



'    Public Sub Text(testo As String)

'        SB.AppendLine("<div class='text'>")
'        SB.AppendLine(Encode(testo))
'        SB.AppendLine("</div>")

'    End Sub


'#End Region



'#Region "Struttura"


'    Public Sub Folder(nome As String)

'        SB.AppendLine(
'            "<div class='folder'>📁 " &
'            Encode(nome) &
'            "</div>")

'    End Sub



'    Public Sub File(nome As String)

'        SB.AppendLine(
'            "<div class='file'>📄 " &
'            Encode(nome) &
'            "</div>")

'    End Sub



'    Public Sub Separator()

'        SB.AppendLine("<hr>")

'    End Sub



'    Public Sub Space()

'        SB.AppendLine("<br>")

'    End Sub


'#End Region



'#Region "Messaggi"


'    Public Sub Note(testo As String)

'        Box("NOTE", testo, "note")

'    End Sub



'    Public Sub Info(testo As String)

'        Box("INFO", testo, "info")

'    End Sub



'    Public Sub Success(testo As String)

'        Box("OK", testo, "success")

'    End Sub



'    Public Sub Warning(testo As String)

'        Box("ATTENZIONE", testo, "warning")

'    End Sub



'    Public Sub [Error](testo As String)

'        Box("ERRORE", testo, "error")

'    End Sub



'    Public Sub NewFeature(testo As String)

'        Box("🆕 NUOVA FUNZIONE",
'            testo,
'            "new")

'    End Sub



'    Public Sub Box(titolo As String,
'                    testo As String,
'                    stile As String)


'        SB.AppendLine(
'            "<div class='box " & stile & "'>")


'        SB.AppendLine(
'            "<b>" & titolo & "</b><br><br>")


'        SB.AppendLine(
'            Encode(testo))


'        SB.AppendLine("</div>")


'    End Sub


'#End Region



'#Region "Codice"


'    Public Sub Code(codice As String)


'        SB.AppendLine("<div class='code'>")


'        SB.AppendLine(
'            Encode(codice))


'        SB.AppendLine("</div>")


'    End Sub


'#End Region



'#Region "Immagini"


'    Public Sub Image(percorso As String,
'                     Optional larghezza As Integer = 32)


'        SB.AppendLine(
'            "<img src='" &
'            percorso &
'            "' width='" &
'            larghezza &
'            "'>")


'    End Sub



'#End Region



'#Region "Link"


'    Public Sub Link(testo As String,
'                    indirizzo As String)


'        SB.AppendLine(
'            "<a href='" &
'            indirizzo &
'            "'>" &
'            Encode(testo) &
'            "</a>")


'    End Sub


'#End Region

'#Region "Directory Tree"


'    Public Sub DirectoryTree(percorso As String,
'                         Optional filtro As String = "*.*")

'        If Not Directory.Exists(percorso) Then

'            Warning("Cartella non trovata: " & percorso)
'            Exit Sub

'        End If


'        SB.AppendLine("<div class='tree'>")


'        SB.AppendLine(
'        "<div class='folder'>📁 " &
'        Encode(Path.GetFileName(percorso)) &
'        "</div>")


'        ScriviDirectory(percorso, 1, filtro)


'        SB.AppendLine("</div>")


'    End Sub
'    Private Sub ScriviDirectory(percorso As String,
'                            livello As Integer,
'                            filtro As String)


'        Dim sottocartelleValide As New List(Of String)


'        ' Cerco solo cartelle che contengono file validi

'        For Each cartella In Directory.GetDirectories(percorso)

'            If ContieneFile(cartella, filtro) Then

'                sottocartelleValide.Add(cartella)

'            End If

'        Next



'        ' Scrivo solo cartelle valide

'        For Each cartella In sottocartelleValide


'            SB.AppendLine(
'            "<div class='folder' style='margin-left:" &
'            livello * 25 &
'            "px'>" &
'            "📁 " &
'            Encode(Path.GetFileName(cartella)) &
'            "</div>")


'            ScriviDirectory(cartella,
'                        livello + 1,
'                        filtro)


'        Next



'        ' Scrivo i file VB cliccabili

'        For Each nomeFile In Directory.GetFiles(percorso, filtro)

'            Dim percorsoJS As String = nomeFile.Replace("\", "\\").Replace("'", "\'")

'            SB.AppendLine(
'        "<div class='file' style='margin-left:" & livello * 25 & "px'>" &
'        "<a href='#' onclick=""window.chrome.webview.postMessage('" &
'        percorsoJS &
'        "'); return false;"">" &
'        "📄 " & Encode(Path.GetFileName(nomeFile)) &
'        "</a></div>")

'        Next


'    End Sub
'    Private Function ContieneFile(percorso As String,
'                              filtro As String) As Boolean


'        If Directory.GetFiles(percorso, filtro).Length > 0 Then
'            Return True
'        End If


'        For Each cartella In Directory.GetDirectories(percorso)

'            If ContieneFile(cartella, filtro) Then
'                Return True
'            End If

'        Next


'        Return False


'    End Function
'#End Region

'#Region "Generazione"


'    Public Function ToHtml() As String


'        SB.AppendLine("</body>")
'        SB.AppendLine("</html>")


'        Return SB.ToString()


'    End Function


'#End Region



'#Region "Utility"


'    Private Function Encode(testo As String) As String

'        If testo Is Nothing Then Return ""

'        Return testo.Replace("&", "&amp;") _
'                    .Replace("<", "&lt;") _
'                    .Replace(">", "&gt;") _
'                    .Replace("""", "&quot;")


'    End Function


'#End Region


'End Class