Public Class LogInUserClass
    Dim name As String
    Dim username As String
    Dim employeeId As String
    Dim email As String
    Dim password As String
    Dim role As String

    Public Sub setNewUserLogIn(uName As String, uUsername As String, uEmployeeId As String, uEmail As String, uPassword As String, uRole As String)
        name = uName
        username = uUsername
        employeeId = uEmployeeId
        email = uEmail
        password = uPassword
        role = uRole

    End Sub

    Public Function getName() As String
        Return name
    End Function

    Public Function getUsername() As String
        Return username
    End Function
    Public Function getEmployeeId() As String
        Return employeeId
    End Function
    Public Function getEmail() As String
        Return email
    End Function
    Public Function getPassword() As String
        Return password
    End Function
    Public Function getRole() As String
        Return role
    End Function




End Class
