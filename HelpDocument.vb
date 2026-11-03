Imports System.Text

Public Class HelpDocument

    Private ReadOnly Html As New StringBuilder

    Public Sub New()

        Html.AppendLine("<!DOCTYPE html>")
        Html.AppendLine("<html>")
        Html.AppendLine("<head>")
        Html.AppendLine("<meta charset='UTF-8'>")

        Html.AppendLine("<style>")

        Html.AppendLine("
body{
font-family:'Segoe UI';
font-size:11pt;
margin:20px;
background:white;
color:black;
}

h2{
color:#0050A0;
margin-bottom:18px;
}

.folder{
color:#0050A0;
font-weight:bold;
margin-top:14px;
}

.file{
margin-left:30px;
margin-top:2px;
}

.note{
margin-top:18px;
padding:10px;
background:#EAF4FF;
border-left:5px solid RoyalBlue;
border-radius:5px;
}

.new{
margin-top:15px;
padding:8px;
background:#FFF4D8;
border-left:5px solid Orange;
border-radius:5px;
}

.code{
background:#F5F5F5;
padding:8px;
font-family:Consolas;
white-space:pre;
border-radius:4px;
}

</style>")

        Html.AppendLine("</head>")
        Html.AppendLine("<body>")

    End Sub



    Public Sub Title(testo As String)

        Html.AppendLine("<h2>" & testo & "</h2>")

    End Sub

    Public Sub Folder(nome As String)

        Html.AppendLine("<div class='folder'>📁 " &
                        nome &
                        "</div>")

    End Sub

    Public Sub File(nome As String)

        Html.AppendLine("<div class='file'>📄 " &
                        nome &
                        "</div>")

    End Sub

    Public Sub Note(testo As String)

        Html.AppendLine("<div class='note'>")

        Html.AppendLine("<b>NOTE</b><br><br>")

        Html.AppendLine(testo)

        Html.AppendLine("</div>")

    End Sub

    Public Sub NewFeature()

        Html.AppendLine("<div class='new'>")

        Html.AppendLine("🆕 <b>Nuova Funzione</b>")

        Html.AppendLine("</div>")

    End Sub
    Private Function HtmlEncode(testo As String) As String

        If testo Is Nothing Then Return ""

        Return testo.Replace("&", "&amp;") _
                .Replace("<", "&lt;") _
                .Replace(">", "&gt;") _
                .Replace("""", "&quot;")

    End Function

    Public Sub Code(codice As String)

        Html.AppendLine("<div class='code'>")

        Html.AppendLine(HtmlEncode(codice))

        Html.AppendLine("</div>")

    End Sub

    Public Function ToHtml() As String

        Html.AppendLine("</body>")
        Html.AppendLine("</html>")

        Return Html.ToString()

    End Function


End Class