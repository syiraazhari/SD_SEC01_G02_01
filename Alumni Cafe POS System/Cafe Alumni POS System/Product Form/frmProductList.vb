Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Public Class frmProductList

    Private Sub frmProductList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProduct()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        With frmProduct
            .btnSave.Visible = True
            .btnUpdate.Visible = False
            .Show()
        End With
    End Sub

    Sub LoadProduct()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select PID,Description,Category,CostPrice,SellPrice from tbl_product where Category!='Stocks'", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("CostPrice").ToString, Read.Item("SellPrice").ToString)
        End While
        cn.Close()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim ColStr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If ColStr = "ColEdit" Then

            With frmProduct
                cn.Open()
                cmd = New MySqlCommand("select Image,PID,Description,Category,CostPrice,SellPrice from tbl_product where PID like '" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    Dim len As Long = Read.GetBytes(0, 0, Nothing, 0, 0)
                    Dim arr(CInt(len)) As Byte
                    Read.GetBytes(0, 0, arr, 0, CInt(len))
                    Dim MS As New MemoryStream(arr)
                    Dim Bitmap As New Bitmap(MS)
                    .PictureBox1.Image = Bitmap
                    .lblPID.Text = Read.Item("PID").ToString
                    .txtDescription.Text = Read.Item("Description").ToString
                    .txtCostPrice.Text = Read.Item("CostPrice").ToString
                    .txtSellPrice.Text = Read.Item("SellPrice").ToString

                End If
                Read.Dispose()
                cn.Close()
                .btnSave.Visible = False
                .btnUpdate.Visible = True
                .ShowDialog()
            End With

        ElseIf ColStr = "ColDel" Then
            If MsgBox("Do you want to delete the product Item?", vbYesNo + vbInformation) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_product where PID like '" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Product item has successfully deleted", vbInformation)
            End If
            LoadProduct()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        Try
            cn.Open()
            cmd = New MySqlCommand("select PID,Description,Category,CostPrice,SellPrice from tbl_product where Description like '%" & txtSearch.Text & "%'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("PID").ToString, Read.Item("Description").ToString, Read.Item("Category").ToString, Read.Item("CostPrice").ToString, Read.Item("SellPrice").ToString)
            End While
            cn.Close()
        Catch ex As Exception
            cn.Close()
        End Try
    End Sub
End Class