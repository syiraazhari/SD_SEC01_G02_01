Imports MySql.Data.MySqlClient
Public Class frmChangePassword
    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtOldPass.PasswordChar = Chr(120)
        txtNewPass.PasswordChar = Chr(120)
        txtConfirmPass.PasswordChar = Chr(120)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtOldPass) = True Then Return
        If check_empty(txtNewPass) = True Then Return
        If check_empty(txtConfirmPass) = True Then Return

        Dim checkPassHashed As String = HashPassword(txtOldPass.Text, SaltString, 10101, 70)

        If PassString <> checkPassHashed Then
            MsgBox("Old Password doesn't match", vbExclamation)
            Return
        End If

        If txtNewPass.Text <> txtConfirmPass.Text Then
            MsgBox("Confirm Password doesn't match", vbExclamation)
            Return
        End If

        Dim newPassHashed As String = HashPassword(txtNewPass.Text, SaltString, 10101, 70)

        Try
            cn.Open()
            cmd = New MySqlCommand("update tbl_users set Password=@Pass where UserID='" & StrUserID & "'", cn)
            cmd.Parameters.AddWithValue("@Pass", newPassHashed)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("New Password has been saved", vbInformation)
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Guna2ImageButton1_Click(sender As Object, e As EventArgs) Handles Guna2ImageButton1.Click
        Me.Dispose()
    End Sub
End Class