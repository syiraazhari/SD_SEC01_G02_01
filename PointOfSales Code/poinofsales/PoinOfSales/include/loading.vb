Module loading
    Public Sub LoadSingleResult(ByVal param As String)

        Try

            MyConn.Open()
            dReader = cmd.ExecuteReader()
            Select param
                
                Case "menu1"
                    Do While dReader.Read = True
                        With frmPOS
                            Dim a As String
                            Dim arrImage() As Byte
                            a = dReader("DISPLAYMENU")

                            For Each ctrl As Control In frmPOS.Panel4.Controls
                                If ctrl.GetType Is GetType(Button) Then

                                    If ctrl.Name = a Then

                                        ctrl.Text = dReader("ITEMDESCRIPTION")
                                        ' ctrl = dReader("ITEMDESCRIPTION")
                                        arrImage = dReader("IMG")
                                        Dim mstream As New System.IO.MemoryStream(arrImage)
                                        ctrl.BackgroundImage = Image.FromStream(mstream)
                                    Else
                                        ctrl.Text = ctrl.Text
                                    End If
                                End If
                            Next
                           

                        End With

                      
                    Loop
                Case "SearchItem"
                    Do While dReader.Read = True
                        frmPOS.txtItemCode.Text = dReader(1)
                        frmPOS.txtdescription.Text = dReader(2)
                        frmPOS.txtprice.Text = dReader(10)
                        frmPOS.txttotalPrice.Text = dReader(10)
                        frmPOS.txttotalPrice.Text = frmPOS.txttotalPrice.Text.Replace(",", "")
                        Format(frmPOS.txttotalPrice.Text, "#,##0.00")
                    Loop
                Case "autonumber"
                    Do While dReader.Read = True
                        autonumber = dReader(0)

                    Loop
              
                Case "login"
                    Do While dReader.Read = True
                        userID = dReader("EMPID")
                        usertype = dReader("EMPPOSITION")
                        fullname = dReader("EMPNAME") 
                    Loop
                Case "DailyCollection"
                    Do While dReader.Read = True
                        Form1.txtdailycollection.Text = dReader(0)
                    Loop


            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            da.Dispose()
            MyConn.Close()
        End Try
    End Sub
    Public Sub LoadData(ByVal obj As Object, ByVal param As String)
        Try

            MyConn.Open()
            dReader = cmd.ExecuteReader()
            '  obj.Rows.Clear()
            Select Case param
                Case "category"
                    obj.Rows.Clear()
                    Do While dReader.Read = True
                        obj.Rows.Add(dReader(0), dReader(1), dReader(2))
                    Loop
                Case "employee"
                    obj.Rows.Clear()
                    Do While dReader.Read = True
                        obj.Rows.Add(dReader(0), dReader(1), dReader(2), dReader(3), dReader(4), dReader(5))
                    Loop
                Case "Items"
                    obj.Rows.Clear()
                    Do While dReader.Read = True
                        obj.Rows.Add(dReader(0), dReader(1), dReader(2), dReader(3), dReader(4), dReader(5), dReader(6), dReader(7), dReader(8), Format(dReader(9), "yyyy-MM-dd"), dReader(10), dReader(11))
                    Loop
                Case "AvailItems"
                    obj.Rows.Clear()
                    Do While dReader.Read = True
                        If dReader(7) = 0 Then
                        Else
                            obj.Rows.Add(dReader(0), dReader(1), dReader(2), dReader(3), dReader(4), dReader(5), dReader(6), dReader(7), dReader(8), Format(dReader(9), "yyyy-MM-dd"), dReader(10))

                        End If
                    Loop
                Case "soLDItems"
                    obj.Rows.Clear()
                    Do While dReader.Read = True
                        If dReader(7) = 0 Then
                            obj.Rows.Add(dReader(0), dReader(1), dReader(2), dReader(3), dReader(4), dReader(5), dReader(6), dReader(7), dReader(8), Format(dReader(9), "yyyy-MM-dd"), dReader(10))

                        End If
                    Loop
                Case "findItems"
                    obj.Rows.Clear()
                    Do While dReader.Read = True 
                        obj.Rows.Add(dReader(0), dReader(1))
                    Loop
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            da.Dispose()
            MyConn.Close()
        End Try
    End Sub
    Public Sub fillTable(ByVal dtgrd As Object, ByVal design As String)
        Dim publictable As New DataTable
        Dim total As Double
        Try

       
            da.SelectCommand = cmd
            da.Fill(publictable)
            dtgrd.DataSource = publictable

            Select Case design
                Case "DailCash"
                    dtgrd.Columns(0).width = 90
                    dtgrd.Columns(1).width = 100
                    dtgrd.Columns(2).width = 150
                    dtgrd.Columns(3).width = 150
                    For i As Integer = 0 To dtgrd.RowCount - 1
                        total += dtgrd.Rows(i).Cells(3).Value
                    Next
                    publictable.Rows.Add(Nothing, Nothing, "Total", total)

                Case "DailyDiscountedCash"
                    dtgrd.Columns(0).width = 90
                    dtgrd.Columns(1).width = 100
                    dtgrd.Columns(2).width = 150
                    dtgrd.Columns(3).width = 150
            End Select

            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

End Module
