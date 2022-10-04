Imports MySql.Data.MySqlClient
Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        passwordTextBox.PasswordChar = Chr(120)
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim found As Boolean
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_users where username='" & usernameTextBox.Text & "' and Password='" & passwordTextBox.Text & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            found = True
            StrUserID = Read.Item("UserID").ToString
            UserString = Read.Item("Username").ToString
            PassString = Read.Item("Password").ToString
            NameString = Read.Item("Name").ToString
            EmailString = Read.Item("Email").ToString
            RoleString = Read.Item("Role").ToString
            StatusString = Read.Item("Status").ToString
        Else
            found = False
            MsgBox("Invalid Username or Password", vbOKOnly + vbExclamation)
            UserString = ""
            PassString = ""
            NameString = ""
            EmailString = ""
            RoleString = ""
            StatusString = ""
        End If
        Read.Close()
        cn.Close()

        If found = True Then
            If StatusString.Trim = "Active" Then
                With MainWindow
                    .Show()
                    .userLabel.Text = NameString
                    .usertypeLabel.Text = RoleString
                    Me.Hide()
                End With
                If RoleString = "Administrator" Then
                    With MainWindow
                        .btnMaster.Enabled = True
                        .picUser.Enabled = True
                        .picStaffUser.Visible = False
                        .picUser.Visible = True
                        .picSetting.Enabled = True
                    End With
                ElseIf RoleString = "Staff" Then
                    With MainWindow
                        .btnMaster.Enabled = False
                        .picStaffUser.Enabled = True
                        .picStaffUser.Visible = True
                        .picUser.Visible = False
                        .picSetting.Enabled = True
                    End With
                End If
            Else
                MsgBox("Your account has been deactivated Please contact administrator", vbExclamation)
                Return
                usernameTextBox.Clear()
                passwordTextBox.Clear()
            End If

        Else
            MsgBox("Invalid Username or Password", vbOKOnly + vbExclamation)
            usernameTextBox.Clear()
            passwordTextBox.Clear()
            usernameTextBox.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub btnForgotPassword_Click(sender As Object, e As EventArgs) Handles btnForgotPassword.Click
        frmVerification.ShowDialog()
    End Sub
End Class