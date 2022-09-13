Imports System.Data.OleDb
Public Class frmBillling
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Dim s1, s2, s3, s4 As String
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub
    Sub StartBillNo()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT StartBillNo from Hotel"
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtStartBillNo.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim OleDb As String = ("SELECT MAX(BillID) FROM RestaurantBillingInfo")
            cmd = New OleDbCommand(OleDb)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                lblBillNo.Text = txtStartBillNo.Text
            Else
                Num = cmd.ExecuteScalar + 1
                lblBillNo.Text = Num.ToString
            End If
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub auto1()
        Try
            Dim Num As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim OleDb As String = ("SELECT MAX(TicketID) FROM KOTGeneration")
            cmd = New OleDbCommand(OleDb)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                lblKOTNo.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                lblKOTNo.Text = Num.ToString
            End If
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillAvailableTables()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmdText1 As String = "SELECT RTRIM(R_Table.TableNo) from R_Table where Status='Activate' Order by TableNo"
            cmd = New OleDbCommand(cmdText1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            flpTables.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.BackColor = Color.White
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 40
                btn.Height = 40
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                flpTables.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            txtTableNo.Text = str
            cmbGroup.Enabled = True
            DataGridView1.Rows.Clear()
            Clear()
            FillMenuItems()
            FillGroup()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub frmBillling_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
        End If
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            btnNewBill.PerformClick()
        End If
        If e.KeyCode = Keys.F2 Then
            e.Handled = True
            btnSave.PerformClick()
        End If
      
        If e.KeyCode = Keys.F3 Then
            e.Handled = True
            btnCancel.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            btnChangeTable.PerformClick()
        End If
        If e.KeyCode = Keys.F4 Then
            e.Handled = True
            btnLock.PerformClick()
        End If
        If e.KeyCode = Keys.F6 Then
            e.Handled = True
            btnBillNote.PerformClick()
        End If
        If e.KeyCode = Keys.F7 And btnDeleteRow.Enabled = True Then
            e.Handled = True
            btnDeleteRow.PerformClick()
        End If
        If e.KeyCode = Keys.F8 Then
            e.Handled = True
            btnGetCash.PerformClick()
        End If
        If e.KeyCode = Keys.F9 Then
            e.Handled = True
            btnItemNote.PerformClick()
        End If
    End Sub
    Private Sub frmBillling_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillAvailableTables()
        FillMenuItems1()
        StartBillNo()
    End Sub

    Private Sub cmbBillType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbBillType.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmbGroup.Focus()
        End If
    End Sub

    Private Sub cmbBillType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbBillType.SelectedIndexChanged
        If cmbBillType.Text = "Dine-In" Then
            cmbPaymentMode.Enabled = False
            txtDiscountPer.ReadOnly = True
            txtDiscount.ReadOnly = True
            txtCash.ReadOnly = True
        Else
            cmbPaymentMode.Enabled = True
            txtDiscountPer.ReadOnly = False
            txtDiscount.ReadOnly = False
            txtCash.ReadOnly = False
        End If
        If cmbBillType.Text = "Takeaway" Then
            txtTACharges.Visible = True
            lblTACharges.Visible = True
            FillMenuItems1()
        Else
            txtTACharges.Visible = False
            lblTACharges.Visible = False
        End If
    End Sub
    Sub Reset()
        txtAddressLine1.ReadOnly = False
        txtAddressLine2.ReadOnly = False
        txtAddressLine3.ReadOnly = False
        txtCustomerName.ReadOnly = False
        txtContactNo.ReadOnly = False
        txtAddressLine1.Text = ""
        txtAddressLine2.Text = ""
        txtAddressLine3.Text = ""
        txtCustomerName.Text = ""
        txtContactNo.Text = ""
        txtTableNo.Text = ""
        cmbBillType.Text = "KOT"
        cmbPaymentMode.Text = ""
        cmbGroup.Text = ""
        cmbGroup.Enabled = False
        cmbPaymentMode.Enabled = False
        Clear()
        DataGridView1.Rows.Clear()
        btnDeleteRow.Enabled = False
        txtTACharges.Visible = False
        txtHDCharges.Visible = False
        lblTACharges.Visible = False
        lblHDCharges.Visible = False
        btnItemNote.Enabled = False
        txtDiscountPer.ReadOnly = True
        txtDiscount.ReadOnly = True
        txtCash.ReadOnly = True
        DataGridView2.Visible = False
        fillTableNo()
        auto()
        txtTableNo.Focus()
    End Sub

    Private Sub btnLock_Click(sender As System.Object, e As System.EventArgs) Handles btnLock.Click
        frmLock.UserID.Text = lblUser.Text
        frmLock.ShowDialog()
        frmLock.Password.Focus()
    End Sub

    Private Sub btnNewBill_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill.Click
        Reset()
    End Sub
    Sub FillMenuItems()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT DishName from Dish,R_Table,InventoryType where Dish.InventoryType=InventoryType.Type and R_Table.InventoryType=InventoryType.Type and R_Table.TableNo=@d1 order by 1"
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            Dim cmbItem As DataGridViewComboBoxColumn
            cmbItem = DataGridView1.Columns("Item")
            cmbItem.Items.Clear()
            While rdr.Read()
                cmbItem.Items.Add(rdr(0).ToString())
            End While
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub FillMenuItems1()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT DishName from Dish order by 1"
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            Dim cmbItem As DataGridViewComboBoxColumn
            cmbItem = DataGridView1.Columns("Item")
            cmbItem.Items.Clear()
            While rdr.Read()
                cmbItem.Items.Add(rdr(0).ToString())
            End While
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub comboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedIndex As Integer = DirectCast(sender, ComboBox).SelectedIndex
    End Sub

 
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            If Len(Trim(cmbBillType.Text)) = 0 Then
                MessageBox.Show("Please select bill type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbBillType.Focus()
                Exit Sub
            End If
            If cmbBillType.Text = "KOT" Then
                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT DishName,VAT,ST,SC,Discount,Rate from Dish,R_Table,InventoryType,Category where Dish.InventoryType=InventoryType.Type and R_Table.InventoryType=InventoryType.Type and Category.Categoryname=Dish.Category and R_Table.TableNo=@d1 and ItemID=@d2"
                cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
                cmd.Parameters.AddWithValue("@d2", Val(DataGridView1.Rows(e.RowIndex).Cells("ItemCode").Value))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    DataGridView1.Rows(e.RowIndex).Cells("Item").Value = rdr.GetValue(0)
                    If DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = Nothing Then
                        DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = 1
                    End If
                    DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value = rdr.GetValue(1)
                    DataGridView1.Rows(e.RowIndex).Cells("STPer").Value = rdr.GetValue(2)
                    DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value = rdr.GetValue(3)
                    DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value = rdr.GetValue(4)
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Value = rdr.GetValue(5)

                    Dim num1, num2, num3, num4, num5, num6, num7 As Double

                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("Rate").Value)
                    num1 = Math.Round(num1, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Amount").Value = num1
                    num2 = (Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value - Val(txtDiscount.Text))
                    num4 = (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) * Val(num3)) / 100
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VAT").Value = num4
                    num5 = (Val(DataGridView1.Rows(e.RowIndex).Cells("STPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num5, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("ST").Value = num5
                    num6 = (Val(DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("SC").Value = num6
                    num7 = CDbl(Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("VAT").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("ST").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("SC").Value) + Val(txtTACharges.Text) + Val(txtHDCharges.Text) - Val(txtDiscount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num7
                    TotalCalc()

                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT ItemID,VAT,ST,SC,Discount,Rate from Dish,R_Table,InventoryType,Category where Dish.InventoryType=InventoryType.Type and R_Table.InventoryType=InventoryType.Type and Category.Categoryname=Dish.Category and R_Table.TableNo=@d1 and DishName=@d2"
                cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
                cmd.Parameters.AddWithValue("@d2", DataGridView1.Rows(e.RowIndex).Cells("Item").Value)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    DataGridView1.Rows(e.RowIndex).Cells("ItemCode").Value = rdr.GetValue(0)
                    If DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = Nothing Then
                        DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = 1
                    End If
                    DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value = rdr.GetValue(1)
                    DataGridView1.Rows(e.RowIndex).Cells("STPer").Value = rdr.GetValue(2)
                    DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value = rdr.GetValue(3)
                    DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value = rdr.GetValue(4)
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Value = rdr.GetValue(5)

                    Dim num1, num2, num3, num4, num5, num6, num7 As Double

                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("Rate").Value)
                    num1 = Math.Round(num1, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Amount").Value = num1
                    num2 = (Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value - Val(txtDiscount.Text))
                    num4 = (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) * Val(num3)) / 100
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VAT").Value = num4
                    num5 = (Val(DataGridView1.Rows(e.RowIndex).Cells("STPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num5, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("ST").Value = num5
                    num6 = (Val(DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("SC").Value = num6
                    num7 = CDbl(Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("VAT").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("ST").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("SC").Value) + Val(txtTACharges.Text) + Val(txtHDCharges.Text) - Val(txtDiscount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num7
                    TotalCalc()

                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
            If cmbBillType.Text = "Takeaway" Or cmbBillType.Text = "Express Billing" Or cmbBillType.Text = "Home Delivery" Then
                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT DishName,VAT,ST,SC,Discount,Rate from Dish,Category where Category.Categoryname=Dish.Category and ItemID=@d2"
                cmd.Parameters.AddWithValue("@d2", Val(DataGridView1.Rows(e.RowIndex).Cells("ItemCode").Value))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    DataGridView1.Rows(e.RowIndex).Cells("Item").Value = rdr.GetValue(0)
                    If DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = Nothing Then
                        DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = 1
                    End If
                    DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value = rdr.GetValue(1)
                    DataGridView1.Rows(e.RowIndex).Cells("STPer").Value = rdr.GetValue(2)
                    DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value = rdr.GetValue(3)
                    DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value = rdr.GetValue(4)
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Value = rdr.GetValue(5)

                    Dim num1, num2, num3, num4, num5, num6, num7 As Double

                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("Rate").Value)
                    num1 = Math.Round(num1, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Amount").Value = num1
                    num2 = (Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value - Val(txtDiscount.Text))
                    num4 = (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) * Val(num3)) / 100
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VAT").Value = num4
                    num5 = (Val(DataGridView1.Rows(e.RowIndex).Cells("STPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num5, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("ST").Value = num5
                    num6 = (Val(DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("SC").Value = num6
                    num7 = CDbl(Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("VAT").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("ST").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("SC").Value) + Val(txtTACharges.Text) + Val(txtHDCharges.Text) - Val(txtDiscount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num7
                    TotalCalc()

                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

                con = New OleDbConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT ItemID,VAT,ST,SC,Discount,Rate from Dish,Category where Category.Categoryname=Dish.Category and DishName=@d2"
                cmd.Parameters.AddWithValue("@d2", DataGridView1.Rows(e.RowIndex).Cells("Item").Value)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    DataGridView1.Rows(e.RowIndex).Cells("ItemCode").Value = rdr.GetValue(0)
                    If DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = Nothing Then
                        DataGridView1.Rows(e.RowIndex).Cells("Qty").Value = 1
                    End If
                    DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value = rdr.GetValue(1)
                    DataGridView1.Rows(e.RowIndex).Cells("STPer").Value = rdr.GetValue(2)
                    DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value = rdr.GetValue(3)
                    DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value = rdr.GetValue(4)
                    DataGridView1.Rows(e.RowIndex).Cells("Rate").Value = rdr.GetValue(5)

                    Dim num1, num2, num3, num4, num5, num6, num7 As Double

                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("Rate").Value)
                    num1 = Math.Round(num1, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Amount").Value = num1
                    num2 = (Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value - Val(txtDiscount.Text))
                    num4 = (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) * Val(num3)) / 100
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VAT").Value = num4
                    num5 = (Val(DataGridView1.Rows(e.RowIndex).Cells("STPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num5, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("ST").Value = num5
                    num6 = (Val(DataGridView1.Rows(e.RowIndex).Cells("SCPer").Value) * Val(num3)) / 100
                    num5 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("SC").Value = num6
                    num7 = CDbl(Val(DataGridView1.Rows(e.RowIndex).Cells("Amount").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("VAT").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("ST").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("SC").Value) + Val(txtTACharges.Text) + Val(txtHDCharges.Text) - Val(txtDiscount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num7
                    TotalCalc()

                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(13).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalST() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(8).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotlVAT() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(6).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalSC() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalItemDiscount() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(12).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalAmt() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(4).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub txtTACharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTACharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTACharges.Text
            Dim selectionStart = Me.txtTACharges.SelectionStart
            Dim selectionLength = Me.txtTACharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtHDCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHDCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtHDCharges.Text
            Dim selectionStart = Me.txtHDCharges.SelectionStart
            Dim selectionLength = Me.txtHDCharges.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscountPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscountPer.Text
            Dim selectionStart = Me.txtDiscountPer.SelectionStart
            Dim selectionLength = Me.txtDiscountPer.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscount.Text
            Dim selectionStart = Me.txtDiscount.SelectionStart
            Dim selectionLength = Me.txtDiscount.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Sub Compute()
        Dim num2, num3, num7 As Double
        num2 = (Val(txtSubTotal.Text) * Val(txtDiscountPer.Text)) / 100
        num2 = Math.Round(num2, 2)
        txtDiscount.Text = num2
        num3 = num2 + Val(txtItemDiscount.Text)
        num7 = CDbl(Val(txtSubTotal.Text) + Val(txtVAT.Text) + Val(txtServiceTax.Text) + Val(txtTACharges.Text) + Val(txtServiceCharges.Text) + Val(txtHDCharges.Text) - Val(txtDiscount.Text) - Val(txtItemDiscount.Text))
        num7 = Math.Round(num7, 2)
        txtGrandTotal.Text = num7
    End Sub

    Private Sub txtTACharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTACharges.TextChanged
        Compute()
    End Sub

    Private Sub txtHDCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtHDCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscountPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountPer.TextChanged
        Compute()
    End Sub

    Sub Clear()
        txtSubTotal.Text = "0.00"
        txtItemDiscount.Text = "0.00"
        txtDiscountPer.Text = "0.00"
        txtDiscount.Text = "0.00"
        txtVAT.Text = "0.00"
        txtServiceTax.Text = "0.00"
        txtServiceCharges.Text = "0.00"
        txtTACharges.Text = "0.00"
        txtHDCharges.Text = "0.00"
        txtGrandTotal.Text = "0.00"
        txtCash.Text = "0.00"
        txtChange.Text = "0.00"
    End Sub
    Sub TotalCalc()
        Dim m As Double = 0
        m = TotalAmt()
        m = Math.Round(m, 2)
        txtSubTotal.Text = m
        Compute()
        Dim j As Double = 0
        j = TotlVAT()
        j = Math.Round(j, 2)
        txtVAT.Text = j

        Dim k As Double = 0
        k = TotalST()
        k = Math.Round(k, 2)
        txtServiceTax.Text = k

        Dim l As Double = 0
        l = TotalSC()
        l = Math.Round(l, 2)
        txtServiceCharges.Text = l



        Dim n As Double = 0
        n = TotalItemDiscount()
        n = Math.Round(n, 2)
        txtItemDiscount.Text = n
        Dim i As Double = 0
        i = GrandTotal()
        i = Math.Round(i, 2)
        txtGrandTotal.Text = i
    End Sub
 
    Sub Remove()
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            TotalCalc()
            btnDeleteRow.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDeleteRow_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteRow.Click
        Remove()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            btnDeleteRow.Enabled = True
            btnItemNote.Enabled = True
        End If
        
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        DataGridView1.Rows.Clear()
        TotalCalc()
        btnDeleteRow.Enabled = False
    End Sub

    Sub Settle()
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into PosGrouping(Col1,Col2,Col3,Col4,Col5,Col6,Col7,Col8,Col9,Col10,Col11,Col12,Col13,Col14,Col15) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                cmd = New OleDbCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d14", Val(row.Cells(13).Value))
                        If row.Cells(14).Value = Nothing Then
                            cmd.Parameters.AddWithValue("@d15", "")
                        Else
                            cmd.Parameters.AddWithValue("@d15", row.Cells(14).Value)
                        End If

                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                cmd = New OleDbCommand("SELECT Col1,Col2,Sum(Col3),Col4,Sum(Col5),(Col6),Sum(Col7),(Col8),Sum(Col9),(Col10),SUM(Col11),(Col12),Sum(Col13),Sum(Col14),Col15 from PosGrouping group by Col1,Col2,Col4,Col6,Col8,Col10,col12,Col15 order by Col2", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
                End While
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb2 As String = "delete from PosGrouping"
                cmd = New OleDbCommand(cb2)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
                DataGridView1.ClearSelection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBillNote_Click(sender As System.Object, e As System.EventArgs) Handles btnBillNote.Click
        frmNotes1.Reset()
        frmNotes1.ShowDialog()
    End Sub

    Private Sub btnItemNote_Click(sender As System.Object, e As System.EventArgs) Handles btnItemNote.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                frmNotes.txtNotes.Text = dr.Cells(14).Value
                frmNotes.ShowDialog()
                btnItemNote.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTableNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTableNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cmbBillType.Focus()
        End If
    End Sub

    Private Sub txtTableNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTableNo.TextChanged
        Try
            cmbGroup.Enabled = True
            DataGridView1.Rows.Clear()
            Clear()
            FillMenuItems()
            FillGroup()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub btnGetCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCash.Click
        frmGetCash.txtCash.Text = ""
        frmGetCash.ShowDialog()
    End Sub
    Sub Calc()
        If DataGridView1.Rows.Count > 0 Then
            Dim num As Decimal
            num = Val(txtCash.Text) - Val(txtGrandTotal.Text)
            num = Math.Round(num, 2)
            If num < 0 Then
                txtChange.Text = "0.00"
            Else
                txtChange.Text = num
            End If
        End If
    End Sub

    Private Sub txtCash_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged
        Calc()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(cmbBillType.Text)) = 0 Then
                MessageBox.Show("Please select bill type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbBillType.Focus()
                Exit Sub
            End If
            If cmbBillType.Text = "KOT" Then
                If Len(Trim(txtTableNo.Text)) = 0 Then
                    MessageBox.Show("Please enter table no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtTableNo.Focus()
                    Exit Sub
                End If
                Settle()
                auto1()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cl As String = "insert into KOTGeneration(TicketID, BillDate, TableNo, GroupName, GrandTotal, OperatorID, BillNote, Status) Values (" & lblKOTNo.Text & ",#" & System.DateTime.Now & "#,@d1,@d2,@d3,@d4,@d5,'Unpaid')"
                cmd = New OleDbCommand(cl)
                cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
                cmd.Parameters.AddWithValue("@d2", cmbGroup.Text)
                cmd.Parameters.AddWithValue("@d3", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d4", lblUser.Text)
                cmd.Parameters.AddWithValue("@d5", txtNotes.Text)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into KOTGenerationItems(Ticket_ID, Item_ID, Qty, Rate, Amount, DiscPer, Disc, VATPer, VATAmt, STPer, STAmt, SCPer, SCAmt, TotalAmt, ItemNote) VALUES (" & lblKOTNo.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
                cmd = New OleDbCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(13).Value))
                        If row.Cells(14).Value = "" Then
                            cmd.Parameters.AddWithValue("@d14", "")
                        Else
                            cmd.Parameters.AddWithValue("@d14", row.Cells(14).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                Dim st As String = "added the new KOT having KOT no. '" & lblKOTNo.Text & "'"
                LogFunc(lblUser.Text, st)
                Print()
                Reset()
            End If

            If cmbBillType.Text = "KOT Billing" Then
                If Len(Trim(cmbPaymentMode.Text)) = 0 Then
                    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbPaymentMode.Focus()
                    Exit Sub
                End If
                Settle()
                auto()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cl As String = "insert into RestaurantBillingInfo(BillId, BillType, BillDate, CustomerName, AddressLine1, AddressLine2, AddressLine3, ContactNo, PaymentMode, SubTotal, ItemDiscount, DiscountPer, Discount, VAT, ServiceTax, ServiceCharges,TACharges, HDCharges, GrandTotal, Cash, Change, OperatorID, BillNote) Values (" & lblBillNo.Text & ",@d1,#" & System.DateTime.Now & "#,@d2,@d3,@d4,@d5,@d6,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
                cmd = New OleDbCommand(cl)
                cmd.Parameters.AddWithValue("@d1", cmbBillType.Text)
                cmd.Parameters.AddWithValue("@d2", txtCustomerName.Text)
                cmd.Parameters.AddWithValue("@d3", txtAddressLine1.Text)
                cmd.Parameters.AddWithValue("@d4", txtAddressLine2.Text)
                cmd.Parameters.AddWithValue("@d5", txtAddressLine3.Text)
                cmd.Parameters.AddWithValue("@d6", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@d8", cmbPaymentMode.Text)
                cmd.Parameters.AddWithValue("@d9", Val(txtSubTotal.Text))
                cmd.Parameters.AddWithValue("@d10", Val(txtItemDiscount.Text))
                cmd.Parameters.AddWithValue("@d11", Val(txtDiscountPer.Text))
                cmd.Parameters.AddWithValue("@d12", Val(txtDiscount.Text))
                cmd.Parameters.AddWithValue("@d13", Val(txtVAT.Text))
                cmd.Parameters.AddWithValue("@d14", Val(txtServiceTax.Text))
                cmd.Parameters.AddWithValue("@d15", Val(txtServiceCharges.Text))
                cmd.Parameters.AddWithValue("@d16", Val(txtTACharges.Text))
                cmd.Parameters.AddWithValue("@d17", Val(txtHDCharges.Text))
                cmd.Parameters.AddWithValue("@d18", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d19", Val(txtCash.Text))
                cmd.Parameters.AddWithValue("@d20", Val(txtChange.Text))
                cmd.Parameters.AddWithValue("@d21", lblUser.Text)
                cmd.Parameters.AddWithValue("@d22", txtNotes.Text)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into RestaurantBillingItems(B_ID, Item_ID, Qty, Rate, Amount, DiscPer, Disc, VATPer, VATAmt, STPer, STAmt, SCPer, SCAmt, TotalAmt,TableNo,GroupName) VALUES (" & lblBillNo.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15)"
                cmd = New OleDbCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(13).Value))
                        cmd.Parameters.AddWithValue("@d14", row.Cells(14).Value)
                        cmd.Parameters.AddWithValue("@d15", row.Cells(15).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                Dim st As String = "added the new restaurant bill having bill no. '" & lblBillNo.Text & "'"
                LogFunc(lblUser.Text, st)

                For Each row As DataGridViewRow In DataGridView2.Rows
                    If Not row.IsNewRow Then
                        con = New OleDbConnection(cs)
                        con.Open()
                        Dim cb As String = "update KOTgeneration Set Status='Paid' where TableNo=@d1 and GroupName=@d2"
                        cmd = New OleDbCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(14).Value)
                        cmd.Parameters.AddWithValue("@d2", row.Cells(15).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                Print1()
                Reset()
            End If
            If cmbBillType.Text = "Home Delivery" Or cmbBillType.Text = "Takeaway" Or cmbBillType.Text = "Express Billing" Then
                If Len(Trim(cmbPaymentMode.Text)) = 0 Then
                    MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbPaymentMode.Focus()
                    Exit Sub
                End If
                If cmbBillType.Text = "Home Delivery" Then
                    If Len(Trim(txtCustomerName.Text)) = 0 Then
                        MessageBox.Show("Please enter customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCustomerName.Focus()
                        Exit Sub
                    End If
                    If Len(Trim(txtAddressLine1.Text)) = 0 Then
                        MessageBox.Show("Please enter address line 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtAddressLine1.Focus()
                        Exit Sub
                    End If
                    If Len(Trim(txtAddressLine2.Text)) = 0 Then
                        MessageBox.Show("Please enter address line 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtAddressLine2.Focus()
                        Exit Sub
                    End If
                    If Len(Trim(txtContactNo.Text)) = 0 Then
                        MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtContactNo.Focus()
                        Exit Sub
                    End If
                End If
                Settle()
                auto()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cl As String = "insert into RestaurantBillingInfo(BillId, BillType, BillDate, CustomerName, AddressLine1, AddressLine2, AddressLine3, ContactNo, PaymentMode, SubTotal, ItemDiscount, DiscountPer, Discount, VAT, ServiceTax, ServiceCharges,TACharges, HDCharges, GrandTotal, Cash, Change, OperatorID, BillNote) Values (" & lblBillNo.Text & ",@d1,#" & System.DateTime.Now & "#,@d2,@d3,@d4,@d5,@d6,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22)"
                cmd = New OleDbCommand(cl)
                cmd.Parameters.AddWithValue("@d1", cmbBillType.Text)
                cmd.Parameters.AddWithValue("@d2", txtCustomerName.Text)
                cmd.Parameters.AddWithValue("@d3", txtAddressLine1.Text)
                cmd.Parameters.AddWithValue("@d4", txtAddressLine2.Text)
                cmd.Parameters.AddWithValue("@d5", txtAddressLine3.Text)
                cmd.Parameters.AddWithValue("@d6", txtContactNo.Text)
                cmd.Parameters.AddWithValue("@d8", cmbPaymentMode.Text)
                cmd.Parameters.AddWithValue("@d9", Val(txtSubTotal.Text))
                cmd.Parameters.AddWithValue("@d10", Val(txtItemDiscount.Text))
                cmd.Parameters.AddWithValue("@d11", Val(txtDiscountPer.Text))
                cmd.Parameters.AddWithValue("@d12", Val(txtDiscount.Text))
                cmd.Parameters.AddWithValue("@d13", Val(txtVAT.Text))
                cmd.Parameters.AddWithValue("@d14", Val(txtServiceTax.Text))
                cmd.Parameters.AddWithValue("@d15", Val(txtServiceCharges.Text))
                cmd.Parameters.AddWithValue("@d16", Val(txtTACharges.Text))
                cmd.Parameters.AddWithValue("@d17", Val(txtHDCharges.Text))
                cmd.Parameters.AddWithValue("@d18", Val(txtGrandTotal.Text))
                cmd.Parameters.AddWithValue("@d19", Val(txtCash.Text))
                cmd.Parameters.AddWithValue("@d20", Val(txtChange.Text))
                cmd.Parameters.AddWithValue("@d21", lblUser.Text)
                cmd.Parameters.AddWithValue("@d22", txtNotes.Text)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                con = New OleDbConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into RestaurantBillingItems(B_ID, Item_ID, Qty, Rate, Amount, DiscPer, Disc, VATPer, VATAmt, STPer, STAmt, SCPer, SCAmt, TotalAmt, ItemNote) VALUES (" & lblBillNo.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
                cmd = New OleDbCommand(cb1)
                cmd.Connection = con
                ' Prepare command for repeated execution
                cmd.Prepare()
                ' Data to be inserted
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(3).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(4).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d6", Val(row.Cells(6).Value))
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(7).Value))
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(9).Value))
                        cmd.Parameters.AddWithValue("@d10", Val(row.Cells(10).Value))
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(11).Value))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(12).Value))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(13).Value))
                        If row.Cells(14).Value = "" Then
                            cmd.Parameters.AddWithValue("@d14", "")
                        Else
                            cmd.Parameters.AddWithValue("@d14", row.Cells(14).Value)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                If cmbBillType.Text = "Express Billing" Then
                    Print2()
                End If
                If cmbBillType.Text = "Takeaway" Then
                    Print3()
                End If
                If cmbBillType.Text = "Home Delivery" Then
                    Print4()
                End If
                Dim st As String = "added the new restaurant bill having bill no. '" & lblBillNo.Text & "'"
                LogFunc(lblUser.Text, st)
                Reset()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtCash_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash.Text
            Dim selectionStart = Me.txtCash.SelectionStart
            Dim selectionLength = Me.txtCash.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnChangeTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeTable.Click
        Try
            If txtTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "Select TableNo from KOTGeneration where Status='Unpaid' and TableNo=@d1"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog1.ShowDialog()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                txtTableNo.Text = ""
                Return
            End If
            frmAvailableTables.lblTable.Text = txtTableNo.Text.Trim()
            frmAvailableTables.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillGroup()
        Try
            cmbGroup.Text = ""
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("Select distinct RTRIM(GroupName) from KOTgeneration where TableNo=@d1 and Status='Unpaid' order by 1", con)
            cmd.Parameters.AddWithValue("@d1", txtTableNo.Text)
            rdr = cmd.ExecuteReader()
            cmbGroup.Items.Clear()
            While rdr.Read()
                cmbGroup.Items.Add(rdr(0))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lvTable_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvTable.ItemChecked
        Try

            If lvTable.CheckedItems.Count > 0 Then
                Dim Condition As String = ""
                Dim Condition1 As String = ""
                For I = 0 To lvTable.CheckedItems.Count - 1

                    Condition += String.Format("'{0}',", lvTable.CheckedItems(I).Text)
                    Condition1 += String.Format("'{0}',", lvTable.CheckedItems(I).SubItems(1).Text)
                Next
                Condition = Condition.Substring(0, Condition.Length - 1)
                Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                DataGridView2.Visible = True
                con = New OleDbConnection(cs)
                con.Open()
                Dim OleDb As String = "Select Item_ID,DishName, SUM(Qty), KOTGenerationItems.Rate, SUM(Amount), DiscPer, SUM(Disc), VATPer, SUM(VATAmt), STPer, SUM(STAmt), SCPer, SUM(SCAmt), SUM(TotalAmt),TableNo,GroupName from KOTGeneration,KOTGenerationItems,Dish where KOTGeneration.TicketID=KOTGenerationItems.Ticket_ID and KOTGenerationItems.Item_ID=Dish.ItemID and TableNo in (" & Condition & ") and GroupName in (" & Condition1 & ")   group by Item_ID,DishName,KOTGenerationItems.Rate,DiscPer,VATPer,STPer,SCPer,TableNo,GroupName order by TableNo"
                cmd = New OleDbCommand(OleDb, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView2.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
                txtCash.Text = "0.00"
                TotalCalc1()
                Calc()
            Else
                Clear()
                DataGridView2.Rows.Clear()
                DataGridView2.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillTableNo()
        Try
            Dim _with1 = lvTable
            _with1.Clear()
            _with1.Columns.Add("Table No.", 120, HorizontalAlignment.Left)
            _with1.Columns.Add("Customer", 240, HorizontalAlignment.Left)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT distinct RTRIM(R_Table.TableNo),RTRIM(GroupName) FROM R_Table,KOTGeneration where KOTGeneration.TableNo=R_Table.TableNo and KOTgeneration.Status='Unpaid' and R_Table.Status='Activate'", con)
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                lvTable.Items.Add(item)
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function GrandTotal1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(13).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalST1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(8).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotlVAT1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(6).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalSC1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalItemDiscount1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(12).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function TotalAmt1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(4).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub TotalCalc1()
        Dim m As Double = 0
        m = TotalAmt1()
        m = Math.Round(m, 2)
        txtSubTotal.Text = m
        Compute()
        Dim j As Double = 0
        j = TotlVAT1()
        j = Math.Round(j, 2)
        txtVAT.Text = j

        Dim k As Double = 0
        k = TotalST1()
        k = Math.Round(k, 2)
        txtServiceTax.Text = k

        Dim l As Double = 0
        l = TotalSC1()
        l = Math.Round(l, 2)
        txtServiceCharges.Text = l
        Dim n As Double = 0
        n = TotalItemDiscount1()
        n = Math.Round(n, 2)
        txtItemDiscount.Text = n
        Dim i As Double = 0
        i = GrandTotal1()
        i = Math.Round(i, 2)
        txtGrandTotal.Text = i
    End Sub

    Private Sub cmbPaymentMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged
        If cmbPaymentMode.Text = "Cash" Then
            txtCash.Text = "0.00"
        Else
            txtCash.Text = txtGrandTotal.Text
            Calc()
        End If
    End Sub

    Sub PrintKOT()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSKOTInvoice 'The report you created.
        Dim myConnection As OleDbConnection
        Dim MyCommand, MyCommand1 As New OleDbCommand()
        Dim myDA, myDA1 As New OleDbDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New OleDbConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT KOTGeneration.TicketID, KOTGeneration.BillDate, KOTGeneration.TableNo, KOTGeneration.GroupName, KOTGeneration.GrandTotal, KOTGeneration.OperatorID, KOTGeneration.BillNote, KOTGeneration.Status,KOTGenerationItems.KOT_ID, KOTGenerationItems.Ticket_ID, KOTGenerationItems.Item_ID, KOTGenerationItems.Qty, KOTGenerationItems.Rate, KOTGenerationItems.Amount, KOTGenerationItems.DiscPer,KOTGenerationItems.Disc, KOTGenerationItems.VATPer, KOTGenerationItems.VATAmt, KOTGenerationItems.STPer, KOTGenerationItems.STAmt, KOTGenerationItems.SCPer, KOTGenerationItems.SCAmt,KOTGenerationItems.TotalAmt, KOTGenerationItems.ItemNote, Dish.ItemID, Dish.Dishname, Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount FROM ((KOTGeneration INNER JOIN KOTGenerationItems ON KOTGeneration.TicketID = KOTGenerationItems.Ticket_ID) INNER JOIN Dish ON KOTGenerationItems.Item_ID = Dish.ItemID) where TicketID=" & lblKOTNo.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "KOTGeneration")
        myDA.Fill(myDS, "KOTGenerationItems")
        myDA.Fill(myDS, "Dish")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New OleDbConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where PrinterType='Ticket Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub PrintKOT_Kitchen()
        Dim CN As New OleDbConnection(cs)
        CN.Open()
        adp = New OleDbDataAdapter()
        adp.SelectCommand = New OleDbCommand("SELECT DISTINCT Kitchen.KitchenName FROM (((Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.KitchenName) INNER JOIN KOTGenerationItems ON Dish.ItemID = KOTGenerationItems.Item_ID) INNER JOIN KOTGeneration ON KOTGenerationItems.Ticket_ID = KOTGeneration.TicketID) where TicketID=" & lblKOTNo.Text & "", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSKOTInvoice_Kitchen 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand, MyCommand1 As New OleDbCommand()
            Dim myDA, myDA1 As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT KOTGeneration.TicketID, KOTGeneration.BillDate, KOTGeneration.TableNo, KOTGeneration.GroupName, KOTGeneration.GrandTotal, KOTGeneration.OperatorID, KOTGeneration.BillNote, KOTGeneration.Status,KOTGenerationItems.KOT_ID, KOTGenerationItems.Ticket_ID, KOTGenerationItems.Item_ID, KOTGenerationItems.Qty, KOTGenerationItems.Rate, KOTGenerationItems.Amount, KOTGenerationItems.DiscPer,KOTGenerationItems.Disc, KOTGenerationItems.VATPer, KOTGenerationItems.VATAmt, KOTGenerationItems.STPer, KOTGenerationItems.STAmt, KOTGenerationItems.SCPer, KOTGenerationItems.SCAmt,KOTGenerationItems.TotalAmt, KOTGenerationItems.ItemNote, Dish.ItemID, Dish.Dishname, Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount FROM ((KOTGeneration INNER JOIN KOTGenerationItems ON KOTGeneration.TicketID = KOTGenerationItems.Ticket_ID) INNER JOIN Dish ON KOTGenerationItems.Item_ID = Dish.ItemID) where TicketID=" & lblKOTNo.Text & " and Kitchen=@d1"
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "KOTGeneration")
            myDA.Fill(myDS, "KOTGenerationItems")
            myDA.Fill(myDS, "Dish")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next

    End Sub
    Sub Print()
        Try
            PrintKOT()
            PrintKOT_Kitchen()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print1()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSFinalBillKOTInvoice 'The report you created.
        Dim myConnection As OleDbConnection
        Dim MyCommand, MyCommand1 As New OleDbCommand()
        Dim myDA, myDA1 As New OleDbDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New OleDbConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantBillingInfo")
        myDA.Fill(myDS, "RestaurantBillingItems")
        myDA.Fill(myDS, "Dish")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New OleDbConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub PrintEB()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSEBInvoice 'The report you created.
        Dim myConnection As OleDbConnection
        Dim MyCommand, MyCommand1 As New OleDbCommand()
        Dim myDA, myDA1 As New OleDbDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New OleDbConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantBillingInfo")
        myDA.Fill(myDS, "RestaurantBillingItems")
        myDA.Fill(myDS, "Dish")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New OleDbConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Sub PrintEB_Kitchen()
        Dim CN As New OleDbConnection(cs)
        CN.Open()
        adp = New OleDbDataAdapter()
        adp.SelectCommand = New OleDbCommand("SELECT DISTINCT Kitchen.KitchenName FROM (((Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.KitchenName) INNER JOIN RestaurantBillingItems ON Dish.ItemID = RestaurantBillingItems.Item_ID) INNER JOIN RestaurantBillingInfo ON RestaurantBillingItems.B_ID = RestaurantBillingInfo.BillID) where BillID=" & lblBillNo.Text & "", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSEBInvoice_Kitchen 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand, MyCommand1 As New OleDbCommand()
            Dim myDA, myDA1 As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantBillingInfo")
            myDA.Fill(myDS, "RestaurantBillingItems")
            myDA.Fill(myDS, "Dish")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next

    End Sub
    Sub Print2()
        PrintEB()
        PrintEB_Kitchen()
    End Sub
    Sub PrintTA()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSTAInvoice 'The report you created.
        Dim myConnection As OleDbConnection
        Dim MyCommand, MyCommand1 As New OleDbCommand()
        Dim myDA, myDA1 As New OleDbDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New OleDbConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantBillingInfo")
        myDA.Fill(myDS, "RestaurantBillingItems")
        myDA.Fill(myDS, "Dish")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New OleDbConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub
    Sub PrintTA_Kitchen()
        Dim CN As New OleDbConnection(cs)
        CN.Open()
        adp = New OleDbDataAdapter()
        adp.SelectCommand = New OleDbCommand("SELECT DISTINCT Kitchen.KitchenName FROM (((Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.KitchenName) INNER JOIN RestaurantBillingItems ON Dish.ItemID = RestaurantBillingItems.Item_ID) INNER JOIN RestaurantBillingInfo ON RestaurantBillingItems.B_ID = RestaurantBillingInfo.BillID) where BillID=" & lblBillNo.Text & "", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSTAInvoice_Kitchen 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand, MyCommand1 As New OleDbCommand()
            Dim myDA, myDA1 As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantBillingInfo")
            myDA.Fill(myDS, "RestaurantBillingItems")
            myDA.Fill(myDS, "Dish")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next

    End Sub
    Sub Print3()
        PrintTA()
        PrintTA_Kitchen()
    End Sub
    Sub PrintHD()
        Cursor = Cursors.WaitCursor
        Timer2.Enabled = True
        Dim rpt As New rptRestaurantPOSHDInvoice 'The report you created.
        Dim myConnection As OleDbConnection
        Dim MyCommand, MyCommand1 As New OleDbCommand()
        Dim myDA, myDA1 As New OleDbDataAdapter()
        Dim myDS As New DataSet 'The DataSet you created.
        myConnection = New OleDbConnection(cs)
        MyCommand.Connection = myConnection
        MyCommand1.Connection = myConnection
        MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
        MyCommand1.CommandText = "SELECT * from Hotel"
        MyCommand.CommandType = CommandType.Text
        MyCommand1.CommandType = CommandType.Text
        myDA.SelectCommand = MyCommand
        myDA1.SelectCommand = MyCommand1
        myDA.Fill(myDS, "RestaurantBillingInfo")
        myDA.Fill(myDS, "RestaurantBillingItems")
        myDA.Fill(myDS, "Dish")
        myDA1.Fill(myDS, "Hotel")
        rpt.SetDataSource(myDS)
        con = New OleDbConnection(cs)
        con.Open()
        cmd = con.CreateCommand()
        cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
        rdr = cmd.ExecuteReader()
        If rdr.Read() Then
            s2 = rdr.GetValue(0)
            rpt.PrintOptions.PrinterName = s2
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
        If (rdr IsNot Nothing) Then
            rdr.Close()
        End If
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Sub PrintHD_Kitchen()
        Dim CN As New OleDbConnection(cs)
        CN.Open()
        adp = New OleDbDataAdapter()
        adp.SelectCommand = New OleDbCommand("SELECT DISTINCT Kitchen.KitchenName FROM (((Dish INNER JOIN Kitchen ON Dish.Kitchen = Kitchen.KitchenName) INNER JOIN RestaurantBillingItems ON Dish.ItemID = RestaurantBillingItems.Item_ID) INNER JOIN RestaurantBillingInfo ON RestaurantBillingItems.B_ID = RestaurantBillingInfo.BillID) where BillID=" & lblBillNo.Text & "", CN)
        ds = New DataSet("ds")
        adp.Fill(ds)
        Dim dtable As DataTable = ds.Tables(0)
        CBox.Items.Clear()
        For Each drow As DataRow In dtable.Rows
            CBox.Items.Add(drow(0).ToString())
        Next
        For Each item As String In CBox.Items
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim rpt As New rptRestaurantPOSHDInvoice_Kitchen 'The report you created.
            Dim myConnection As OleDbConnection
            Dim MyCommand, MyCommand1 As New OleDbCommand()
            Dim myDA, myDA1 As New OleDbDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New OleDbConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT RestaurantBillingInfo.BillId, RestaurantBillingInfo.BillType, RestaurantBillingInfo.BillDate, RestaurantBillingInfo.CustomerName, RestaurantBillingInfo.AddressLine1, RestaurantBillingInfo.AddressLine2,RestaurantBillingInfo.AddressLine3, RestaurantBillingInfo.ContactNo, RestaurantBillingInfo.PaymentMode, RestaurantBillingInfo.SubTotal, RestaurantBillingInfo.ItemDiscount, RestaurantBillingInfo.DiscountPer,RestaurantBillingInfo.Discount, RestaurantBillingInfo.VAT, RestaurantBillingInfo.ServiceTax, RestaurantBillingInfo.ServiceCharges, RestaurantBillingInfo.TACharges, RestaurantBillingInfo.HDCharges,RestaurantBillingInfo.GrandTotal, RestaurantBillingInfo.Cash, RestaurantBillingInfo.Change, RestaurantBillingInfo.OperatorID, RestaurantBillingInfo.BillNote, RestaurantBillingItems.P_ID,RestaurantBillingItems.B_ID, RestaurantBillingItems.Item_ID, RestaurantBillingItems.Qty, RestaurantBillingItems.Rate, RestaurantBillingItems.Amount, RestaurantBillingItems.DiscPer,RestaurantBillingItems.Disc, RestaurantBillingItems.VATPer, RestaurantBillingItems.VATAmt, RestaurantBillingItems.STPer, RestaurantBillingItems.STAmt, RestaurantBillingItems.SCPer,RestaurantBillingItems.SCAmt, RestaurantBillingItems.TotalAmt, RestaurantBillingItems.ItemNote, RestaurantBillingItems.TableNo, RestaurantBillingItems.GroupName, Dish.ItemID, Dish.Dishname,Dish.Category, Dish.Kitchen, Dish.InventoryType, Dish.Rate AS Expr1, Dish.Discount AS Expr2 FROM ((RestaurantBillingInfo INNER JOIN RestaurantBillingItems ON RestaurantBillingInfo.BillId = RestaurantBillingItems.B_ID) INNER JOIN Dish ON RestaurantBillingItems.Item_ID = Dish.ItemID) where BillID=" & lblBillNo.Text & ""
            MyCommand.Parameters.AddWithValue("@d1", item)
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "RestaurantBillingInfo")
            myDA.Fill(myDS, "RestaurantBillingItems")
            myDA.Fill(myDS, "Dish")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            con = New OleDbConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Printer) from Kitchen where KitchenName=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", item)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                rpt.PrintOptions.PrinterName = s1
                rpt.PrintToPrinter(1, False, 0, 0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Next

    End Sub
    Sub Print4()
        PrintHD()
        PrintHD_Kitchen()
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    'Private Sub cmbGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbGroup.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        DataGridView2.BeginEdit(True)
    '    End If
    'End Sub
End Class
