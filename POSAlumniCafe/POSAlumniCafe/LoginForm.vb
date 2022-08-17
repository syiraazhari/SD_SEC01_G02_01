Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32


Public Class LoginForm


    Private Sub ConfirmLoginButton_Click(sender As Object, e As EventArgs) Handles ConfirmLoginButton.Click
        loginStatus = checkUserLogin(UsernameTextBox.Text, PassswordTextBox.Text)
        If loginStatus = True Then
            MessageBox.Show("User valid")
            MDIParent1.PaymentToolStripButton.Visible = True
        End If
    End Sub
End Class
