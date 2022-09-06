Public Class UpdateProfileForm
    Private Sub UpdateProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UpdateImagePictureBox =  LoginForm.userLogIn
        UpdateNameTextBox.Text = LoginForm.userLogIn.getName()
        UpdateEmpIdTextBox.Text = LoginForm.userLogIn.getEmployeeId()
        UpdateUsernameTextBox.Text = LoginForm.userLogIn.getUsername()
        UpdateEmailTextBox.Text = LoginForm.userLogIn.getEmail()
        UpdatePasswordTextBox.Text = LoginForm.userLogIn.getPassword()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles DoneUpdateButton.Click

        Dim uName As String = UpdateNameTextBox.Text
        Dim uUsername As String = UpdateUsernameTextBox.Text
        Dim uEmail As String = UpdateEmailTextBox.Text
        Dim uPassword As String = UpdatePasswordTextBox.Text
        Dim empID As String = LoginForm.userLogIn.getEmployeeId()


        Try
            updateUserProfile(uName, uUsername, uEmail, uPassword, empID)
            MessageBox.Show("Success to update profile")

        Catch ex As Exception
            MessageBox.Show("Fail to update profile")
        End Try



        'If updateDatabase("user", "name = '" & UpdateNameTextBox.Text & "', username = '" & UpdateUsernameTextBox.Text & "', email = '" & UpdateEmailTextBox.Text & "'", " empID = '" & LoginForm.userLogIn.getEmployeeId & "'") Then
        '    MessageBox.Show("Your profile has been updated")
        '    Me.Close()
        'Else
        '    MessageBox.Show("Fail to update your profile")
        '    Me.Close()
        'End If

        'updateTable()


    End Sub
End Class