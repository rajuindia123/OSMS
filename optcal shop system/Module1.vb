Imports System.Data
Imports System.Data.SqlClient
Module Module1
    Public con As New SqlConnection("Data Source=DESKTOP-NQ0D1LV\SQLEXPRESS;Initial Catalog=OSMS;Integrated Security=True")
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet
    Public str As String
End Module
