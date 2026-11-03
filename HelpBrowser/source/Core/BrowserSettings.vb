Imports System.IO

Public Class BrowserSettings

    Private Shared ReadOnly SettingsFolder As String =
    Path.Combine(Application.StartupPath, "BrowserSettings")

    Private Shared ReadOnly LastFolderFile As String =
        Path.Combine(SettingsFolder, "LastFolder.txt")

    Public Shared Sub SaveLastFolder(folder As String)

        If Not Directory.Exists(SettingsFolder) Then

            Directory.CreateDirectory(SettingsFolder)

        End If

        File.WriteAllText(LastFolderFile, folder)

    End Sub

    Public Shared Function LoadLastFolder() As String

        If Not File.Exists(LastFolderFile) Then

            Return ""

        End If

        Return File.ReadAllText(LastFolderFile)

    End Function

End Class