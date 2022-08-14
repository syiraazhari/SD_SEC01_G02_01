<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsPOS = New System.Windows.Forms.ToolStripButton()
        Me.tsStocks = New System.Windows.Forms.ToolStripButton()
        Me.tsCategory = New System.Windows.Forms.ToolStripButton()
        Me.tsUser = New System.Windows.Forms.ToolStripButton()
        Me.tsReport = New System.Windows.Forms.ToolStripButton()
        Me.tsLogin = New System.Windows.Forms.ToolStripButton()
        Me.tsExit = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statsloginname = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtdailycollection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPOS, Me.tsStocks, Me.tsCategory, Me.tsUser, Me.tsReport, Me.tsLogin, Me.tsExit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(60, 478)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsPOS
        '
        Me.tsPOS.Image = CType(resources.GetObject("tsPOS.Image"), System.Drawing.Image)
        Me.tsPOS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPOS.Name = "tsPOS"
        Me.tsPOS.Size = New System.Drawing.Size(57, 43)
        Me.tsPOS.Text = "POS"
        Me.tsPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsStocks
        '
        Me.tsStocks.Image = CType(resources.GetObject("tsStocks.Image"), System.Drawing.Image)
        Me.tsStocks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsStocks.Name = "tsStocks"
        Me.tsStocks.Size = New System.Drawing.Size(57, 43)
        Me.tsStocks.Text = "Stock"
        Me.tsStocks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsCategory
        '
        Me.tsCategory.Image = CType(resources.GetObject("tsCategory.Image"), System.Drawing.Image)
        Me.tsCategory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCategory.Name = "tsCategory"
        Me.tsCategory.Size = New System.Drawing.Size(57, 43)
        Me.tsCategory.Text = "Category"
        Me.tsCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsUser
        '
        Me.tsUser.Image = CType(resources.GetObject("tsUser.Image"), System.Drawing.Image)
        Me.tsUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(57, 43)
        Me.tsUser.Text = "Manage"
        Me.tsUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsReport
        '
        Me.tsReport.Image = CType(resources.GetObject("tsReport.Image"), System.Drawing.Image)
        Me.tsReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReport.Name = "tsReport"
        Me.tsReport.Size = New System.Drawing.Size(57, 43)
        Me.tsReport.Text = "Reports"
        Me.tsReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsLogin
        '
        Me.tsLogin.Image = Global.PoinOfSales.My.Resources.Resources.loginkey
        Me.tsLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsLogin.Name = "tsLogin"
        Me.tsLogin.Size = New System.Drawing.Size(57, 43)
        Me.tsLogin.Text = "Login"
        Me.tsLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsExit
        '
        Me.tsExit.Image = CType(resources.GetObject("tsExit.Image"), System.Drawing.Image)
        Me.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsExit.Name = "tsExit"
        Me.tsExit.Size = New System.Drawing.Size(57, 43)
        Me.tsExit.Text = "Exit"
        Me.tsExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statsloginname, Me.ToolStripStatusLabel2, Me.txtdailycollection})
        Me.StatusStrip1.Location = New System.Drawing.Point(60, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(89, 17)
        Me.ToolStripStatusLabel1.Text = "Logged in User:"
        '
        'statsloginname
        '
        Me.statsloginname.Name = "statsloginname"
        Me.statsloginname.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(96, 17)
        Me.ToolStripStatusLabel2.Text = "Daily Collection :"
        '
        'txtdailycollection
        '
        Me.txtdailycollection.Name = "txtdailycollection"
        Me.txtdailycollection.Size = New System.Drawing.Size(28, 17)
        Me.txtdailycollection.Text = "0.00"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1004, 478)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sales | Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsPOS As ToolStripButton
    Friend WithEvents tsStocks As ToolStripButton
    Friend WithEvents tsCategory As ToolStripButton
    Friend WithEvents tsUser As ToolStripButton
    Friend WithEvents tsReport As ToolStripButton
    Friend WithEvents tsLogin As ToolStripButton
    Friend WithEvents tsExit As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents statsloginname As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents txtdailycollection As ToolStripStatusLabel
End Class
