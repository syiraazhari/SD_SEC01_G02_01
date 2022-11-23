Imports MySql.Data.MySqlClient
Public Class frmQty
    Private Sub txtRestName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case 13
            Case Else
                e.Handled = True
        End Select
    End Sub

    Dim PID As String
    Dim Duplicate As Boolean
    Dim salesID As String
    Dim Desc As String
    Dim Category As String
    Dim Price As Double
    Private Sub txtRestName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Enter Then
            If check_empty(txtQty) = True Then Return
            cn.Open()
                cmd = New MySqlCommand("select * from tbl_sales where PID='" & PID & "' and InvoiceNo='" & frmSales.lblInvoiceNo.Text & "'", cn)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    Duplicate = True
                    salesID = Read.Item("SalesID").ToString
                    Read.Close()
                    cn.Close()

                Else
                    Duplicate = False
                    Read.Close()
                    cn.Close()

                End If
                Read.Close()
                cn.Close()

                If Duplicate = True Then
                    cn.Open()
                    cmd = New MySqlCommand("update tbl_sales set Qty=Qty+@Qty where SalesID='" & salesID & "'", cn)
                    cmd.Parameters.AddWithValue("@Qty", CDbl(txtQty.Text))
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    cn.Open()
                    cmd = New MySqlCommand("update tbl_sales set Amount=Qty * Price", cn)
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    Me.Dispose()
                Else
                    cn.Open()
                    cmd = New MySqlCommand("insert into tbl_sales (InvoiceNo,SDate,STime,PID,Description,Category,Qty,Price,Amount,TableName,User) value (@InvoiceNo,@SDate,@STime,@PID,@Description,@Category,@Qty,@Price,@Amount,@TableName,@User)", cn)
                    With cmd
                        .Parameters.AddWithValue("@InvoiceNo", frmSales.lblInvoiceNo.Text)
                        .Parameters.AddWithValue("@SDate", CDate(frmSales.lblDate.Text))
                        .Parameters.AddWithValue("@STime", CDate(frmSales.lblTime.Text))
                        .Parameters.AddWithValue("@PID", PID)
                        .Parameters.AddWithValue("@Description", Desc)
                        .Parameters.AddWithValue("@Category", Category)
                        .Parameters.AddWithValue("@Qty", CDbl(txtQty.Text))
                        .Parameters.AddWithValue("@Price", Price)
                        .Parameters.AddWithValue("@Amount", CDbl(txtQty.Text) * Price)
                        .Parameters.AddWithValue("@TableName", frmSales.cboTable.Text)
                        .Parameters.AddWithValue("@User", UserString)
                        .ExecuteNonQuery()
                    End With
                    cn.Close()
                    Me.Dispose()
                End If
            End If
            LoadCart()
    End Sub

    Sub AddCart(PID As String, Description As String, Category As String, Price As Double)
        Me.PID = PID
        Me.Desc = Description
        Me.Category = Category
        Me.Price = Price
    End Sub

    Sub LoadCart()
        Dim i As Integer
        Dim Total As Double
        frmSales.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_sales where InvoiceNo='" & frmSales.lblInvoiceNo.Text & "'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Total += CDbl(Read.Item("Amount").ToString)
            frmSales.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, CDbl(Read.Item("Qty").ToString), FormatCurrency(Read.Item("Price").ToString), FormatCurrency(Read.Item("Amount").ToString))
        End While
        Read.Close()
        cn.Close()

        frmSales.lblSubTotal.Text = FormatCurrency(Total)
    End Sub

End Class