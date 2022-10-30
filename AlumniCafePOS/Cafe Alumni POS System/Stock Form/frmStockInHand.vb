Imports MySql.Data.MySqlClient

Public Class frmStockInHand
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Sub LoadStock()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select PID, Description, Category, StockAvailable from tbl_stock where Category = '" & cboCategory.Text & "' group by PID", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("StockAvailable").ToString)
        End While
        Read.Close()
        cn.Close()
    End Sub
    Sub LoadCategory()
        Try
            Me.cboCategory.Items.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_category where Category='Stocks'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                Me.cboCategory.Items.Add(Read.Item("Category").ToString)
            End While
            Read.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try
    End Sub

    Private Sub frmStockInHand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategory()
        'Me.cboCategory.Items.Add("All")
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim i As Integer
        If check_empty(cboCategory) = True Then Return

        If cboCategory.Text = "All" Then
            Me.Guna2DataGridView1.Rows.Clear()
            cn.Open()
            cmd = New MySqlCommand("select PID, Description, Category, StockAvailable from tbl_stock group by PID", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("StockAvailable").ToString)
            End While
            Read.Close()
            cn.Close()

        Else

            Me.Guna2DataGridView1.Rows.Clear()
            cn.Open()
            cmd = New MySqlCommand("select PID, Description, Category, StockAvailable from tbl_stock where Category = '" & cboCategory.Text & "' group by PID", cn)
            'cmd = New MySqlCommand("select PID, Description, Category, sum(PurQty-SalesQty) as StockAvailable from tbl_stock where Category = '" & cboCategory.Text & "' group by PID", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("StockAvailable").ToString)
            End While
            Read.Close()
            cn.Close()

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim Dt As New DataTable
        Dim Cr As New crStockInHand

        Dt.Columns.Add("PID")
        Dt.Columns.Add("Description")
        Dt.Columns.Add("Category")
        Dt.Columns.Add("StockAvailable")

        For Each dr As DataGridViewRow In Me.Guna2DataGridView1.Rows
            Dt.Rows.Add(dr.Cells(1).Value, dr.Cells(2).Value, dr.Cells(3).Value, dr.Cells(4).Value)
        Next

        Cr.SetDataSource(Dt)
        With frmPrint
            .CrystalReportViewer1.ReportSource = Cr
            .Show()
        End With

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim ColStr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If ColStr = "ColEdit" Then

            With frmUpdateStock
                cn.Open()
                cmd = New MySqlCommand("select PID,Description,StockAvailable from tbl_stock where PID like '" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then

                    .lblPID.Text = Read.Item("PID").ToString
                    .txtDescription.Text = Read.Item("Description").ToString
                    .txtStockInHand.Text = Read.Item("StockAvailable").ToString

                End If
                Read.Dispose()
                cn.Close()
                .ShowDialog()
                LoadStock()

            End With

        ElseIf ColStr = "ColDel" Then
            If MsgBox("Do you want to delete the product Item?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_stock where PID like '" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Stock item has successfully deleted", vbInformation)
            End If
            LoadStock()
        End If
    End Sub
End Class