<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingPasswordForm
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
        Me.CurrentPassLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ConfirmButton = New System.Windows.Forms.Button()
        Me.ContinueButton = New System.Windows.Forms.Button()
        Me.ReenterPassTextBox = New System.Windows.Forms.TextBox()
        Me.ReenterPassLabel = New System.Windows.Forms.Label()
        Me.NewPassTextBox = New System.Windows.Forms.TextBox()
        Me.NewPassLabel = New System.Windows.Forms.Label()
        Me.CurrentPassTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CurrentPassLabel
        '
        Me.CurrentPassLabel.AutoSize = True
        Me.CurrentPassLabel.Location = New System.Drawing.Point(67, 120)
        Me.CurrentPassLabel.Name = "CurrentPassLabel"
        Me.CurrentPassLabel.Size = New System.Drawing.Size(203, 29)
        Me.CurrentPassLabel.TabIndex = 0
        Me.CurrentPassLabel.Text = "Current password"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ConfirmButton)
        Me.Panel1.Controls.Add(Me.ContinueButton)
        Me.Panel1.Controls.Add(Me.ReenterPassTextBox)
        Me.Panel1.Controls.Add(Me.ReenterPassLabel)
        Me.Panel1.Controls.Add(Me.NewPassTextBox)
        Me.Panel1.Controls.Add(Me.NewPassLabel)
        Me.Panel1.Controls.Add(Me.CurrentPassTextBox)
        Me.Panel1.Controls.Add(Me.CurrentPassLabel)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(61, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1294, 663)
        Me.Panel1.TabIndex = 1
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(72, 550)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(131, 43)
        Me.ConfirmButton.TabIndex = 8
        Me.ConfirmButton.Text = "Confirm"
        Me.ConfirmButton.UseVisualStyleBackColor = True
        Me.ConfirmButton.Visible = False
        '
        'ContinueButton
        '
        Me.ContinueButton.Location = New System.Drawing.Point(72, 226)
        Me.ContinueButton.Name = "ContinueButton"
        Me.ContinueButton.Size = New System.Drawing.Size(131, 43)
        Me.ContinueButton.TabIndex = 7
        Me.ContinueButton.Text = "Continue"
        Me.ContinueButton.UseVisualStyleBackColor = True
        '
        'ReenterPassTextBox
        '
        Me.ReenterPassTextBox.Location = New System.Drawing.Point(72, 487)
        Me.ReenterPassTextBox.Name = "ReenterPassTextBox"
        Me.ReenterPassTextBox.Size = New System.Drawing.Size(387, 34)
        Me.ReenterPassTextBox.TabIndex = 6
        Me.ReenterPassTextBox.Visible = False
        '
        'ReenterPassLabel
        '
        Me.ReenterPassLabel.AutoSize = True
        Me.ReenterPassLabel.Location = New System.Drawing.Point(67, 442)
        Me.ReenterPassLabel.Name = "ReenterPassLabel"
        Me.ReenterPassLabel.Size = New System.Drawing.Size(321, 29)
        Me.ReenterPassLabel.TabIndex = 5
        Me.ReenterPassLabel.Text = "Re-enter your new password"
        Me.ReenterPassLabel.Visible = False
        '
        'NewPassTextBox
        '
        Me.NewPassTextBox.Location = New System.Drawing.Point(72, 383)
        Me.NewPassTextBox.Name = "NewPassTextBox"
        Me.NewPassTextBox.Size = New System.Drawing.Size(387, 34)
        Me.NewPassTextBox.TabIndex = 4
        Me.NewPassTextBox.Visible = False
        '
        'NewPassLabel
        '
        Me.NewPassLabel.AutoSize = True
        Me.NewPassLabel.Location = New System.Drawing.Point(67, 338)
        Me.NewPassLabel.Name = "NewPassLabel"
        Me.NewPassLabel.Size = New System.Drawing.Size(284, 29)
        Me.NewPassLabel.TabIndex = 3
        Me.NewPassLabel.Text = "Enter your new password"
        Me.NewPassLabel.Visible = False
        '
        'CurrentPassTextBox
        '
        Me.CurrentPassTextBox.Location = New System.Drawing.Point(72, 165)
        Me.CurrentPassTextBox.Name = "CurrentPassTextBox"
        Me.CurrentPassTextBox.Size = New System.Drawing.Size(387, 34)
        Me.CurrentPassTextBox.TabIndex = 2
        '
        'SettingPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SettingPasswordForm"
        Me.Text = "SettingPasswordForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CurrentPassLabel As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NewPassTextBox As TextBox
    Friend WithEvents NewPassLabel As Label
    Friend WithEvents CurrentPassTextBox As TextBox
    Friend WithEvents ReenterPassTextBox As TextBox
    Friend WithEvents ReenterPassLabel As Label
    Friend WithEvents ContinueButton As Button
    Friend WithEvents ConfirmButton As Button
End Class
