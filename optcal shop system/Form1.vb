Public Class Form1

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim res As Integer = MsgBox("Do You Realy Want To LogOuct The Application", MsgBoxStyle.YesNo)
        If res = DialogResult.No Then
        ElseIf res = DialogResult.Yes Then
            LoginForm1.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        customerAdd.Show()

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Editcustomer.Show()
    End Sub

    Private Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        Addproduct.Show()
    End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        Editproduct.Show()

    End Sub
End Class
