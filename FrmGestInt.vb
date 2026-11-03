
Imports System.Data.SqlClient
'Imports CustomMessageBoxVB
Imports WinItalPascal
Imports System.IO

Public Class FrmGestInt

    Private dtClienti As DataTable
    Private dvClienti As DataView

    Private dtBeni As DataTable
    Private dvBeni As DataView


    Private dtInterventi As DataTable
    Private dvInterventi As DataView

    Private FormInCaricamento As Boolean = True

    ' Chiamata al metodo di connessione al database e visualizzazione del messaggio
    Dim connection As SqlConnection = DB.GetConnection()

    Private Sub FrmGestInt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ScreenUtility.FullScreen(Me)
        FrmTitolo.CTitolo(Me, "Gestione Interventi")
        CaricaPopup()

        ' Legge datagrid e Imposta Colonne

        Me.ClientiTableAdapter.Fill(Me.GdRDataSet.Clienti)
        ImpostaColInt(IDataGrid)

        Me.BeniTableAdapter.Fill(Me.GdRDataSet.Beni)
        ImpostaColBeni(BDataGrid)

        Me.InterventiTableAdapter.Fill(Me.GdRDataSet.Interventi)
        ImpostaColClienti(CDataGrid)


        ' Disabilita l'aggiunta manuale finché non sono selezionati categoria/modello
        IDataGrid.AllowUserToAddRows = False

        FormInCaricamento = True    ' verificare dopo aver caricato le combo

        ImpostaColInt(IDataGrid)
        CaricaCategorie()
        CboModello.DataSource = Nothing
        CboModello.Items.Clear()

        Dim CQryT As String = "SELECT * FROM Clienti"
        dvClienti = New DataView(dtClienti)
        dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

        DataGVLoad.ApriDGV(CDataGrid, CQryT)
        ImpostaColClienti(CDataGrid)
        ColoraDgv(CDataGrid)






    End Sub

    Private Sub InterventiBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles InterventiBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.InterventiBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.GdRDataSet)

    End Sub



#Region "Carica Popup"

    Public Sub CaricaPopup()
        'Image popup per i pulsanti
        Dim imgRep As Image = My.Resources.online_order
        Dim imgOrd As Image = My.Resources.cheque
        Dim imgSer As Image = My.Resources.services
        Dim imgSet As Image = My.Resources.setting

        PopupHelper.AttachPopup(RjBtnSalvaInterventi, "" & vbCrLf & "Interventi " & vbCrLf & vbCrLf & "Salva modifiche Interventi ", imgRep)
        PopupHelper.AttachPopup(RjCircOrdini, "" & vbCrLf & "Gestione Ordini " & vbCrLf & vbCrLf & "Apro il form Gestione Ordini " &
                 vbCrLf & "Con Interventi e Risorse in Magazzino ", imgOrd)
        PopupHelper.AttachPopup(RjCircRipristina, "" & vbCrLf & "Ripristina " & vbCrLf & vbCrLf & "Ripristo griglia Clienti", imgSer)
        PopupHelper.AttachPopup(RjCircLeggiLog, "" & vbCrLf & "File di Log " & vbCrLf & vbCrLf & "Apro il file di Log ", imgSet)



        PopupHelper.AttachPopup(RjCircNInt, "" & vbCrLf & "Nuovo Intervento " & vbCrLf & vbCrLf & "Inserimento Nuovo Intervento ", imgOrd)

        'Dim imgStPdf As Image = My.Resources.stampaPdf
        'Dim imgSta As Image = My.Resources.stampa
        'Dim imgPri As Image = My.Resources.printer

        'PopupHelper.AttachPopup(RjBtnOrdClienti, "" & vbCrLf & "Report RDLC " & vbCrLf & vbCrLf & "Apro il file OrdiniClienti RDLC", imgSta)
        'PopupHelper.AttachPopup(RjBtnRepOrdiniClienti, "" & vbCrLf & "Report " & vbCrLf & vbCrLf & "Apro il file RepOrdiniClienti " & vbCrLf & "Impostare Stampa Orizzontale ", imgStPdf)
        'PopupHelper.AttachPopup(RjBtnStampa2Opz, "" & vbCrLf & "Report 2 Opzione" & vbCrLf & vbCrLf & "Apro il file RepOrdiniClienti ", imgPri)

    End Sub


