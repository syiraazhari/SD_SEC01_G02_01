Imports MySql.Data.MySqlClient

Module janobe
    Public Sub writeThisError(ByVal errMsg As String)
        Try
            Dim FILE_NAME As String = Application.StartupPath & "\errorlogfile.txt"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)

            objWriter.WriteLine(errMsg)
            objWriter.Close()
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub
    Public Function getAutonumber(ByVal str As String) As Integer
        janobefindthis("SELECT CONCAT(`AUTOEND`+`AUTOINC`) FROM `tblautonumber` where AUTOCODE='" & str & "'")
        LoadSingleResult("autonumber")
        Return autonumber
    End Function
    Public Function collectionofToday() As Double

        janobefindthis("SELECT * FROM `tbltransaction` where DATE(TRANSDATE)='" & Format(Now(), "yyyy-MM-dd") & "'")
        If GetNumRows() > 0 Then
            janobefindthis("SELECT SUM(`TOTALDUE`) FROM `tbltransaction` where DATE(TRANSDATE)='" & Format(Now(), "yyyy-MM-dd") & "'")
            LoadSingleResult("DailyCollection")
            Return dailyCollection
        Else
            Form1.txtdailycollection.Text = "0.00"
        End If

        Return Nothing
    End Function


    Public Function DefaultResultID() As Integer
        Dim table As New DataTable

        Try
            da.SelectCommand = cmd
            da.Fill(table)

            If table.Rows.Count > 0 Then

                Return table.Rows(0).Item(0)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Nothing
    End Function

    Public Function DefaultResult() As Boolean
        Dim table As New DataTable

        Try
            da.SelectCommand = cmd
            da.Fill(table)

            If table.Rows.Count > 0 Then

                Return True
            Else

                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return Nothing
    End Function
    Public Function isemptyresult() As Integer
        Try
            If GetNumRows() > 0 Then

                Return GetNumRows()

            End If
        Catch ex As Exception
            writeThisError(Format(Now, "Long Date") & " " & Date.Now.ToString("H:mm:ss") & " ===>> " & ex.Message)
            MsgBox(ex.Message)
        End Try

        Return Nothing

    End Function
    Public Function GetCount() As Integer
        Dim table As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(table)

            Return table.Rows(0).Item(0)

        Catch ex As Exception
            writeThisError(Format(Now, "Long Date") & " " & Date.Now.ToString("H:mm:ss") & " ===>> " & ex.Message)
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Function GetNumRows() As Integer
        Dim table As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(table)

            Return table.Rows.Count

        Catch ex As Exception
            writeThisError(Format(Now, "Long Date") & " " & Date.Now.ToString("H:mm:ss") & " ===>> " & ex.Message)
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Sub txtAutocomplete(sql As String, txt As TextBox)
        Try
            MyConn.Open()
            cmd = New MySqlCommand
            With cmd
                .Connection = MyConn
                .CommandText = sql
            End With
            dReader = cmd.ExecuteReader()
            txt.AutoCompleteCustomSource.Clear()
            Do While dReader.Read = True
                txt.AutoCompleteCustomSource.Add(dReader(0).ToString)
            Loop



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MyConn.Close()
            dReader.Dispose()

        End Try
    End Sub
#Region "Auto Fill"

    Public Sub autofill(ByVal txt As Object)
        Dim publictable As New DataTable

        Try
            da.SelectCommand = cmd
            da.Fill(publictable)

            Dim r As DataRow

            txt.AutoCompleteCustomSource.Clear()
            'for each datarow in the rows of the datatable
            For Each r In publictable.Rows
                'adding the specific row of the table in the AutoCompleteCustomSource of the textbox
                txt.AutoCompleteCustomSource.Add(r.Item("ACCOUNT_USERNAME").ToString)
            Next


            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Public Sub autofillid(ByVal txt As Object)
        Dim publictable As New DataTable

        Try
            da.SelectCommand = cmd
            da.Fill(publictable)

            Dim r As DataRow

            txt.AutoCompleteCustomSource.Clear()
            'for each datarow in the rows of the datatable
            For Each r In publictable.Rows
                'adding the specific row of the table in the AutoCompleteCustomSource of the textbox
                txt.AutoCompleteCustomSource.Add(r.Item("IDNO").ToString)
            Next


            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

#End Region
#Region "Fill Combo Box"

    Public Sub fillcombo(ByVal combo As Object, ByVal member As String, ByVal idparam As String)
        Dim publictable As New DataTable
        Try
            da.SelectCommand = cmd
            da.Fill(publictable)
            With combo
                .DataSource = publictable
                .displaymember = member
                .valuemember = idparam
            End With

            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

#End Region
    Public Sub ClearAll(ByVal group As Object, ByVal what As String)

        Select Case what

            Case "Category"
                For Each ctrl As Control In group.Controls
                    If ctrl.GetType Is GetType(TextBox) Then
                        ctrl.Text = Nothing
                    End If
                Next
            Case "employee"
                For Each ctrl As Control In group.Controls
                    If ctrl.GetType Is GetType(TextBox) Then
                        ctrl.Text = Nothing
                    End If
                Next
            Case "Items"
                For Each ctrl As Control In group.Controls
                    If ctrl.GetType Is GetType(TextBox) Then
                        ctrl.Text = Nothing
                    End If
                Next
        End Select
    End Sub

    Public Sub closeChildForm()
        For Each ChildForm As Form In Form1.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Public Sub anyfrm(ByVal frm As Object)

        With frm

            .MdiParent = Form1
            ' .Dock = DockStyle.Fill
            .Show()
        End With

    End Sub
End Module
