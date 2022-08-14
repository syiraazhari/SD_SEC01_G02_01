Imports MySql.Data.MySqlClient
Public Class frmPOS

    Private Sub frmPOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.R Then
        '    btnrecievePayment.Focus()
        '    MsgBox("G")
        'End If
    End Sub



    Private Sub frmPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clearPOS()
        Timer1.Start()
        'sql = "SELECT ITEMNAME FROM `tblitem`"
        'txtAutocomplete(sql, txtitemname)
        LBLCASHIER.Text = "Logged in Cashier: " & fullname

        'For Each ctrl As Control In Panel4.Controls
        '    If ctrl.GetType Is GetType(Button) Then


        '        ctrl.BackgroundImage = My.Resources.menu

        '    End If
        'Next

        'For i As Integer = 1 To 16

        '    janobefindthis("SELECT * FROM `tblitem` where DISPLAY ='YES' AND ITEMNO='" & i & "'")
        '    LoadSingleResult("menu1")

        'Next
    End Sub

    Private Sub completeitem()
        Try

            sql = "SELECT * FROM `tblitem`"
            cmd = New MySqlCommand
            With cmd
                .Connection = MyConn
                .CommandText = sql
            End With
            Dim da As New MySqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            Dim r As DataRow
            da.Fill(dt)
            txtitemname.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                txtitemname.AutoCompleteCustomSource.Add(r.Item(2).ToString)
            Next

            MyConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Public Sub SearchItem()

        janobefindthis("SELECT * FROM `tblitem` where ITEMNAME like	'%" & txtitemname.Text & "%'")
        LoadSingleResult("SearchItem")

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay
        lbldate.Text = Date.Today
    End Sub



    Private Sub txtitemname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtitemname.KeyDown
        If txtitemname.Text = Nothing Then

        Else
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                SearchItem()
                txtqty.Focus()
            End If

        End If
    End Sub

    Private Sub txtqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqty.KeyDown
        If txtqty.Text = Nothing Then
        Else
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                janobefindthis("SELECT SUM(`ONHAND`) FROM `tblitem` WHERE `ITEMCODE`='" & txtItemCode.Text & "'")
                ' MsgBox(CheckItem())
                If Val(txtqty.Text) > CheckItem() Then
                    MsgBox("Out of Stock!")
                Else
                    '  
                    If dtgItems.RowCount = 0 Then
                        ' MsgBox("y")
                        dtgItems.Rows.Add(txtItemCode.Text, txtdescription.Text, txtqty.Text, txtprice.Text, txttotalPrice.Text)

                    Else
                        Dim ifexist As Integer
                        For i As Integer = 0 To dtgItems.RowCount - 1

                            If txtItemCode.Text = dtgItems.Rows(i).Cells(0).Value.ToString Then
                                Dim newQTy As Integer


                                newQTy = Val(dtgItems.Rows(i).Cells(2).Value) + Val(txtqty.Text)
                                If newQTy > CheckItem() Then
                                    MsgBox("Out of Stock!")
                                Else
                                    dtgItems.Rows(i).Cells(2).Value = newQTy
                                    dtgItems.Rows(i).Cells(4).Value = newQTy * Val(txtprice.Text)
                                End If



                                ifexist = 1

                            End If

                        Next

                        If ifexist > 0 Then
                        Else
                            dtgItems.Rows.Add(txtItemCode.Text, txtdescription.Text, txtqty.Text, txtprice.Text, txttotalPrice.Text)
                        End If
                        '
                    End If
                    dtgItems.Sort(dtgItems.Columns(0), System.ComponentModel.ListSortDirection.Descending)
                End If


                txtItemCode.Text = ""
                txtdescription.Text = ""
                txtqty.Text = 1
                txtitemname.Text = ""
                txtprice.Text = "0.00"
                txttotalPrice.Text = "0.00"
                txtsubtotal.Text = "0.00"
                computeItems()

                txtitemname.Focus()
            End If

        End If

    End Sub
    Public Sub computeItems()
        For i As Integer = 0 To dtgItems.RowCount - 1

            txtsubtotal.Text = Val(txtsubtotal.Text) + dtgItems.Rows(i).Cells(4).Value
            subtotal = txtsubtotal.Text.Replace(",", "")
            Format(subtotal, "#,##0.00")
        Next
    End Sub
    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        Try
            txttotalPrice.Text = Val(txtprice.Text) * Val(txtqty.Text)

            totalPriceofItem = txttotalPrice.Text.Replace(",", "")
            Format(totalPriceofItem, "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRemove.Click
        For Each row As DataGridViewRow In dtgItems.SelectedRows

            txtsubtotal.Text = Val(txtsubtotal.Text) - dtgItems.CurrentRow.Cells(4).Value
            dtgItems.Rows.Remove(row)

        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtdiscount.Text = Val(txtSubtotal1.Text) * 0.1
            TxtTotalDue.Text = Val(txtsubtotal.Text) - Val(txtdiscount.Text)
            discount = txtdiscount.Text.Replace(",", "")
            Format(discount, "#,##0.00")
        Else
            txtdiscount.Text = "0.00"
            TxtTotalDue.Text = Val(txtsubtotal.Text)
            totaldue = TxtTotalDue.Text.Replace(",", "")
            Format(totaldue, "#,##0.00")
            discount = txtdiscount.Text.Replace(",", "")
            Format(discount, "#,##0.00")
        End If
    End Sub

    Private Sub txtsubtotal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsubtotal.KeyDown

    End Sub

    Private Sub txtsubtotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsubtotal.TextChanged
        Try
            txtSubtotal1.Text = txtsubtotal.Text
            TxtTotalDue.Text = Val(txtsubtotal.Text) - Val(txtdiscount.Text)

            totaldue = TxtTotalDue.Text.Replace(",", "")
            Format(totaldue, "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Try
            If CheckBox2.Checked = True Then
                txtTax.Text = Val(txtSubtotal1.Text) * 0.12
                TxtTotalDue.Text = Val(txtsubtotal.Text) - Val(txtdiscount.Text)

                vat = txtTax.Text.Replace(",", "")
                Format(vat, "#,##0.00")
            Else
                txtTax.Text = "0.00"
                TxtTotalDue.Text = Val(txtsubtotal.Text)
                totaldue = TxtTotalDue.Text.Replace(",", "")
                Format(totaldue, "#,##0.00")
                vat = txtTax.Text.Replace(",", "")
                Format(vat, "#,##0.00")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtAmountRecieve_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountRecieve.Enter
        txtAmountRecieve.Text = ""
    End Sub

    Private Sub txtAmountRecieve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmountRecieve.KeyDown
        If txtAmountRecieve.Text = Nothing Then
            '  MsgBox("Amount Recieve is not enough!")
        Else
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If Val(TxtTotalDue.Text) > Val(txtAmountRecieve.Text) Then
                    MsgBox("Amount entered is not Enough!")
                Else
                    btnsavetrans_Click(sender, e)
                    collectionofToday()
                End If


            End If

        End If

    End Sub
    Public Sub clearPOS()
        txtinvoice.Text = getAutonumber("invoice")
        txtOR.Text = getAutonumber("OR")
        txtitemname.Focus()
        txtcustomer.Text = "Default"
        txtAmountRecieve.Text = "0.00"
        txtsubtotal.Text = "0.00"
        txtSubtotal1.Text = "0.00"
        txtdiscount.Text = "0.00"
        txtTax.Text = "0.00"
        TxtTotalDue.Text = "0.00"
        txtAmountRecieve.Text = "0.00"
        txtChange.Text = "0.00"
        txtitemname.Text = ""
        txtItemCode.Text = ""
        txtprice.Text = "0.00"
        txttotalPrice.Text = "0.00"
        txtdescription.Text = ""
        dtgItems.Rows.Clear()
    End Sub
    Private Sub txtAmountRecieve_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountRecieve.LostFocus
        If txtAmountRecieve.Text = "" Then
            txtAmountRecieve.Text = "0.00"
        End If
    End Sub


    Private Sub txtAmountRecieve_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmountRecieve.TextChanged

        If Val(txtAmountRecieve.Text) > Val(TxtTotalDue.Text) Then

            txtChange.Text = Val(txtAmountRecieve.Text) - Val(TxtTotalDue.Text)
        Else
            txtChange.Text = "0.00"
        End If
    End Sub

    Private Sub btnsavetrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click

        sql = "INSERT INTO `tbltransaction` (`TRANSID`, `INVOICENO`, `ORNO`, `TRANSDATE`, `TRANSTIME`, `AMOUNTSALE`, `DISCOUNT`, `TAX`, `TOTALDUE`, `AMOUNTRECIEVED`, `AMOUNTCHANGE`, `TENDEREDBY`, `CASHIER`, `CUSTOMER`)" &
              " VALUES (NULL,@INVOICENO, @ORNO, @TRANSDATE, @TRANSTIME, @AMOUNTSALE, @DISCOUNT, @TAX, @TOTALDUE, @AMOUNTRECIEVED, @AMOUNTCHANGE, @TENDEREDBY, @CASHIER, @CUSTOMER);"

        issucess = SaveTrans(sql)

        If issucess = True Then

            janoupdate("UPDATE `tblautonumber` SET `AUTOEND` = " & getAutonumber("invoice") & " WHERE `AUTOCODE` = 'invoice';")
            ' MsgBox("New Transaction has been added!")

            Dim itemcode, itemdescription As String
            Dim qty As Integer
            Dim price, totprice As Double
            For i As Integer = 0 To dtgItems.RowCount - 1
                sql = "INSERT INTO `tbltransdetails` (`TRANSDETAILSID`, `INVOICENO`, `ITEMDESCRIPTION`, `ITEMQTY`, `ITEMPRICE`, `ITEMTOTPRICE`, `ITEMCODE`) VALUES (NULL, @INVOICENO, @ITEMDESCRIPTION, @ITEMQTY, @ITEMPRICE, @ITEMTOTPRICE, @ITEMCODE);"

                itemcode = dtgItems.Rows(i).Cells(0).Value
                itemdescription = dtgItems.Rows(i).Cells(1).Value.ToString
                qty = dtgItems.Rows(i).Cells(2).Value
                price = dtgItems.Rows(i).Cells(3).Value
                totprice = dtgItems.Rows(i).Cells(4).Value

                issucess = SaveTransDetails(sql, itemcode, itemdescription, qty, price, totprice)
                janoupdate("UPDATE tblitem SET ONHAND=0 WHERE ONHAND=1 AND ITEMCODE = '" & itemcode & "' LIMIT " & qty)

                If i = dtgItems.RowCount - 1 Then
                    If issucess = True Then


                        MsgBox("New Transaction has been added!")

                        collectionofToday()

                        sql = "SELECT * FROM `tbltransdetails`  td, `tbltransaction` t WHERE td.`INVOICENO`=t.`INVOICENO` AND t.INVOICENO='" & txtinvoice.Text & "'"
                        reports(sql, "receipt", frmReceipt.CrystalReportViewer1)
                        frmReceipt.Show()
                        frmReceipt.Focus()
                    Else
                        MsgBox("No Transaction has been Saved!")
                    End If
                End If

            Next


        Else
            MsgBox("No Transaction has been Saved!")
        End If



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To dtgItems.RowCount - 1
            MsgBox(i)
            ' MsgBox(dtgItems.RowCount - 1)

        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNew.Click
        clearPOS()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPayment.Click
        txtAmountRecieve.Focus()
    End Sub



    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        frmFindItems.ShowDialog()
    End Sub


End Class