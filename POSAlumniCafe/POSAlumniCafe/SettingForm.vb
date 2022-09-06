Public Class SettingForm


    Private Sub SettingPanel_MouseEnter(sender As Object, e As EventArgs) Handles PasswordPanel.MouseEnter
        PasswordPanel.BackColor = Color.FromArgb(239, 208, 158)

    End Sub

    Private Sub SettingPanel_MouseLeave(sender As Object, e As EventArgs) Handles PasswordPanel.MouseLeave
        PasswordPanel.BackColor = Color.WhiteSmoke


    End Sub

    Private Sub PasswordPanel_Click(sender As Object, e As EventArgs) Handles PasswordPanel.Click
        With SettingPasswordForm
            .MdiParent = MDIParent1
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub
End Class