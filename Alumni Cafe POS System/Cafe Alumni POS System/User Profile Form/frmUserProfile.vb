Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class frmUserProfile
    Sub Clear()
        txtUsername.Clear()
        txtPassword.Clear()
        txtName.Clear()
        txtEmail.Clear()
        cboRole.Text = ""
        cboStatus.Text = ""
        PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
        PictureBox1.SizeMode = ImageLayout.Zoom
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Sub LoadUser()
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        Try
            cn.Open()
            cmd = New MySqlCommand("Select * From tbl_users", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("UserID").ToString, Read.Item("Username").ToString, Read.Item("Password").ToString, Read.Item("Name").ToString, Read.Item("Email").ToString, Read.Item("Role").ToString, Read.Item("Status").ToString)
            End While
            Read.Close()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check_empty(txtUsername) = True Then Return
        If check_empty(txtPassword) = True Then Return
        If check_empty(txtName) = True Then Return
        If check_empty(txtEmail) = True Then Return
        If check_empty(cboRole) = True Then Return
        If check_empty(cboStatus) = True Then Return

        If ValidateDuplicate("select * from tbl_users where Username='" & txtUsername.Text & "'") = True Then Return

        cn.Open()
        Dim Arr_image() As Byte
        Dim MStream As New MemoryStream
        PictureBox1.Image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png)
        Arr_image = MStream.GetBuffer

        'Hash Password
        Dim salt As String = GenerateSalt(70)
        Dim passHashed As String = HashPassword(txtPassword.Text, salt, 10101, 70)


        cmd = New MySqlCommand("insert into tbl_users(Username,Password,Salt,Name,Email,Role,Status,Image) values(@Username,@Password,@Salt,@Name,@Email,@Role,@Status,@Image)", cn)
        With cmd
            .Parameters.AddWithValue("@Username", txtUsername.Text)
            .Parameters.AddWithValue("@Password", passHashed)
            .Parameters.AddWithValue("@Salt", salt)
            .Parameters.AddWithValue("@Name", txtName.Text)
            .Parameters.AddWithValue("@Email", txtEmail.Text)
            .Parameters.AddWithValue("@Role", cboRole.Text)
            .Parameters.AddWithValue("@Status", cboStatus.Text)
            .Parameters.AddWithValue("@Image", Arr_image)
            .ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("User Details has been save successfully", vbInformation)
        'PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
        Clear()
        LoadUser()
    End Sub

    Private Sub frmUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = Chr(120)
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim Role As String = ""
        Dim Status As String = ""
        Dim colstr As String = Me.Guna2DataGridView1.Columns(e.ColumnIndex).Name

        Try
            If colstr = "ColEdit" Then
                txtPassword.Enabled = False
                cn.Open()
                cmd = New MySqlCommand("select * from tbl_users where UserID='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn) 'Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
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
                btnUpdate.Visible = True
                btnSave.Visible = False
                txtPassword.PasswordChar = Chr(120)

            ElseIf colstr = "ColDel" Then
                If MsgBox("Do you want to delete the userID?", vbYesNo + vbQuestion) = vbYes And Guna2DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString <> "Administrator" Then
                    cn.Open()
                    cmd = New MySqlCommand("delete from tbl_users where UserID='" & Me.Guna2DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("User has successfully deleted", vbInformation)
                End If
            End If
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        LoadUser()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.JPEG;*.GIF)|*.PNG;*.JPEG;*.GIF"
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Nothing
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            If Image.FromFile(OpenFileDialog1.FileName).Size.Width > 350 Or Image.FromFile(OpenFileDialog1.FileName).Size.Height > 350 Then
                MsgBox("Image too large", vbExclamation)
                PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
            End If
        End If
    End Sub

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
        cn.Close()
        MsgBox("User Details has been update successfully", vbInformation)
        Clear()
        LoadUser()
        btnSave.Visible = True
        btnUpdate.Visible = False
        txtPassword.Enabled = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Dim i As Integer
        Me.Guna2DataGridView1.Rows.Clear()
        Try
            cn.Open()
            cmd = New MySqlCommand("Select * From tbl_users where Username like '%" & Guna2TextBox1.Text & "%' or Name like '%" & Guna2TextBox1.Text & "%'", cn)
            Read = cmd.ExecuteReader
            While Read.Read
                i += 1
                Me.Guna2DataGridView1.Rows.Add(i, Read.Item("UserID").ToString, Read.Item("Username").ToString, Read.Item("Password").ToString, Read.Item("Name").ToString, Read.Item("Email").ToString, Read.Item("Role").ToString, Read.Item("Status").ToString)
            End While
            Read.Close()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
End Class