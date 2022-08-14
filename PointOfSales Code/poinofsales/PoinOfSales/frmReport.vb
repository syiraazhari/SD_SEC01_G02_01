Public Class frmReport
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "SELECT * FROM `tbltransdetails`  td, `tbltransaction` t WHERE td.`INVOICENO`=t.`INVOICENO` AND DATE(TRANSDATE)=DATE(NOW())"
        reports(sql, "sales", CrystalReportViewer1)
    End Sub
    Private Sub btnSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSales.Click

        sql = "SELECT * FROM `tbltransdetails`  td, `tbltransaction` t WHERE td.`INVOICENO`=t.`INVOICENO` AND DATE(TRANSDATE)=DATE(NOW())"
        reports(sql, "sales", CrystalReportViewer1)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sql = "SELECT `ITEMNO`, `ITEMCODE`, `ITEMNAME`, `ITEMDESCRIPTION`, `ITEMCATEGORY`, `SIZE`,SUM( `QTY`) as 'Qty',  SUM(`ONHAND`) as 'Ave. QTY',`UNITPRICE`, `DATEIN`, `MARKUP` FROM `tblitem` GROUP by ITEMCODE"
        reports(sql, "remaining", CrystalReportViewer1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sql = "SELECT * FROM `tbltransaction` t, `tbltransdetails` td WHERE t.`INVOICENO`=td.`INVOICENO`  AND DATE(TRANSDATE)='" & Format(Now(), "yyyy-MM-dd") & "'"
        reports(sql, "sold", CrystalReportViewer1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "SELECT * FROM `tbltransdetails`  td, `tbltransaction` t WHERE td.`INVOICENO`=t.`INVOICENO` AND MONTH(TRANSDATE)=MONTH(NOW())"
        reports(sql, "monthlysales", CrystalReportViewer1)
    End Sub


End Class