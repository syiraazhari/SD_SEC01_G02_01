Imports System.IO

Public Class frmMainMenu
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim dt As DateTime = Today
        lblD.Text = dt.ToString("dd/MM/yyyy")
        lblL.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub KitchenMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KitchenMasterToolStripMenuItem.Click
        frmKitchen_Section.lblUser.Text = lblUser.Text
        frmKitchen_Section.Reset()
        frmKitchen_Section.ShowDialog()
    End Sub

    Private Sub ItemCategoryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ItemCategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub POSPrinterSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles POSPrinterSettingToolStripMenuItem.Click
        frmPrinterSetting.Reset()
        frmPrinterSetting.ShowDialog()
    End Sub

    Private Sub RestaurantInfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantInfoToolStripMenuItem.Click
        frmRestaurantMaster.lblUser.Text = lblUser.Text
        frmRestaurantMaster.Reset()
        frmRestaurantMaster.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotepadToolStripMenuItem.Click
        Process.Start("Notepad.exe")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Process.Start("Calc.exe")
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Process.Start("Wordpad.exe")
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Process.Start("WinWord.exe")
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Process.Start("TaskMgr.exe")
    End Sub

    Private Sub PaintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaintToolStripMenuItem.Click
        Process.Start("MSPaint.exe")
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.Reset()
        frmLogs.ShowDialog()
    End Sub

    Private Sub ChargeTypeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChargeTypeToolStripMenuItem.Click
        frmInventoryType.lblUser.Text = lblUser.Text
        frmInventoryType.Reset()
        frmInventoryType.ShowDialog()
    End Sub

    Private Sub TablesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TablesToolStripMenuItem.Click
        frmTable.lblUser.Text = lblUser.Text
        frmTable.Reset()
        frmTable.ShowDialog()
    End Sub

    Private Sub MenuItemsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MenuItemsToolStripMenuItem.Click
        frmItem.lblUser.Text = lblUser.Text
        frmItem.Reset()
        frmItem.ShowDialog()
    End Sub

    Private Sub NotesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NotesToolStripMenuItem.Click
        frmNotesMaster.lblUser.Text = lblUser.Text
        frmNotesMaster.Reset()
        frmNotesMaster.ShowDialog()
    End Sub

    Private Sub BillingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BillingToolStripMenuItem.Click
        frmBillling.Reset()
        frmBillling.lblUser.Text = lblUser.Text
        frmBillling.ShowDialog()
    End Sub
    Sub Backup()
        Try
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            If (Not System.IO.Directory.Exists("C:\DBBackup")) Then
                System.IO.Directory.CreateDirectory("C:\DBBackup")
            End If
            Dim destdir As String = "C:\DBBackup\RPOS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".accdb"
            Dim dlg As New SaveFileDialog
            con.Close()
            File.Copy(Application.StartupPath & "\RPOS_DB.accdb", destdir, True)
            Dim st As String = "Sucessfully performed the Database Backup"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DatbaseBackupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DatbaseBackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub DatabaseRestoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DatabaseRestoreToolStripMenuItem.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            Dim dlg As New OpenFileDialog
            dlg.DefaultExt = "*.accdb"
            dlg.Filter = "ACCESS DB|*.accdb|All File|*"
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                con.Close()
                File.Copy(dlg.FileName, Application.StartupPath & "\RPOS_DB.accdb", True)
                frmMainMenu_Load(Nothing, Nothing)
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub frmMainMenu_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
    End Sub

    Private Sub frmMainMenu_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
    Sub LogOut()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuItemsImportExportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MenuItemsImportExportToolStripMenuItem.Click
        frmMenuItemsExportImport.Reset()
        frmMenuItemsExportImport.ShowDialog()
    End Sub

    Private Sub DeleteInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteInvoiceToolStripMenuItem.Click
        frmDeleteInvoice.Reset()
        frmDeleteInvoice.lblUser.Text = lblUser.Text
        frmDeleteInvoice.ShowDialog()
    End Sub

    Private Sub BillingRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillingRecordsToolStripMenuItem.Click
        frmBillingRecord.ShowDialog()
    End Sub

End Class
