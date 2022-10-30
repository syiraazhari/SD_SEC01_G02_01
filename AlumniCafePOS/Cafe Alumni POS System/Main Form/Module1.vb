Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Public Module Module1
    Public cn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public Read As MySqlDataReader
    Public StrUserID As String
    Public UserString As String
    Public PassString As String
    Public SaltString As String
    Public NameString As String
    Public EmailString As String
    Public RoleString As String
    Public StatusString As String

    Sub Connection()
        cn = New MySqlConnection
        With cn
            .ConnectionString = "server=localhost;user id=root;password=;port=3306;database=alumnicafe;"
        End With
    End Sub

    Public Function check_empty(text As Object) As Boolean
        If text.text = "" Then
            MsgBox("Required field are empty", vbCritical)
            text.backcolor = Color.LightYellow
            text.focus
            check_empty = True
        Else
            text.backcolor = Color.White
            check_empty = False
        End If
    End Function

    Public Function GenerateSalesInvoice() As String
        Dim str As String
        Dim SDate As String = Now.ToString("yyyyMMdd")

        Try
            cn.Open()
            cmd = New MySqlCommand("select Max(InvoiceNo) from tbl_sales", cn)
            If IsDBNull(cmd.ExecuteScalar) Then
                str = SDate & "10001"
            Else
                str = cmd.ExecuteScalar + 1
            End If
            cn.Close()
            Return str
        Catch ex As Exception
            Return Now.ToString("yyyyMMdd") & "10001"
            cn.Close()
            MsgBox(ex.Message)
        End Try

    End Function
    Function ValidateDuplicate(ByVal Sql As String) As Boolean
        cn.Open()
        cmd = New MySqlCommand(Sql, cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            ValidateDuplicate = True
            MsgBox("Warning: Duplicate Entry", vbExclamation)
            Read.Close()
            cn.Close()
        Else
            ValidateDuplicate = False
            Read.Close()
            cn.Close()
        End If
        Read.Close()
        cn.Close()
        Return ValidateDuplicate
    End Function

    Function Gettax() As Double

        cn.Open()
        cmd = New MySqlCommand("select * from tbl_tax", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then Gettax = CDbl(Read.Item("tax").ToString) Else Gettax = "0.00"
        Read.Close()
        cn.Close()
        Return Gettax
    End Function

    Function ValidateData(ByVal Sql As String) As Boolean
        cn.Open()
        cmd = New MySqlCommand(Sql, cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            ValidateData = True
            Read.Close()
            cn.Close()
        Else
            ValidateData = False
            MsgBox("Email not Found. Please enter valid email", vbExclamation)
            Read.Close()
            cn.Close()
        End If
        Read.Close()
        cn.Close()
        Return ValidateData
    End Function


    'Hash Code

    Function GenerateSalt(ByVal nSalt As Integer) As String
        Dim saltBytes = New Byte(nSalt) {}

        Using provider = New RNGCryptoServiceProvider()
            provider.GetNonZeroBytes(saltBytes)
        End Using

        Return Convert.ToBase64String(saltBytes)
    End Function

    Function HashPassword(ByVal password As String, ByVal salt As String, ByVal nIterations As Integer, ByVal nHash As Integer) As String
        Dim saltBytes = Convert.FromBase64String(salt)

        Using rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, saltBytes, nIterations)
            Return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash))
        End Using
    End Function
End Module
