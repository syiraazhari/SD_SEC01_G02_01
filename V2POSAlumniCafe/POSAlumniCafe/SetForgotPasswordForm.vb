Public Class SetForgotPasswordForm
    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click
        Dim newPassword As String = NewPassTextBox.Text
        Dim reEnterPassword As String = ReenterPassTextBox.Text
        'Dim currentPassword As String = LoginForm.userLogIn.getPassword
        Dim empId As String = ForgotPasswordForm.empIdChangePass



        If newPassword = reEnterPassword Then
            sqlConn.Close()
            updatePassword(newPassword, empId)
            MessageBox.Show("Successfully change your password")
            Hide()

            With LoginForm
                .MdiParent = MDIParent1
                .WindowState = FormWindowState.Maximized
                .Show()
            End With


        Else
            MessageBox.Show("You re-enter the wrong password")
            ReenterPassTextBox.Focus()
            ReenterPassTextBox.Clear()
        End If


    End Sub
End Class