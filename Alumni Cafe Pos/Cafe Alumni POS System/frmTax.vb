Imports MySql.Data.MySqlClient
Public Class frmTax

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtTax) = True Then Return

        cn.Open()
        cmd = New MySqlCommand("select count(*) from tbl_tax", cn)
        Dim icount As Integer = CInt(cmd.ExecuteScalar)
        cn.Close()

        If icount > 0 Then
            cn.Open()
            cmd = New MySqlCommand("update tbl_tax set Tax='" & CDbl(txtTax.Text) & "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Tax has been successfully saved", vbInformation)
        Else
            cn.Open()
            cmd = New MySqlCommand("insert into tbl_tax (Tax) values('" & CDbl(txtTax.Text) & "')", cn)
            MsgBox("Tax has been successfully saved", vbInformation)
            cmd.ExecuteNonQuery()
            cn.Close()
        End If
    End Sub

    Private Sub frmTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTax.Text = Gettax()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class