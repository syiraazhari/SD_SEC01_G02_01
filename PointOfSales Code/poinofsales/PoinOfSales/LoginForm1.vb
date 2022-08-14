Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        sql = "SELECT * FROM `tblemployee` WHERE `USERNAME` ='" & UsernameTextBox.Text & "' and `PASSWRD` = sha1('" & PasswordTextBox.Text & "')"
        janobefindthis(sql)

        If GetNumRows() = 1 Then
            LoadSingleResult("login")
            ' MsgBox(fullname)
            Form1.statsloginname.Text = fullname
            Form1.tsLogin.Text = "Logout"

            If usertype = "Administrator" Then
                Visible_Admin(True)
            Else
                Visible_Cashier(True)
            End If
        Else
            MsgBox("Username or Password not registered!")
        End If


        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click

    End Sub
End Class
