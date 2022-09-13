
Imports System.Data.OleDb
Imports System.Drawing.Printing
Public Class frmPrinterSetting
    Dim st2 As String
    Sub Reset()
        cmbPrinterType.SelectedIndex = -1
        cmbPrinter.Text = ""
        chkIsEnabled.Checked = True
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        cmbPrinterType.Focus()
    End Sub
    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(cmbPrinterType.Text)) = 0 Then
            MessageBox.Show("Please select printer type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinterType.Focus()
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
            Dim ct As String = "select PrinterType from PosPrinterSetting where PrinterType=@d1"
            cmd = New OleDbCommand(ct)
            cmd.Parameters.AddWithValue("@d1", cmbPrinterType.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
            Dim cb As String = "insert into PosPrinterSetting(PrinterType,PrinterName,IsEnabled) VALUES (@d1,@d2,@d3)"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbPrinterType.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully saved", "POS Printer Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand("SELECT ID,RTRIM(PrinterType), RTRIM(PrinterName),RTRIM(IsEnabled) from PosPrinterSetting order by PrinterName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub frmPrinterSetting_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
        End If
    End Sub
    Private Sub frmSMSSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Getdata()
        PopulateInstalledPrintersCombo()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
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
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = "delete from PosPrinterSetting where ID=@d1"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show("Successfully deleted", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                cmbPrinterType.Text = dr.Cells(1).Value.ToString()
                cmbPrinter.Text = dr.Cells(2).Value.ToString()
                If dr.Cells(3).Value.ToString() = "Yes" Then
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

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(cmbPrinterType.Text)) = 0 Then
            MessageBox.Show("Please select printer type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPrinterType.Focus()
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
            Dim cb As String = "Update PosPrinterSetting set PrinterType=@d1,PrinterName=@d2,IsEnabled=@d3 where ID=" & txtID.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbPrinterType.Text)
            cmd.Parameters.AddWithValue("@d2", cmbPrinter.Text)
            cmd.Parameters.AddWithValue("@d3", st2)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully updated", "POS Printer Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

End Class