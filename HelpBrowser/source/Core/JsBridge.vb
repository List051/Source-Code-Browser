'Imports System.Text.Json
Imports Newtonsoft.Json

Public Class JsBridge

    Private ReadOnly _owner As HtmlHelpBuilder2

    Public Sub New(owner As HtmlHelpBuilder2)
        _owner = owner
    End Sub

    '  WebMessageReceived()
    Public Sub ProcessMessage(message As String)

        Try

            'Dim data = JsonSerializer.Deserialize(Of JsMessage)(message) ' NON è possibile convertire il valore tipo String in jsonreader
            Dim data = JsonConvert.DeserializeObject(Of JsMessage)(message)
            Select Case data.Command


                Case "TestWebView"

                    'MessageBox.Show(
                    '    "WebView2 collegato correttamente",
                    '    "Test"
                    ')

                Case "OpenFile"

                    If IO.File.Exists(data.Value) Then

                        _owner.CaricaFile(data.Value)

                    End If

            End Select


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub


End Class


Public Class JsMessage

    Public Property Command As String
    Public Property Value As String

End Class