﻿Imports MySql.Data.MySqlClient
Public Class frmForgotPassword
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtNewPass) = True Then Return
        If check_empty(txtConfirmPass) = True Then Return

        If txtNewPass.Text <> txtConfirmPass.Text Then
            MsgBox("Confirm Password doesn't match", vbExclamation)
            Return
        End If

        Try
            cn.Open()
            cmd = New MySqlCommand("update tbl_users set Password=@Pass where UserID='" & StrUserID & "'", cn)
            cmd.Parameters.AddWithValue("@Pass", txtNewPass.Text)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("New Password has been saved", vbInformation)
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmForgotPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNewPass.PasswordChar = Chr(120)
        txtConfirmPass.PasswordChar = Chr(120)
    End Sub
End Class