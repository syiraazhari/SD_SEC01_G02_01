Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32

Module database
    Public sqlConn As New MySqlConnection
    Public sqlCmd As New MySqlCommand
    Public sqlRd As MySqlDataReader
    Public sqlDt As New DataTable
    Public DtA As New MySqlDataAdapter
    Dim sqlQuery As String

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = ""
    Dim database As String = "alumnicafepos"

    Public loginStatus As Boolean

    Private bitmap As Bitmap

    Public Sub openConnection()
        With sqlConn
            .ConnectionString = "server = " + server + ";user id = " + username + ";password = " + password + ";database = " + database
            .Open()
        End With
    End Sub
    Public Function checkUserLogin(usernameLogin As String, passwordLogin As String) As Boolean

        'Need to use HasRows instead of Read(). Read() will skips thr first row
        'Reference: https://stackoverflow.com/questions/15448616/datareader-not-displaying-first-row

        'openConnection()

        'sqlCmd.Connection = sqlConn
        'sqlCmd.CommandText = "SELECT * FROM user"

        'sqlRd = sqlCmd.ExecuteReader
        Dim processUsersList As MySqlDataReader = getUser()

        If processUsersList.HasRows Then
            While (processUsersList.Read)
                If processUsersList("name") = usernameLogin And processUsersList("password") = passwordLogin Then
                    sqlRd.Close()
                    sqlConn.Close()
                    Return True
                End If
            End While

        Else
            MessageBox.Show("User not found")
            sqlRd.Close()
            sqlConn.Close()
            Return False
        End If

        sqlRd.Close()
        sqlConn.Close()
        Return False

        'If sqlRd.Read Then
        '    sqlDt.Load(sqlRd)

        '    For i As Integer = 0 To sqlDt.Rows.Count - 1
        '        Dim drRow As DataRow = sqlDt.Rows(i)
        '        If drRow.Item("name") = usernameLogin And drRow.Item("password") = passwordLogin Then
        '            sqlConn.Close()
        '            Return True

        '        End If
        '    Next

        '    For Each drRow As DataRow In sqlDt.Rows
        '        If drRow.Item("name") = usernameLogin And drRow.Item("password") = passwordLogin Then
        '            sqlConn.Close()
        '            Return True
        '        End If
        '    Next drRow

        '    MessageBox.Show("User not found")
        '    sqlRd.Close()
        '    sqlConn.Close()
        '    Return False


        'Else
        '    MessageBox.Show("No DATA FOUND")
        '    sqlRd.Close()
        '    sqlConn.Close()
        '    Return False

        '    Return False
        'End If

    End Function

    Public Function addNewEmployee(newEmpId As String, newEmpName As String, newEmpUsername As String, newEmpPassword As String, newEmpRole As String) As Boolean
        openConnection()

        With sqlCmd
            .Connection = sqlConn
            .CommandText = "INSERT INTO user(empID, name, username, password, role) VALUES (@newEmpId, @newEmpName, @newEmpUsername, @newEmpPassword, @newEmpRole)"
            .Parameters.AddWithValue("@newEmpId", newEmpId)
            .Parameters.AddWithValue("@newEmpName", newEmpName)
            .Parameters.AddWithValue("@newEmpUsername", newEmpUsername)
            .Parameters.AddWithValue("@newEmpPassword", newEmpPassword)
            .Parameters.AddWithValue("@newEmpRole", newEmpRole)


        End With

        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        updateTable()
        Return True



    End Function

    Public Function getUser() As MySqlDataReader
        With sqlConn
            .ConnectionString = "server = " + server + ";user id = " + username + ";password = " + password + ";database = " + database
            .Open()
        End With

        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM user"

        sqlRd = sqlCmd.ExecuteReader()
        Return sqlRd


    End Function

    Public Sub updateTable()
        sqlDt.Load(getUser())
        StaffForm.EmployeeDataGridView.Refresh()
        'StaffForm.EmployeeDataGridView.DataSource = sqlDt
        sqlConn.Close()
    End Sub

    Public Function getDatabase(query As String) As MySqlDataReader

        With sqlConn
            .ConnectionString = "server = " + server + ";user id = " + username + ";password = " + password + ";database = " + database
            .Open()
        End With

        sqlCmd.Connection = sqlConn

        With sqlCmd
            .CommandText = "SELECT * FROM user WHERE username = @username"
            .CommandType = CommandType.Text
            '.Parameters.AddWithValue("@table", table)
            .Parameters.AddWithValue("@username", query)


        End With

        sqlRd = sqlCmd.ExecuteReader()
        Return sqlRd
        'sqlConn.Close()

        'updateTable()

        'MessageBox.Show("SELECT * FROM " + table + " WHERE " + query)
        'sqlCmd.Connection = sqlConn
        'sqlCmd.CommandText = "SELECT * FROM " + table + " WHERE " + query

        'sqlRd = sqlCmd.ExecuteReader
        'Return sqlRd
    End Function


    Public Function updateDatabase(table As String, update As String, query As String) As Boolean
        openConnection()

        Try
            sqlCmd.Connection = sqlConn
            sqlCmd.CommandText = "UPDATE " + table + " SET " + update + " WHERE " + query
            sqlCmd.ExecuteReader()
            sqlConn.Close()

            Return True
        Catch ex As Exception
            sqlConn.Close()
            MessageBox.Show(ex.ToString)
        End Try

        sqlConn.Close()
        Return False

    End Function

    Public Sub updateUserProfile(uName As String, uUsername As String, uEmail As String, uPassword As String, empID As String)

        With sqlConn
            .ConnectionString = "server = " + server + ";user id = " + username + ";password = " + password + ";database = " + database
            .Open()
        End With

        sqlCmd.Connection = sqlConn

        With sqlCmd
            .CommandText = "UPDATE user SET name = @uName, username = @uUsername, email = @uEmail, password = @uPassword WHERE empID = @empID"

            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@uName", uName)
            .Parameters.AddWithValue("@uUsername", uUsername)
            .Parameters.AddWithValue("@uEmail", uEmail)
            .Parameters.AddWithValue("@uPassword", uPassword)
            .Parameters.AddWithValue("@empID", empID)

        End With

        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        updateTable()
    End Sub






End Module
