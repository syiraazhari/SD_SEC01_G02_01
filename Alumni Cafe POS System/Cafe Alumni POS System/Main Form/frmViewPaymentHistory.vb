Imports MySql.Data.MySqlClient
Public Class frmViewPaymentHistory
    Sub LoadPaymentHistory()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        Try
            cn.Open()
            cmd = New MySqlCommand("Select * From tbl_sales", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("SalesID").ToString, Read.Item("InvoiceNo").ToString, Read.Item("SDate").ToString, Read.Item("STime").ToString, Read.Item("TableName").ToString, Read.Item("Description").ToString, Read.Item("Amount").ToString)
            End While
            Read.Close()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmViewPaymentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPaymentHistory()
    End Sub
End Class