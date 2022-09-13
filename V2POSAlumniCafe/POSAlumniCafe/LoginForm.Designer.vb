<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ForgotPasswordLabel = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ConfirmLoginButton = New System.Windows.Forms.Button()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PassswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ForgotPasswordLabel)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.ConfirmLoginButton)
        Me.GroupBox1.Controls.Add(Me.UsernameTextBox)
        Me.GroupBox1.Controls.Add(Me.PassswordTextBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft YaHei", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(2000, 2000)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Login"
        '
        'ForgotPasswordLabel
        '
        Me.ForgotPasswordLabel.Location = New System.Drawing.Point(682, 361)
        Me.ForgotPasswordLabel.Name = "ForgotPasswordLabel"
        Me.ForgotPasswordLabel.Size = New System.Drawing.Size(209, 77)
        Me.ForgotPasswordLabel.TabIndex = 8
        Me.ForgotPasswordLabel.Text = "Forgot Password"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(39, 361)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(602, 245)
        Me.DataGridView1.TabIndex = 7
        Me.DataGridView1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 35
        Me.ListBox1.Location = New System.Drawing.Point(25, 170)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(165, 144)
        Me.ListBox1.TabIndex = 6
        Me.ListBox1.Visible = False
        '
        'ConfirmLoginButton
        '
        Me.ConfirmLoginButton.Location = New System.Drawing.Point(688, 469)
        Me.ConfirmLoginButton.Name = "ConfirmLoginButton"
        Me.ConfirmLoginButton.Size = New System.Drawing.Size(203, 45)
        Me.ConfirmLoginButton.TabIndex = 5
        Me.ConfirmLoginButton.Text = "Login"
        Me.ConfirmLoginButton.UseVisualStyleBackColor = True
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Location = New System.Drawing.Point(522, 169)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(369, 43)
        Me.UsernameTextBox.TabIndex = 4
        '
        'PassswordTextBox
        '
        Me.PassswordTextBox.Location = New System.Drawing.Point(522, 288)
        Me.PassswordTextBox.Name = "PassswordTextBox"
        Me.PassswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassswordTextBox.Size = New System.Drawing.Size(369, 43)
        Me.PassswordTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(317, 295)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 36)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(317, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 683)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ConfirmLoginButton As Button
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PassswordTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ForgotPasswordLabel As Label
End Class
