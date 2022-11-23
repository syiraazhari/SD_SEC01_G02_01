Imports MySql.Data.MySqlClient

Public Class frmPurchase

    Public _PID As String
    Public _Category As String

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim view As New ListViewItem
        Try
            If txtSearch.TextLength > 0 Then
                With frmProductItem
                    .ListView1.Items.Clear()
                    cn.Open()
                    cmd = New MySqlCommand("select * from tbl_product where Description like '%" & txtSearch.Text.Trim & "%' and Category='Stocks'", cn)
                    Read = cmd.ExecuteReader
                    While Read.Read
                        view = New ListViewItem(Read.Item("PID").ToString)
                        view.SubItems.Add(Read.Item("Description").ToString)
                        view.SubItems.Add(Read.Item("Category").ToString)
                        view.SubItems.Add(Read.Item("CostPrice").ToString)
                        .ListView1.Items.Add(view)
                    End While
                    .ShowDialog()
                End With
            End If
            Read.Close()
            cn.Close()


        Catch ex As Exception
            cn.Close()
        End Try

    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        Dim Total As Double
        Total = Val(txtQty.Text) * Val(txtPrice.Text)
        txtAmount.Text = FormatCurrency(Total)
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub frmPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.Text = Now.ToString("yyyy-MM-dd")
        LoadSupplierName()

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        txtDate.Text = Format(Me.DateTimePicker1.Value, "yyyy-MM-dd")
    End Sub

    Sub LoadSupplierName()
        Try
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_Supplier", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                cboSupplierName.Items.Add(Read.Item("SuppName").ToString)
            End While
            Read.Close()
            cn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Finalize()
            cn.Close()
        End Try
    End Sub

    Sub loadGenerateInvoice()
        Dim sdate As String = Now.ToString("yyyyMMdd")
        cn.Open()
        cmd = New MySqlCommand("select MAX(InvoiceNo) from tbl_purchase", cn)
        If IsDBNull(cmd.ExecuteScalar) Then
            lblInvoiceNo.Text = sdate & "10001"
        Else
            lblInvoiceNo.Text = cmd.ExecuteScalar + 1
        End If
        cn.Close()

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If check_empty(txtBillNo) = True Then Return
        If check_empty(cboSupplierName) = True Then Return
        If check_empty(txtDescription) = True Then Return
        If check_empty(txtQty) = True Then Return

        Dim SID As String = ""
        Dim PID As String = ""
        Dim Category As String = ""
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_supplier where SuppName = '" & cboSupplierName.Text & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            SID = Read.Item("SID").ToString
        End If
        Read.Close()
        cn.Close()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_product where PID='" & _PID & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            PID = Read.Item("PID").ToString
            Category = Read.Item("Category").ToString

        End If
        Read.Close()
        cn.Close()

        Dim Duplicate As Boolean = False
        Dim PurID As String = ""
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_purchase where PID = @PID and InvoiceNo = @InvoiceNo", cn)
        With cmd
            .Parameters.AddWithValue("@PID", PID)
            .Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text)
        End With
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            Duplicate = True
            PurID = Read.Item("PurID").ToString
        Else
            Duplicate = False
            Read.Close()
            cn.Close()
        End If
        Read.Close()
        cn.Close()

        If Duplicate = True Then

            cn.Open()
            cmd = New MySqlCommand("update tbl_purchase set Qty = Qty+@Qty where PurID = '" & PurID & "'", cn)
            cmd.Parameters.AddWithValue("@Qty", CDbl(txtQty.Text))
            cmd.ExecuteNonQuery()
            cn.Close()

            cn.Open()
            cmd = New MySqlCommand("update tbl_purchase set Amount = Qty*Price", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Else
            cn.Open()
            cmd = New MySqlCommand("insert into tbl_purchase(PDate, InvoiceNo, SID,BillNo,PID,Description,Category,Qty,Price,Amount,User) values(@PDate, @InvoiceNo, @SID,@BillNo,@PID,@Description,@Category,@Qty,@Price,@Amount,@User)", cn)
            With cmd
                .Parameters.AddWithValue("@PDate", txtDate.Text)
                .Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text)
                .Parameters.AddWithValue("@SID", SID)                               'problem 
                .Parameters.AddWithValue("@BillNo", txtBillNo.Text)
                .Parameters.AddWithValue("@PID", PID)
                .Parameters.AddWithValue("@Description", txtDescription.Text)
                .Parameters.AddWithValue("@Category", Category)
                .Parameters.AddWithValue("@Qty", CDbl(txtQty.Text))
                .Parameters.AddWithValue("@Price", CDbl(txtPrice.Text))
                .Parameters.AddWithValue("@Amount", CDbl(txtAmount.Text))
                .Parameters.AddWithValue("@User", UserString)
                .ExecuteNonQuery()

            End With
            cn.Close()
        End If
        txtQty.Clear()
        txtSearch.Clear()
        txtDescription.Clear()
        txtPrice.Clear()
        txtAmount.Text = "0.00"
        LoadPurchase()

    End Sub

    Sub LoadPurchase()
        Dim i As Integer
        Dim _Total As Double
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select p.PID,Pur.PID, p.Description,p.Category,Pur.Qty,p.CostPrice,Pur.Amount from tbl_purchase as Pur inner join tbl_product as P on pur.PID=p.PID where InvoiceNo='" & lblInvoiceNo.Text & "'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            _Total += CDbl(Read.Item("Amount").ToString)
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("Qty").ToString, FormatCurrency(Read.Item("CostPrice").ToString), FormatCurrency(Read.Item("Amount").ToString))
        End While
        Read.Close()
        cn.Close()
        lblTotal.Text = FormatCurrency(_Total)
        cn.Close()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If colstr = "ColDel" Then
            If MsgBox("Do you want to remove the item. Click YES to Confirm", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_purchase where PID = '" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "' and InvoiceNo = '" & lblInvoiceNo.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()

            End If
        End If
        LoadPurchase()
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        If Me.Guna2DataGridView1.Rows.Count <= 0 Then
            MsgBox("there are NO items in the cart", vbInformation)
            Return
        End If

        cn.Open()
        cmd = New MySqlCommand("insert into tbl_purpayment(PDate, InvoiceNo,Total,User) values(@PDate, @InvoiceNo,@Total,@User)", cn)
        With cmd
            .Parameters.AddWithValue("@PDate", txtDate.Text)
            .Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text)
            .Parameters.AddWithValue("Total", CDbl(lblTotal.Text))
            .Parameters.AddWithValue("User", UserString)
            cmd.ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("Purchase transaction has been successfully saved", vbInformation)
        updateCart()
        loadStock()
        clear()
        'Me.Dispose()
    End Sub

    Sub updateCart()
        cn.Open()
        cmd = New MySqlCommand("update tbl_purchase set Status = 'Settled' where InvoiceNo='" & lblInvoiceNo.Text & "'", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Sub loadStock()
        For i = 0 To Me.Guna2DataGridView1.Rows.Count - 1
            Dim PID As String = Me.Guna2DataGridView1.Rows(i).Cells(1).Value
            Dim Description As String = Me.Guna2DataGridView1.Rows(i).Cells(2).Value
            Dim Category As String = Me.Guna2DataGridView1.Rows(i).Cells(3).Value
            Dim Qty As Integer = Me.Guna2DataGridView1.Rows(i).Cells(4).Value

            cn.Open()
            cmd = New MySqlCommand("insert into tbl_stockin(SDate,PID,Description,Category,Qty) values(@SDate,@PID,@Description,@Category,@Qty)", cn)
            With cmd
                .Parameters.AddWithValue("SDate", txtDate.Text)
                .Parameters.AddWithValue("PID", PID)
                .Parameters.AddWithValue("@Description", Description)
                .Parameters.AddWithValue("@Category", Category)
                .Parameters.AddWithValue("@Qty", CInt(Qty))
                .ExecuteNonQuery()
            End With
            cn.Close()

            Dim stockID As String = "'"
            Dim Duplicate As Boolean = False

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_stock where PID = '" & PID & "'", cn)
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                Duplicate = True
                stockID = Read.Item("StockID").ToString
            Else
                Duplicate = False
            End If
            Read.Close()
            cn.Close()

            If Duplicate = True Then
                cn.Open()
                cmd = New MySqlCommand("update tbl_stock set PurQty = PurQty + @Qty where StockID = '" & stockID & "'", cn)
                cmd.Parameters.AddWithValue("@Qty", Qty)
                cmd.ExecuteNonQuery()
                cn.Close()
            Else
                cn.Open()
                cmd = New MySqlCommand("insert into tbl_stock(PID, Description, Category, PurQty, SalesQty, StockAvailable) values(@PID, @Description, @Category, @PurQty, @SalesQty, @StockAvailable)", cn)
                With cmd
                    .Parameters.AddWithValue("PID", PID)
                    .Parameters.AddWithValue("@Description", Description)
                    .Parameters.AddWithValue("@Category", Category)
                    .Parameters.AddWithValue("@PurQty", Qty)
                    .Parameters.AddWithValue("@SalesQty", 0)
                    .Parameters.AddWithValue("@StockAvailable", Qty)
                    .ExecuteNonQuery()
                End With
                cn.Close()

            End If
        Next
    End Sub

    Private Sub btnUnsettledTrans_Click(sender As Object, e As EventArgs) Handles btnUnsettledTrans.Click
        With frmUnsettledPurTrans
            .LoadUnsettInvoice()
            .ShowDialog()
        End With
    End Sub

    Sub clear()
        txtBillNo.Clear()
        txtSearch.Clear()
        txtDescription.Clear()
        txtPrice.Clear()
        lblTotal.Text = "0.00"
        txtQty.Clear()
        txtPrice.Clear()
        txtAmount.Clear()
        cboSupplierName.Text = ""
        Me.Guna2DataGridView1.Rows.Clear()
    End Sub
End Class