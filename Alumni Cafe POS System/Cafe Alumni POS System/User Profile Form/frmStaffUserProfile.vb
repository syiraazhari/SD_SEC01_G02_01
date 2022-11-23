Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Public Class frmStaffUserProfile
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If check_empty(txtUsername) = True Then Return
        If check_empty(txtPassword) = True Then Return
        If check_empty(txtName) = True Then Return
        If check_empty(txtEmail) = True Then Return
        If check_empty(cboRole) = True Then Return
        If check_empty(cboStatus) = True Then Return

        cn.Open()

        If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
            cmd = New MySqlCommand("update tbl_users set Username=@Username,Password=@Password,Name=@Name,Email=@Email,Role=@Role,Status=@Status,Image=@Image where UserID='" & lblUserID.Text & "'", cn)
        Else
            cmd = New MySqlCommand("update tbl_users set Username=@Username,Password=@Password,Name=@Name,Email=@Email,Role=@Role,Status=@Status where UserID='" & lblUserID.Text & "'", cn)
        End If

        Dim Arr_image() As Byte
        Dim MStream As New MemoryStream
        PictureBox1.Image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png)
        Arr_image = MStream.GetBuffer

        'cmd = New MySqlCommand("update tbl_users set Username=@Username,Password=@Password,Name=@Name,Email=@Email,Role=@Role,Status=@Status,Image=@Image where UserID='" & lblUserID.Text & "'", cn)

        With cmd
            .Parameters.AddWithValue("@Username", txtUsername.Text)
            .Parameters.AddWithValue("@Password", txtPassword.Text)
            .Parameters.AddWithValue("@Name", txtName.Text)
            .Parameters.AddWithValue("@Email", txtEmail.Text)
            .Parameters.AddWithValue("@Role", cboRole.Text)
            .Parameters.AddWithValue("@Status", cboStatus.Text)
            If OpenFileDialog1.FileName <> "OpenFileDialog1" Then .Parameters.AddWithValue("@Image", Arr_image)
            .ExecuteNonQuery()
        End With

        'FIX
        NameString = txtName.Text
        MainWindow.userLabel.Text = NameString
        RoleString = cboRole.Text

        cn.Close()
        MsgBox("User Details has been update successfully", vbInformation)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Sub Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtName.Clear()
        txtEmail.Clear()
        cboRole.Text = ""
        cboStatus.Text = ""
        PictureBox1.Image = Nothing
        PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
        PictureBox1.SizeMode = ImageLayout.Zoom
    End Sub

    Private Sub frmStaffUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Role As String = ""
        Dim Status As String = ""

        cn.Open()
        cmd = New MySqlCommand("select * from tbl_users where Name='" & NameString & "'", cn)
        Read = cmd.ExecuteReader
        Read.Read()
        If Read.HasRows Then
            Dim arr() As Byte
            Dim MS As System.IO.MemoryStream
            arr = Read.Item("Image")
            MS = New System.IO.MemoryStream(arr)

            lblUserID.Text = Read.Item("UserID").ToString
            txtUsername.Text = Read.Item("Username").ToString
            txtPassword.Text = Read.Item("Password").ToString
            txtName.Text = Read.Item("Name").ToString
            txtEmail.Text = Read.Item("Email").ToString
            Role = Read.Item("Role").ToString
            Status = Read.Item("Status").ToString
            PictureBox1.SizeMode = ImageLayout.Zoom
            PictureBox1.Image = System.Drawing.Image.FromStream(MS)
        End If
        Read.Close()
        cn.Close()
        cboRole.Text = Role
        cboStatus.Text = Status
        txtPassword.PasswordChar = Chr(120)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.JPEG;*.GIF)|*.PNG;*.JPEG;*.GIF"
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            If Image.FromFile(OpenFileDialog1.FileName).Size.Width > 350 Or Image.FromFile(OpenFileDialog1.FileName).Size.Height > 350 Then
                MsgBox("Image too large", vbExclamation)
            End If
        End If
    End Sub
End Class