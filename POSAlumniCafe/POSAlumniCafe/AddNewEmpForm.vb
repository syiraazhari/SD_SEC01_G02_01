Public Class AddNewEmpForm
    Private Sub AddNewEmpButton_Click(sender As Object, e As EventArgs) Handles AddNewEmpButton.Click
        Dim name = NameNewEmpTextBox.Text
        Dim empId = EmpIdNewEmpTextBox.Text
        Dim username = UsernameNewEmpTextBox.Text
        Dim password = PasswordNewEmpTextBox.Text
        Dim role = "staff"
        addNewEmployee(empId, name, username, password, role)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub
End Class