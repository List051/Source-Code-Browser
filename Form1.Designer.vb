<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.RjBtnChiudiApp = New RJCodeAdvance.RJControls.RJButton()
        Me.RjBtnCreaAlbero = New RJCodeAdvance.RJControls.RJButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BrnApriCartella = New RJCodeAdvance.RJControls.RJButton()
        Me.BtnApreUltimaCartella = New RJCodeAdvance.RJControls.RJButton()
        Me.RjBtnInt = New RJCodeAdvance.RJControls.RJButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SezionePictBox = New System.Windows.Forms.PictureBox()
        Me.AvvisoPictBox = New System.Windows.Forms.PictureBox()
        Me.PanelMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SezionePictBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvvisoPictBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.Orange
        Me.PanelMenu.Controls.Add(Me.RjBtnChiudiApp)
        Me.PanelMenu.Controls.Add(Me.RjBtnCreaAlbero)
        Me.PanelMenu.Controls.Add(Me.Panel1)
        Me.PanelMenu.Controls.Add(Me.BrnApriCartella)
        Me.PanelMenu.Controls.Add(Me.BtnApreUltimaCartella)
        Me.PanelMenu.Controls.Add(Me.RjBtnInt)
        Me.PanelMenu.Controls.Add(Me.PictureBox1)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(433, 1050)
        Me.PanelMenu.TabIndex = 0
        '
        'RjBtnChiudiApp
        '
        Me.RjBtnChiudiApp.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnChiudiApp.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnChiudiApp.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RjBtnChiudiApp.BorderRadius = 20
        Me.RjBtnChiudiApp.BorderSize = 0
        Me.RjBtnChiudiApp.FlatAppearance.BorderSize = 0
        Me.RjBtnChiudiApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjBtnChiudiApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjBtnChiudiApp.ForeColor = System.Drawing.Color.White
        Me.RjBtnChiudiApp.Location = New System.Drawing.Point(28, 869)
        Me.RjBtnChiudiApp.Name = "RjBtnChiudiApp"
        Me.RjBtnChiudiApp.Size = New System.Drawing.Size(362, 121)
        Me.RjBtnChiudiApp.TabIndex = 6
        Me.RjBtnChiudiApp.Text = "Chiudi App"
        Me.RjBtnChiudiApp.TextColor = System.Drawing.Color.White
        Me.RjBtnChiudiApp.UseVisualStyleBackColor = False
        '
        'RjBtnCreaAlbero
        '
        Me.RjBtnCreaAlbero.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnCreaAlbero.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnCreaAlbero.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RjBtnCreaAlbero.BorderRadius = 20
        Me.RjBtnCreaAlbero.BorderSize = 0
        Me.RjBtnCreaAlbero.FlatAppearance.BorderSize = 0
        Me.RjBtnCreaAlbero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjBtnCreaAlbero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjBtnCreaAlbero.ForeColor = System.Drawing.Color.White
        Me.RjBtnCreaAlbero.Location = New System.Drawing.Point(28, 748)
        Me.RjBtnCreaAlbero.Name = "RjBtnCreaAlbero"
        Me.RjBtnCreaAlbero.Size = New System.Drawing.Size(362, 54)
        Me.RjBtnCreaAlbero.TabIndex = 5
        Me.RjBtnCreaAlbero.Text = "Apri mio YouTube"
        Me.RjBtnCreaAlbero.TextColor = System.Drawing.Color.White
        Me.RjBtnCreaAlbero.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(41, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(349, 190)
        Me.Panel1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(15, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(316, 153)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "Utilizza il pulsante " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Apri Cartella" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " per vedere il codice dei *.vb" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Selezioni" &
    " il File" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleziona la routine da visualizzare"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BrnApriCartella
        '
        Me.BrnApriCartella.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.BrnApriCartella.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.BrnApriCartella.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.BrnApriCartella.BorderRadius = 20
        Me.BrnApriCartella.BorderSize = 0
        Me.BrnApriCartella.FlatAppearance.BorderSize = 0
        Me.BrnApriCartella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BrnApriCartella.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BrnApriCartella.ForeColor = System.Drawing.Color.White
        Me.BrnApriCartella.Location = New System.Drawing.Point(28, 433)
        Me.BrnApriCartella.Name = "BrnApriCartella"
        Me.BrnApriCartella.Size = New System.Drawing.Size(362, 54)
        Me.BrnApriCartella.TabIndex = 3
        Me.BrnApriCartella.Text = "Apri Cartella"
        Me.BrnApriCartella.TextColor = System.Drawing.Color.White
        Me.BrnApriCartella.UseVisualStyleBackColor = False
        '
        'BtnApreUltimaCartella
        '
        Me.BtnApreUltimaCartella.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnApreUltimaCartella.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnApreUltimaCartella.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.BtnApreUltimaCartella.BorderRadius = 20
        Me.BtnApreUltimaCartella.BorderSize = 0
        Me.BtnApreUltimaCartella.FlatAppearance.BorderSize = 0
        Me.BtnApreUltimaCartella.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApreUltimaCartella.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApreUltimaCartella.ForeColor = System.Drawing.Color.Navy
        Me.BtnApreUltimaCartella.Image = Global.GdRVideo.My.Resources.Resources.favorites
        Me.BtnApreUltimaCartella.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnApreUltimaCartella.Location = New System.Drawing.Point(12, 520)
        Me.BtnApreUltimaCartella.Name = "BtnApreUltimaCartella"
        Me.BtnApreUltimaCartella.Size = New System.Drawing.Size(392, 156)
        Me.BtnApreUltimaCartella.TabIndex = 2
        Me.BtnApreUltimaCartella.Text = "Apri Ultima Cartella"
        Me.BtnApreUltimaCartella.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnApreUltimaCartella.TextColor = System.Drawing.Color.Navy
        Me.BtnApreUltimaCartella.UseVisualStyleBackColor = False
        '
        'RjBtnInt
        '
        Me.RjBtnInt.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnInt.BackgroundColor = System.Drawing.Color.MediumSlateBlue
        Me.RjBtnInt.BorderColor = System.Drawing.Color.PaleVioletRed
        Me.RjBtnInt.BorderRadius = 20
        Me.RjBtnInt.BorderSize = 0
        Me.RjBtnInt.FlatAppearance.BorderSize = 0
        Me.RjBtnInt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RjBtnInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RjBtnInt.ForeColor = System.Drawing.Color.White
        Me.RjBtnInt.Location = New System.Drawing.Point(28, 143)
        Me.RjBtnInt.Name = "RjBtnInt"
        Me.RjBtnInt.Size = New System.Drawing.Size(362, 54)
        Me.RjBtnInt.TabIndex = 1
        Me.RjBtnInt.Text = "IPMessaggeBox"
        Me.RjBtnInt.TextColor = System.Drawing.Color.White
        Me.RjBtnInt.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GdRVideo.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(28, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(362, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(486, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1070, 1026)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1062, 993)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Libreria"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(1016, 978)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1062, 993)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'SezionePictBox
        '
        Me.SezionePictBox.Image = Global.GdRVideo.My.Resources.Resources.arrows
        Me.SezionePictBox.Location = New System.Drawing.Point(1802, 181)
        Me.SezionePictBox.Name = "SezionePictBox"
        Me.SezionePictBox.Size = New System.Drawing.Size(100, 89)
        Me.SezionePictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.SezionePictBox.TabIndex = 3
        Me.SezionePictBox.TabStop = False
        '
        'AvvisoPictBox
        '
        Me.AvvisoPictBox.Image = Global.GdRVideo.My.Resources.Resources.arrows
        Me.AvvisoPictBox.Location = New System.Drawing.Point(1802, 470)
        Me.AvvisoPictBox.Name = "AvvisoPictBox"
        Me.AvvisoPictBox.Size = New System.Drawing.Size(100, 89)
        Me.AvvisoPictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AvvisoPictBox.TabIndex = 2
        Me.AvvisoPictBox.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1050)
        Me.Controls.Add(Me.SezionePictBox)
        Me.Controls.Add(Me.AvvisoPictBox)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Menu"
        Me.PanelMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.SezionePictBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvvisoPictBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMenu As Panel
    Friend WithEvents RjBtnInt As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents BtnApreUltimaCartella As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents AvvisoPictBox As PictureBox
    Friend WithEvents BrnApriCartella As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents SezionePictBox As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents RjBtnCreaAlbero As RJCodeAdvance.RJControls.RJButton
    Friend WithEvents RjBtnChiudiApp As RJCodeAdvance.RJControls.RJButton
End Class
