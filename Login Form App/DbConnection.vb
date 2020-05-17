Imports System.Data.OleDb

Module DbConnection
    ReadOnly dbSource As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Db.accdb"
    Public conAn As New OleDb.OleDbConnection(dbSource)
    Dim da As OleDb.OleDbDataAdapter

    Public Sub LoginPro(ByVal sql As String, ByVal dt As DataSet)
        If conAn.State = ConnectionState.Closed Then
            conAn.Open()
        End If
        Try
            da = New OleDbDataAdapter(sql, conAn)
            da.Fill(dt)
            conAn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module
