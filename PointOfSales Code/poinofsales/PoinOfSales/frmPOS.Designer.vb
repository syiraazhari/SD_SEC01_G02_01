<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOS))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtChange = New System.Windows.Forms.TextBox()
        Me.txtAmountRecieve = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtTotalDue = New System.Windows.Forms.TextBox()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.txtdiscount = New System.Windows.Forms.TextBox()
        Me.txtSubtotal1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcustomer = New System.Windows.Forms.TextBox()
        Me.txtOR = New System.Windows.Forms.TextBox()
        Me.txtinvoice = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txttotalPrice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtitemname = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgItems = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.tsPayment = New System.Windows.Forms.ToolStripButton()
        Me.tsNew = New System.Windows.Forms.ToolStripButton()
        Me.tsRemove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LBLCASHIER = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lbldate = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.lbltime = New System.Windows.Forms.ToolStripLabel()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Location = New System.Drawing.Point(661, 90)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(424, 440)
        Me.Panel4.TabIndex = 39
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.txtChange)
        Me.GroupBox3.Controls.Add(Me.txtAmountRecieve)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(13, 199)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(406, 150)
        Me.GroupBox3.TabIndex = 29
        Me.GroupBox3.TabStop = False
        '
        'txtChange
        '
        Me.txtChange.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtChange.Enabled = False
        Me.txtChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtChange.Location = New System.Drawing.Point(206, 82)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(194, 44)
        Me.txtChange.TabIndex = 42
        Me.txtChange.Text = "0.00"
        Me.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountRecieve
        '
        Me.txtAmountRecieve.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtAmountRecieve.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountRecieve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtAmountRecieve.Location = New System.Drawing.Point(206, 29)
        Me.txtAmountRecieve.Name = "txtAmountRecieve"
        Me.txtAmountRecieve.Size = New System.Drawing.Size(194, 47)
        Me.txtAmountRecieve.TabIndex = 41
        Me.txtAmountRecieve.Text = "0.00"
        Me.txtAmountRecieve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(18, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(182, 24)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Amount Received:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(105, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 24)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Change :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.TxtTotalDue)
        Me.GroupBox2.Controls.Add(Me.txtTax)
        Me.GroupBox2.Controls.Add(Me.txtdiscount)
        Me.GroupBox2.Controls.Add(Me.txtSubtotal1)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 181)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        '
        'TxtTotalDue
        '
        Me.TxtTotalDue.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TxtTotalDue.Enabled = False
        Me.TxtTotalDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TxtTotalDue.Location = New System.Drawing.Point(178, 127)
        Me.TxtTotalDue.Name = "TxtTotalDue"
        Me.TxtTotalDue.Size = New System.Drawing.Size(222, 31)
        Me.TxtTotalDue.TabIndex = 40
        Me.TxtTotalDue.Text = "0.00"
        Me.TxtTotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTax
        '
        Me.txtTax.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTax.Enabled = False
        Me.txtTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTax.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtTax.Location = New System.Drawing.Point(178, 86)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(222, 31)
        Me.txtTax.TabIndex = 39
        Me.txtTax.Text = "0.00"
        Me.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdiscount
        '
        Me.txtdiscount.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtdiscount.Enabled = False
        Me.txtdiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiscount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtdiscount.Location = New System.Drawing.Point(178, 48)
        Me.txtdiscount.Name = "txtdiscount"
        Me.txtdiscount.Size = New System.Drawing.Size(222, 31)
        Me.txtdiscount.TabIndex = 38
        Me.txtdiscount.Text = "0.00"
        Me.txtdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotal1
        '
        Me.txtSubtotal1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtSubtotal1.Enabled = False
        Me.txtSubtotal1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSubtotal1.Location = New System.Drawing.Point(178, 12)
        Me.txtSubtotal1.Name = "txtSubtotal1"
        Me.txtSubtotal1.Size = New System.Drawing.Size(222, 31)
        Me.txtSubtotal1.TabIndex = 37
        Me.txtSubtotal1.Text = "0.00"
        Me.txtSubtotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(23, 89)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(114, 25)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "12% TAX :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(21, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 25)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Sub Total :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(157, 25)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "10% Discount :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 25)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Total Due :"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(274, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(496, 37)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "BUDZ FOOD HUB POS System"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtcustomer)
        Me.GroupBox1.Controls.Add(Me.txtOR)
        Me.GroupBox1.Controls.Add(Me.txtinvoice)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(661, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 10)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'txtcustomer
        '
        Me.txtcustomer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtcustomer.Enabled = False
        Me.txtcustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcustomer.Location = New System.Drawing.Point(98, 64)
        Me.txtcustomer.Name = "txtcustomer"
        Me.txtcustomer.Size = New System.Drawing.Size(315, 20)
        Me.txtcustomer.TabIndex = 39
        '
        'txtOR
        '
        Me.txtOR.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtOR.Enabled = False
        Me.txtOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOR.Location = New System.Drawing.Point(98, 38)
        Me.txtOR.Name = "txtOR"
        Me.txtOR.Size = New System.Drawing.Size(315, 20)
        Me.txtOR.TabIndex = 38
        '
        'txtinvoice
        '
        Me.txtinvoice.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtinvoice.Enabled = False
        Me.txtinvoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinvoice.Location = New System.Drawing.Point(98, 12)
        Me.txtinvoice.Name = "txtinvoice"
        Me.txtinvoice.Size = New System.Drawing.Size(315, 20)
        Me.txtinvoice.TabIndex = 37
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(11, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Customer: "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(11, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Invoice No. :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(15, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "OR No. :"
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1086, 84)
        Me.Panel1.TabIndex = 35
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(155, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.CheckBox2)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.txtsubtotal)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txttotalPrice)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtprice)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtdescription)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtqty)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtitemname)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtItemCode)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dtgItems)
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 99)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(653, 431)
        Me.Panel2.TabIndex = 36
        '
        'btnFind
        '
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Location = New System.Drawing.Point(314, 13)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(61, 26)
        Me.btnFind.TabIndex = 39
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Black
        Me.CheckBox2.Location = New System.Drawing.Point(14, 398)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(92, 24)
        Me.CheckBox2.TabIndex = 38
        Me.CheckBox2.Text = "Add TAX"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Black
        Me.CheckBox1.Location = New System.Drawing.Point(14, 375)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(129, 24)
        Me.CheckBox1.TabIndex = 37
        Me.CheckBox1.Text = "Less Discount"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsubtotal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtsubtotal.Enabled = False
        Me.txtsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtsubtotal.Location = New System.Drawing.Point(307, 365)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(341, 62)
        Me.txtsubtotal.TabIndex = 36
        Me.txtsubtotal.Text = "0.00"
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(149, 388)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 33)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Sub Total :"
        '
        'txttotalPrice
        '
        Me.txttotalPrice.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txttotalPrice.Enabled = False
        Me.txttotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalPrice.Location = New System.Drawing.Point(467, 38)
        Me.txttotalPrice.Name = "txttotalPrice"
        Me.txttotalPrice.Size = New System.Drawing.Size(165, 22)
        Me.txttotalPrice.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(381, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Total Price:"
        '
        'txtprice
        '
        Me.txtprice.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtprice.Enabled = False
        Me.txtprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprice.Location = New System.Drawing.Point(246, 43)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(129, 22)
        Me.txtprice.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(188, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Price :"
        '
        'txtdescription
        '
        Me.txtdescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtdescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtdescription.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtdescription.Enabled = False
        Me.txtdescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescription.Location = New System.Drawing.Point(73, 67)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(559, 22)
        Me.txtdescription.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Confirm :"
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(73, 43)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(109, 22)
        Me.txtqty.TabIndex = 10
        Me.txtqty.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Qty."
        '
        'txtitemname
        '
        Me.txtitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtitemname.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtitemname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemname.Location = New System.Drawing.Point(73, 15)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.Size = New System.Drawing.Size(235, 22)
        Me.txtitemname.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Product :"
        '
        'txtItemCode
        '
        Me.txtItemCode.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtItemCode.Enabled = False
        Me.txtItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(467, 12)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(165, 22)
        Me.txtItemCode.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(381, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Item Code :"
        '
        'dtgItems
        '
        Me.dtgItems.AllowUserToAddRows = False
        Me.dtgItems.AllowUserToDeleteRows = False
        Me.dtgItems.AllowUserToOrderColumns = True
        Me.dtgItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dtgItems.Location = New System.Drawing.Point(3, 97)
        Me.dtgItems.Name = "dtgItems"
        Me.dtgItems.ReadOnly = True
        Me.dtgItems.RowHeadersVisible = False
        Me.dtgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgItems.Size = New System.Drawing.Size(645, 266)
        Me.dtgItems.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Item Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Description"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 230
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "QTY."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "Price"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 150
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSave, Me.tsPayment, Me.tsNew, Me.tsRemove, Me.ToolStripSeparator1, Me.LBLCASHIER, Me.ToolStripSeparator2, Me.ToolStripLabel2, Me.lbldate, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.lbltime})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 530)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1086, 57)
        Me.ToolStrip1.TabIndex = 40
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSave
        '
        Me.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(54, 54)
        Me.tsSave.Text = "Save"
        '
        'tsPayment
        '
        Me.tsPayment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPayment.Image = CType(resources.GetObject("tsPayment.Image"), System.Drawing.Image)
        Me.tsPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPayment.Name = "tsPayment"
        Me.tsPayment.Size = New System.Drawing.Size(54, 54)
        Me.tsPayment.Text = "Recieve Payment"
        '
        'tsNew
        '
        Me.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsNew.Image = CType(resources.GetObject("tsNew.Image"), System.Drawing.Image)
        Me.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNew.Name = "tsNew"
        Me.tsNew.Size = New System.Drawing.Size(54, 54)
        Me.tsNew.Text = "New"
        '
        'tsRemove
        '
        Me.tsRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRemove.Image = CType(resources.GetObject("tsRemove.Image"), System.Drawing.Image)
        Me.tsRemove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemove.Name = "tsRemove"
        Me.tsRemove.Size = New System.Drawing.Size(54, 54)
        Me.tsRemove.Text = "Void"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 57)
        '
        'LBLCASHIER
        '
        Me.LBLCASHIER.Name = "LBLCASHIER"
        Me.LBLCASHIER.Size = New System.Drawing.Size(48, 54)
        Me.LBLCASHIER.Text = "None"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 57)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(49, 54)
        Me.ToolStripLabel2.Text = "Date :"
        '
        'lbldate
        '
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(100, 54)
        Me.lbldate.Text = "mm/dd/yyyy"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 57)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(51, 54)
        Me.ToolStripLabel3.Text = "Time :"
        '
        'lbltime
        '
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(76, 54)
        Me.lbltime.Text = "hh:mm:ss"
        '
        'frmPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1086, 587)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmPOS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS"
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtgItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtChange As TextBox
    Friend WithEvents txtAmountRecieve As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtcustomer As TextBox
    Friend WithEvents txtOR As TextBox
    Friend WithEvents txtinvoice As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TxtTotalDue As TextBox
    Friend WithEvents txtTax As TextBox
    Friend WithEvents txtdiscount As TextBox
    Friend WithEvents txtSubtotal1 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFind As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtsubtotal As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txttotalPrice As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtprice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtdescription As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtqty As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtitemname As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtgItems As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSave As ToolStripButton
    Friend WithEvents tsNew As ToolStripButton
    Friend WithEvents tsPayment As ToolStripButton
    Friend WithEvents tsRemove As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents LBLCASHIER As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents lbldate As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents lbltime As ToolStripLabel
End Class
