Imports MySql.Data.MySqlClient
Public Class frmSupplier
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Sub Clear()
        txtName.Clear()
        txtAddress.Clear()
        txtContact.Clear()
        txtEmailID.Clear()
        txtName.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtName) = True Then Return
        If check_empty(txtAddress) = True Then Return
        If check_empty(txtContact) = True Then Return
        If check_empty(txtEmailID) = True Then Return

        cn.Open()
        cmd = New MySqlCommand("insert into tbl_supplier(SuppName,Address,ContactNo,Email) values(@SuppName,@Address,@ContactNo,@Email)", cn)
        With cmd
            .Parameters.AddWithValue("@SuppName", txtName.Text)
            .Parameters.AddWithValue("@Address", txtAddress.Text)
            .Parameters.AddWithValue("@ContactNo", txtContact.Text)
            .Parameters.AddWithValue("@Email", txtEmailID.Text)
            .ExecuteNonQuery()

        End With

        cn.Close()
        MsgBox("Supplier details has being successfully save", vbInformation)
        Clear()
        LoadSupplierDetails()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Sub LoadSupplierDetails()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_supplier", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("SID").ToString, Read.Item("SuppName").ToString, Read.Item("Address").ToString, Read.Item("ContactNo").ToString, Read.Item("Email").ToString)
        End While
        cn.Close()

    End Sub

    Private Sub frmSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplierDetails()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim i As Integer
            Me.Guna2DataGridView1.Rows.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_supplier where SuppName like  '%" & txtSearch.Text.Trim & "%'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("SID").ToString, Read.Item("SuppName").ToString, Read.Item("Address").ToString, Read.Item("ContactNo").ToString, Read.Item("Email").ToString)
            End While
            cn.Close()
        Catch ex As Exception
            cn.Close()

        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If check_empty(txtName) = True Then Return
        If check_empty(txtAddress) = True Then Return
        If check_empty(txtContact) = True Then Return
        If check_empty(txtEmailID) = True Then Return

        cn.Open()
        cmd = New MySqlCommand("udpate tbl_supplier set SuppName = @SuppName, Address = @Address, ContactNo = @ContactNo, Email = @Email where SID = '" & lblSID.Text & "'", cn)
        With cmd
            .Parameters.AddWithValue("@SuppName", txtName.Text)
            .Parameters.AddWithValue("@Address", txtAddress.Text)
            .Parameters.AddWithValue("@ContactNo", txtContact.Text)
            .Parameters.AddWithValue("@Email", txtEmailID.Text)
            .ExecuteNonQuery()

        End With

        cn.Close()
        MsgBox("Supplier details has being successfully updated", vbInformation)
        Clear()
        LoadSupplierDetails()
        btnSave.Visible = True
        btnUpdate.Visible = False
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If colstr = "ColEdit" Then
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_supplier where SID='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                lblSID.Text = Read.Item("SID").ToString
                txtName.Text = Read.Item("SuppName").ToString
                txtAddress.Text = Read.Item("Address").ToString
                txtContact.Text = Read.Item("ContactNo").ToString
                txtEmailID.Text = Read.Item("Email").ToString
            End If
            cn.Close()
            btnUpdate.Visible = True
            btnSave.Visible = False

        ElseIf colstr = "ColDel" Then
            If MsgBox("Do you want to remove the supplier?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_supplier where SID='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Supplier has been deleted", vbInformation)
            End If
            LoadSupplierDetails()
        End If
    End Sub
End Class