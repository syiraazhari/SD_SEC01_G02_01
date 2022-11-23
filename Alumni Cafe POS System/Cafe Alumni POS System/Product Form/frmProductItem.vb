Imports MySql.Data.MySqlClient

Public Class frmProductItem
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
        With frmPurchase
            .txtDescription.Clear()
            .txtPrice.Clear()
            .txtSearch.Clear()
            .txtSearch.Focus()

        End With
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim view As New ListViewItem
        Try

            ListView1.Items.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_product where Description like '%" & txtSearch.Text.Trim & "%'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                view = New ListViewItem(Read.Item("PID").ToString)
                view.SubItems.Add(Read.Item("Description").ToString)
                view.SubItems.Add(Read.Item("Category").ToString)
                view.SubItems.Add(Read.Item("CostPrice").ToString)
                ListView1.Items.Add(view)
            End While
            Read.Close()
            'cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try

    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseClick
        With frmPurchase
            ._PID = Me.ListView1.SelectedItems(0).SubItems(0).Text
            .txtDescription.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text
            ._Category = Me.ListView1.SelectedItems(0).SubItems(2).Text
            .txtPrice.Text = Me.ListView1.SelectedItems(0).SubItems(3).Text

        End With

        Me.Dispose()

    End Sub
End Class