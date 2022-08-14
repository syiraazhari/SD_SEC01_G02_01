Module modTrans
    Public Function SaveTrans(ByVal sqlstring As String) As Boolean
        Try
            sql = sqlstring


            MyConn.Open()
            cmd.Connection = MyConn
            cmd.CommandText = sql
            Dim amount, change As Double
            amount = frmPOS.txtAmountRecieve.Text.Replace(",", "")
            Format(amount, "#,##0.00")
            change = frmPOS.txtChange.Text.Replace(",", "")
            Format(change, "#,##0.00")

            With frmPOS
                cmd.Parameters.AddWithValue("@INVOICENO", .txtinvoice.Text)
                cmd.Parameters.AddWithValue("@ORNO", .txtOR.Text)
                cmd.Parameters.AddWithValue("@TRANSDATE", Format(Date.Today, "yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@TRANSTIME", .lbltime.Text)
                cmd.Parameters.AddWithValue("@AMOUNTSALE", subtotal)
                cmd.Parameters.AddWithValue("@DISCOUNT", discount)
                cmd.Parameters.AddWithValue("@TAX", vat)
                cmd.Parameters.AddWithValue("@TOTALDUE", totaldue)
                cmd.Parameters.AddWithValue("@AMOUNTRECIEVED", Format(amount, "#,##0.00"))
                cmd.Parameters.AddWithValue("@AMOUNTCHANGE", Format(change, "#,##0.00"))
                cmd.Parameters.AddWithValue("@TENDEREDBY", userID)
                cmd.Parameters.AddWithValue("@CASHIER", fullname)
                cmd.Parameters.AddWithValue("@CUSTOMER", .txtcustomer.Text)

            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                Return True
            Else
                Return False
            End If

        Finally
            cmd.Parameters.Clear()
            cmd.Dispose()
            MyConn.Close()
        End Try

    End Function

    Public Function SaveTransDetails(ByVal sqlstring As String, ByVal itemcode As String, ByVal itemdescription As String, ByVal qty As Integer, ByVal price As Double, ByVal totprice As Double) As Boolean
        Try
            sql = sqlstring


            MyConn.Open()
            cmd.Connection = MyConn
            cmd.CommandText = sql
            'Dim amount, change As Double
            ' Dim itemcode, itemdescription As String
            'Dim qty As Integer
            'Dim price, totprice As Double


            '  amount = price.Replace(",", "")
            'Format(price, "#,##0.00")
            'change = frmPOS.txtChange.Text.Replace(",", "")
            'Format(totprice, "#,##0.00")

            With frmPOS
                cmd.Parameters.AddWithValue("@INVOICENO", .txtinvoice.Text)
                cmd.Parameters.AddWithValue("@ITEMDESCRIPTION", itemdescription)
                cmd.Parameters.AddWithValue("@ITEMQTY", qty)
                cmd.Parameters.AddWithValue("@ITEMPRICE", Format(price, "#,##0.00"))
                cmd.Parameters.AddWithValue("@ITEMTOTPRICE", Format(totprice, "#,##0.00"))
                cmd.Parameters.AddWithValue("@ITEMCODE", itemcode)

            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                Return True
            Else
                Return False
            End If

        Finally
            cmd.Parameters.Clear()
            cmd.Dispose()
            MyConn.Close()
        End Try

    End Function
End Module
