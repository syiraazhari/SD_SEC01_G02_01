<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetForgotPasswordForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ConfirmButton = New System.Windows.Forms.Button()
        Me.ReenterPassTextBox = New System.Windows.Forms.TextBox()
        Me.ReenterPassLabel = New System.Windows.Forms.Label()
        Me.NewPassTextBox = New System.Windows.Forms.TextBox()
        Me.NewPassLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ConfirmButton)
        Me.Panel1.Controls.Add(Me.ReenterPassTextBox)
        Me.Panel1.Controls.Add(Me.ReenterPassLabel)
        Me.Panel1.Controls.Add(Me.NewPassTextBox)
        Me.Panel1.Controls.Add(Me.NewPassLabel)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(61, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1165, 621)
        Me.Panel1.TabIndex = 2
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(89, 301)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(131, 43)
        Me.ConfirmButton.TabIndex = 8
        Me.ConfirmButton.Text = "Confirm"
        Me.ConfirmButton.UseVisualStyleBackColor = True
        '
        'ReenterPassTextBox
        '
        Me.ReenterPassTextBox.Location = New System.Drawing.Point(89, 238)
        Me.ReenterPassTextBox.Name = "ReenterPassTextBox"
        Me.ReenterPassTextBox.Size = New System.Drawing.Size(387, 34)
        Me.ReenterPassTextBox.TabIndex = 6
        '
        'ReenterPassLabel
        '
        Me.ReenterPassLabel.AutoSize = True
        Me.ReenterPassLabel.Location = New System.Drawing.Point(84, 193)
        Me.ReenterPassLabel.Name = "ReenterPassLabel"
        Me.ReenterPassLabel.Size = New System.Drawing.Size(321, 29)
        Me.ReenterPassLabel.TabIndex = 5
        Me.ReenterPassLabel.Text = "Re-enter your new password"
        '
        'NewPassTextBox
        '
        Me.NewPassTextBox.Location = New System.Drawing.Point(89, 134)
        Me.NewPassTextBox.Name = "NewPassTextBox"
        Me.NewPassTextBox.Size = New System.Drawing.Size(387, 34)
        Me.NewPassTextBox.TabIndex = 4
        '
        'NewPassLabel
        '
        Me.NewPassLabel.AutoSize = True
        Me.NewPassLabel.Location = New System.Drawing.Point(84, 89)
        Me.NewPassLabel.Name = "NewPassLabel"
        Me.NewPassLabel.Size = New System.Drawing.Size(284, 29)
        Me.NewPassLabel.TabIndex = 3
        Me.NewPassLabel.Text = "Enter your new password"
        '
        'SetForgotPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1422, 781)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SetForgotPasswordForm"
        Me.Text = "SetForgotPasswordForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ConfirmButton As Button
    Friend WithEvents ReenterPassTextBox As TextBox
    Friend WithEvents ReenterPassLabel As Label
    Friend WithEvents NewPassTextBox As TextBox
    Friend WithEvents NewPassLabel As Label
End Class
