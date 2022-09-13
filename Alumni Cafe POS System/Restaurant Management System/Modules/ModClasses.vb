Imports System.Data.OleDb
Module ModClasses
    Public con As OleDbConnection = Nothing
    Public cmd, cmd1, cmd2, cmd3, cmd4 As OleDbCommand
    Public rdr As OleDbDataReader = Nothing
    Public ds As DataSet
    Public adp, adp1, adp2, adp3, adp4 As OleDbDataAdapter
    Public dtable, dtable1, dtable2, dtable3, dtable4 As DataTable
    Public TempFileNames2 As String
End Module
