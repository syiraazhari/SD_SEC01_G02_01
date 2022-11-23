Public Class frmGetCash
    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim change, cash, netTotal As Double

        frmSales.lblCash.Text = FormatCurrency(txtGetCash.Text)
        cash = Double.Parse(txtGetCash.Text)
        netTotal = frmSales.lblNetTotal.Text
        If cash < netTotal Then
            MsgBox("Cash amount can not be lower than Net Total", vbExclamation)
        ElseIf cash > netTotal Then
            change = cash - netTotal
            frmSales.lblChange.Text = FormatCurrency(change.ToString)
        End If
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class