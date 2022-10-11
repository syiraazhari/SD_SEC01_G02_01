Imports MySql.Data.MySqlClient
Public Class frmUpdateStock
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cn.Open()
        cmd = New MySqlCommand("update tbl_stock set Description=@Description,StockAvailable=@StockAvailable where PID='" & lblPID.Text & "'", cn)
        With cmd
            .Parameters.AddWithValue("@Description", txtDescription.Text)
            .Parameters.AddWithValue("@StockAvailable", txtStockInHand.Text)
            .Parameters.AddWithValue("@PID", lblPID.Text)
            .ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("Stock details update successfully", vbInformation)
        Me.Dispose()
        With frmStockInHand
            .LoadStock()
        End With
    End Sub
End Class