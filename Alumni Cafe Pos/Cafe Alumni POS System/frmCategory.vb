Imports MySql.Data.MySqlClient

Public Class frmCategory
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            cn.Open()
            cmd = New MySqlCommand("insert into tbl_category(Category) values('" & txtCategory.Text & "')", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Category has been successfully saved", vbInformation)
            Me.Close()
            txtCategory.Clear()
            With frmProduct
                .LoadCategory()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            cn.Close()
        End Try
    End Sub
End Class