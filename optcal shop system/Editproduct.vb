Imports System.Data
Imports System.Data.SqlClient
Public Class Editproduct
    Private Sub Editproduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getdata()
    End Sub
    Public Sub getdata()
        con.Close()

        con.Open()
        Using cmd As New SqlCommand()
            cmd.CommandText = "Select * From Product"
            cmd.Connection = con
            Dim dt As New DataTable()

            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Close()
        con.Open()
        Using cmd As New SqlCommand()
            cmd.CommandText = "Select * From Product where ProductID LIKE @ID + '%' "
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@ID", TextBox1.Text.Trim())

            Dim dt As New DataTable()

            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    DataGridView1.DataSource = dt
                    TextBox2.Enabled = False
                    TextBox2.Text = dt.Rows(0)(0).ToString()
                    TextBox3.Text = dt.Rows(0)(1).ToString()
                    TextBox4.Text = dt.Rows(0)(2).ToString()
                    TextBox5.Text = dt.Rows(0)(3).ToString()
                    TextBox6.Text = dt.Rows(0)(4).ToString()
                    TextBox7.Text = dt.Rows(0)(5).ToString()
                Else
                    MsgBox("Recode Not Found", MsgBoxStyle.Critical, MsgBoxStyle.OkOnly)
                End If
            End Using
        End Using
    End Sub
    Public Sub cls()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        cls()
        getdata()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        con.Close()


        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("plz FIll the details")
            Exit Sub

        End If
        Try
            con.Close()
            con.Open()
            str = "UPDATE Product set ProductName=@name,EyePower=@eye,GlassType=@gt,FrameType=@ft,Price=@price where ProductID=@id"
            cmd = New SqlCommand(str, con)
            TextBox2.Enabled = False
            cmd.Parameters.AddWithValue("@name", TextBox3.Text)
            cmd.Parameters.AddWithValue("@eye", TextBox4.Text)
            cmd.Parameters.AddWithValue("@gt", TextBox5.Text)
            cmd.Parameters.AddWithValue("@ft", TextBox6.Text)
            cmd.Parameters.AddWithValue("@price", TextBox7.Text)
            cmd.Parameters.AddWithValue("@id", TextBox2.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Record Update Successfully", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
            cls()

            getdata()
        Catch ex As Exception
            MsgBox("Error", ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        con.Close()

        If TextBox2.Text = "" Then
            MsgBox("plz FIll the details")
            Exit Sub
        End If
        con.Open()
        Dim msg As Integer = MsgBox("Do You Really Want To Delete Customer:-'" & TextBox2.Text & "'?", MsgBoxStyle.YesNoCancel, "Delete Customer Record")
        If msg = DialogResult.Yes Then
            cmd = New SqlCommand("Delete from Product Where ProductID='" & TextBox2.Text & "'", con)
            Try

                cmd.ExecuteNonQuery()
                MsgBox("Recrod Delete Successffully...")
                getdata()
                cls()

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()

            End Try
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox2.Enabled = False
        Me.TextBox2.Text = DataGridView1.Item(0, i).Value
        Me.TextBox3.Text = DataGridView1.Item(1, i).Value
        Me.TextBox4.Text = DataGridView1.Item(2, i).Value
        Me.TextBox5.Text = DataGridView1.Item(3, i).Value
        Me.TextBox6.Text = DataGridView1.Item(4, i).Value
        Me.TextBox7.Text = DataGridView1.Item(5, i).Value
    End Sub
End Class