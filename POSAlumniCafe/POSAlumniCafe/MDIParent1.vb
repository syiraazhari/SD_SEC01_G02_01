Imports System.Windows.Forms

Public Class MDIParent1


    Private Sub LoginStripButton_Click(sender As Object, e As EventArgs) Handles LoginStripButton.Click
        LoginForm.MdiParent = Me
        LoginForm.WindowState = FormWindowState.Maximized
        LoginForm.Show()
    End Sub

    Private Sub ExitToolStripButton_Click(sender As Object, e As EventArgs) Handles ExitToolStripButton.Click
        Dim iExit As DialogResult
        If loginStatus = True Then
            iExit = MessageBox.Show("You will be logout from your account" + vbCrLf + "Confirm if you want to exit?", "Exit Alumni Cafe Pos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            iExit = MessageBox.Show("Confirm if you want to exit?", "Exit Alumni Cafe Pos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If


        If iExit = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub StaffToolStripButton_Click(sender As Object, e As EventArgs) Handles StaffToolStripButton.Click
        With StaffForm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With

    End Sub

    Private Sub ProfileToolStripButton_Click(sender As Object, e As EventArgs) Handles ProfileToolStripButton.Click
        With ProfileForm
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub


End Class
