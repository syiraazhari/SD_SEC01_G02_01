Public Class frmStocks
    Dim unitprice, markup As Double

    Private Sub frmnewStocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        janobefindthis("Select * from tblcategory")
        fillcombo(ComboBox1, "CATNAME", "CATNAME")
        ComboBox1.Text = combo
        If txtItemCode.Text = Nothing Then
            txtItemCode.Text = Format(Date.Today, "dd") & Format(Date.Today, "MM") & Format(Date.Today, "yyyy") & getAutonumber("item")
        End If

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If itemMessage = "SaveOnly" Then


            For i As Integer = 1 To Val(txtQuantity.Text)
                sql = "INSERT INTO `tblitem` ( `ITEMCODE`,`BARCODE`, `ITEMNAME`, `ITEMDESCRIPTION`, " &
                                                                  " `ITEMCATEGORY`, `SIZE`, `QTY`, `UNITPRICE`, `ONHAND`, `DATEIN`, `MARKUP`, " &
                                                                  " `ENCODEDBY`, `EMPID`) VALUES (@ITEMCODE,@BARCODE, @ITEMNAME, @ITEMDESCRIPTION, " &
                                                                  " @ITEMCATEGORY, @SIZE, @QTY, @UNITPRICE, @ONHAND, @DATEIN, @MARKUP, " &
                                                                  " @ENCODEDBY, @EMPID);"

                issucess = SaveStocks("SaveOnly", sql)

                If issucess = True Then
                    If i = Val(txtQuantity.Text) Then
                        janoupdate("UPDATE `tblautonumber` SET `AUTOEND` = " & getAutonumber("item") & " WHERE `AUTOCODE` = 'item';")
                        MsgBox("New Item has been added!")
                        Me.Close()
                    End If

                Else
                    MsgBox("No Item has been added!")
                End If
            Next


        ElseIf itemMessage = "UpdateOnly" Then
            For i As Integer = 1 To Val(txtQuantity.Text)
                sql = "UPDATE `tblitem` SET BARCODE=@BARCODE, ITEMNAME=@ITEMNAME, `ITEMDESCRIPTION`=@ITEMDESCRIPTION, " &
                                " `ITEMCATEGORY`=@ITEMCATEGORY, `SIZE`= @SIZE, `UNITPRICE`=@UNITPRICE, " &
                                "  MARKUP=@MARKUP WHERE ITEMCODE=@ITEMCODE"
                issucess = SaveStocks("UpdateOnly", sql)

                If issucess = True Then
                    If i = Val(txtQuantity.Text) Then
                        MsgBox("Item(s) has been updated!")
                        Me.Close()
                    End If

                Else
                    MsgBox("No Item has been updated!")

                End If
            Next



        End If

        reloaditems()
    End Sub


    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class