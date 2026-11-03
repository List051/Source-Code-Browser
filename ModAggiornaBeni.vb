Imports System.Data.SqlClient
Imports WinItalPascal
Module ModAggiornaBeni

    Public Sub AggiornaBeniDaOrdine(connection As SqlConnection,
                                    Categoria As String,
                                    Modello As String,
                                    Descrizione As String,
                                    QtaOrd As Integer)
        ' Controllo parametri obbligatori
        If String.IsNullOrWhiteSpace(Categoria) OrElse
       String.IsNullOrWhiteSpace(Modello) Then
            Exit Sub
        End If

        Try

            Dim sql As String =
"IF EXISTS (
    SELECT 1
    FROM Beni
    WHERE Categoria = @Categoria
      AND Modello = @Modello
)

BEGIN

    UPDATE Beni
       SET Magazzino = CAST(ISNULL(TRY_CAST(Magazzino AS INT),0) + @QtaOrd AS NVARCHAR(510)),
           Descrizione = CASE
                            WHEN Descrizione IS NULL
                              OR Descrizione = ''
                              OR Descrizione = 'Da inserire'
                            THEN @Descrizione
                            ELSE Descrizione
                         END
     WHERE Categoria = @Categoria
       AND Modello = @Modello

END
ELSE
BEGIN

    INSERT INTO Beni
    (
        Categoria,
        Descrizione,
        Magazzino,
        Fornitore,
        Modello,
        Utilizzate,
        Residuo
    )
    VALUES
    (
        @Categoria,
        @Descrizione,
        CAST(@QtaOrd AS NVARCHAR(510)),
        'Da inserire',
        @Modello,
        0,
        @QtaOrd
    )

END"

            Using cmd As New SqlCommand(sql, connection)

                cmd.Parameters.AddWithValue("@Categoria", Categoria)
                cmd.Parameters.AddWithValue("@Modello", Modello)
                cmd.Parameters.AddWithValue("@Descrizione", Descrizione)
                cmd.Parameters.AddWithValue("@QtaOrd", QtaOrd)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

            IPMessageBox.Show("Errore durante l'aggiornamento della tabella Beni." &
                            vbCrLf & vbCrLf &
                            ex.Message,
                            "Aggiorna Beni",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

End Module