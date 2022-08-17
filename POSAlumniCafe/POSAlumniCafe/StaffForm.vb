Public Class StaffForm

    Public Sub StaffForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlDt.Load(getUser())
        EmployeeDataGridView.DataSource = sqlDt
        Dim colUpdate As New DataGridViewButtonColumn

        With colUpdate
            .DataPropertyName = "Update"
            .HeaderText = ""
            .Name = "Update"
            .DefaultCellStyle.NullValue = "Update"
        End With

        EmployeeDataGridView.Columns.Add(colUpdate)

        Dim colDelete As New DataGridViewButtonColumn

        With colDelete
            .DataPropertyName = "Delete"
            .HeaderText = ""
            .Name = "Delete"
            .DefaultCellStyle.NullValue = "Delete"

        End With

        EmployeeDataGridView.Columns.Add(colDelete)

    End Sub

    Private Sub EmployeeDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeeDataGridView.CellClick

        MsgBox(("Row : " + e.RowIndex.ToString & "  Col : ") + e.ColumnIndex.ToString)

    End Sub
End Class