Imports WinItalPascal

Public Class FrmMessBox
    Private Sub FrmMessBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmTitolo.CTitolo(Me, "Inserimento IPMessage in WinItalPascal")
    End Sub

    Private Sub RjButton1_Click(sender As Object, e As EventArgs) Handles RjButton1.Click
        Dim result = IPMessageBox.Show("Sei sicuro di annullare?", "Annulla Operazione",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error)
    End Sub

    Private Sub RjToggleButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RjToggleButton1.CheckedChanged


        Dim result = IPMessageBox.Show("Sei sicuro di annullare?", "Annulla Operazione",
                      MessageBoxButtons.YesNoCancel,
                      MessageBoxIcon.Question)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result = IPMessageBox.Show(" Private Sub CalcolaRiga(rowIndex As Integer)

        Dim row As DataGridViewRow = FatDataGrid.Rows(rowIndex)

        Dim Qta As Integer = 0
        Dim SxImp As Integer = 0
        Dim TotImp As Integer = 0

        ' Qta (colonna 3)
        If Not IsDBNull(row.Cells(7).Value) AndAlso
         IsNumeric(row.Cells(7).Value) Then
            Qta = CInt(row.Cells(7).Value)
        End If

        ' Importo(colonna 9)
        If Not IsDBNull(row.Cells(8).Value) AndAlso
         IsNumeric(row.Cells(8).Value) Then
            SxImp = CInt(row.Cells(8).Value)
        End If

        ' Calcolo Totale
        TotImp = Qta * SxImp

        ' Scrivi il risultato nella colonna 7
        row.Cells(9).Value = TotImp

    End Sub " & vbCrLf & "",
        "Procedo con i Calcoli")

        'MessageBoxButtons.OKCancel)
        'MessageBoxIcon.Question)

    End Sub

    Private Sub RjCircularPictureBox1_Click(sender As Object, e As EventArgs) Handles RjCircularPictureBox1.Click
        Dim result = IPMessageBox.Show("Disattivato: Imports CustomMessageBox", "IPMessagreBox in WinItalPascal",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
    End Sub
End Class