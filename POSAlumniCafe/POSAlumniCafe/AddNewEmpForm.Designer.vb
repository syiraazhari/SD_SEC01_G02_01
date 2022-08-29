<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewEmpForm
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
        Me.Label = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NameNewEmpTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordNewEmpTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameNewEmpTextBox = New System.Windows.Forms.TextBox()
        Me.EmpIdNewEmpTextBox = New System.Windows.Forms.TextBox()
        Me.CancelNewEmpButton = New System.Windows.Forms.Button()
        Me.ResetNewEmpButton = New System.Windows.Forms.Button()
        Me.AddNewEmpButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(232, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(325, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD NEW EMPLOYEE"
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(142, 158)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(45, 17)
        Me.Label.TabIndex = 1
        Me.Label.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(142, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Employee ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(142, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Username"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Password"
        '
        'NameNewEmpTextBox
        '
        Me.NameNewEmpTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameNewEmpTextBox.Location = New System.Drawing.Point(238, 158)
        Me.NameNewEmpTextBox.Name = "NameNewEmpTextBox"
        Me.NameNewEmpTextBox.Size = New System.Drawing.Size(305, 34)
        Me.NameNewEmpTextBox.TabIndex = 5
        '
        'PasswordNewEmpTextBox
        '
        Me.PasswordNewEmpTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordNewEmpTextBox.Location = New System.Drawing.Point(238, 329)
        Me.PasswordNewEmpTextBox.Name = "PasswordNewEmpTextBox"
        Me.PasswordNewEmpTextBox.Size = New System.Drawing.Size(305, 34)
        Me.PasswordNewEmpTextBox.TabIndex = 6
        '
        'UsernameNewEmpTextBox
        '
        Me.UsernameNewEmpTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameNewEmpTextBox.Location = New System.Drawing.Point(238, 269)
        Me.UsernameNewEmpTextBox.Name = "UsernameNewEmpTextBox"
        Me.UsernameNewEmpTextBox.Size = New System.Drawing.Size(305, 34)
        Me.UsernameNewEmpTextBox.TabIndex = 7
        '
        'EmpIdNewEmpTextBox
        '
        Me.EmpIdNewEmpTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpIdNewEmpTextBox.Location = New System.Drawing.Point(238, 212)
        Me.EmpIdNewEmpTextBox.Name = "EmpIdNewEmpTextBox"
        Me.EmpIdNewEmpTextBox.Size = New System.Drawing.Size(305, 34)
        Me.EmpIdNewEmpTextBox.TabIndex = 8
        '
        'CancelNewEmpButton
        '
        Me.CancelNewEmpButton.Location = New System.Drawing.Point(165, 493)
        Me.CancelNewEmpButton.Name = "CancelNewEmpButton"
        Me.CancelNewEmpButton.Size = New System.Drawing.Size(100, 100)
        Me.CancelNewEmpButton.TabIndex = 9
        Me.CancelNewEmpButton.Text = "Cancel"
        Me.CancelNewEmpButton.UseVisualStyleBackColor = True
        '
        'ResetNewEmpButton
        '
        Me.ResetNewEmpButton.Location = New System.Drawing.Point(335, 493)
        Me.ResetNewEmpButton.Name = "ResetNewEmpButton"
        Me.ResetNewEmpButton.Size = New System.Drawing.Size(100, 100)
        Me.ResetNewEmpButton.TabIndex = 10
        Me.ResetNewEmpButton.Text = "Reset"
        Me.ResetNewEmpButton.UseVisualStyleBackColor = True
        '
        'AddNewEmpButton
        '
        Me.AddNewEmpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AddNewEmpButton.Location = New System.Drawing.Point(502, 493)
        Me.AddNewEmpButton.Name = "AddNewEmpButton"
        Me.AddNewEmpButton.Size = New System.Drawing.Size(100, 100)
        Me.AddNewEmpButton.TabIndex = 11
        Me.AddNewEmpButton.Text = "Add"
        Me.AddNewEmpButton.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(235, 387)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 54)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 397)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Role"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(22, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 21)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Staff"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(174, 21)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(68, 21)
        Me.RadioButton2.TabIndex = 15
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Admin"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'AddNewEmpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(800, 642)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AddNewEmpButton)
        Me.Controls.Add(Me.ResetNewEmpButton)
        Me.Controls.Add(Me.CancelNewEmpButton)
        Me.Controls.Add(Me.EmpIdNewEmpTextBox)
        Me.Controls.Add(Me.UsernameNewEmpTextBox)
        Me.Controls.Add(Me.PasswordNewEmpTextBox)
        Me.Controls.Add(Me.NameNewEmpTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AddNewEmpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddNewEmpForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NameNewEmpTextBox As TextBox
    Friend WithEvents PasswordNewEmpTextBox As TextBox
    Friend WithEvents UsernameNewEmpTextBox As TextBox
    Friend WithEvents EmpIdNewEmpTextBox As TextBox
    Friend WithEvents CancelNewEmpButton As Button
    Friend WithEvents ResetNewEmpButton As Button
    Friend WithEvents AddNewEmpButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label2 As Label
End Class
