Module profileManager

    Public Sub loadUserProfile()
        ProfileForm.NameLabel.Text = LoginForm.userLogIn.getName()
        ProfileForm.UsernameLabel.Text = LoginForm.userLogIn.getUsername()
        ProfileForm.RoleLabel.Text = LoginForm.userLogIn.getRole()
        ProfileForm.EmpIdLabel.Text = LoginForm.userLogIn.getEmployeeId()
        ProfileForm.EmailLabel.Text = LoginForm.userLogIn.getEmail()
    End Sub

End Module
