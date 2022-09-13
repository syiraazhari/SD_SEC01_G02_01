Imports System.Data.OleDb
Imports System.Drawing.Printing
Public Class frmKitchen_Section
    Dim st2 As String
    Sub Reset()
        cmbPrinter.SelectedIndex = -1
        chkIsEnabled.Checked = True
        txtKitchenName.Text = ""
        txtKitchenName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub PopulateInstalledPrintersCombo()
        Try
            ' Add list of installed printers found to the combo box.
            ' The pkInstalledPrinters string will be used to provide the display string.
            Dim i As Integer
            Dim pkInstalledPrinters As String
            cmbPrinter.Items.Clear()
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
                cmbPrinter.Items.Add(pkInstalledPrinters)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtKitchenName.Text)) = 0 Then
            MessageBox.Show("Please enter kitchen/section name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKitchenName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbPrinter.Text)) = 0 Then
            MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinter.Focus()
            Exit Sub
        End If

        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = "select KitchenName from Kitchen where KitchenName=@d1"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Kitchen/Section Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtKitchenName.Text = ""
                txtKitchenName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "insert into Kitchen(KitchenName,Printer,IsEnabled) VALUES (@d1,@d2,@d3)"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Kitchen/section '" & txtKitchenName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            con.Open()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cl As String = "select Kitchen.KitchenName from Kitchen,Dish where Kitchen.KitchenName=Dish.Kitchen and Kitchen.KitchenName=@d1"
            cmd = New OleDbCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Menu Item Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from Kitchen where KitchenName=@d1"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Kitchen/section '" & txtKitchenName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtKitchenName.Text)) = 0 Then
            MessageBox.Show("Please enter kitchen/section name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKitchenName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbPrinter.Text)) = 0 Then
            MessageBox.Show("Please select printer", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinter.Focus()
            Exit Sub
        End If

        Try
            If chkIsEnabled.Checked = True Then
                st2 = "Yes"
            Else
                st2 = "No"
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = "Update Kitchen set KitchenName=@d1,Printer=@d2,IsEnabled=@d3 where KitchenName=@d4"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtKitchenName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.Parameters.AddWithValue("@d4", txtKitchen.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the Kitchen/section '" & txtKitchenName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT RTRIM(KitchenName), RTRIM(Printer),RTRIM(IsEnabled) from Kitchen order by KitchenName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub frmKitchen_Section_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
        End If
    End Sub

    Private Sub frmKitchen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        PopulateInstalledPrintersCombo()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtKitchenName.Text = dr.Cells(0).Value.ToString()
                txtKitchen.Text = dr.Cells(0).Value.ToString()
                cmbPrinter.Text = dr.Cells(1).Value.ToString()
                If dr.Cells(2).Value.ToString() = "Yes" Then
                    chkIsEnabled.Checked = True
                Else
                    chkIsEnabled.Checked = False
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
End Class
