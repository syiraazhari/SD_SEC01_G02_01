Public Class frmListStocks
    Dim DISPLAY As String
    Dim imgpath As String
    Dim arrImage() As Byte
    Private Sub frmstocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reloaditems()
    End Sub

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtitemname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmStocks.Show()
        itemMessage = "SaveOnly"
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        With frmStocks
            .txtitemname.Text = DataGridView1.CurrentRow.Cells(2).Value
            .txtItemCode.Text = DataGridView1.CurrentRow.Cells(1).Value
            .txtDescription.Text = DataGridView1.CurrentRow.Cells(3).Value
            combo = DataGridView1.CurrentRow.Cells(4).Value

            .txtSize.Text = DataGridView1.CurrentRow.Cells(5).Value
            .txtQuantity.Text = DataGridView1.CurrentRow.Cells(6).Value
            .txtUnitPrice.Text = DataGridView1.CurrentRow.Cells(8).Value

            .txtmarkup.Text = DataGridView1.CurrentRow.Cells(10).Value
            .txtBarcode.Text = DataGridView1.CurrentRow.Cells(11).Value
            .btnsave.Text = "Update"
            .Text = DataGridView1.CurrentRow.Cells(1).Value

            itemMessage = "UpdateOnly"
            .txtQuantity.ReadOnly = True
            .Show()


        End With

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        With frmStocks
            .txtitemname.Text = DataGridView1.CurrentRow.Cells(2).Value
            .txtItemCode.Text = DataGridView1.CurrentRow.Cells(1).Value
            .txtDescription.Text = DataGridView1.CurrentRow.Cells(3).Value
            combo = DataGridView1.CurrentRow.Cells(4).Value

            .txtSize.Text = DataGridView1.CurrentRow.Cells(5).Value
            .txtQuantity.Text = DataGridView1.CurrentRow.Cells(6).Value
            .txtUnitPrice.Text = DataGridView1.CurrentRow.Cells(8).Value

            .txtmarkup.Text = DataGridView1.CurrentRow.Cells(10).Value
            .btnsave.Text = "Add Quantity"
            .Text = DataGridView1.CurrentRow.Cells(1).Value

            itemMessage = "SaveOnly"
            .txtQuantity.ReadOnly = False
            .Show()
            For Each ctrl As Control In .GroupBox1.Controls
                If ctrl.GetType Is GetType(TextBox) Then
                    ctrl.Enabled = False
                    If ctrl.Name = "txtQuantity" Then
                        ctrl.Enabled = True
                    End If
                End If
                If ctrl.GetType Is GetType(ComboBox) Then
                    ctrl.Enabled = False

                End If
            Next

        End With
    End Sub


End Class