<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.LoginStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PaymentToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ExitToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ReportToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StaffToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.InventoryToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SettingToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginStripButton, Me.PaymentToolStripButton, Me.ExitToolStripButton, Me.ReportToolStripButton, Me.StaffToolStripButton, Me.InventoryToolStripButton, Me.SettingToolStripButton})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(75, 656)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'LoginStripButton
        '
        Me.LoginStripButton.Image = CType(resources.GetObject("LoginStripButton.Image"), System.Drawing.Image)
        Me.LoginStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LoginStripButton.Name = "LoginStripButton"
        Me.LoginStripButton.Size = New System.Drawing.Size(72, 44)
        Me.LoginStripButton.Text = "Login"
        Me.LoginStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PaymentToolStripButton
        '
        Me.PaymentToolStripButton.Image = CType(resources.GetObject("PaymentToolStripButton.Image"), System.Drawing.Image)
        Me.PaymentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PaymentToolStripButton.Name = "PaymentToolStripButton"
        Me.PaymentToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.PaymentToolStripButton.Text = "Payment"
        Me.PaymentToolStripButton.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.PaymentToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.PaymentToolStripButton.Visible = False
        '
        'ExitToolStripButton
        '
        Me.ExitToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ExitToolStripButton.Image = CType(resources.GetObject("ExitToolStripButton.Image"), System.Drawing.Image)
        Me.ExitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExitToolStripButton.Name = "ExitToolStripButton"
        Me.ExitToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.ExitToolStripButton.Text = "Exit"
        Me.ExitToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ReportToolStripButton
        '
        Me.ReportToolStripButton.Image = CType(resources.GetObject("ReportToolStripButton.Image"), System.Drawing.Image)
        Me.ReportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ReportToolStripButton.Name = "ReportToolStripButton"
        Me.ReportToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.ReportToolStripButton.Text = "Report"
        Me.ReportToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StaffToolStripButton
        '
        Me.StaffToolStripButton.Image = CType(resources.GetObject("StaffToolStripButton.Image"), System.Drawing.Image)
        Me.StaffToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StaffToolStripButton.Name = "StaffToolStripButton"
        Me.StaffToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.StaffToolStripButton.Text = "Staff"
        Me.StaffToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'InventoryToolStripButton
        '
        Me.InventoryToolStripButton.Image = CType(resources.GetObject("InventoryToolStripButton.Image"), System.Drawing.Image)
        Me.InventoryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InventoryToolStripButton.Name = "InventoryToolStripButton"
        Me.InventoryToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.InventoryToolStripButton.Text = "Inventory"
        Me.InventoryToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SettingToolStripButton
        '
        Me.SettingToolStripButton.Image = CType(resources.GetObject("SettingToolStripButton.Image"), System.Drawing.Image)
        Me.SettingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SettingToolStripButton.Name = "SettingToolStripButton"
        Me.SettingToolStripButton.Size = New System.Drawing.Size(72, 44)
        Me.SettingToolStripButton.Text = "Setting"
        Me.SettingToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 656)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1289, 26)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(49, 20)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1289, 682)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MDIParent1"
        Me.Text = "MDIParent1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents LoginStripButton As ToolStripButton
    Friend WithEvents ExitToolStripButton As ToolStripButton
    Friend WithEvents PaymentToolStripButton As ToolStripButton
    Friend WithEvents ReportToolStripButton As ToolStripButton
    Friend WithEvents InventoryToolStripButton As ToolStripButton
    Friend WithEvents StaffToolStripButton As ToolStripButton
    Friend WithEvents SettingToolStripButton As ToolStripButton
End Class
