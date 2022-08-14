Public Class frmFindItems

    Private Sub frmFindItems_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmPOS.txtitemname.Focus()
    End Sub

    Private Sub frmFindItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        janobefindthis("SELECT `ITEMCODE`, `ITEMNAME` FROM `tblitem` GROUP by ITEMCODE")
        LoadData(DataGridView1, "findItems")
    End Sub


    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            frmPOS.txtitemname.Text = DataGridView1.CurrentRow.Cells(1).FormattedValue
            frmPOS.SearchItem()
            frmPOS.txtqty.Focus()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            frmPOS.txtitemname.Text = DataGridView1.CurrentRow.Cells(1).FormattedValue
            frmPOS.SearchItem()
            frmPOS.txtqty.Focus()
            Me.Close()
            'frmPOS.txtitemname.Focus()
        Catch ex As Exception

        End Try
    End Sub
End Class