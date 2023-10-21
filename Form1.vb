Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        txtFirst.Enabled = False
        txtLast.Enabled = False
        txtstudcourse.Enabled = False
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        SaveRecord()
    End Sub

    Private Sub btnSEARCH_Click(sender As Object, e As EventArgs) Handles btnSEARCH.Click
        Search()

    End Sub
End Class
