<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForgotPasswordForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.SendCodeButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.EnterCodeButton = New System.Windows.Forms.Button()
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(689, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Trouble Logging In?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(596, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(356, 50)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Enter your email or username and we'll send you a code to get back into your acco" &
    "unt"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Location = New System.Drawing.Point(618, 337)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(302, 25)
        Me.EmailTextBox.TabIndex = 2
        '
        'SendCodeButton
        '
        Me.SendCodeButton.Location = New System.Drawing.Point(721, 389)
        Me.SendCodeButton.Name = "SendCodeButton"
        Me.SendCodeButton.Size = New System.Drawing.Size(98, 37)
        Me.SendCodeButton.TabIndex = 3
        Me.SendCodeButton.Text = "Send Code"
        Me.SendCodeButton.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(618, 563)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(302, 27)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Back to Login"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'EnterCodeButton
        '
        Me.EnterCodeButton.Location = New System.Drawing.Point(721, 494)
        Me.EnterCodeButton.Name = "EnterCodeButton"
        Me.EnterCodeButton.Size = New System.Drawing.Size(98, 37)
        Me.EnterCodeButton.TabIndex = 6
        Me.EnterCodeButton.Text = "Enter Code"
        Me.EnterCodeButton.UseVisualStyleBackColor = True
        Me.EnterCodeButton.Visible = False
        '
        'CodeTextBox
        '
        Me.CodeTextBox.Location = New System.Drawing.Point(618, 442)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(302, 25)
        Me.CodeTextBox.TabIndex = 5
        Me.CodeTextBox.Visible = False
        '
        'ForgotPasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.EnterCodeButton)
        Me.Controls.Add(Me.CodeTextBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.SendCodeButton)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ForgotPasswordForm"
        Me.Text = "ForgotPasswordForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents SendCodeButton As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents EnterCodeButton As Button
    Friend WithEvents CodeTextBox As TextBox
End Class
