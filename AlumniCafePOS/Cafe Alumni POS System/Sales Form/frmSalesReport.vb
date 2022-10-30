Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Public Class frmSalesReport
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click

        Dim date1 As String = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim date2 As String = Me.DateTimePicker2.Value.ToString("yyyy-MM-dd")

        Dim DT As New DataTable
        Dim DS As New DataSet
        Dim DA As New MySqlDataAdapter
        Dim CrSales As New crSalesItem
        Dim CrIncome As New crSalesIncome

        Dim PFields As New ParameterFields

        Dim pField1 As New ParameterField
        Dim PDescret1 As New ParameterDiscreteValue

        Dim pField2 As New ParameterField
        Dim PDescret2 As New ParameterDiscreteValue

        If cboReportType.Text = "" Then
            MsgBox("Please select report type", vbExclamation)
        End If

        If cboReportType.Text = "Sales Items" Then

            pField1.Name = "SDate1"
            PDescret1.Value = date1
            pField1.CurrentValues.Add(PDescret1)
            PFields.Add(pField1)

            pField2.Name = "SDate2"
            PDescret2.Value = date2
            pField2.CurrentValues.Add(PDescret2)
            PFields.Add(pField2)

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_sales where SDate between '" & date1 & "' and '" & date2 & "' and Status = 'Settled' order by SDate, InvoiceNo desc", cn)
            DA = New MySqlDataAdapter(cmd)
            DT.Reset()
            DA.Fill(DS, "tbl_sales")
            DT = DS.Tables(0)
            CrSales.SetDataSource(DT)
            CrystalReportViewer1.ReportSource = CrSales
            CrystalReportViewer1.ParameterFieldInfo = PFields
            CrystalReportViewer1.Refresh()
            cn.Close()

        ElseIf cboReportType.Text = "Income" Then
            pField1.Name = "SDate1"
            PDescret1.Value = date1
            pField1.CurrentValues.Add(PDescret1)
            PFields.Add(pField1)

            pField2.Name = "SDate2"
            PDescret2.Value = date2
            pField2.CurrentValues.Add(PDescret2)
            PFields.Add(pField2)

            cn.Open()
            cmd = New MySqlCommand("select * from tbl_salespayment where SDate between '" & date1 & "' and '" & date2 & "' order by SDate, InvoiceNo desc", cn)
            DA = New MySqlDataAdapter(cmd)
            DT.Reset()
            DA.Fill(DS, "tbl_salespayment")
            DT = DS.Tables(0)
            CrIncome.SetDataSource(DT)
            CrystalReportViewer1.ReportSource = CrIncome
            CrystalReportViewer1.ParameterFieldInfo = PFields
            CrystalReportViewer1.Refresh()
            cn.Close()
        End If
    End Sub
End Class