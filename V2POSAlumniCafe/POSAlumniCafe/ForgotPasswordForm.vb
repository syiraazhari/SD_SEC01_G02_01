Imports System.Net.Mail
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Text
Imports System.Runtime.InteropServices
Imports EASendMail
Imports MySql.Data.MySqlClient


Public Class ForgotPasswordForm

    Public getUserChangePass As MySqlDataReader
    Public checkUser As MySqlDataReader
    Public empIdChangePass As String
    Private Sub SendCodeButton_Click(sender As Object, e As EventArgs) Handles SendCodeButton.Click

        Dim emailEntered As String = EmailTextBox.Text

        checkUser = getDatabaseWhereEmail(emailEntered)

        If (checkUser.Read) Then

            MessageBox.Show(checkUser.GetString("email") + "//" + emailEntered)
            If checkUser.GetString("email") = emailEntered Then

                Try
                    empIdChangePass = checkUser.GetString("empID")
                    Dim p As GoogleOauth = New GoogleOauth()
                    p.DoOauthAndSendEmail(EmailTextBox.Text)

                    EmailTextBox.Visible = False
                    SendCodeButton.Visible = False
                    CodeTextBox.Visible = True
                    EnterCodeButton.Visible = True

                Catch ep As Exception
                    Console.WriteLine(ep.ToString())
                End Try

            Else
                MessageBox.Show("User with this email doesn't exist", "No user", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else
            MessageBox.Show("User with this email doesn't exist", "No user", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub EnterCodeButton_Click(sender As Object, e As EventArgs) Handles EnterCodeButton.Click
        Dim codeEntered As Integer = Integer.Parse(CodeTextBox.Text)

        If codeEntered = oneTimeCode Then
            With SetForgotPasswordForm
                .MdiParent = MDIParent1
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        End If
    End Sub
End Class