Imports MySql.Data.MySqlClient
Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection()
        passwordTextBox.PasswordChar = Chr(120)
    End Sub

    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        Application.Exit()
    End Sub

    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim userSalt As String = ""
        Dim passHashed As String = ""
        cn.Open()
        cmd = New MySqlCommand("select Salt from tbl_users where username = '" & usernameTextBox.Text & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            userSalt = Read.Item("Salt").ToString
            passHashed = HashPassword(passwordTextBox.Text, userSalt, 10101, 70)
        Else
            MsgBox("Invalid Username or Password", vbOKOnly + vbExclamation)
            usernameTextBox.Clear()
            passwordTextBox.Clear()
            usernameTextBox.Focus()
        End If

        Read.Close()
        cn.Close()

        Dim found As Boolean
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_users where username='" & usernameTextBox.Text & "' and Password='" & passHashed & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            found = True
            StrUserID = Read.Item("UserID").ToString
            UserString = Read.Item("Username").ToString
            PassString = Read.Item("Password").ToString
            SaltString = Read.Item("Salt").ToString
            NameString = Read.Item("Name").ToString
            EmailString = Read.Item("Email").ToString
            RoleString = Read.Item("Role").ToString
            StatusString = Read.Item("Status").ToString
        Else
            found = False
            MsgBox("Invalid Username or Password", vbOKOnly + vbExclamation)
            UserString = ""
            PassString = ""
            SaltString = ""
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
                    Me.Hide()
                End With
                If RoleString = "Administrator" Then
                    With MainWindow
                        .btnMaster.Enabled = True
                        .picUser.Enabled = True
                        .picStaffUser.Visible = False
                        .picUser.Visible = True
                        .picSetting.Enabled = True
                        .btnMaster.BackColor = Color.MediumSlateBlue
                        .btnReport.BackColor = Color.MediumSlateBlue
                        .btnStock.BackColor = Color.MediumSlateBlue
                        .btnTransaction.BackColor = Color.Purple
                        .btnTools.BackColor = Color.Purple
                    End With
                ElseIf RoleString = "Staff" Then
                    With MainWindow
                        .btnMaster.Enabled = True
                        .picStaffUser.Enabled = True
                        .picStaffUser.Visible = True
                        .picUser.Visible = False
                        .picSetting.Enabled = True
                        .btnMaster.BackColor = Color.RoyalBlue
                        .btnReport.BackColor = Color.RoyalBlue
                        .btnStock.BackColor = Color.RoyalBlue
                        .btnTransaction.BackColor = Color.Crimson
                        .btnTools.BackColor = Color.Crimson
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

    Private Sub btnForgotPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnForgotPassword.LinkClicked
        Me.Hide()
        frmVerification.ShowDialog()
    End Sub
End Class