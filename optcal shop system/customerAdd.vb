Imports System.Data
Imports System.Data.SqlClient
Public Class customerAdd

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then TextBox1.Focus() : Exit Sub
        If TextBox2.Text = "" Then TextBox2.Focus() : Exit Sub
        If TextBox3.Text = "" Then TextBox3.Focus() : Exit Sub
        If TextBox4.Text = "" Then TextBox4.Focus() : Exit Sub
        If TextBox5.Text = "" Then TextBox5.Focus() : Exit Sub
        Try
            con.Open()

            cmd = New SqlCommand("INSERT INTO Customer(CustomerName,Address,Phone,EyePower,[Consultant Doctor]) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')", con)
            Dim i As Integer = cmd.ExecuteNonQuery
            If (i > 0) Then
                MsgBox("Record Saved Successfully  ", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
               
                clr()
                TextBox1.Focus()
            Else
                MsgBox("Record NOT Saved Successfully", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)
            End If
           Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()

        End Try
        con.Close()


    End Sub
    Public Sub clr()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End

    End Sub
End Class