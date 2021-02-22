Imports System.Data
Imports System.Data.SqlClient
Public Class Addproduct

    Private Sub Addproduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        str = "Select * from Product"
        cmd = New SqlCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Product")
        'for Generating BilL No.
        Dim lastno As Integer
        lastno = ds.Tables("Product").Rows.Count + 1
        If lastno >= 0 Then
            TextBox1.Text = "PID" & lastno

        Else
            TextBox1.Text = "PID" & 0
            TextBox2.Focus()

        End If
        con.Close()


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()

        TextBox2.Focus()


        If TextBox1.Text = "" Then TextBox1.Focus() : Exit Sub
        If TextBox2.Text = "" Then TextBox2.Focus() : Exit Sub
        If TextBox3.Text = "" Then TextBox3.Focus() : Exit Sub
        If TextBox4.Text = "" Then TextBox4.Focus() : Exit Sub
        If TextBox5.Text = "" Then TextBox5.Focus() : Exit Sub
        If TextBox6.Text = "" Then TextBox6.Focus() : Exit Sub
        Try


            con.Open()

            cmd = New SqlCommand("INSERT INTO Product(ProductName,EyePower,GlassType,FrameType,Price) values('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')", con)

            Dim i As Integer = cmd.ExecuteNonQuery
            If (i > 0) Then
                MsgBox("Record Saved Successfully  ", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
                Dim result As Integer = MessageBox.Show("New Product Added. Want To Add Another One .", "Added", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    clr()
                    str = "Select * from Product"
                    cmd = New SqlCommand(str, con)
                    da.SelectCommand = cmd
                    da.Fill(ds, "Product")
                    'for Generating BilL No.
                    Dim lastno As Integer
                    lastno = ds.Tables("Product").Rows.Count + 1
                    If lastno >= 0 Then
                        TextBox1.Text = "PID" & lastno

                    Else
                        TextBox1.Text = "PID" & 0
                        TextBox2.Focus()

                    End If

                End If
            Else
                MsgBox("Record NOT Saved Successfully", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try

        con.Close()
    End Sub
    Public Sub clr()
        ds.Clear()

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


    End Sub
End Class