#End Region

#Region "Imposta Colonne DataGrid"

    Sub ImpostaColInt(ByRef dgv As DataGridView)    ' IDataGrid
        ' Imposta il font generale per tutto il DataGridView
        dgv.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.Columns(0).Width = 0
        dgv.Columns(0).HeaderText = "ID Int."
        dgv.Columns(1).Width = 60
        dgv.Columns(2).Width = 100
        dgv.Columns(3).Width = 120
        dgv.Columns(4).Width = 300
        dgv.Columns(5).Width = 220
        dgv.Columns(6).Width = 200
        dgv.Columns(7).Width = 85
        dgv.Columns(8).Width = 120

        ColoraColonneSpec(IDataGrid, {5, 6}, Color.Gold, Color.Blue)
        GridUtility.ImpostaColNull(IDataGrid, "Concluso")
    End Sub

    Sub ImpostaColClienti(ByRef dgv As DataGridView)    ' CDataGrid
        ' Imposta il font generale per tutto il DataGridView
        dgv.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        ' Imposta il font per l'header delle colonne
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgv.Columns(0).Width = 70
        dgv.Columns(0).HeaderText = "ID Clienti"
        dgv.Columns(1).Width = 300
        dgv.Columns(2).Width = 300
        dgv.Columns(3).Width = 300
        dgv.Columns(4).Width = 60
        dgv.Columns(5).Width = 80
        dgv.Columns(6).Width = 80
        dgv.Columns(7).Width = 100

    End Sub

    Sub ImpostaColBeni(ByRef dgv As DataGridView)    ' BDataGrid
        ' Imposta il font generale per tutto il DataGridView
        dgv.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ' Assicurati che la colonna 6 sia editabile e la colonna 7 sola lettura (risultato)
        dgv.Columns(0).Width = 50
        dgv.Columns(1).Width = 280
        dgv.Columns(2).Width = 280
        dgv.Columns(3).Width = 80
        dgv.Columns(4).Width = 220
        dgv.Columns(5).Width = 220
        If dgv.Columns.Count > 6 Then
            dgv.Columns(6).ReadOnly = False
            dgv.Columns(6).HeaderText = dgv.Columns(6).HeaderText
            dgv.Columns(6).Width = 80
        End If

        If dgv.Columns.Count > 7 Then
            dgv.Columns(7).ReadOnly = True
            dgv.Columns(7).HeaderText = "Differenza"
            dgv.Columns(7).Width = 100
        End If
        ColoraColonneSpec(BDataGrid, {3, 6}, Color.GreenYellow, Color.Blue)
        ColoraColonneSpec(BDataGrid, {7}, Color.Orange, Color.Blue) ' calcolo automatico
        ColoraColonneSpec(BDataGrid, {1, 5}, Color.Yellow, Color.Blue)
        GridUtility.EvidenziaTesto(BDataGrid, "Da Inserire")
    End Sub

#End Region

