
' Prima di integrare il tutto con la mia libreria WinItalPasscal

' dovevo usare tutto questo codice per creare un'interfaccia in VB.NET per gestire un database SQL Server

' Ora posso usare la mia libreria WinItalPasscal per fare tutto questo in modo piu' semplice e veloce.

' Guarda su NuGet, GitHub e Visual Studio Marketplace per trovare la mia libreria WinItalPasscal.

' Ovviamente anche la mia libreria WinItalPasscal e' open source e gratuita, quindi puoi usarla liberamente nei tuoi progetti.

' https://www.youtube.com/@iaoraGo/playlists

' ************************


' Ecco i passaggi principali ( non piu' usati ):

'Passaggi per creare l'interfaccia in VB.NET:

'1. Apri Visual Studio Code e crea un progetto WinForms in VB.NET.


'2. Aggiungi un DataGridView (dgvDati) e i pulsanti (btnAggiungi, btnModifica, btnElimina, btnAvanti, btnIndietro).


'3. Imposta la connessione a SQL Server.


'4. Scrivi il codice per ogni pulsante.

'---

'Codice VB.NET per la gestione del database

'Imports System.Data.SqlClient

'Public Class Form1
'    Dim connString As String = "Server=TUO_SERVER;Database=TUO_DATABASE;Trusted_Connection=True;"
'    Dim conn As New SqlConnection(connString)
'    Dim adapter As SqlDataAdapter
'    Dim dt As New DataTable()
'    Dim pos As Integer = 0

'    ' Carica i dati iniziali nel DataGridView
'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        CaricaDati()
'    End Sub

'    ' Metodo per caricare i dati nel DataGridView
'    Private Sub CaricaDati()
'        Try
'            conn.Open()
'            adapter = New SqlDataAdapter("SELECT * FROM TuaTabella", conn)
'            dt.Clear()
'            adapter.Fill(dt)
'            dgvDati.DataSource = dt
'        Catch ex As Exception
'            MessageBox.Show("Errore: " & ex.Message)
'        Finally
'            conn.Close()
'        End Try
'    End Sub

'    ' Pulsante per aggiungere un record
'    Private Sub btnAggiungi_Click(sender As Object, e As EventArgs) Handles btnAggiungi.Click
'        Dim valore As String = InputBox("Inserisci un nuovo valore:", "Aggiungi")
'        If valore <> "" Then
'            Try
'                conn.Open()
'                Dim cmd As New SqlCommand("INSERT INTO TuaTabella (Colonna1) VALUES (@valore)", conn)
'                cmd.Parameters.AddWithValue("@valore", valore)
'                cmd.ExecuteNonQuery()
'                MessageBox.Show("Record aggiunto con successo!")
'                CaricaDati()
'            Catch ex As Exception
'                MessageBox.Show("Errore: " & ex.Message)
'            Finally
'                conn.Close()
'            End Try
'        End If
'    End Sub

'    ' Pulsante per modificare un record
'    Private Sub btnModifica_Click(sender As Object, e As EventArgs) Handles btnModifica.Click
'        If dgvDati.SelectedRows.Count > 0 Then
'            Dim id As Integer = dgvDati.SelectedRows(0).Cells("ID").Value
'            Dim nuovoValore As String = InputBox("Inserisci il nuovo valore:", "Modifica")
'            If nuovoValore <> "" Then
'                Try
'                    conn.Open()
'                    Dim cmd As New SqlCommand("UPDATE TuaTabella SET Colonna1 = @valore WHERE ID = @id", conn)
'                    cmd.Parameters.AddWithValue("@valore", nuovoValore)
'                    cmd.Parameters.AddWithValue("@id", id)
'                    cmd.ExecuteNonQuery()
'                    MessageBox.Show("Record modificato con successo!")
'                    CaricaDati()
'                Catch ex As Exception
'                    MessageBox.Show("Errore: " & ex.Message)
'                Finally
'                    conn.Close()
'                End Try
'            End If
'        Else
'            MessageBox.Show("Seleziona un record da modificare.")
'        End If
'    End Sub

'    ' Pulsante per eliminare un record
'    Private Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
'        If dgvDati.SelectedRows.Count > 0 Then
'            Dim id As Integer = dgvDati.SelectedRows(0).Cells("ID").Value
'            If MessageBox.Show("Sei sicuro di voler eliminare il record?", "Conferma", MessageBoxButtons.YesNo) = DialogResult.Yes Then
'                Try
'                    conn.Open()
'                    Dim cmd As New SqlCommand("DELETE FROM TuaTabella WHERE ID = @id", conn)
'                    cmd.Parameters.AddWithValue("@id", id)
'                    cmd.ExecuteNonQuery()
'                    MessageBox.Show("Record eliminato con successo!")
'                    CaricaDati()
'                Catch ex As Exception
'                    MessageBox.Show("Errore: " & ex.Message)
'                Finally
'                    conn.Close()
'                End Try
'            End If
'        Else
'            MessageBox.Show("Seleziona un record da eliminare.")
'        End If
'    End Sub

'    ' Pulsante per andare avanti nei record
'    Private Sub btnAvanti_Click(sender As Object, e As EventArgs) Handles btnAvanti.Click
'        If pos < dt.Rows.Count - 1 Then
'            pos += 1
'            dgvDati.ClearSelection()
'            dgvDati.Rows(pos).Selected = True
'            dgvDati.CurrentCell = dgvDati.Rows(pos).Cells(0)
'        End If
'    End Sub

'    ' Pulsante per andare indietro nei record
'    Private Sub btnIndietro_Click(sender As Object, e As EventArgs) Handles btnIndietro.Click
'        If pos > 0 Then
'            pos -= 1
'            dgvDati.ClearSelection()
'            dgvDati.Rows(pos).Selected = True
'            dgvDati.CurrentCell = dgvDati.Rows(pos).Cells(0)
'        End If
'    End Sub
'End Class


'---

'Spiegazione del codice:

'Connessione al database: Usa SqlConnection per connettersi a SQL Server.

'Carica i dati all'avvio: La funzione CaricaDati() carica i record in un DataGridView.

'Aggiungere un record: Usa INSERT INTO per aggiungere un nuovo valore.

'Modificare un record: Usa UPDATE per modificare il record selezionato.

'Eliminare un record: Usa DELETE FROM per eliminare il record selezionato.

'Navigare nei record: I pulsanti "Avanti" e "Indietro" permettono di scorrere i record nel DataGridView.
