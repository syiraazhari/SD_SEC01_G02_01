<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.RoleLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EmpIdLabel = New System.Windows.Forms.Label()
        Me.ProfilePictureBox = New System.Windows.Forms.PictureBox()
        Me.EmailLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EditProfileLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.ProfilePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-6, 273)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1942, 789)
        Me.Panel1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(430, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(151, 29)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Performance"
        '
        'UsernameLabel
        '
        Me.UsernameLabel.AutoSize = True
        Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(416, 104)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(44, 25)
        Me.UsernameLabel.TabIndex = 3
        Me.UsernameLabel.Text = "null"
        '
        'RoleLabel
        '
        Me.RoleLabel.AutoSize = True
        Me.RoleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoleLabel.Location = New System.Drawing.Point(424, 166)
        Me.RoleLabel.Name = "RoleLabel"
        Me.RoleLabel.Size = New System.Drawing.Size(51, 29)
        Me.RoleLabel.TabIndex = 6
        Me.RoleLabel.Text = "null"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(622, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 25)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Employee ID"
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(403, 51)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(84, 44)
        Me.NameLabel.TabIndex = 2
        Me.NameLabel.Text = "null"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(424, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Role"
        '
        'EmpIdLabel
        '
        Me.EmpIdLabel.AutoSize = True
        Me.EmpIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpIdLabel.Location = New System.Drawing.Point(622, 166)
        Me.EmpIdLabel.Name = "EmpIdLabel"
        Me.EmpIdLabel.Size = New System.Drawing.Size(51, 29)
        Me.EmpIdLabel.TabIndex = 7
        Me.EmpIdLabel.Text = "null"
        '
        'ProfilePictureBox
        '
        Me.ProfilePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ProfilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ProfilePictureBox.Image = CType(resources.GetObject("ProfilePictureBox.Image"), System.Drawing.Image)
        Me.ProfilePictureBox.Location = New System.Drawing.Point(45, 26)
        Me.ProfilePictureBox.Name = "ProfilePictureBox"
        Me.ProfilePictureBox.Size = New System.Drawing.Size(352, 342)
        Me.ProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ProfilePictureBox.TabIndex = 0
        Me.ProfilePictureBox.TabStop = False
        '
        'EmailLabel
        '
        Me.EmailLabel.AutoSize = True
        Me.EmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLabel.Location = New System.Drawing.Point(866, 166)
        Me.EmailLabel.Name = "EmailLabel"
        Me.EmailLabel.Size = New System.Drawing.Size(51, 29)
        Me.EmailLabel.TabIndex = 11
        Me.EmailLabel.Text = "null"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(866, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 25)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Email"
        '
        'EditProfileLabel
        '
        Me.EditProfileLabel.AutoSize = True
        Me.EditProfileLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditProfileLabel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.EditProfileLabel.Location = New System.Drawing.Point(426, 229)
        Me.EditProfileLabel.Name = "EditProfileLabel"
        Me.EditProfileLabel.Size = New System.Drawing.Size(102, 25)
        Me.EditProfileLabel.TabIndex = 9
        Me.EditProfileLabel.Text = "Edit profile"
        '
        'ProfileForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(158, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.EmailLabel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.EditProfileLabel)
        Me.Controls.Add(Me.ProfilePictureBox)
        Me.Controls.Add(Me.EmpIdLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RoleLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Name = "ProfileForm"
        Me.Text = "Profile"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ProfilePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents RoleLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NameLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EmpIdLabel As Label
    Friend WithEvents ProfilePictureBox As PictureBox
    Friend WithEvents EmailLabel As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents EditProfileLabel As Label
End Class