#Region "Interventi"

    Private Sub RjCircNInt_Click(sender As Object, e As EventArgs) Handles RjCircNInt.Click
        ' FrmNuovoInt.Show()
    End Sub


    Private Sub RjBtnSalvaInterventi_Click(sender As Object, e As EventArgs) Handles RjBtnSalvaInterventi.Click

        Try
            AggiornaRecordCorrente() ' assicura che il BindingSource corrente venga modificato
            GridUtility.ConvertiMaiuscolo(IDataGrid)
            ' Forza il commit dell'edit corrente nella DataGrid (se l'utente stava ancora editando)
            IDataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit)
            IDataGrid.EndEdit()

            ' Recupera la binding source e il dataset effettivi
            Dim bs As BindingSource = TryCast(IDataGrid.DataSource, BindingSource)
            If bs Is Nothing Then bs = If(InterventiBindingSource IsNot Nothing, InterventiBindingSource, InterventiBindingSource)

            If bs Is Nothing Then
                LogLeggiScrivi.ScriviLogMsg("Impossibile salvare: BindingSource non disponibile.")
                IPMessageBox.Show("Errore interno: BindingSource non inizializzata.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            bs.EndEdit()

            ' Usa il DataSet/Adapter reali (fallback alla versione *1)
            Dim ds = If(Me.GdRDataSet, Me.GdRDataSet)
            If ds Is Nothing Then
                LogLeggiScrivi.ScriviLogMsg("Impossibile salvare: DataSet non disponibile.")
                IPMessageBox.Show("Errore interno: DataSet non inizializzato.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            ' Fallback: aggiorna singole tabelle usando adapter *1
            If Me.InterventiTableAdapter IsNot Nothing AndAlso ds.Tables.Contains("Interventi") Then
                Me.InterventiTableAdapter.Update(ds.Interventi)
                LogLeggiScrivi.ScriviLogMsg("Interventi aggiornati via InterventiTableAdapter1.")
            End If
            If Me.BeniTableAdapter IsNot Nothing AndAlso ds.Tables.Contains("Beni") Then
                Me.BeniTableAdapter.Update(ds.Beni)
                LogLeggiScrivi.ScriviLogMsg("Beni aggiornati via BeniTableAdapter1.")
            End If


            ColoraDgv(IDataGrid)
            GridUtility.ImpostaColNull(IDataGrid, "Concluso")

        Catch ex As Exception
            LogLeggiScrivi.ScriviLogMsg("Eccezione salvataggio: " & ex.ToString())
            IPMessageBox.Show("Errore durante il salvataggio: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub CboModello_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboModello.SelectedIndexChanged

        If FormInCaricamento Then Exit Sub
        IDataGrid.AllowUserToAddRows = CanAddNew()
        If CboModello.SelectedIndex = -1 Then Exit Sub
        AggiornaRecordCorrente()

    End Sub

    Private Sub CboCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboCategoria.SelectedIndexChanged

        'CaricaModelli(CboCategoria.Text)
        ' MessageBox.Show(BeniBindingSource.DataSource.GetType().ToString)
        If FormInCaricamento Then Exit Sub
        IDataGrid.AllowUserToAddRows = CanAddNew()
        If CboCategoria.SelectedIndex = -1 Then Exit Sub
        CaricaModelli(CboCategoria.Text)
        AggiornaRecordCorrente()

    End Sub

    '=====================================================================
    ' Aggiorna il record corrente del BindingSource
    ' Funziona sia in Inserimento che in Modifica
    '=====================================================================
    Private Sub AggiornaRecordCorrente()

        Dim bs As BindingSource = TryCast(IDataGrid.DataSource, BindingSource)
        If bs Is Nothing Then
            bs = If(InterventiBindingSource IsNot Nothing, InterventiBindingSource, InterventiBindingSource)
        End If

        Dim row As DataRowView = TryCast(bs?.Current, DataRowView)
        If row Is Nothing Then Exit Sub

        row("Modello") = CboModello.Text.Trim()
        row("Categoria") = CboCategoria.Text.Trim()

    End Sub

    Private Sub CaricaCategorie()
        Try
            ' Assicurarsi che la tabella Beni esista e sia popolata
            If Me.GdRDataSet Is Nothing OrElse Not Me.GdRDataSet.Tables.Contains("Beni") Then
                LogLeggiScrivi.ScriviLogMsg("CaricaCategorie: GdRDataSet1 o tabella Beni non disponibili.")
                CboCategoria.DataSource = Nothing
                CboCategoria.Items.Clear()
                Return
            End If

            Dim beniTable = Me.GdRDataSet.Beni
            If beniTable.Rows.Count = 0 Then
                LogLeggiScrivi.ScriviLogMsg("CaricaCategorie: tabella Beni vuota.")
                CboCategoria.DataSource = Nothing
                CboCategoria.Items.Clear()
                Return
            End If

            ' Costruisce elenco sicuro rimuovendo valori null/empty e duplicati
            Dim elenco = beniTable.AsEnumerable() _
            .Where(Function(r) Not r.IsCategoriaNull() AndAlso Not String.IsNullOrWhiteSpace(r.Categoria)) _
            .Select(Function(r) r.Categoria.Trim()) _
            .Distinct(StringComparer.OrdinalIgnoreCase) _
            .OrderBy(Function(x) x) _
            .ToList()

            If elenco.Count = 0 Then
                LogLeggiScrivi.ScriviLogMsg("CaricaCategorie: nessuna categoria valida trovata.")
                CboCategoria.DataSource = Nothing
                CboCategoria.Items.Clear()
                Return
            End If

            ' Imposta DataSource in modo sicuro (disabilita eventi durante l'assegnazione)
            FormInCaricamento = True
            CboCategoria.DataSource = Nothing
            CboCategoria.Items.Clear()
            CboCategoria.DataSource = elenco
            CboCategoria.SelectedIndex = -1
            FormInCaricamento = False

            LogLeggiScrivi.ScriviLogMsg($"CaricaCategorie: caricate {elenco.Count} categorie.")
        Catch ex As Exception
            LogLeggiScrivi.ScriviLogMsg("Errore CaricaCategorie: " & ex.Message)
            IPMessageBox.Show("Errore CaricaCategorie: " & ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=====================================================================
    ' CARICA I COMBOBOX SENZA DUPLICATI
    ' Da richiamare nel Load della maschera
    '=====================================================================

    Private Sub CaricaModelli(Categoria As String)

        Dim elenco = GdRDataSet.Beni.AsEnumerable().
        Where(Function(r) Not r.IsCategoriaNull() AndAlso
                          Not r.IsModelloNull() AndAlso
                          r.Categoria.Trim().Equals(Categoria, StringComparison.OrdinalIgnoreCase)).
        Select(Function(r) r.Modello.Trim()).
        Distinct(StringComparer.OrdinalIgnoreCase).
        OrderBy(Function(x) x).
        ToList()

        CboModello.DataSource = Nothing
        CboModello.Items.Clear()
        CboModello.DataSource = elenco

    End Sub

    Private Sub CaricaImage()
        ' Quando clicco su una riga del IDataGrid carico l'immagine
        Try
            If IDataGrid.CurrentRow Is Nothing Then
                IPMessageBox.Show("Nessuna riga selezionata.")
                Exit Sub
            End If

            Dim Indice As Integer = IDataGrid.CurrentRow.Index
            Dim valoreConcluso As String = If(IsDBNull(IDataGrid.Rows(Indice).Cells(8).Value), "", IDataGrid.Rows(Indice).Cells(8).Value.ToString().Trim())
            ' Mostra il valore Concluso in un MessageBox ed è esatto
            '    RJMessageBox.Show("Valore Concluso: " & valoreConcluso)  ' cosa consegnare

            ' Imposto l'immagine in base al valore "valoreConcluso"
            Select Case valoreConcluso
                Case "RISOLTO", "Risolto"
                    PictBoxConcluso.Image = My.Resources.spedito ' materiale arrivato e consegnato
                Case "Attesa", "ATTESA"
                    PictBoxConcluso.Image = My.Resources.attesa   ' materiale in arrico
                Case Else
                    PictBoxConcluso.Image = My.Resources.online_order
            End Select

            ' Carico l'immagine dal percorso, se esiste
            Dim imagePath As String = IDataGrid.Rows(Indice).Cells(8).Value.ToString()
            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                PictBoxConcluso.Image = Image.FromFile(imagePath)
            End If

        Catch ex As Exception
            IPMessageBox.Show("Errore durante il caricamento dell'immagine: " & ex.Message)
        End Try
    End Sub

    Private Sub IDataGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles IDataGrid.CellClick
        CaricaImage()
    End Sub


    Private Function CanAddNew() As Boolean
        Return CboCategoria.SelectedIndex <> -1 AndAlso CboModello.SelectedIndex <> -1
    End Function


#End Region

#Region "Clienti"


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtCerca.TextChanged
        Dim CQryT As String = "SELECT * FROM Clienti"
        dvClienti = New DataView(dtClienti)
        dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

        DataGVLoad.ApriDGV(CDataGrid, CQryT)

        Dim CQryE As String = TxtCerca.Text.Trim.ToUpper()
        GridUtility.FiltraTutti(CDataGrid, dtClienti, CQryE)
        GridUtility.EvidenziaTesto(CDataGrid, CQryE)

        If TxtCerca.Text = "" Then
            ResetColoriDgv(CDataGrid)
            ColoraDgv(CDataGrid)
        End If
    End Sub

    Private Sub CDataGrid_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles CDataGrid.ColumnHeaderMouseClick

        IPMessageBox.Show("Hai cliccato sulla colonna: " & CDataGrid.Columns(e.ColumnIndex).HeaderText)

        ColoraDgv(CDataGrid)
    End Sub

    'Private Sub RjBtnNuovoCliente_Click(sender As Object, e As EventArgs) Handles RjBtnNuovoCliente.Click
    '    '  FrmAggiungi.Show()
    'End Sub

    Private Sub RjCircRipristina_Click(sender As Object, e As EventArgs) Handles RjCircRipristina.Click
        TxtCerca.Text = ""
        Dim CQryT As String = "SELECT * FROM Clienti"
        dvClienti = New DataView(dtClienti)
        dtClienti = DB.FillDataTable("SELECT * FROM Clienti")

        DataGVLoad.ApriDGV(CDataGrid, CQryT)
        ResetColoriDgv(CDataGrid)
        ColoraDgv(CDataGrid)
    End Sub

    Private Sub RjBtnRipristina_Click(sender As Object, e As EventArgs) Handles RjBtnRipristina.Click
        TxtCerca.Text = ""
    End Sub

#End Region


#Region "Beni"

    Private Sub BDataGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles BDataGrid.CellEndEdit

        ' Se la riga è nuova, esci
        If BDataGrid.Rows(e.RowIndex).IsNewRow Then Exit Sub

        ' Colonne interessate: Qta (3) e Utilizzate (6)
        If e.ColumnIndex = 3 OrElse e.ColumnIndex = 6 Then
            CalcolaResiduoRiga(e.RowIndex)
        End If

    End Sub

    Private Sub CalcolaResiduoRiga(rowIndex As Integer)

        Dim row As DataGridViewRow = BDataGrid.Rows(rowIndex)

        Dim Qta As Integer = 0
        Dim QtaUti As Integer = 0
        Dim QtaRes As Integer = 0

        ' Qta (colonna 3)
        If Not IsDBNull(row.Cells(3).Value) AndAlso
         IsNumeric(row.Cells(3).Value) Then
            Qta = CInt(row.Cells(3).Value)
        End If

        ' Utilizzate (colonna 6)
        If Not IsDBNull(row.Cells(6).Value) AndAlso
         IsNumeric(row.Cells(6).Value) Then
            QtaUti = CInt(row.Cells(6).Value)
        End If

        ' Calcolo residuo
        QtaRes = Qta - QtaUti

        ' Scrivi il risultato nella colonna 7
        row.Cells(7).Value = QtaRes

    End Sub

#End Region

End Class