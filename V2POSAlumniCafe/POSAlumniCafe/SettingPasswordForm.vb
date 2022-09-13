Imports MySql.Data.MySqlClient
Public Class SettingPasswordForm

    Dim sqlQuery As String
    Private Sub ContinueButton_Click(sender As Object, e As EventArgs) Handles ContinueButton.Click
        Dim user As MySqlDataReader = getDatabase(LoginForm.userLogIn.getUsername)

        If (user.Read) Then
            If (user.GetValue(3) = CurrentPassTextBox.Text) Then
                MessageBox.Show("Password: true")
                CurrentPassLabel.Visible = False
                CurrentPassTextBox.Visible = False
                ContinueButton.Visible = False
                NewPassLabel.Visible = True
                NewPassTextBox.Visible = True
                ReenterPassLabel.Visible = True
                ReenterPassTextBox.Visible = True
                ConfirmButton.Visible = True
            Else
                MessageBox.Show("You enter the wrong password")
                CurrentPassTextBox.Focus()
                CurrentPassTextBox.Clear()
            End If
        End If

        sqlConn.Close()

    End Sub

    Private Sub ConfirmButton_Click(sender As Object, e As EventArgs) Handles ConfirmButton.Click

        Dim newPassword As String = NewPassTextBox.Text
        Dim reEnterPassword As String = ReenterPassTextBox.Text
        Dim currentPassword As String = LoginForm.userLogIn.getPassword
        Dim empId As String = LoginForm.userLogIn.getEmployeeId

        If newPassword = reEnterPassword Then
            If (newPassword = currentPassword) Then
                MessageBox.Show("You can't enter the same password as the old one")
                NewPassTextBox.Focus()
                NewPassTextBox.Clear()
            Else
                updatePassword(newPassword, empId)
                MessageBox.Show("Successfully change your password")
            End If
        Else
            MessageBox.Show("You re-enter the wrong password")
            ReenterPassTextBox.Focus()
            ReenterPassTextBox.Clear()
        End If


    End Sub
End Class