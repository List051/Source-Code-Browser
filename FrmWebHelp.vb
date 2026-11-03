
Imports System.IO
Imports Microsoft.Web.WebView2.Core
Imports WinItalPascal
Imports CustomMessageBoxVB

Public Class FrmWebHelp

    Private _HelpBuilder As HtmlHelpBuilder2


    Private ReadOnly _SourcePath As String

    Public Sub New(sourcePath As String)

        InitializeComponent()

        _SourcePath = sourcePath

    End Sub

    Private Async Sub FrmWebHelp_Load(
    sender As Object,
    e As EventArgs) Handles MyBase.Load

        Inizio()  '  Aggiungo un titolo alla Form con FrmTitolo

        Dim helpPath As String =
        Path.GetFullPath(
            Path.Combine(
                Application.StartupPath,
                "..\..\HelpBrowser"))


        'Dim sourcePath As String =
        'Path.GetFullPath(
        '    Path.Combine(
        '        Application.StartupPath,
        '        "..\.."))

        If String.IsNullOrWhiteSpace(_SourcePath) Then

            IPMessageBox.Show("Selezionare prima una cartella.")

            Me.Close()

            Return

        End If

        _HelpBuilder =
        New HtmlHelpBuilder2(
            WebView21,
            helpPath,
            _SourcePath)


        Await _HelpBuilder.BuildAsync()

    End Sub

    Sub Inizio()
        FrmTitolo.CTitolo(Me, "Presentazione Aggiornamento Libreria")
        ScreenUtility.FullScreen(Me)
    End Sub

End Class