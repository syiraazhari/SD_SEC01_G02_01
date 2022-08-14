Module modstocks
    Public Function SaveStocks(ByVal saving As String, ByVal sqlstring As String) As Boolean
        Try

            If saving = "SaveOnly" Then
                sql = sqlstring
            ElseIf saving = "UpdateOnly" Then
                sql = sqlstring
            ElseIf saving = "AddQty" Then
                sql = sqlstring
            End If
            MyConn.Open()
            cmd.Connection = MyConn
            cmd.CommandText = sql
            With frmStocks
                Dim unitprice, markup As Double

                unitprice = .txtUnitPrice.Text.Replace(",", "")
                Format(unitprice, "#,##0.00")
                markup = .txtmarkup.Text.Replace(",", "")
                Format(markup, "#,##0.00")

                If saving = "SaveOnly" Then

                    cmd.Parameters.AddWithValue("@ITEMNAME", .txtitemname.Text)
                    cmd.Parameters.AddWithValue("@BARCODE", .txtBarcode.Text)
                    cmd.Parameters.AddWithValue("@ITEMDESCRIPTION", .txtDescription.Text)
                    cmd.Parameters.AddWithValue("@ITEMCATEGORY", .ComboBox1.SelectedValue)
                    cmd.Parameters.AddWithValue("@SIZE", .txtSize.Text)
                    cmd.Parameters.AddWithValue("@UNITPRICE", unitprice)
                    cmd.Parameters.AddWithValue("@MARKUP", markup)
                    cmd.Parameters.AddWithValue("@ITEMCODE", .txtItemCode.Text)
                    cmd.Parameters.AddWithValue("@QTY", 1)
                    cmd.Parameters.AddWithValue("@ONHAND", 1)
                    cmd.Parameters.AddWithValue("@DATEIN", Format(Date.Today, "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@ENCODEDBY", fullname)
                    cmd.Parameters.AddWithValue("@EMPID", userID)

                ElseIf saving = "UpdateOnly" Then

                    cmd.Parameters.AddWithValue("@ITEMNAME", .txtitemname.Text)
                    cmd.Parameters.AddWithValue("@BARCODE", .txtBarcode.Text)
                    cmd.Parameters.AddWithValue("@ITEMDESCRIPTION", .txtDescription.Text)
                    cmd.Parameters.AddWithValue("@ITEMCATEGORY", .ComboBox1.SelectedValue)
                    cmd.Parameters.AddWithValue("@SIZE", .txtSize.Text)
                    cmd.Parameters.AddWithValue("@UNITPRICE", unitprice)
                    cmd.Parameters.AddWithValue("@MARKUP", markup)
                    cmd.Parameters.AddWithValue("@ITEMCODE", .txtItemCode.Text)


                End If




                'If saving = "SaveOnly" Then

                'End If


            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                Return True
            Else
                Return False
            End If
            'Catch ex As Exception
            '    MsgBox(ex.Message)
        Finally
            cmd.Parameters.Clear()
            cmd.Dispose()
            MyConn.Close()

        End Try

    End Function
    Public Sub reloaditems()
        janobefindthis("SELECT `ITEMNO`,`ITEMCODE`, `ITEMNAME`, `ITEMDESCRIPTION`, `ITEMCATEGORY`, `SIZE`,SUM( `QTY`) as 'Qty',  SUM(`ONHAND`) as 'Ave. QTY',`UNITPRICE`, `DATEIN`, `MARKUP`,Barcode FROM `tblitem` GROUP by ITEMCODE")
        LoadData(frmListStocks.DataGridView1, "Items")
    End Sub

    Public Function CheckItem() As Integer
        Dim dr As String = ""
        Try

            MyConn.Open()
            dReader = cmd.ExecuteReader()
            Do While dReader.Read = True
                dr = dReader(0)
            Loop

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            Return dr
        Finally
            MyConn.Close()

        End Try
    End Function

End Module
