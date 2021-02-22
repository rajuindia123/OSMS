Imports System.Data
Imports System.Data.SqlClient

Public Class LoginForm1
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        con.Close()

        If UsernameTextBox.Text = "" Then UsernameTextBox.Focus() : Exit Sub
        If PasswordTextBox.Text = "" Then PasswordTextBox.Focus() : Exit Sub
        Try

            str = "Select * From login where UserName='" & UsernameTextBox.Text & "' and Password='" & PasswordTextBox.Text & "'"
            cmd = New SqlCommand(str, con)
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                con.Close()

                My.Forms.Form1.Show()
                Me.Hide()
                clr()

            Else
                MsgBox("UserName & Passwore Not Mateched", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try


        con.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Public Sub clr()
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        UsernameTextBox.Focus()
    End Sub

    Private Sub UsernameLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameLabel.Click

    End Sub
End Class
