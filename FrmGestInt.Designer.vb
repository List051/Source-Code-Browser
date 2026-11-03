<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGestInt
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGestInt))
        Me.GdRDataSet = New GdRVideo.GdRDataSet()
        Me.InterventiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InterventiTableAdapter = New GdRVideo.GdRDataSetTableAdapters.InterventiTableAdapter()
        Me.TableAdapterManager = New GdRVideo.GdRDataSetTableAdapters.TableAdapterManager()
        Me.BeniTableAdapter = New GdRVideo.GdRDataSetTableAdapters.BeniTableAdapter()
        Me.ClientiTableAdapter = New GdRVideo.GdRDataSetTableAdapters.ClientiTableAdapter()
        Me.InterventiBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InterventiBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.IDataGrid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modello = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concluso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BDataGrid = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoriaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescrizioneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MagazzinoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FornitoreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModelloDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UtilizzateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResiduoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeniBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CDataGrid = New System.Windows.Forms.DataGridView()
        Me.IdClientiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndirizzoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CittaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtCerca = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RjBtnRipristina = New RJCodeAdvance.RJControls.RJButton()
        Me.RjButton1 = New RJCodeAdvance.RJControls.RJButton()
        Me.PictBoxConcluso = New System.Windows.Forms.PictureBox()
        Me.CboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboModello = New System.Windows.Forms.ComboBox()
        Me.RjBtnSalvaInterventi = New RJCodeAdvance.RJControls.RJButton()
        Me.RjCircRipristina = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjCircLeggiLog = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjCircOrdini = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        Me.RjCircNInt = New RJCodeAdvance.RJControls.RJCircularPictureBox()
        CType(Me.GdRDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InterventiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InterventiBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InterventiBindingNavigator.SuspendLayout()
        CType(Me.IDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeniBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictBoxConcluso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircRipristina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircLeggiLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircOrdini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RjCircNInt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GdRDataSet
        '
        Me.GdRDataSet.DataSetName = "GdRDataSet"
        Me.GdRDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'InterventiBindingSource
        '
        Me.InterventiBindingSource.DataMember = "Interventi"
        Me.InterventiBindingSource.DataSource = Me.GdRDataSet
        '
        'InterventiTableAdapter
        '
        Me.InterventiTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BeniTableAdapter = Me.BeniTableAdapter
        Me.TableAdapterManager.ClientiTableAdapter = Me.ClientiTableAdapter
        Me.TableAdapterManager.FatturaTableAdapter = Nothing
        Me.TableAdapterManager.InterventiTableAdapter = Me.InterventiTableAdapter
        Me.TableAdapterManager.OrdiniTableAdapter = Nothing
        Me.TableAdapterManager.RisultatoTableAdapter = Nothing
        Me.TableAdapterManager.TecnicoTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = GdRVideo.GdRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UtilizzatiTableAdapter = Nothing
        '
        'BeniTableAdapter
        '
        Me.BeniTableAdapter.ClearBeforeFill = True
        '
        'ClientiTableAdapter
        '
        Me.ClientiTableAdapter.ClearBeforeFill = True
        '
        'InterventiBindingNavigator
        '
        Me.InterventiBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.InterventiBindingNavigator.BindingSource = Me.InterventiBindingSource
        Me.InterventiBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.InterventiBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.InterventiBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.InterventiBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.InterventiBindingNavigatorSaveItem})
        Me.InterventiBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.InterventiBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.InterventiBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.InterventiBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.InterventiBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.InterventiBindingNavigator.Name = "InterventiBindingNavigator"
        Me.InterventiBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.InterventiBindingNavigator.Size = New System.Drawing.Size(1924, 27)
        Me.InterventiBindingNavigator.TabIndex = 0
        Me.InterventiBindingNavigator.Text = "BindingNavigator1"
        Me.InterventiBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorAddNewItem.Text = "Aggiungi nuovo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(44, 24)
        Me.BindingNavigatorCountItem.Text = "di {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Numero totale di elementi"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorDeleteItem.Text = "Elimina"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Sposta in prima posizione"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Sposta indietro"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posizione"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posizione corrente"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Sposta avanti"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Sposta in ultima posizione"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'InterventiBindingNavigatorSaveItem
        '
        Me.InterventiBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InterventiBindingNavigatorSaveItem.Image = CType(resources.GetObject("InterventiBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.InterventiBindingNavigatorSaveItem.Name = "InterventiBindingNavigatorSaveItem"
        Me.InterventiBindingNavigatorSaveItem.Size = New System.Drawing.Size(29, 24)
        Me.InterventiBindingNavigatorSaveItem.Text = "Salva dati"
        '
        'IDataGrid
        '
        Me.IDataGrid.AutoGenerateColumns = False
        Me.IDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.Modello, Me.Categoria, Me.DataGridViewTextBoxColumn8, Me.Concluso, Me.DataGridViewTextBoxColumn10})
        Me.IDataGrid.DataSource = Me.InterventiBindingSource
        Me.IDataGrid.Location = New System.Drawing.Point(29, 158)
        Me.IDataGrid.Name = "IDataGrid"
        Me.IDataGrid.RowHeadersWidth = 51
        Me.IDataGrid.RowTemplate.Height = 24
        Me.IDataGrid.Size = New System.Drawing.Size(1850, 220)
        Me.IDataGrid.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdInt"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdInt"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IdCli"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdCli"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 125
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DataInt"
        Me.DataGridViewTextBoxColumn3.HeaderText = "DataInt"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Tecnico"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tecnico"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Intervento"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Intervento"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 125
        '
        'Modello
        '
        Me.Modello.DataPropertyName = "Modello"
        Me.Modello.HeaderText = "Modello"
        Me.Modello.MinimumWidth = 6
        Me.Modello.Name = "Modello"
        Me.Modello.Width = 125
        '
        'Categoria
        '
        Me.Categoria.DataPropertyName = "Categoria"
        Me.Categoria.HeaderText = "Categoria"
        Me.Categoria.MinimumWidth = 6
        Me.Categoria.Name = "Categoria"
        Me.Categoria.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Costo"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 125
        '
        'Concluso
        '
        Me.Concluso.DataPropertyName = "Risolto"
        Me.Concluso.HeaderText = "Risolto"
        Me.Concluso.MinimumWidth = 6
        Me.Concluso.Name = "Concluso"
        Me.Concluso.Width = 125
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "DataRisolto"
        Me.DataGridViewTextBoxColumn10.HeaderText = "DataRisolto"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 125
        '
        'BDataGrid
        '
        Me.BDataGrid.AutoGenerateColumns = False
        Me.BDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.CategoriaDataGridViewTextBoxColumn, Me.DescrizioneDataGridViewTextBoxColumn, Me.MagazzinoDataGridViewTextBoxColumn, Me.FornitoreDataGridViewTextBoxColumn, Me.ModelloDataGridViewTextBoxColumn, Me.UtilizzateDataGridViewTextBoxColumn, Me.ResiduoDataGridViewTextBoxColumn})
        Me.BDataGrid.DataSource = Me.BeniBindingSource
        Me.BDataGrid.Location = New System.Drawing.Point(29, 468)
        Me.BDataGrid.Name = "BDataGrid"
        Me.BDataGrid.RowHeadersWidth = 51
        Me.BDataGrid.RowTemplate.Height = 24
        Me.BDataGrid.Size = New System.Drawing.Size(1850, 216)
        Me.BDataGrid.TabIndex = 2
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Width = 125
        '
        'CategoriaDataGridViewTextBoxColumn
        '
        Me.CategoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria"
        Me.CategoriaDataGridViewTextBoxColumn.HeaderText = "Categoria"
        Me.CategoriaDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.CategoriaDataGridViewTextBoxColumn.Name = "CategoriaDataGridViewTextBoxColumn"
        Me.CategoriaDataGridViewTextBoxColumn.Width = 125
        '
        'DescrizioneDataGridViewTextBoxColumn
        '
        Me.DescrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione"
        Me.DescrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione"
        Me.DescrizioneDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.DescrizioneDataGridViewTextBoxColumn.Name = "DescrizioneDataGridViewTextBoxColumn"
        Me.DescrizioneDataGridViewTextBoxColumn.Width = 125
        '
        'MagazzinoDataGridViewTextBoxColumn
        '
        Me.MagazzinoDataGridViewTextBoxColumn.DataPropertyName = "Magazzino"
        Me.MagazzinoDataGridViewTextBoxColumn.HeaderText = "Magazzino"
        Me.MagazzinoDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.MagazzinoDataGridViewTextBoxColumn.Name = "MagazzinoDataGridViewTextBoxColumn"
        Me.MagazzinoDataGridViewTextBoxColumn.Width = 125
        '
        'FornitoreDataGridViewTextBoxColumn
        '
        Me.FornitoreDataGridViewTextBoxColumn.DataPropertyName = "Fornitore"
        Me.FornitoreDataGridViewTextBoxColumn.HeaderText = "Fornitore"
        Me.FornitoreDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.FornitoreDataGridViewTextBoxColumn.Name = "FornitoreDataGridViewTextBoxColumn"
        Me.FornitoreDataGridViewTextBoxColumn.Width = 125
        '
        'ModelloDataGridViewTextBoxColumn
        '
        Me.ModelloDataGridViewTextBoxColumn.DataPropertyName = "Modello"
        Me.ModelloDataGridViewTextBoxColumn.HeaderText = "Modello"
        Me.ModelloDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ModelloDataGridViewTextBoxColumn.Name = "ModelloDataGridViewTextBoxColumn"
        Me.ModelloDataGridViewTextBoxColumn.Width = 125
        '
        'UtilizzateDataGridViewTextBoxColumn
        '
        Me.UtilizzateDataGridViewTextBoxColumn.DataPropertyName = "Utilizzate"
        Me.UtilizzateDataGridViewTextBoxColumn.HeaderText = "Utilizzate"
        Me.UtilizzateDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.UtilizzateDataGridViewTextBoxColumn.Name = "UtilizzateDataGridViewTextBoxColumn"
        Me.UtilizzateDataGridViewTextBoxColumn.Width = 125
        '
        'ResiduoDataGridViewTextBoxColumn
        '
        Me.ResiduoDataGridViewTextBoxColumn.DataPropertyName = "Residuo"
        Me.ResiduoDataGridViewTextBoxColumn.HeaderText = "Residuo"
        Me.ResiduoDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ResiduoDataGridViewTextBoxColumn.Name = "ResiduoDataGridViewTextBoxColumn"
        Me.ResiduoDataGridViewTextBoxColumn.Width = 125
        '
        'BeniBindingSource
        '
        Me.BeniBindingSource.DataMember = "Beni"
        Me.BeniBindingSource.DataSource = Me.GdRDataSet
        '
        'CDataGrid
        '
        Me.CDataGrid.AutoGenerateColumns = False
        Me.CDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdClientiDataGridViewTextBoxColumn, Me.ClienteDataGridViewTextBoxColumn, Me.IndirizzoDataGridViewTextBoxColumn, Me.CittaDataGridViewTextBoxColumn, Me.ProvDataGridViewTextBoxColumn, Me.CAPDataGridViewTextBoxColumn, Me.TelDataGridViewTextBoxColumn, Me.PIVADataGridViewTextBoxColumn})
        Me.CDataGrid.DataSource = Me.ClientiBindingSource
        Me.CDataGrid.Location = New System.Drawing.Point(29, 765)
        Me.CDataGrid.Name = "CDataGrid"
        Me.CDataGrid.RowHeadersWidth = 51
        Me.CDataGrid.RowTemplate.Height = 24
        Me.CDataGrid.Size = New System.Drawing.Size(1850, 172)
        Me.CDataGrid.TabIndex = 3
        '
        'IdClientiDataGridViewTextBoxColumn
        '
        Me.IdClientiDataGridViewTextBoxColumn.DataPropertyName = "IdClienti"
        Me.IdClientiDataGridViewTextBoxColumn.HeaderText = "IdClienti"
        Me.IdClientiDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.IdClientiDataGridViewTextBoxColumn.Name = "IdClientiDataGridViewTextBoxColumn"
        Me.IdClientiDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdClientiDataGridViewTextBoxColumn.Width = 125
        '
        'ClienteDataGridViewTextBoxColumn
        '
        Me.ClienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente"
        Me.ClienteDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.ClienteDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ClienteDataGridViewTextBoxColumn.Name = "ClienteDataGridViewTextBoxColumn"
        Me.ClienteDataGridViewTextBoxColumn.Width = 125
        '
        'IndirizzoDataGridViewTextBoxColumn
        '
        Me.IndirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo"
        Me.IndirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo"
        Me.IndirizzoDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.IndirizzoDataGridViewTextBoxColumn.Name = "IndirizzoDataGridViewTextBoxColumn"
        Me.IndirizzoDataGridViewTextBoxColumn.Width = 125
        '
        'CittaDataGridViewTextBoxColumn
        '
        Me.CittaDataGridViewTextBoxColumn.DataPropertyName = "Citta"
        Me.CittaDataGridViewTextBoxColumn.HeaderText = "Citta"
        Me.CittaDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.CittaDataGridViewTextBoxColumn.Name = "CittaDataGridViewTextBoxColumn"
        Me.CittaDataGridViewTextBoxColumn.Width = 125
        '
        'ProvDataGridViewTextBoxColumn
        '
        Me.ProvDataGridViewTextBoxColumn.DataPropertyName = "Prov"
        Me.ProvDataGridViewTextBoxColumn.HeaderText = "Prov"
        Me.ProvDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.ProvDataGridViewTextBoxColumn.Name = "ProvDataGridViewTextBoxColumn"
        Me.ProvDataGridViewTextBoxColumn.Width = 125
        '
        'CAPDataGridViewTextBoxColumn
        '
        Me.CAPDataGridViewTextBoxColumn.DataPropertyName = "CAP"
        Me.CAPDataGridViewTextBoxColumn.HeaderText = "CAP"
        Me.CAPDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.CAPDataGridViewTextBoxColumn.Name = "CAPDataGridViewTextBoxColumn"
        Me.CAPDataGridViewTextBoxColumn.Width = 125
        '
        'TelDataGridViewTextBoxColumn
        '
        Me.TelDataGridViewTextBoxColumn.DataPropertyName = "Tel"
        Me.TelDataGridViewTextBoxColumn.HeaderText = "Tel"
        Me.TelDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.TelDataGridViewTextBoxColumn.Name = "TelDataGridViewTextBoxColumn"
        Me.TelDataGridViewTextBoxColumn.Width = 125
        '
        'PIVADataGridViewTextBoxColumn
        '
        Me.PIVADataGridViewTextBoxColumn.DataPropertyName = "P_IVA"
        Me.PIVADataGridViewTextBoxColumn.HeaderText = "P_IVA"
        Me.PIVADataGridViewTextBoxColumn.MinimumWidth = 6
        Me.PIVADataGridViewTextBoxColumn.Name = "PIVADataGridViewTextBoxColumn"
        Me.PIVADataGridViewTextBoxColumn.Width = 125
        '
        'ClientiBindingSource
        '
        Me.ClientiBindingSource.DataMember = "Clienti"
        Me.ClientiBindingSource.DataSource = Me.GdRDataSet
        '
        'TxtCerca
        '
        Me.TxtCerca.BackColor = System.Drawing.Color.Yellow
        Me.TxtCerca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCerca.Location = New System.Drawing.Point(207, 729)
        Me.TxtCerca.Name = "TxtCerca"
        Me.TxtCerca.Size = New System.Drawing.Size(137, 30)
        Me.TxtCerca.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 734)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Cerca Cliente"
        '
        'RjBtnRipristina
        '
        Me.RjBtnRipristina.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnRipristina.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnRipristina.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RjBtnRipristina.BorderRadius = 20
        Me.RjBtnRipristina.BorderSize = 0
        Me.RjBtnRipristina.FlatAppearance.BorderSize = 0
        Me.RjBtnRipristina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjBtnRipristina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjBtnRipristina.ForeColor = System.Drawing.Color.White
        Me.RjBtnRipristina.Location = New System.Drawing.Point(372, 719)
        Me.RjBtnRipristina.Name = "RjBtnRipristina"
        Me.RjBtnRipristina.Size = New System.Drawing.Size(150, 40)
        Me.RjBtnRipristina.TabIndex = 6
        Me.RjBtnRipristina.Text = "Ripristina"
        Me.RjBtnRipristina.TextColor = System.Drawing.Color.White
        Me.RjBtnRipristina.UseVisualStyleBackColor = False
        '
        'RjButton1
        '
        Me.RjButton1.BackColor = System.Drawing.Color.GreenYellow
        Me.RjButton1.BackgroundColor = System.Drawing.Color.GreenYellow
        Me.RjButton1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RjButton1.BorderRadius = 20
        Me.RjButton1.BorderSize = 2
        Me.RjButton1.FlatAppearance.BorderSize = 0
        Me.RjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjButton1.ForeColor = System.Drawing.Color.Navy
        Me.RjButton1.Location = New System.Drawing.Point(582, 719)
        Me.RjButton1.Name = "RjButton1"
        Me.RjButton1.Size = New System.Drawing.Size(193, 40)
        Me.RjButton1.TabIndex = 7
        Me.RjButton1.Text = "Nuovo Cliente"
        Me.RjButton1.TextColor = System.Drawing.Color.Navy
        Me.RjButton1.UseVisualStyleBackColor = False
        '
        'PictBoxConcluso
        '
        Me.PictBoxConcluso.Image = Global.GdRVideo.My.Resources.Resources.online_order
        Me.PictBoxConcluso.Location = New System.Drawing.Point(1885, 249)
        Me.PictBoxConcluso.Name = "PictBoxConcluso"
        Me.PictBoxConcluso.Size = New System.Drawing.Size(100, 88)
        Me.PictBoxConcluso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictBoxConcluso.TabIndex = 8
        Me.PictBoxConcluso.TabStop = False
        '
        'CboCategoria
        '
        Me.CboCategoria.BackColor = System.Drawing.Color.Gold
        Me.CboCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCategoria.FormattingEnabled = True
        Me.CboCategoria.Location = New System.Drawing.Point(148, 99)
        Me.CboCategoria.Name = "CboCategoria"
        Me.CboCategoria.Size = New System.Drawing.Size(347, 33)
        Me.CboCategoria.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Categoria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(528, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 25)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Modello"
        '
        'CboModello
        '
        Me.CboModello.BackColor = System.Drawing.Color.Gold
        Me.CboModello.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboModello.FormattingEnabled = True
        Me.CboModello.Location = New System.Drawing.Point(652, 99)
        Me.CboModello.Name = "CboModello"
        Me.CboModello.Size = New System.Drawing.Size(347, 33)
        Me.CboModello.TabIndex = 12
        '
        'RjBtnSalvaInterventi
        '
        Me.RjBtnSalvaInterventi.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnSalvaInterventi.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnSalvaInterventi.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RjBtnSalvaInterventi.BorderRadius = 20
        Me.RjBtnSalvaInterventi.BorderSize = 0
        Me.RjBtnSalvaInterventi.FlatAppearance.BorderSize = 0
        Me.RjBtnSalvaInterventi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjBtnSalvaInterventi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjBtnSalvaInterventi.ForeColor = System.Drawing.Color.White
        Me.RjBtnSalvaInterventi.Location = New System.Drawing.Point(1044, 94)
        Me.RjBtnSalvaInterventi.Name = "RjBtnSalvaInterventi"
        Me.RjBtnSalvaInterventi.Size = New System.Drawing.Size(190, 40)
        Me.RjBtnSalvaInterventi.TabIndex = 14
        Me.RjBtnSalvaInterventi.Text = "Salva Interventi"
        Me.RjBtnSalvaInterventi.TextColor = System.Drawing.Color.White
        Me.RjBtnSalvaInterventi.UseVisualStyleBackColor = False
        '
        'RjCircRipristina
        '
        Me.RjCircRipristina.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircRipristina.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircRipristina.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircRipristina.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircRipristina.BorderSize = 2
        Me.RjCircRipristina.GradientAngle = 50.0!
        Me.RjCircRipristina.Image = Global.GdRVideo.My.Resources.Resources.services
        Me.RjCircRipristina.Location = New System.Drawing.Point(830, 692)
        Me.RjCircRipristina.Name = "RjCircRipristina"
        Me.RjCircRipristina.Size = New System.Drawing.Size(67, 67)
        Me.RjCircRipristina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircRipristina.TabIndex = 15
        Me.RjCircRipristina.TabStop = False
        '
        'RjCircLeggiLog
        '
        Me.RjCircLeggiLog.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircLeggiLog.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircLeggiLog.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircLeggiLog.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircLeggiLog.BorderSize = 2
        Me.RjCircLeggiLog.GradientAngle = 50.0!
        Me.RjCircLeggiLog.Image = Global.GdRVideo.My.Resources.Resources.setting
        Me.RjCircLeggiLog.Location = New System.Drawing.Point(1671, 52)
        Me.RjCircLeggiLog.Name = "RjCircLeggiLog"
        Me.RjCircLeggiLog.Size = New System.Drawing.Size(100, 100)
        Me.RjCircLeggiLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircLeggiLog.TabIndex = 16
        Me.RjCircLeggiLog.TabStop = False
        '
        'RjCircOrdini
        '
        Me.RjCircOrdini.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircOrdini.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircOrdini.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircOrdini.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircOrdini.BorderSize = 2
        Me.RjCircOrdini.GradientAngle = 50.0!
        Me.RjCircOrdini.Image = Global.GdRVideo.My.Resources.Resources.order
        Me.RjCircOrdini.Location = New System.Drawing.Point(336, 393)
        Me.RjCircOrdini.Name = "RjCircOrdini"
        Me.RjCircOrdini.Size = New System.Drawing.Size(69, 69)
        Me.RjCircOrdini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircOrdini.TabIndex = 17
        Me.RjCircOrdini.TabStop = False
        '
        'RjCircNInt
        '
        Me.RjCircNInt.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat
        Me.RjCircNInt.BorderColor = System.Drawing.Color.RoyalBlue
        Me.RjCircNInt.BorderColor2 = System.Drawing.Color.HotPink
        Me.RjCircNInt.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.RjCircNInt.BorderSize = 2
        Me.RjCircNInt.GradientAngle = 50.0!
        Me.RjCircNInt.Image = Global.GdRVideo.My.Resources.Resources.open_enrollment
        Me.RjCircNInt.Location = New System.Drawing.Point(1283, 52)
        Me.RjCircNInt.Name = "RjCircNInt"
        Me.RjCircNInt.Size = New System.Drawing.Size(100, 100)
        Me.RjCircNInt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RjCircNInt.TabIndex = 18
        Me.RjCircNInt.TabStop = False
        '
        'FrmGestInt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.RjCircNInt)
        Me.Controls.Add(Me.RjCircOrdini)
        Me.Controls.Add(Me.RjCircLeggiLog)
        Me.Controls.Add(Me.RjCircRipristina)
        Me.Controls.Add(Me.RjBtnSalvaInterventi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CboModello)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboCategoria)
        Me.Controls.Add(Me.PictBoxConcluso)
        Me.Controls.Add(Me.RjButton1)
        Me.Controls.Add(Me.RjBtnRipristina)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCerca)
        Me.Controls.Add(Me.CDataGrid)
        Me.Controls.Add(Me.BDataGrid)
        Me.Controls.Add(Me.IDataGrid)
        Me.Controls.Add(Me.InterventiBindingNavigator)
        Me.Name = "FrmGestInt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmGestInt"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GdRDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InterventiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InterventiBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InterventiBindingNavigator.ResumeLayout(False)
        Me.InterventiBindingNavigator.PerformLayout()
        CType(Me.IDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeniBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictBoxConcluso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircRipristina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircLeggiLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircOrdini, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RjCircNInt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GdRDataSet As GdRDataSet
    Friend WithEvents InterventiBindingSource As BindingSource
    Friend WithEvents InterventiTableAdapter As GdRDataSetTableAdapters.InterventiTableAdapter
    Friend WithEvents TableAdapterManager As GdRDataSetTableAdapters.TableAdapterManager
    Friend WithEvents InterventiBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents InterventiBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents IDataGrid As DataGridView
    Friend WithEvents BeniTableAdapter As GdRDataSetTableAdapters.BeniTableAdapter
    Friend WithEvents BDataGrid As DataGridView
    Friend WithEvents BeniBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CategoriaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DescrizioneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MagazzinoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FornitoreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ModelloDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UtilizzateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ResiduoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClientiTableAdapter As GdRDataSetTableAdapters.ClientiTableAdapter
    Friend WithEvents CDataGrid As DataGridView
    Friend WithEvents ClientiBindingSource As BindingSource
    Friend WithEvents IdClientiDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClienteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IndirizzoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CittaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ProvDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CAPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PIVADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TxtCerca As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RjBtnRipristina As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents RjButton1 As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents PictBoxConcluso As PictureBox
    Friend WithEvents CboCategoria As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CboModello As ComboBox
    Friend WithEvents RjBtnSalvaInterventi As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents RjCircRipristina As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjCircLeggiLog As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjCircOrdini As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents RjCircNInt As RJCodeAdvance.RJControls.RJCircularPictureBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents Modello As DataGridViewTextBoxColumn
    Friend WithEvents Categoria As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Concluso As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
End Class
