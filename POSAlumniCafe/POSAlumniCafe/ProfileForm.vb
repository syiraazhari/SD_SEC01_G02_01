Imports System.ComponentModel

Public Class ProfileForm

    Private Sub ProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        NameLabel.Text = LoginForm.userLogIn.getName()
        UsernameLabel.Text = LoginForm.userLogIn.getUsername()
        RoleLabel.Text = LoginForm.userLogIn.getRole()
        EmpIdLabel.Text = LoginForm.userLogIn.getEmployeeId()
        EmailLabel.Text = LoginForm.userLogIn.getEmail()


    End Sub

    Private Sub EditProfileLabel_Click(sender As Object, e As EventArgs) Handles EditProfileLabel.Click
        Dim updateProfileForm As New UpdateProfileForm
        updateProfileForm.Show()
        updateProfileForm.Select()

    End Sub
End Class