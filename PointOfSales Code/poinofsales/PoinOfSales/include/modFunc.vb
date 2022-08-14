Module modFunc
    Public Sub Visible_Admin(ByVal result As Boolean)
        With Form1
            .tsPOS.Visible = result
            .tsStocks.Visible = result
            .tsCategory.Visible = result
            .tsUser.Visible = result
            .tsReport.Visible = result

        End With

    End Sub
    Public Sub Visible_Cashier(ByVal result As Boolean)
        With Form1
            .tsPOS.Visible = result
            .tsReport.Visible = result
        End With

    End Sub
End Module
