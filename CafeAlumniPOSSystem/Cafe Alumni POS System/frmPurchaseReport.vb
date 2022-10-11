Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared

Public Class frmPurchaseReport
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Sub LoadReportType()
        If cboReportType.Text.Trim = "Date Wise" Then
            Me.DateTimePicker1.Enabled = True
            Me.DateTimePicker2.Enabled = True
            cboSupplier.Enabled = False
            btnShow.Enabled = True
            Me.cboSupplier.SelectedIndex = -1

        ElseIf cboReportType.Text.Trim = "Supplier Wise" Then
            Me.DateTimePicker1.Enabled = True
            Me.DateTimePicker2.Enabled = True
            cboSupplier.Enabled = True
            btnShow.Enabled = True

        ElseIf cboReportType.Text.Trim = "Payment Wise" Then
            Me.DateTimePicker1.Enabled = True
            Me.DateTimePicker2.Enabled = True
            cboSupplier.Enabled = False
            btnShow.Enabled = True
            Me.cboSupplier.SelectedIndex = -1

        Else
            Me.DateTimePicker1.Enabled = False
            Me.DateTimePicker2.Enabled = False
            cboSupplier.Enabled = False
            btnShow.Enabled = False
            Me.cboSupplier.SelectedIndex = -1

        End If
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged
        LoadReportType()
    End Sub

    Sub LoadSupplier()

        Try
            cboSupplier.Items.Clear()
            cn.Open()
            cmd = New MySqlCommand("select * from tbl_supplier", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                cboSupplier.Items.Add(Read.Item("SuppName").ToString)
            End While
            Read.Close()
            cn.Close()

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmPurchaseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplier()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim date1 As String = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date2 As String = Me.DateTimePicker2.Value.ToString("yyyy-MM-dd")

        Dim DT As New DataTable
        Dim DS As New DataSet
        Dim DA As New MySqlDataAdapter
        Dim Cr As New crPurchase
        Dim CrPayment As New crPurPayment

        Dim SID As String = ""

        Dim PFields As New ParameterFields

        Dim pField1 As New ParameterField
        Dim PDescret1 As New ParameterDiscreteValue

        Dim pField2 As New ParameterField
        Dim PDescret2 As New ParameterDiscreteValue


        If cboReportType.Text = "Date Wise" Then
            pField1.Name = "PDate1"
            PDescret1.Value = date1
            pField1.CurrentValues.Add(PDescret1)
            PFields.Add(pField1)

            pField2.Name = "PDate2"
            PDescret2.Value = date2
            pField2.CurrentValues.Add(PDescret2)
            PFields.Add(pField2)

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_purchase where PDate between '" & date1 & "' and '" & date2 & "' order by PDate,InvoiceNo desc", cn)
            DA = New MySqlDataAdapter(cmd)
            DT.Reset()
            DA.Fill(DS, "tbl_purchase")
            DT = DS.Tables(0)
            Cr.SetDataSource(DT)
            CrystalReportViewer1.ReportSource = Cr
            CrystalReportViewer1.ParameterFieldInfo = PFields
            CrystalReportViewer1.Refresh()

            cn.Close()

        ElseIf cboReportType.Text = "Supplier Wise" Then

            pField1.Name = "PDate1"
            PDescret1.Value = date1
            pField1.CurrentValues.Add(PDescret1)
            PFields.Add(pField1)

            pField2.Name = "PDate2"
            PDescret2.Value = date2
            pField2.CurrentValues.Add(PDescret2)
            PFields.Add(pField2)

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_supplier where SuppName ='" & cboSupplier.Text & "'", cn)
            Read = cmd.ExecuteReader
            Read.Read()

            If Read.HasRows Then
                SID = Read.Item("SID").ToString
            End If
            Read.Close()
            cn.Close()

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_purchase where SID = '" & SID & "' and PDate between '" & date1 & "' and '" & date2 & "' order by PDate,InvoiceNo desc", cn)

            DA = New MySqlDataAdapter(cmd)
            DT.Reset()
            DA.Fill(DS, "tbl_purchase")
            DT = DS.Tables(0)
            Cr.SetDataSource(DT)
            CrystalReportViewer1.ReportSource = Cr
            CrystalReportViewer1.ParameterFieldInfo = PFields
            CrystalReportViewer1.Refresh()

            cn.Close()

        ElseIf cboReportType.Text = "Payment Wise" Then

            pField1.Name = "PDate1"
            PDescret1.Value = date1
            pField1.CurrentValues.Add(PDescret1)
            PFields.Add(pField1)

            pField2.Name = "PDate2"
            PDescret2.Value = date2
            pField2.CurrentValues.Add(PDescret2)
            PFields.Add(pField2)


            cn.Open()
            cmd = New MySqlCommand("select * from tbl_purpayment where PDate between '" & date1 & "' and '" & date2 & "' order by PDate,InvoiceNo desc", cn)

            DA = New MySqlDataAdapter(cmd)
            DT.Reset()
            DA.Fill(DS, "tbl_purpayment")
            DT = DS.Tables(0)
            CrPayment.SetDataSource(DT)
            CrystalReportViewer1.ReportSource = CrPayment
            CrystalReportViewer1.ParameterFieldInfo = PFields
            CrystalReportViewer1.Refresh()

            cn.Close()
        End If
    End Sub
End Class