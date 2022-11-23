Imports MySql.Data.MySqlClient
Public Class frmSales
    Private WithEvents PIC As New PictureBox
    Private WithEvents lblDesc As New Label
    Private WithEvents lblPrice As New Label
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDate.Text = Now.ToString("dddd yyyy-MM-dd")
        lblTime.Text = Now.ToLongTimeString
    End Sub

    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblInvoiceNo.Text = GenerateSalesInvoice()
        LoadTableName()
        CreateCategoryInTabPages()
        CreatePICInTabPages()
        LoadUnSettletable()
    End Sub

    Sub calculateTotal()
        Dim itax As Double = Gettax()
        Dim Total As Double = 0.00, tax = 0.00
        tax = CDbl(lblSubTotal.Text) * CDbl(itax) / 100
        lblTax.Text = FormatCurrency(tax)
        Total = CDbl(lblSubTotal.Text) + CDbl(lblTax.Text)
        lblNetTotal.Text = FormatCurrency(Total)
    End Sub
    Sub LoadTableName()
        Try
            cboTable.Items.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_table", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                cboTable.Items.Add(Read.Item("TableName").ToString())
            End While
            Read.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
        calculateTotal()
    End Sub

    Sub CreateCategoryInTabPages()
        Try
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_category where Category<>'Stocks' ", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                Me.TabControl1.TabPages.Add(Read.Item("Category").ToString)
            End While
            Read.Close()
            cn.Close()
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub CreatePICInTabPages()
        Try
            For Each tp As TabPage In Me.TabControl1.TabPages
                cn.Open()
                cmd = New MySqlCommand("select * from tbl_product where Category ='" & tp.Text & "'", cn)
                Read = cmd.ExecuteReader

                Dim flow As New FlowLayoutPanel
                flow.Dock = DockStyle.Fill
                flow.BackColor = Color.FromArgb(199, 236, 238)
                While Read.Read
                    Dim arr() As Byte
                    Dim MS As System.IO.MemoryStream
                    arr = Read.Item("Image")
                    MS = New System.IO.MemoryStream(arr)

                    PIC = New PictureBox
                    PIC.Width = 150
                    PIC.Height = 100
                    PIC.BackgroundImageLayout = ImageLayout.Stretch

                    lblDesc = New Label
                    lblDesc.ForeColor = Color.Black
                    lblDesc.BackColor = Color.FromArgb(255, 118, 117)
                    lblDesc.Dock = DockStyle.Bottom
                    lblDesc.Height = 30

                    lblPrice = New Label
                    lblPrice.ForeColor = Color.White
                    lblPrice.BackColor = Color.FromArgb(9, 132, 227)
                    lblPrice.Width = 60
                    lblPrice.Height = 18

                    PIC.BackgroundImage = System.Drawing.Image.FromStream(MS)
                    lblDesc.Text = Read.Item("Description").ToString
                    lblPrice.Text = FormatCurrency(Read.Item("SellPrice").ToString)
                    PIC.Tag = Read.Item("PID").ToString
                    lblDesc.Tag = Read.Item("PID").ToString
                    lblPrice.Tag = Read.Item("PID").ToString
                    PIC.Controls.Add(lblDesc)
                    PIC.Controls.Add(lblPrice)
                    flow.Controls.Add(PIC)
                    AddHandler PIC.Click, AddressOf select_Click
                    AddHandler lblDesc.Click, AddressOf select_Click
                    AddHandler lblPrice.Click, AddressOf select_Click
                End While
                tp.Controls.Add(flow)
                cn.Close()
            Next
        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub select_Click(sender As Object, e As EventArgs)
        Dim PID As String = ""
        Dim Desc As String = ""
        Dim Category As String = ""
        Dim Price As Double

        If cboTable.Text = "" Then
            MsgBox("Select restaurant table", vbInformation)
            Return
        End If

        cn.Open()
        cmd = New MySqlCommand("select * from tbl_product where PID='" & sender.tag & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            PID = Read.Item("PID").ToString
            Desc = Read.Item("Description").ToString
            Category = Read.Item("Category").ToString
            Price = Read.Item("SellPrice").ToString
        End If
        Read.Close()
        cn.Close()
        calculateTotal()
        With frmQty
            .AddCart(PID, Desc, Category, Price)
            .ShowDialog()
            calculateTotal()
        End With
        calculateTotal()
        LoadUnSettletable()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If colstr = "ColDel" Then
            If MsgBox("Do you want to remove the item?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_sales where PID='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "' and InvoiceNo='" & lblInvoiceNo.Text & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
            End If
        End If
        With frmQty
            .LoadCart()
            calculateTotal()
        End With
        calculateTotal()
        LoadItemByTable()
        LoadUnSettletable()
    End Sub

    Private Sub cboTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTable.SelectedIndexChanged
        Dim found As Boolean = False
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_sales where TableName='" & cboTable.Text & "'", cn)
        Read = cmd.ExecuteReader
        If Read.HasRows Then
            found = True
            Read.Close()
            cn.Close()
        Else
            found = False
            Read.Close()
            cn.Close()
        End If
        Read.Close()
        cn.Close()

        If found = True Then
            LoadItemByTable()
            calculateTotal()
        Else
            found = False
            lblInvoiceNo.Text = GenerateSalesInvoice()
            Me.Guna2DataGridView1.Rows.Clear()
            lblSubTotal.Text = "0.00"
            lblTax.Text = "0.00"
            lblNetTotal.Text = "0.00"
            lblCash.Text = "0.00"
            lblChange.Text = "0.00"
            calculateTotal()
        End If
        calculateTotal()
        LoadUnSettletable()
    End Sub

    Sub LoadItemByTable()
        Dim i As Integer
        Dim total As Double
        Dim found As Boolean = False
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_sales where TableName='" & cboTable.Text & "' and Status='UnSettled'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            found = True
            i += 1
            total += CDbl(Read.Item("Amount").ToString)
            lblInvoiceNo.Text = Read.Item("InvoiceNo").ToString
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("Qty").ToString, FormatCurrency(Read.Item("Price").ToString), FormatCurrency(Read.Item("Amount").ToString))
        End While
        Read.Close()
        cn.Close()
        lblCash.Text = "0.00"
        lblChange.Text = "0.00"
        lblSubTotal.Text = FormatCurrency(total)
        calculateTotal()

        If found = False Then
            lblInvoiceNo.Text = GenerateSalesInvoice()
            Me.Guna2DataGridView1.Rows.Clear()
            lblSubTotal.Text = "0.00"
            lblTax.Text = "0.00"
            lblNetTotal.Text = "0.00"
            lblCash.Text = "0.00"
            lblChange.Text = "0.00"
            calculateTotal()
        End If
    End Sub

    Private Sub btnGetCash_Click(sender As Object, e As EventArgs) Handles btnGetCash.Click
        With frmGetCash
            .Show()
            btnPayment.Enabled = True
        End With
    End Sub

    Sub LoadUnSettletable()
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.Controls.Clear()
        cn.Open()
        cmd = New MySqlCommand("select distinct(TableName) from tbl_sales where Status='Unsettled' order by TableName asc", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            Dim btn As New Button
            btn.Width = 100
            btn.Height = 60
            btn.BackColor = Color.FromArgb(253, 203, 110)
            btn.FlatStyle = FlatStyle.Flat
            btn.ForeColor = Color.FromArgb(99, 110, 114)
            btn.Text = Read.Item("TableName").ToString
            btn.Tag = Read.Item("TableName").ToString
            FlowLayoutPanel1.Controls.Add(btn)
            AddHandler btn.Click, AddressOf LoadUnsettleItem_Click
        End While
        cn.Close()

    End Sub

    Private Sub LoadUnsettleItem_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Dim total As Double
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_sales where TableName='" & sender.tag & "' and Status='UnSettled'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            total = CDbl(Read.Item("Amount").ToString)
            lblInvoiceNo.Text = Read.Item("InvoiceNo").ToString
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("Qty").ToString, FormatCurrency(Read.Item("Price").ToString), FormatCurrency(Read.Item("Amount").ToString))
        End While
        cn.Close()
        lblSubTotal.Text = FormatCurrency(total)
        lblCash.Text = "0.00"
        lblChange.Text = "0.00"
        calculateTotal()
        cboTable.Text = sender.tag
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        MainWindow.RefreshButton.Visible = True
        If Me.Guna2DataGridView1.Rows.Count <= 0 Then
            MsgBox("There are no Order in the cart", vbInformation)
            Return
        End If
        cn.Open()
        cmd = New MySqlCommand("insert into tbl_salespayment (InvoiceNo,SDate,STime,SubTotal,Tax,Cash,NetTotal,Changes,User) values (@InvoiceNo,@SDate,@STime,@SubTotal,@Tax,@Cash,@NetTotal,@Changes,@User)", cn)
        With cmd
            .Parameters.AddWithValue("@InvoiceNo", lblInvoiceNo.Text)
            .Parameters.AddWithValue("@SDate", CDate(lblDate.Text))
            .Parameters.AddWithValue("@STime", CDate(lblTime.Text))
            .Parameters.AddWithValue("@SubTotal", CDbl(lblSubTotal.Text))
            .Parameters.AddWithValue("@Tax", CDbl(lblTax.Text))
            .Parameters.AddWithValue("@Cash", CDbl(lblCash.Text))
            .Parameters.AddWithValue("@NetTotal", CDbl(lblNetTotal.Text))
            .Parameters.AddWithValue("@Changes", CDbl(lblChange.Text))
            .Parameters.AddWithValue("@User", UserString)
            .ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("Payment Successful", vbInformation)
        LoadStock()
        AddCart()
    End Sub

    Sub AddCart()
        cn.Open()
        cmd = New MySqlCommand("update tbl_sales set Status='Settled' where InvoiceNo='" & lblInvoiceNo.Text & "'", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        LoadItemByTable()
        LoadUnSettletable()
    End Sub

    Sub LoadStock()
        For i = 0 To (Me.Guna2DataGridView1.Rows.Count - 2)

            Dim PID_ As String = Me.Guna2DataGridView1.Rows(i).Cells(1).Value.ToString
            Dim Desc_ As String = Me.Guna2DataGridView1.Rows(i).Cells(2).Value.ToString
            Dim Cat_ As String = Me.Guna2DataGridView1.Rows(i).Cells(3).Value.ToString
            Dim Qty_ As Integer = Me.Guna2DataGridView1.Rows(i).Cells(4).Value.ToString

            cn.Open()
            cmd = New MySqlCommand("insert into tbl_stockout(SDate, PID, Description, Category, Qty) values (@SDate, @PID, @Description, @Category, @Qty)", cn)
            With cmd
                .Parameters.AddWithValue("@SDate", CDate(lblDate.Text))
                .Parameters.AddWithValue("@PID", PID_)
                .Parameters.AddWithValue("@Description", Desc_)
                .Parameters.AddWithValue("@Category", Cat_)
                .Parameters.AddWithValue("@Qty", CInt(Qty_))
                .ExecuteNonQuery()

            End With
            cn.Close()

            Dim Duplicate As Boolean = False
            Dim stockID As String = ""
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_stock where PID = '" & PID_ & "'", cn)
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                Duplicate = True
                stockID = Read.Item("StockID").ToString
            Else
                Duplicate = False
                stockID = ""
            End If
            Read.Close()
            cn.Close()

            If Duplicate = True Then
                cn.Open()
                cmd = New MySqlCommand("update tbl_stock set SalesQty=SalesQty+@Qty where StockID ='" & stockID & "'", cn)           'ISSUE: Command doesnt update database
                cmd.Parameters.AddWithValue("@Qty", CInt(Qty_))
                cn.Close()
            Else
                cn.Open()
                cmd = New MySqlCommand("insert into tbl_stock (PID, Description, Category, PurQty, SalesQty, StockAvailable) values(@PID, @Description, @Category, @PurQty, @SalesQty, @StockAvailable)", cn)
                With cmd
                    .Parameters.AddWithValue("@PID", PID_)
                    .Parameters.AddWithValue("@Description", Desc_)
                    .Parameters.AddWithValue("@Category", Cat_)
                    .Parameters.AddWithValue("@PurQty", 0)
                    .Parameters.AddWithValue("@SalesQty", Qty_)
                    .Parameters.AddWithValue("@StockAvailable", Qty_)
                    .ExecuteNonQuery()
                End With
                cn.Close()
            End If

        Next
    End Sub
End Class