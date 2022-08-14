Public Class frmCategory

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If btnsave.Text = "Save" Then
            issucess = janobeinsert("INSERT INTO `tblcategory` (`CATEGORYID`, `CATNAME`, `CATDESCIPTION`) VALUES (NULL, '" & txtname.Text & "', '" & txtdescrption.Text & "');")
            If issucess = True Then
                MsgBox("Category has been successfully created!")

                Call frmcategory_Load(sender, e)

            Else
                MsgBox("No Category has been created!")
            End If
        Else
            issucess = janoupdate("UPDATE `tblcategory` SET `CATNAME`='" & txtname.Text & "', `CATDESCIPTION`= '" & txtdescrption.Text & "' WHERE CATEGORYID=" & Val(lblid.Text) & " ;")
            If issucess = True Then
                MsgBox("Category has been updated!")
                btnsave.Text = "Save"
                Call frmcategory_Load(sender, e)

            Else
                MsgBox("No Category has been updated!")
            End If
        End If
        ClearAll(GroupBox1, "Category")

    End Sub

    Private Sub frmcategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        janobefindthis("Select * from tblcategory")
        LoadData(DataGridView1, "category")
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        lblid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtdescrption.Text = DataGridView1.CurrentRow.Cells(2).Value
        btnsave.Text = "Update"
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class