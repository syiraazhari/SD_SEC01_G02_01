Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading.Tasks
Imports System.Text
Imports System.Runtime.InteropServices
Imports EASendMail

Module ModuleGoogleOauth

    Public oneTimeCode As Integer
    'Sub Main(ByVal args As String())
    '    Console.WriteLine("+------------------------------------------------------------------+")
    '    Console.WriteLine("  Sign in with Google                                             ")
    '    Console.WriteLine("   If you got ""This app isn't verified"" information in Web Browser, ")
    '    Console.WriteLine("   click ""Advanced"" -> Go to ... to continue test.")
    '    Console.WriteLine("+------------------------------------------------------------------+")
    '    Console.WriteLine("")
    '    Console.WriteLine("Press any key to sign in...")
    '    Console.ReadKey()

    '    Try
    '        Dim p As GoogleOauth = New GoogleOauth()
    '        p.DoOauthAndSendEmail()
    '    Catch ep As Exception
    '        Console.WriteLine(ep.ToString())
    '    End Try

    '    Console.ReadKey()
    'End Sub

    Public Class GoogleOauth
        Private Sub SendMailWithXOAUTH2(ByVal userEmail As String, ByVal accessToken As String, ByVal toEmail As String)
            ' Create a random number generator
            Dim Generator As System.Random = New System.Random()

            ' Get a random number >= MyMin and <= MyMax
            oneTimeCode = Generator.Next(1000, 9999)


            ' Gmail SMTP server address
            Dim oServer As SmtpServer = New SmtpServer("smtp.gmail.com")
            ' enable SSL connection
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto
            ' Using 587 port, you can also use 465 port
            oServer.Port = 587

            ' use SMTP OAUTH 2.0 authentication
            oServer.AuthType = SmtpAuthType.XOAUTH2
            ' set user authentication
            oServer.User = userEmail
            ' use access token as password
            oServer.Password = accessToken

            Dim oMail As SmtpMail = New SmtpMail("TryIt")

            ' Your email address
            oMail.From = "alumnicafepos@gmail.com"

            ' Please change recipient address to yours for test
            oMail.[To] = toEmail
            oMail.Subject = "One-Time Code to Change Password"
            oMail.TextBody = "Your code is " + oneTimeCode.ToString

            Console.WriteLine("start to send email using OAUTH 2.0 ...")

            Dim oSmtp As SmtpClient = New SmtpClient()
            oSmtp.SendMail(oServer, oMail)

            Console.WriteLine("The email has been submitted to server successfully!")
        End Sub

        ' client configuration
        ' You should create your client id And client secret,
        ' do Not use the following client id in production environment, it Is used for test purpose only.
        Const clientID As String = "177707143075-bgfl0m1rmvodabiiiav593854k45n91l.apps.googleusercontent.com"
        Const clientSecret As String = "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"
        Const scope As String = "openid%20profile%20email%20https://mail.google.com"
        Const authUri As String = "https://accounts.google.com/o/oauth2/v2/auth"
        Const tokenUri As String = "https://www.googleapis.com/oauth2/v4/token"

        Private Shared Function GetRandomUnusedPort() As Integer
            Dim listener = New TcpListener(IPAddress.Loopback, 0)
            listener.Start()
            Dim port = (CType(listener.LocalEndpoint, IPEndPoint)).Port
            listener.[Stop]()
            Return port
        End Function

        Public Async Sub DoOauthAndSendEmail(ByVal toEmail As String)
            ' Creates a redirect URI using an available port on the loopback address.
            Dim redirectUri As String = String.Format("http://127.0.0.1:{0}/", GetRandomUnusedPort())
            Console.WriteLine("redirect URI: " & redirectUri)

            ' Creates an HttpListener to listen for requests on that redirect URI.
            Dim http = New HttpListener()
            http.Prefixes.Add(redirectUri)
            Console.WriteLine("Listening ...")
            http.Start()

            ' Creates the OAuth 2.0 authorization request.
            Dim authorizationRequest = String.Format("{0}?response_type=code&scope={1}&redirect_uri={2}&client_id={3}",
                                            authUri,
                                            scope,
                                            Uri.EscapeDataString(redirectUri),
                                            clientID)

            ' Opens request in the browser
            System.Diagnostics.Process.Start(authorizationRequest)

            ' Waits for the OAuth authorization response.
            Dim context = Await http.GetContextAsync()

            ' Brings the Console to Focus.
            BringConsoleToFront()

            ' Sends an HTTP response to the browser.
            Dim response = context.Response
            Dim responseString As String = String.Format("<html><head></head><body>Please return to the app and close current window.</body></html>")
            Dim buffer = Encoding.UTF8.GetBytes(responseString)
            response.ContentLength64 = buffer.Length
            Dim responseOutput = response.OutputStream
            Dim responseTask As Task = responseOutput.
                WriteAsync(buffer, 0, buffer.Length).
                ContinueWith(Sub(task)
                                 responseOutput.Close()
                                 http.[Stop]()
                                 Console.WriteLine("HTTP server stopped.")
                             End Sub)

            ' Checks for errors.
            If context.Request.QueryString.[Get]("error") IsNot Nothing Then
                Console.WriteLine(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.[Get]("error")))
                Return
            End If

            If context.Request.QueryString.[Get]("code") Is Nothing Then
                Console.WriteLine("Malformed authorization response. " & context.Request.RawUrl)
                Return
            End If

            ' extracts the authorization code
            Dim code = context.Request.QueryString.[Get]("code")
            Console.WriteLine("Authorization code: " & code)

            Dim responseText As String = Await RequestAccessToken(code, redirectUri)
            Console.WriteLine(responseText)

            Dim parser As OAuthResponseParser = New OAuthResponseParser()
            parser.Load(responseText)

            Dim user = parser.EmailInIdToken
            Dim accessToken = parser.AccessToken

            Console.WriteLine("User: {0}", user)
            Console.WriteLine("AccessToken: {0}", accessToken)

            SendMailWithXOAUTH2(user, accessToken, toEmail)
        End Sub

        Private Async Function RequestAccessToken(ByVal code As String, ByVal redirectUri As String) As Task(Of String)
            Console.WriteLine("Exchanging code for tokens...")

            ' builds the  request
            Dim tokenRequestBody = String.Format("code={0}&redirect_uri={1}&client_id={2}&client_secret={3}&grant_type=authorization_code",
                                            code,
                                            Uri.EscapeDataString(redirectUri),
                                            clientID,
                                            clientSecret)

            ' sends the request
            Dim tokenRequest As HttpWebRequest = CType(WebRequest.Create(tokenUri), HttpWebRequest)
            tokenRequest.Method = "POST"
            tokenRequest.ContentType = "application/x-www-form-urlencoded"
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"

            Dim _byteVersion As Byte() = Encoding.ASCII.GetBytes(tokenRequestBody)
            tokenRequest.ContentLength = _byteVersion.Length
            Dim stream As Stream = tokenRequest.GetRequestStream()
            Await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length)
            stream.Close()

            Try
                ' gets the response
                Dim tokenResponse As WebResponse = Await tokenRequest.GetResponseAsync()

                Using reader As StreamReader = New StreamReader(tokenResponse.GetResponseStream())
                    ' reads response body
                    Return Await reader.ReadToEndAsync()
                End Using

            Catch ex As WebException

                If ex.Status = WebExceptionStatus.ProtocolError Then
                    Dim response = TryCast(ex.Response, HttpWebResponse)

                    If response IsNot Nothing Then
                        Console.WriteLine("HTTP: " & response.StatusCode)

                        ' reads response body
                        Using reader As StreamReader = New StreamReader(response.GetResponseStream())
                            Dim responseText As String = reader.ReadToEnd()
                            Console.WriteLine(responseText)
                        End Using
                    End If
                End If

                Throw ex
            End Try
        End Function

        ' Hack to bring the Console window to front.
        Public Sub BringConsoleToFront()
            SetForegroundWindow(GetConsoleWindow())
        End Sub

        Private Declare Auto Function GetConsoleWindow Lib "kernel32.dll" () As IntPtr
        Private Declare Auto Function SetForegroundWindow Lib "user32.dll" (ByVal hWnd As IntPtr) As Int32

    End Class

End Module