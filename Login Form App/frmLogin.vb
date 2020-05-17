Public Class frmLogin

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dt As New DataSet
        Dim sqlQuery As String = "SELECT * FROM Users WHERE UserNumber = " & Val(txtUserNumber.Text) & " AND UserPassword = '" & txtUserPassword.Text & "'"
        LoginPro(sqlQuery, dt)
        If dt.Tables(0).Rows.Count <> 0 Then
            MsgBox("Thanks Login Success to" & vbNewLine & txtUserName.Text)
            txtUserName.Clear()
            txtUserNumber.Clear()
            txtUserPassword.Clear()
            dt.Clear()
        Else
            MsgBox("Plz Try Again!!")
            txtUserName.Clear()
            txtUserNumber.Clear()
            txtUserPassword.Clear()
            dt.Clear()
        End If
    End Sub

    Private Sub txtUserNumber_TextChanged(sender As Object, e As EventArgs) Handles txtUserNumber.TextChanged
        Dim dt As New DataSet
        Dim sql As String = "SELECT UserName FROM Users WHERE UserNumber=" & CInt(Val(txtUserNumber.Text))
        LoginPro(sql, dt)
        If dt.Tables(0).Rows.Count <> 0 Then
            txtUserName.Text = dt.Tables(0).Rows(0).Item(0).ToString
        Else
            txtUserName.Clear()
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblInfo.Text = vbNewLine & "You Can Use This to Login: " & vbNewLine & "UserNumber: 10001      Password: 123" & vbNewLine & "UserNumber: 10002      Password: 111"
    End Sub
End Class
