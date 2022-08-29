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
        openConnection()

        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM user"

        sqlRd = sqlCmd.ExecuteReader

        If sqlRd.Read Then
            sqlDt.Load(sqlRd)

            'DataGridView1.DataSource = sqlDt
            For Each drRow As DataRow In sqlDt.Rows
                'ListBox1.Items.Add(drRow.Item("name").ToString())
                If drRow.Item("name") = usernameLogin And drRow.Item("password") = passwordLogin Then
                    sqlRd.Close()
                    sqlConn.Close()
                    Return True

                End If
            Next

            Return False

        Else
            MessageBox.Show("No DATA FOUND")
            sqlRd.Close()
            sqlConn.Close()
            Return False
        End If

        Return False

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
            '.CommandText = "INSERT INTO user (empID, name, username, password, role) VALUES ('" & newEmpId & "','" & newEmpName & "','" & newEmpUsername & "','" & newEmpPassword & "','" & newEmpRole & "')"


        End With

        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        updateTable()
        Return True



    End Function

    Public Function getUser() As MySqlDataReader
        openConnection()

        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM user"

        sqlRd = sqlCmd.ExecuteReader
        Return sqlRd


    End Function

    Public Sub updateTable()
        sqlDt.Load(getUser())
        StaffForm.EmployeeDataGridView.Refresh()
        'StaffForm.EmployeeDataGridView.DataSource = sqlDt
        sqlConn.Close()
    End Sub


End Module
