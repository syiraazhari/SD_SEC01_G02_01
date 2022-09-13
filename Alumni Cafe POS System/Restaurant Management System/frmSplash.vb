Imports System.Data.OleDb
Public Class frmSplash

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            ProgressBar2.Increment(1)
            If (ProgressBar2.Value = 100) Then
                Timer2.Stop()
                Me.Hide()
                frmLogin.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
        Timer2.Start()
        Timer2.Interval = 10
    End Sub

End Class