Imports MySql.Data.MySqlClient
Public Class frmUnsettledPurTrans

    Sub LoadUnsettInvoice()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select distinct(InvoiceNo) from tbl_purchase where Status='Unsettled'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("InvoiceNo").ToString, "Select")
        End While
        Read.Close()
        cn.Close()

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If colstr = "ColSelect" Then
            With frmPurchase
                cn.Open()
                cmd = New MySqlCommand("select * from tbl_purchase where InvoiceNo='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    .lblInvoiceNo.Text = Read.Item("InvoiceNo").ToString
                    .txtBillNo.Text = Read.Item("BillNo").ToString
                    .txtDate.Text = Format(Read.Item("PDate"), "yyy-MM-dd")   'CDate(Read.Item("PDate").ToString)
                End If
                Read.Close()
                cn.Close()
            End With
        End If
        LoadSupplierName()
        LoadUnsettledItems()
        Me.Dispose()
    End Sub

    Sub LoadSupplierName()
        Dim SuppName As String = ""
        With frmPurchase
            .cboSupplierName.Items.Clear()
            cn.Open()
            cmd = New MySqlCommand("select S.SID,S.SuppName,Pur.SID from tbl_purchase as Pur inner join tbl_supplier as S on Pur.SID=S.SID where InvoiceNo='" & .lblInvoiceNo.Text & "' and Status = 'Unsettled'", cn)
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                SuppName = Read.Item("SuppName").ToString
            End If
            Read.Close()
            cn.Close()
            .LoadSupplierName()
            .cboSupplierName.Text = SuppName

        End With
    End Sub

    Sub LoadUnsettledItems()
        Dim i As Integer
        Dim _Total As Double
        With frmPurchase
            .Guna2DataGridView1.Rows.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_purchase where InvoiceNo = '" & .lblInvoiceNo.Text & "' and Status = 'UnSettled'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                _Total += CDbl(Read.Item("Amount").ToString)
                .Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, CDbl(Read.Item("Qty").ToString), FormatCurrency(Read.Item("Price").ToString), FormatCurrency(Read.Item("Amount").ToString))
            End While
            Read.Close()
            cn.Close()
            .lblTotal.Text = FormatCurrency(_Total)

        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class