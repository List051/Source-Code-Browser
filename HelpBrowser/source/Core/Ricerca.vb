Imports System.IO

Public Class Ricerca

    ' ============================================================
    ' Risultato di una singola occorrenza
    ' ============================================================

    Public Class Risultato

        Public Property FilePath As String

        Public Property NomeFile As String

        Public Property NumeroRiga As Integer

        Public Property TestoRiga As String

    End Class


    ' ============================================================
    ' Cerca nei file VB.NET
    ' ============================================================

    Public Shared Function Cerca(
        cartella As String,
        testoDaCercare As String) As List(Of Risultato)

        Dim risultati As New List(Of Risultato)


        ' --------------------------------------------------------
        ' Controllo cartella
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(cartella) Then
            Return risultati
        End If


        If Not Directory.Exists(cartella) Then
            Return risultati
        End If


        ' --------------------------------------------------------
        ' Controllo testo ricerca
        ' --------------------------------------------------------

        If String.IsNullOrWhiteSpace(testoDaCercare) Then
            Return risultati
        End If


        ' --------------------------------------------------------
        ' Cerca tutti i file VB
        ' comprese le sottocartelle
        ' --------------------------------------------------------

        Dim files As String() =
            Directory.GetFiles(
                cartella,
                "*.vb",
                SearchOption.AllDirectories)


        ' --------------------------------------------------------
        ' Analizza ogni file
        ' --------------------------------------------------------

        For Each filePath As String In files

            Dim righe As String()


            Try

                righe =
                    File.ReadAllLines(filePath)

            Catch ex As Exception

                ' Se un file non può essere letto,
                ' lo ignoriamo e continuiamo con gli altri.

                Continue For

            End Try


            ' ----------------------------------------------------
            ' Analizza le righe del file
            ' ----------------------------------------------------

            For numeroRiga As Integer = 0 To righe.Length - 1

                Dim riga As String =
                    righe(numeroRiga)


                ' ------------------------------------------------
                ' Ricerca senza distinzione maiuscole/minuscole
                ' ------------------------------------------------

                If riga.IndexOf(
                    testoDaCercare,
                    StringComparison.OrdinalIgnoreCase) >= 0 Then


                    Dim risultato As New Risultato()


                    risultato.FilePath =
                        filePath


                    risultato.NomeFile =
                        Path.GetFileName(filePath)


                    risultato.NumeroRiga =
                        numeroRiga + 1


                    risultato.TestoRiga =
                        riga.Trim()


                    risultati.Add(risultato)

                End If

            Next

        Next


        Return risultati

    End Function

End Class
