Imports System.IO
Imports System.Text
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Imports Newtonsoft.Json
Public Class TreeBuilder
#Region "Campi privati"

    Private ReadOnly _SourceFolder As String


#End Region

#Region "TreeBuilder"
    Public Function BuildTree() As String

        Return BuildDirectoryTree()

    End Function
#End Region

#Region "Costruttore"
    Public Sub New(sourceFolder As String)

        _SourceFolder = sourceFolder

    End Sub
#End Region

#Region "Directory Tree"
    
	
	' funzionante
	
	Private Function BuildDirectoryTree() As String

        Dim sb As New StringBuilder()

        sb.AppendLine("<ul>")

        Dim files() As String =
            Directory.GetFiles(
                _SourceFolder,
                "*.vb")

        For Each file As String In files

            Dim nomeFile As String =
                Path.GetFileName(file)

            Dim percorsoJs As String =
                file.Replace("\", "\\")

            Dim html As String =
                String.Format(
                    "<li onclick=""SelectFile('{0}', this)"">📄 {1}</li>",
                    percorsoJs,
                    nomeFile)

            sb.AppendLine(html)

        Next

        sb.AppendLine("</ul>")

        Return sb.ToString()

    End Function

#End Region

#Region "JavaScript"


#End Region

End Class


