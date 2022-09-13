Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32


Public Class LoginForm
    Public userLogIn As LogInUserClass = New LogInUserClass()

    Private Sub ConfirmLoginButton_Click(sender As Object, e As EventArgs) Handles ConfirmLoginButton.Click
        loginStatus = checkUserLogin(UsernameTextBox.Text, PassswordTextBox.Text)
        If loginStatus = True Then
            Dim database As MySqlDataReader = getDatabase(UsernameTextBox.Text)
            'An SqlDataReader returns data a row at a time, and it only knows when to "change the row" when you explicitly tell it to do that by calling Read
            'The Read method fetches the next row, and returns true if one is available.
            'Reference: https://www.codeproject.com/Questions/1210890/Invalid-attempt-to-access-a-field-before-calling-r
            If (database.Read) Then
                'COULD IMPROVE: PASS OBJECT ONLY INTO THE LogInUserClass
                userLogIn.setNewUserLogIn(database.GetString("name"), database.GetString("username"), database.GetString("empID"), database.GetString("email"), database.GetString("password"), database.GetString("role"))

                MessageBox.Show("User valid")
                If database.GetString("role") = "admin" Then
                    MDIParent1.PaymentToolStripButton.Visible = True
                    MDIParent1.ReportToolStripButton.Visible = True
                    MDIParent1.StaffToolStripButton.Visible = True
                    MDIParent1.InventoryToolStripButton.Visible = True
                    MDIParent1.ProfileToolStripButton.Visible = True
                    MDIParent1.SettingToolStripButton.Visible = True

                    MDIParent1.LoginStripButton.Visible = False
                ElseIf database.GetString("role") = "staff" Then
                    MDIParent1.PaymentToolStripButton.Visible = True
                    MDIParent1.InventoryToolStripButton.Visible = True
                    MDIParent1.ProfileToolStripButton.Visible = True
                    MDIParent1.SettingToolStripButton.Visible = True

                    MDIParent1.LoginStripButton.Visible = False
                End If
                Hide()
                sqlRd.Close()
                sqlConn.Close()
            End If


            'sqlRd.Close()
            'sqlConn.Close()
            'MessageBox.Show("User valid")
            'MDIParent1.PaymentToolStripButton.Visible = True
            'MDIParent1.LoginStripButton.Visible = False

        Else
            MessageBox.Show("User not found")
        End If

        sqlDt.Load(getUser())
        DataGridView1.DataSource = sqlDt
        sqlConn.Close()
    End Sub

    Private Sub ForgotPasswordLabel_Click(sender As Object, e As EventArgs) Handles ForgotPasswordLabel.Click
        With ForgotPasswordForm
            .MdiParent = MDIParent1
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
End Class
