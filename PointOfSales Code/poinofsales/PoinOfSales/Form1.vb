Public Class Form1
    Private Sub tsPOS_Click(sender As Object, e As EventArgs) Handles tsPOS.Click
        closeChildForm()
        anyfrm(frmPOS)
    End Sub

    Private Sub tsStocks_Click(sender As Object, e As EventArgs) Handles tsStocks.Click
        closeChildForm()
        anyfrm(frmListStocks)
    End Sub

    Private Sub tsCategory_Click(sender As Object, e As EventArgs) Handles tsCategory.Click
        closeChildForm()
        anyfrm(frmCategory)
    End Sub

    Private Sub tsUser_Click(sender As Object, e As EventArgs) Handles tsUser.Click
        closeChildForm()
        anyfrm(frmUser)
    End Sub

    Private Sub tsReport_Click(sender As Object, e As EventArgs) Handles tsReport.Click
        closeChildForm()
        anyfrm(frmReport)
    End Sub

    Private Sub tsExit_Click(sender As Object, e As EventArgs) Handles tsExit.Click
        Me.Close()
    End Sub

    Private Sub tsLogin_Click(sender As Object, e As EventArgs) Handles tsLogin.Click
        If tsLogin.Text = "Login" Then
            LoginForm1.Show()
        Else
            tsLogin.Text = "Login"
            statsloginname.Text = "User default"
            Visible_Admin("False")

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Visible_Admin("False")
    End Sub
End Class
