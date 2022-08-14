Public Class frmUser

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtpassword.Text = "" Then
            MsgBox("Password must be filled up.", MsgBoxStyle.Exclamation)
            Return
        End If
        If txtcpaswrd.Text = "" Then
            MsgBox("Password must be filled up.", MsgBoxStyle.Exclamation)
            Return
        End If
        If btnsave.Text = "Save" Then
            If txtpassword.Text = txtcpaswrd.Text Then
                issucess = janobeinsert("INSERT INTO `tblemployee` (`EMPID`, `EMPNAME`, `EMPADDRESS`, `EMPCONTACT`, `EMPPOSITION`, `USERNAME`, `PASSWRD`) " &
                            " VALUES (NULL, '" & txtname.Text & "', '" & txtadress.Text & "', '" & txtcontact.Text & "', '" & txtposition.Text & "', '" & txtusername.Text & "', sha1('" & txtpassword.Text & "'));")
                If issucess = True Then
                    MsgBox("Employee record has been saved!")
                Else
                    MsgBox("No record has been saved!")
                End If
            Else
                MsgBox("Password not match!")
            End If
        Else
            If txtpassword.Text = txtcpaswrd.Text Then
                issucess = janoupdate("UPDATE `tblemployee` SET `EMPNAME`='" & txtname.Text & "', `EMPADDRESS`='" & txtadress.Text & "', `EMPCONTACT`='" & txtcontact.Text & "', `EMPPOSITION`='" & txtposition.Text & "', `USERNAME`='" & txtusername.Text & "', `PASSWRD`=sha1('" & txtpassword.Text & "') where EMPID=" & Val(lblid.Text) & "")
                If issucess = True Then
                    MsgBox("Employee record has been Updated!")
                Else
                    MsgBox("No record has been Updated!")
                End If
            Else
                MsgBox("Password not match!")
            End If
        End If
        Call btnnew_Click(sender, e)
    End Sub

    Private Sub frmuser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        janobefindthis("Select `EMPID`, `EMPNAME`, `EMPADDRESS`, `EMPCONTACT`, `EMPPOSITION`, `USERNAME` from tblemployee")
        LoadData(DataGridView1, "employee")
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        janobefindthis("Select `EMPID`, `EMPNAME`, `EMPADDRESS`, `EMPCONTACT`, `EMPPOSITION`, `USERNAME` from tblemployee")
        LoadData(DataGridView1, "employee")
        ClearAll(GroupBox1, "employee")
        txtposition.Text = "Select"
        btnsave.Text = "Save"
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        lblid.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtadress.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtcontact.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtposition.Text = DataGridView1.CurrentRow.Cells(4).Value
        txtusername.Text = DataGridView1.CurrentRow.Cells(5).Value
        btnsave.Text = "Update"
    End Sub

    Private Sub txtposition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtposition.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class