Imports MySql.Data.MySqlClient
Module db
    Public MyConn As MySqlConnection = myconnecction()
    Public result As Integer
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dReader As MySqlDataReader
    Public sql As String = ""
    Public reportselect, reportname As String
    Public switch, switchcurr As String
    Public issucess As Boolean
    Public fullname As String = ""
    Public usertype As String = ""
    Public userID As Integer = 0
    Public autonumber As Integer
    Public dailyCollection As Double
    Public itemMessage As String = ""
    Public combo As String
    Public subtotal As Double
    Public totaldue As Double
    Public discount As Double
    Public vat As Double
    Public totalPriceofItem As Double
    Public ds As New DataSet

    Public Function myconnecction() As MySqlConnection

        Return New MySqlConnection(My.Settings.janobesettings)
    End Function
    Public Sub janobefindthis(ByVal sql As String)
        Try
            MyConn.Open()
            With cmd
                .Connection = MyConn
                .CommandText = sql
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            MyConn.Close()
        End Try


    End Sub
    Public Function janobeinsert(ByVal sql As String) As Boolean

        Try
            MyConn.Open()
            With cmd
                .Connection = MyConn
                .CommandText = sql

                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    Return False
                Else
                    Return True
                End If
            End With
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            MyConn.Close()

        End Try

    End Function


    Public Function janoupdate(ByVal sql As String) As Boolean
        Try
            MyConn.Open()
            With cmd
                .Connection = MyConn
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then

                    Return False
                Else
                    Return True

                End If
            End With
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            MyConn.Close()

        End Try

    End Function

    Public Function janobedelete(ByVal sql As String) As Boolean
        Try
            MyConn.Open()
            With cmd
                .Connection = MyConn
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    Return False
                Else
                    Return True
                End If
            End With
            'Catch ex As Exception
            '    MsgBox(ex.Message, MsgBoxStyle.Information)
        Finally
            MyConn.Close()

        End Try
    End Function

#Region "Report"
    Public Sub reports(ByVal sql As String, ByVal rptname As String, ByVal crystalRpt As Object)
        Try
            MyConn.Open()

            Dim reportname As String
            With cmd
                .Connection = MyConn
                .CommandText = sql
            End With
            ds = New DataSet
            da = New MySqlDataAdapter(sql, MyConn)
            da.Fill(ds)
            reportname = rptname
            Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim strReportPath As String
            strReportPath = Application.StartupPath & "\report\" & reportname & ".rpt"
            With reportdoc
                .Load(strReportPath)
                .SetDataSource(ds.Tables(0))
            End With
            With crystalRpt
                .Displaytoolbar = True
                .DisplayStatusbar = True
                .ShowRefreshButton = False
                .ShowCloseButton = False
                .ShowGroupTreeButton = False
                .ReportSource = reportdoc
            End With
        Catch ex As Exception
            MsgBox(ex.Message & "No Crystal Reports have been Installed")
        Finally
            MyConn.Close()
            da.Dispose() 
        End Try
    End Sub
#End Region


End Module
