Imports System.Net
Imports System.Net.Mail
Public Class frmVerification
    Dim randomCode As String
    Dim toUser As String
    Private Sub otpBtn_Click(sender As Object, e As EventArgs) Handles otpBtn.Click
        Dim from, pass, messageBody As String
        Dim rand As Random = New Random()
        randomCode = (rand.Next(999999).ToString)
        Dim message As MailMessage = New MailMessage
        toUser = txtEmail.Text
        If ValidateData("select * from tbl_users where Email='" & txtEmail.Text & "'") = True Then
            from = "muhdnik12@gmail.com"
            pass = "cfeiuqsjxcbzptst"
            messageBody = "Your reset code is " + randomCode
            message.To.Add(toUser)
            message.From = New MailAddress(from)
            message.Body = messageBody
            message.Subject = "Password reset code"
            Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com")
            smtp.EnableSsl = True
            smtp.Port = 587
            smtp.DeliveryMethod = smtp.DeliveryMethod.Network
            smtp.Credentials = New NetworkCredential(from, pass)
            verifyBtn.Enabled = True
            Try
                smtp.Send(message)
                MessageBox.Show("Please check your email")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub verifyBtn_Click(sender As Object, e As EventArgs) Handles verifyBtn.Click
        If (txtCode.Text.Equals(randomCode)) Then
            Me.Hide()
            frmForgotPassword.Show()
        Else
            MessageBox.Show("Invalid Code")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        frmLogin.Show()
    End Sub
End Class