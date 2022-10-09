
Imports MySql.Data.MySqlClient
Public Class frmStockOut
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim Date1 As String = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim Date2 As String = Me.DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim i As Integer
        Try
            Me.Guna2DataGridView1.Rows.Clear()
            cn.Open()
            cmd = New MySqlCommand("select StockID, SDate,PID, Description, Category, sum(Qty) as Qty from tbl_stockout where SDate between '" & Date1 & "' and '" & Date2 & "' group by SDate, PID, Qty order by SDate desc", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("StockID").ToString, Format(CDate(Read.Item("SDate").ToString), "yyyy-MM-dd"), Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("Qty").ToString)
            End While
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim DT As New DataTable
        Dim Cr As New crStockOut

        DT.Columns.Add("SDate")
        DT.Columns.Add("PID")
        DT.Columns.Add("Description")
        DT.Columns.Add("Category")
        DT.Columns.Add("Qty")

        For Each dr As DataGridViewRow In Me.Guna2DataGridView1.Rows
            DT.Rows.Add(dr.Cells(2).Value, dr.Cells(3).Value, dr.Cells(4).Value, dr.Cells(5).Value, dr.Cells(6).Value)
        Next

        Cr.SetDataSource(DT)
        With frmPrint
            .CrystalReportViewer1.ReportSource = Cr
            .Show()
        End With

    End Sub
End Class