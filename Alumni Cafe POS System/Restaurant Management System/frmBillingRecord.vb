Imports System.Data.OleDb


Public Class frmBillingRecord
    Private Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            'cmd = New OleDbCommand("SELECT RTRIM(UserID),[Date],RTRIM(Operation) from Logs order by Date", con)
            cmd = New OleDbCommand("SELECT RTRIM(DishName), RTRIM(Category),RTRIM(Kitchen),InventoryType, Rate,Discount from Dish order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgvbillrecord.Rows.Clear()
            While (rdr.Read() = True)
                dgvbillrecord.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvbillrecord_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvbillrecord.CellDoubleClick
        
    End Sub

   

    Private Sub dgvbillrecord_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvbillrecord.DoubleClick
        'this.customersDataGridView.Columns[0].Visible = false;

        Me.dgvbillrecord.Columns("SelectBill").Visible = True
    End Sub



    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvbillrecord.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgvbillrecord.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgvbillrecord.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub


    Private Sub frmBillingRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub dgvbillrecord_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvbillrecord.CellContentClick

    End Sub
End Class