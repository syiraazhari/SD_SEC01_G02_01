Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class MainWindow

    Dim profit As Double = 0
    Dim income As Double = 0
    Dim tax As Double = 0
    Dim profitSeries As New Series
    Dim incomeSeries As New Series
    Dim taxSeries As New Series

    Sub DoChart()

        profitSeries.Name = "Profit"

        'Change to a line graph.
        profitSeries.ChartType = SeriesChartType.Column
        profitSeries.XValueType = ChartValueType.String
        profitSeries.Color = Color.FromArgb(125, 225, 155)
        profitSeries.BorderWidth = 5

        incomeSeries.Name = "Income"

        'Change to a line graph.
        incomeSeries.ChartType = SeriesChartType.Column
        incomeSeries.XValueType = ChartValueType.String
        incomeSeries.Color = Color.FromArgb(252, 211, 84)
        incomeSeries.BorderWidth = 5

        taxSeries.Name = "Tax"

        'Change to a line graph.
        taxSeries.ChartType = SeriesChartType.Column
        taxSeries.XValueType = ChartValueType.String
        taxSeries.Color = Color.FromArgb(225, 225, 155)
        taxSeries.BorderWidth = 5

        For index As Integer = 1 To 12
            Try
                cn.Open()
                cmd = New MySqlCommand("select sum((SellPrice - CostPrice) * s.Qty) as Profit from tbl_sales as s inner join tbl_product as p on s.PID = p.PID where month(s.SDate) = @SDate and Status = 'Settled'", cn)
                cmd.Parameters.AddWithValue("@SDate", index)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    'MsgBox(Read.Item("Profit").ToString)
                    profit = CDbl(Read.Item("Profit").ToString)
                End If
                cn.Close()

            Catch ex As Exception
                cn.Close()
            End Try

            Try
                cn.Open()
                cmd = New MySqlCommand("select sum(Price * Qty) as Income from tbl_sales as s inner join tbl_product as p on s.PID = p.PID where month(s.SDate) = @SDate and Status = 'Settled'", cn)
                cmd.Parameters.AddWithValue("@SDate", index)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    income = CDbl(Read.Item("Income").ToString)
                End If
                cn.Close()

            Catch ex As Exception
                cn.Close()
            End Try

            Try
                cn.Open()
                cmd = New MySqlCommand("select sum(Tax) as TotalTax from tbl_salespayment where month(s.SDate) = @SDate", cn)
                cmd.Parameters.AddWithValue("@SDate", index)
                Read = cmd.ExecuteReader
                Read.Read()
                If Read.HasRows Then
                    income = CDbl(Read.Item("Tax").ToString)
                End If
                cn.Close()

            Catch ex As Exception
                cn.Close()
            End Try

            If index >= 0 And index <= 12 Then
                profitSeries.Points.AddXY(MonthName(index), profit)
                incomeSeries.Points.AddXY(MonthName(index), income)
                taxSeries.Points.AddXY(MonthName(index), tax)
            End If

        Next

        Chart1.Series.Add(profitSeries)
        Chart1.Series.Add(incomeSeries)
        Chart1.Series.Add(taxSeries)

    End Sub



    Sub loadProfit()
        Try
            cn.Open()
            cmd = New MySqlCommand("select sum((SellPrice - CostPrice) * s.Qty) as Profit from tbl_sales as s inner join tbl_product as p on s.PID = p.PID where s.SDate = @SDate and Status = 'Settled'", cn)
            cmd.Parameters.AddWithValue("@SDate", Format(Date.Today.Date, "yyyy-MM-dd"))
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                profit = CDbl(Read.Item("Profit").ToString)
            End If
            cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try

        lblProfit.Text = FormatCurrency(profit)
    End Sub

    Sub loadIncome()
        Try
            cn.Open()
            cmd = New MySqlCommand("select sum(Price * Qty) as Income from tbl_sales as s inner join tbl_product as p on s.PID = p.PID where s.SDate = @SDate and Status = 'Settled'", cn)
            cmd.Parameters.AddWithValue("@SDate", Format(Date.Today.Date, "yyyy-MM-dd"))
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                income = CDbl(Read.Item("Income").ToString)
            End If
            cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try

        lblIncome.Text = FormatCurrency(income)
    End Sub

    Sub loadTax()
        Try
            cn.Open()
            cmd = New MySqlCommand("select sum(Tax) as TotalTax from tbl_salespayment where SDate = @SDate", cn)
            cmd.Parameters.AddWithValue("@SDate", Format(Date.Today.Date, "yyyy-MM-dd"))
            Read = cmd.ExecuteReader
            Read.Read()
            If Read.HasRows Then
                tax = CDbl(Read.Item("TotalTax").ToString)
            End If
            cn.Close()

        Catch ex As Exception
            cn.Close()
        End Try

        lblTax.Text = FormatCurrency(tax)
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBox("Do you want to exit?", vbYesNo + vbQuestion) = vbYes Then
            Application.Exit()
        End If

    End Sub
    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Start()
        loadProfit()
        loadIncome()
        DoChart()
        loadTax()
    End Sub
    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        If pnlMaster.Height = 10 Then
            pnlMaster.Height = 130
        Else
            pnlMaster.Height = 10

        End If
    End Sub

    Private Sub btnTransaction_Click(sender As Object, e As EventArgs) Handles btnTransaction.Click
        If pnlTransaction.Height = 10 Then
            pnlTransaction.Height = 127
        Else
            pnlTransaction.Height = 10

        End If
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        If pnlReport.Height = 10 Then
            pnlReport.Height = 100
        Else
            pnlReport.Height = 10

        End If
    End Sub

    Private Sub btnTools_Click(sender As Object, e As EventArgs) Handles btnTools.Click
        If pnlTools.Height = 10 Then
            pnlTools.Height = 106
        Else
            pnlTools.Height = 10

        End If
    End Sub

    Private Sub btnStock_Click(sender As Object, e As EventArgs) Handles btnStock.Click
        If pnlStock.Height = 10 Then
            pnlStock.Height = 138
        Else
            pnlStock.Height = 10

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If MsgBox("Do you want to log out?", vbYesNo + vbQuestion) = vbYes Then
            With frmLogin
                .usernameTextBox.Clear()
                .passwordTextBox.Clear()
                .Show()
                Me.Hide()
            End With
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmProductList
            .Show()
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dt As DateTime = Today
        dateLabel.Text = dt.ToString("dd/MM/yyyy")
        timeLabel.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub picStaffUser_Click(sender As Object, e As EventArgs) Handles picStaffUser.Click
        With frmStaffUserProfile
            .Show()
        End With
    End Sub

    Private Sub picPassword_Click(sender As Object, e As EventArgs) Handles picPassword.Click
        With frmChangePassword
            .Show()
        End With
    End Sub

    Private Sub picUser_Click(sender As Object, e As EventArgs) Handles picUser.Click
        With frmUserProfile
            .LoadUser()
            .Show()
        End With
    End Sub

    Private Sub picSetting_Click(sender As Object, e As EventArgs) Handles picSetting.Click
        With frmTax
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With frmRestTable
            .Show()
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With frmSales
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmPurchase
            .loadGenerateInvoice()
            .Show()
        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With frmSupplier
            .Show()
        End With
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With frmStockIn
            .Show()
        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With frmStockOut
            .Show()
        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        With frmStockInHand
            .LoadCategory()
            .Show()
        End With
    End Sub

    Private Sub purchaseReportButton_Click(sender As Object, e As EventArgs) Handles purchaseReportButton.Click
        With frmPurchaseReport
            .Show()
        End With
    End Sub

    Private Sub salesReportButton_Click(sender As Object, e As EventArgs) Handles salesReportButton.Click
        With frmSalesReport
            .Show()
        End With
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        loadProfit()
        loadIncome()
        loadTax()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        With frmViewPaymentHistory
            .Show()
        End With
    End Sub

    Private Sub notepadButton_Click(sender As Object, e As EventArgs) Handles notepadButton.Click
        Process.Start("Notepad.exe")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Process.Start("Calc.exe")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        frmAbout.ShowDialog()
    End Sub

End Class