Imports System.Data.OleDb
Public Class frmAvailableTables
    Dim UserButtons As List(Of Button) = New List(Of Button)
    Private Sub frmAvailableTables_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AvailableTables()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim btn1 As Button = CType(sender, Button)
            Dim str As String = btn1.Text.Trim()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "Update KOTGeneration set TableNo=@d1 where TableNo=@d2"
            cmd = New OleDbCommand(cb)
            cmd.Parameters.AddWithValue("@d1", str)
            cmd.Parameters.AddWithValue("@d2", lblTable.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            frmCustomDialog2.ShowDialog()
            Me.Hide()
            frmBillling.txtTableNo.Text = ""
            frmBillling.fillTableNo()
            frmBillling.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub AvailableTables()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select R_Table.TableNo from R_Table where R_Table.Status='Activate' and R_Table.TableNo not in (Select TableNo from KOTGeneration where Status='Unpaid')"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            FlowLayoutPanel1.Controls.Clear()
            Do While (rdr.Read())
                Dim btn As New Button
                btn.Text = rdr.GetValue(0)
                btn.TextAlign = ContentAlignment.MiddleCenter
                btn.BackColor = Color.LightGreen
                btn.FlatStyle = FlatStyle.Popup
                btn.Width = 180
                btn.Height = 80
                btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                UserButtons.Add(btn)
                FlowLayoutPanel1.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Me.Button2_Click
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        AvailableTables()
    End Sub

End Class