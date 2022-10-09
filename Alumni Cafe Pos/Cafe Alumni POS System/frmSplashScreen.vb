Public NotInheritable Class frmSplashScreen
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            GunaProgressBar1.Increment(1)
            If (GunaProgressBar1.Value = 100) Then
                Timer1.Stop()
                Me.Hide()
                frmLogin.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub frmSplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.BackColor = System.Drawing.Color.Transparent
        Label2.BackColor = System.Drawing.Color.Transparent
        Label3.BackColor = System.Drawing.Color.Transparent
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 5
    End Sub
End Class
