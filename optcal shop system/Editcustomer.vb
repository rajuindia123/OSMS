Imports System.Data
Imports System.Data.SqlClient
Public Class Editcustomer

    Private Sub Editcustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Close()
        cusID()
    End Sub
    Public Sub cusID()
        ComboBox1.Text = ""

        con.Close()
        con.Open()
        str = "Select *  from Customer"
        cmd = New SqlCommand(str, con)
        da.SelectCommand = cmd
        da.Fill(ds, "Customer")
        Dim a As Integer = ds.Tables("Customer").Rows.Count - 1
        For i As Integer = 0 To a
            ComboBox1.Items.Add(ds.Tables("Customer").Rows(i)(0).ToString())

        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        con.Close()
        con.Open()
        cmd = New SqlCommand(str, con)
        If IsNumeric(ComboBox1.Text) Then
            cmd.CommandText = "Select * from Customer where CustomerID=@cid"
            cmd.Prepare()
            cmd.Parameters.AddWithValue("@cid", ComboBox1.Text)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Try
                If dr.Read() Then
                    TextBox1.Text = dr.GetValue(1)
                    TextBox2.Text = dr.GetValue(2)
                    TextBox3.Text = dr.GetValue(3)
                    TextBox4.Text = dr.GetValue(4)
                    TextBox5.Text = dr.GetValue(5)
                    dr.Close()

                End If

            Catch ex As Exception
                MsgBox("Error", ex.Message)
                dr.Close()
            Finally
                con.Close()

            End Try

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("plz FIll the details")
            Exit Sub

        End If
        Try
            con.Close()
            con.Open()
            str = "UPDATE Customer set CustomerName=@name,Address=@adderss,Phone=@phone,EyePower=@ep,[Consultant Doctor]=@cd where CustomerID=@id"
            cmd = New SqlCommand(str, con)
            cmd.Parameters.AddWithValue("@name", TextBox1.Text)
            cmd.Parameters.AddWithValue("@adderss", TextBox2.Text)
            cmd.Parameters.AddWithValue("@phone", TextBox3.Text)
            cmd.Parameters.AddWithValue("@ep", TextBox4.Text)
            cmd.Parameters.AddWithValue("@cd", TextBox5.Text)
            cmd.Parameters.AddWithValue("@id", ComboBox1.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Record Update Successfully", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)
            clr()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()

        End Try
    End Sub
    Public Sub clr()
        ComboBox1.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("plz FIll the details")
            Exit Sub

        End If
        Dim msg As Integer = MsgBox("Do You Really Want To Delete Customer:-'" & TextBox1.Text & "'?", MsgBoxStyle.YesNoCancel, "Delete Customer Record")
        If msg = DialogResult.Yes Then
            Try
                con.Close()
                con.Open()
                str = "Delete From Customer Where CustomerID=@id"
                cmd = New SqlCommand(str, con)
                cmd.Parameters.AddWithValue("@id", ComboBox1.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Customer Record Delete ", MsgBoxStyle.Information, MsgBoxStyle.OkOnly)

                clr()
                Dim ctr As Integer
                ComboBox1.Items.Clear()
                ds.Clear()
                str = "Select * from Customer"
                cmd = New SqlCommand(str, con)
                da.SelectCommand = cmd

                da.Fill(ds, "Customer")
                ctr = ds.Tables("customer").Rows.Count - 1
                For i = 0 To ctr
                    ComboBox1.Items.Add(ds.Tables("Customer").Rows(i)(0).ToString)

                Next


            Catch ex As Exception
                MsgBox("Record Not  Delete")
            Finally
                con.Close()

            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
End Class