<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        Me.PasswordPanel = New System.Windows.Forms.Panel()
        Me.PrivacyLabel = New System.Windows.Forms.Label()
        Me.PasswordPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PasswordPanel
        '
        Me.PasswordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordPanel.Controls.Add(Me.PrivacyLabel)
        Me.PasswordPanel.Location = New System.Drawing.Point(0, 0)
        Me.PasswordPanel.Name = "PasswordPanel"
        Me.PasswordPanel.Size = New System.Drawing.Size(1942, 78)
        Me.PasswordPanel.TabIndex = 0
        '
        'PrivacyLabel
        '
        Me.PrivacyLabel.AutoSize = True
        Me.PrivacyLabel.Font = New System.Drawing.Font("Microsoft YaHei UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrivacyLabel.Location = New System.Drawing.Point(65, 24)
        Me.PrivacyLabel.Name = "PrivacyLabel"
        Me.PrivacyLabel.Size = New System.Drawing.Size(122, 31)
        Me.PrivacyLabel.TabIndex = 0
        Me.PrivacyLabel.Text = "Password"
        '
        'SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.PasswordPanel)
        Me.Name = "SettingForm"
        Me.Text = "SettingForm"
        Me.PasswordPanel.ResumeLayout(False)
        Me.PasswordPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PasswordPanel As Panel
    Friend WithEvents PrivacyLabel As Label
End Class
