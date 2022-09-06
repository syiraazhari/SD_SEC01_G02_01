<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateProfileForm
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
        Me.UpdateImagePictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DoneUpdateButton = New System.Windows.Forms.Button()
        Me.UpdateEmailTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.UpdateUsernameTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UpdateEmpIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UpdateNameTextBox = New System.Windows.Forms.TextBox()
        Me.UpdatePasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.UpdateImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UpdateImagePictureBox
        '
        Me.UpdateImagePictureBox.Location = New System.Drawing.Point(80, 52)
        Me.UpdateImagePictureBox.Name = "UpdateImagePictureBox"
        Me.UpdateImagePictureBox.Size = New System.Drawing.Size(224, 304)
        Me.UpdateImagePictureBox.TabIndex = 0
        Me.UpdateImagePictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UpdatePasswordTextBox)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.DoneUpdateButton)
        Me.Panel1.Controls.Add(Me.UpdateEmailTextBox)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.UpdateUsernameTextBox)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.UpdateEmpIdTextBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.UpdateNameTextBox)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(394, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 606)
        Me.Panel1.TabIndex = 2
        '
        'DoneUpdateButton
        '
        Me.DoneUpdateButton.BackColor = System.Drawing.SystemColors.Highlight
        Me.DoneUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DoneUpdateButton.Location = New System.Drawing.Point(53, 543)
        Me.DoneUpdateButton.Name = "DoneUpdateButton"
        Me.DoneUpdateButton.Size = New System.Drawing.Size(119, 42)
        Me.DoneUpdateButton.TabIndex = 3
        Me.DoneUpdateButton.Text = "Done"
        Me.DoneUpdateButton.UseVisualStyleBackColor = False
        '
        'UpdateEmailTextBox
        '
        Me.UpdateEmailTextBox.BackColor = System.Drawing.Color.Linen
        Me.UpdateEmailTextBox.Location = New System.Drawing.Point(53, 383)
        Me.UpdateEmailTextBox.Name = "UpdateEmailTextBox"
        Me.UpdateEmailTextBox.Size = New System.Drawing.Size(360, 34)
        Me.UpdateEmailTextBox.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 29)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email"
        '
        'UpdateUsernameTextBox
        '
        Me.UpdateUsernameTextBox.BackColor = System.Drawing.Color.Linen
        Me.UpdateUsernameTextBox.Location = New System.Drawing.Point(53, 279)
        Me.UpdateUsernameTextBox.Name = "UpdateUsernameTextBox"
        Me.UpdateUsernameTextBox.Size = New System.Drawing.Size(360, 34)
        Me.UpdateUsernameTextBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Username"
        '
        'UpdateEmpIdTextBox
        '
        Me.UpdateEmpIdTextBox.BackColor = System.Drawing.Color.Linen
        Me.UpdateEmpIdTextBox.Location = New System.Drawing.Point(53, 172)
        Me.UpdateEmpIdTextBox.Name = "UpdateEmpIdTextBox"
        Me.UpdateEmpIdTextBox.ReadOnly = True
        Me.UpdateEmpIdTextBox.Size = New System.Drawing.Size(360, 34)
        Me.UpdateEmpIdTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Employee ID"
        '
        'UpdateNameTextBox
        '
        Me.UpdateNameTextBox.BackColor = System.Drawing.Color.Linen
        Me.UpdateNameTextBox.Location = New System.Drawing.Point(53, 65)
        Me.UpdateNameTextBox.Name = "UpdateNameTextBox"
        Me.UpdateNameTextBox.Size = New System.Drawing.Size(360, 34)
        Me.UpdateNameTextBox.TabIndex = 2
        '
        'UpdatePasswordTextBox
        '
        Me.UpdatePasswordTextBox.BackColor = System.Drawing.Color.Linen
        Me.UpdatePasswordTextBox.Location = New System.Drawing.Point(53, 475)
        Me.UpdatePasswordTextBox.Name = "UpdatePasswordTextBox"
        Me.UpdatePasswordTextBox.Size = New System.Drawing.Size(360, 34)
        Me.UpdatePasswordTextBox.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(48, 443)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 29)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Password"
        '
        'UpdateProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(1352, 694)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.UpdateImagePictureBox)
        Me.Name = "UpdateProfileForm"
        Me.Text = "UpdateProfile"
        CType(Me.UpdateImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UpdateImagePictureBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UpdateEmpIdTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents UpdateNameTextBox As TextBox
    Friend WithEvents UpdateEmailTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents UpdateUsernameTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DoneUpdateButton As Button
    Friend WithEvents UpdatePasswordTextBox As TextBox
    Friend WithEvents Label5 As Label
End Class
