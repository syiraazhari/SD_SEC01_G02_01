Imports MySql.Data.MySqlClient
Public Class frmRestTable
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Sub LoadTable()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        cn.Open()
        cmd = New MySqlCommand("select tablename from tbl_Table", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            i += 1
            Me.Guna2DataGridView1.Rows.Add(i, Read.Item("TableName").ToString)
        End While
        cn.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtRestName) = True Then Return

        cn.Open()
        cmd = New MySqlCommand("insert into tbl_Table (TableName) values ('" & txtRestName.Text & "')", cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        MsgBox("Restaurant table name has been save successfully", vbInformation)
        LoadTable()
        txtRestName.Clear()
    End Sub

    Private Sub frmRestTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTable()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name
        If colstr = "ColDel" Then
            If MsgBox("Do you want to delete the restaurant table?", vbYesNo + vbQuestion) = vbYes Then
                cn.Open()
                cmd = New MySqlCommand("delete from tbl_Table where tablename='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value & "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("Restaurant table has been delete successfully", vbInformation)
            End If
            LoadTable()
        End If
    End Sub
End Class