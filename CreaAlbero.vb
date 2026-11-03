Imports System.IO
Imports System.Text

Public Class HtmlTreeTest

    Public Shared Sub CreaAlberoTest()

        Dim cartella As String =
            "C:\Users\Utente\Documents\VSC\TempTest"

        If Not Directory.Exists(cartella) Then
            Directory.CreateDirectory(cartella)
        End If

        Dim fileHtml As String =
            Path.Combine(cartella, "Albero_vb.html")


        Dim sb As New StringBuilder()

        sb.AppendLine("<!DOCTYPE html>")
        sb.AppendLine("<html>")
        sb.AppendLine("<head>")
        sb.AppendLine("<meta charset='utf-8'>")
        sb.AppendLine("<title>Test Albero VB</title>")
        sb.AppendLine("</head>")

        sb.AppendLine("<body>")


        sb.AppendLine(
        "<div onclick=""alert('CLICK FILE')"" " &
        "style='cursor:pointer'>" &
        "📄 Form1.vb" &
        "</div>")


        sb.AppendLine("</body>")
        sb.AppendLine("</html>")


        File.WriteAllText(fileHtml, sb.ToString(), Encoding.UTF8)


    End Sub

End Class