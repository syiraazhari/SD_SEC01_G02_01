<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StaffForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.EmployeeDataGridView = New System.Windows.Forms.DataGridView()
        Me.DeleteEmpButton = New System.Windows.Forms.Button()
        Me.UpdateEmpButton = New System.Windows.Forms.Button()
        Me.AddNewEmpButton = New System.Windows.Forms.Button()
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmployeeDataGridView
        '
        Me.EmployeeDataGridView.AllowUserToOrderColumns = True
        Me.EmployeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.EmployeeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.EmployeeDataGridView.BackgroundColor = System.Drawing.Color.Beige
        Me.EmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EmployeeDataGridView.Location = New System.Drawing.Point(12, 12)
        Me.EmployeeDataGridView.Name = "EmployeeDataGridView"
        Me.EmployeeDataGridView.RowHeadersWidth = 51
        Me.EmployeeDataGridView.RowTemplate.Height = 24
        Me.EmployeeDataGridView.Size = New System.Drawing.Size(1075, 491)
        Me.EmployeeDataGridView.TabIndex = 0
        '
        'DeleteEmpButton
        '
        Me.DeleteEmpButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DeleteEmpButton.Location = New System.Drawing.Point(1208, 12)
        Me.DeleteEmpButton.Name = "DeleteEmpButton"
        Me.DeleteEmpButton.Size = New System.Drawing.Size(217, 82)
        Me.DeleteEmpButton.TabIndex = 1
        Me.DeleteEmpButton.Text = "Delete"
        Me.DeleteEmpButton.UseVisualStyleBackColor = False
        '
        'UpdateEmpButton
        '
        Me.UpdateEmpButton.BackColor = System.Drawing.Color.White
        Me.UpdateEmpButton.Location = New System.Drawing.Point(1208, 118)
        Me.UpdateEmpButton.Name = "UpdateEmpButton"
        Me.UpdateEmpButton.Size = New System.Drawing.Size(217, 78)
        Me.UpdateEmpButton.TabIndex = 2
        Me.UpdateEmpButton.Text = "Update"
        Me.UpdateEmpButton.UseVisualStyleBackColor = False
        '
        'AddNewEmpButton
        '
        Me.AddNewEmpButton.BackColor = System.Drawing.Color.White
        Me.AddNewEmpButton.Location = New System.Drawing.Point(1208, 212)
        Me.AddNewEmpButton.Name = "AddNewEmpButton"
        Me.AddNewEmpButton.Size = New System.Drawing.Size(217, 90)
        Me.AddNewEmpButton.TabIndex = 3
        Me.AddNewEmpButton.Text = "Add New Employee"
        Me.AddNewEmpButton.UseVisualStyleBackColor = False
        '
        'StaffForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1924, 853)
        Me.Controls.Add(Me.AddNewEmpButton)
        Me.Controls.Add(Me.UpdateEmpButton)
        Me.Controls.Add(Me.DeleteEmpButton)
        Me.Controls.Add(Me.EmployeeDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "StaffForm"
        Me.Text = "StaffForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EmployeeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents EmployeeDataGridView As DataGridView
    Friend WithEvents DeleteEmpButton As Button
    Friend WithEvents UpdateEmpButton As Button
    Friend WithEvents AddNewEmpButton As Button
End Class
