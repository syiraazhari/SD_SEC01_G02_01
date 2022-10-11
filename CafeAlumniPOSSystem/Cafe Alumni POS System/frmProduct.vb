Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmProduct
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        With frmCategory
            .ShowDialog()
        End With
    End Sub

    Sub LoadCategory()
        cbocategory.Items.Clear()
        cn.Open()
        cmd = New MySqlCommand("select * from tbl_category", cn)
        Read = cmd.ExecuteReader
        While Read.Read
            cbocategory.Items.Add(Read.Item("Category").ToString)
        End While
        Read.Dispose()
        cn.Close()
    End Sub

    Sub clear()
        txtDescription.Clear()
        txtCostPrice.Clear()
        txtSellPrice.Clear()
        cbocategory.SelectedText = ""
        PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If check_empty(txtDescription) = True Then Return
        If check_empty(cbocategory) = True Then Return
        If check_empty(txtCostPrice) = True Then Return
        If check_empty(txtSellPrice) = True Then Return

        Dim _CostPrice As Double = Convert.ToDecimal(txtCostPrice.Text)
        Dim _SellPrice As Double = Convert.ToDecimal(txtSellPrice.Text)

        'If _SellPrice <= _CostPrice Then
        '    MsgBox("Sell Price can't be less than Cost Price", vbInformation)
        '    Return
        'End If

        cn.Open()
        Dim Arr_image() As Byte
        Dim MStream As New MemoryStream
        PictureBox1.Image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png)
        Arr_image = MStream.GetBuffer

        cmd = New MySqlCommand("insert into tbl_product(Description,Category,CostPrice,SellPrice,Image) values(@Description,@Category,@CostPrice,@SellPrice,@Image)", cn)
        With cmd
            .Parameters.AddWithValue("@Description", txtDescription.Text)
            .Parameters.AddWithValue("@Category", cbocategory.Text)
            .Parameters.AddWithValue("@CostPrice", _CostPrice)
            .Parameters.AddWithValue("@SellPrice", _SellPrice)
            .Parameters.AddWithValue("@Image", Arr_image)
            .ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("Product details save successfully", vbInformation)
        PictureBox1.Image = Image.FromFile(Application.StartupPath & "\nopictures.png")
        clear()
        With frmProductList
            .LoadProduct()
        End With
    End Sub

    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategory()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        OpenFileDialog1.Filter = "Image Files(*.PNG;*.JPEG;*.GIF)|*.PNG;*.JPEG;*.GIF"
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If MsgBox("Do you want to delete the category ", vbYesNo + MsgBoxStyle.Question) = vbYes Then
            cn.Open()
            cmd = New MySqlCommand("delete from tbl_category where Category='" & cbocategory.Text & "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("Category has been successfully deleted", vbInformation)
            LoadCategory()
        End If
    End Sub

    Private Sub txtCostPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostPrice.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub txtSellPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSellPrice.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 8
            Case 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If check_empty(txtDescription) = True Then Return
        If check_empty(cbocategory) = True Then Return
        If check_empty(txtCostPrice) = True Then Return
        If check_empty(txtSellPrice) = True Then Return

        Dim _CostPrice As Double = Convert.ToDecimal(txtCostPrice.Text)
        Dim _SellPrice As Double = Convert.ToDecimal(txtSellPrice.Text)

        'If _SellPrice <= _CostPrice Then
        '    MsgBox("Sell Price can't be less than Cost Price", vbInformation)
        '    Return
        'End If

        cn.Open()

        If OpenFileDialog1.FileName <> "OpenFileDialog1" Then
            cmd = New MySqlCommand("update tbl_product set Description=@Description,Category=@Category,CostPrice=@CostPrice,SellPrice=@SellPrice,Image=@Image where PID=@PID", cn)
        Else
            cmd = New MySqlCommand("update tbl_product set Description=@Description,Category=@Category,CostPrice=@CostPrice,SellPrice=@SellPrice where PID=@PID", cn)
        End If

        Dim Arr_image() As Byte
        Dim MStream As New MemoryStream
        PictureBox1.Image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png)
        Arr_image = MStream.GetBuffer

        With cmd
            .Parameters.AddWithValue("@Description", txtDescription.Text)
            .Parameters.AddWithValue("@Category", cbocategory.Text)
            .Parameters.AddWithValue("@CostPrice", _CostPrice)
            .Parameters.AddWithValue("@SellPrice", _SellPrice)
            If OpenFileDialog1.FileName <> "OpenFileDialog1" Then .Parameters.AddWithValue("@Image", Arr_image)
            .Parameters.AddWithValue("@PID", lblPID.Text)
            .ExecuteNonQuery()
        End With
        cn.Close()
        MsgBox("Product details update successfully", vbInformation)
        Me.Dispose()
        With frmProductList
            .LoadProduct()
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class