Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()
        txtFirst.Enabled = False
        txtLast.Enabled = False
        txtstudcourse.Enabled = False
        btndelete.Enabled = False
        btnupdate.Enabled = False

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        SaveRecord()
    End Sub
    Private Sub btnSEARCH_Click(sender As Object, e As EventArgs) Handles btnSEARCH.Click
        Search()
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Dim ANS As DialogResult = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ANS = DialogResult.Yes Then
            UpdateRecords(txtuid.Text, txtFirst.Text, txtLast.Text, txtstudcourse.Text)
            MsgBox("Update successfull!")
        Else
            MsgBox("Update Cancelled! ")
        End If

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim ANS As DialogResult = MessageBox.Show("Do you want to delete records ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If ANS = DialogResult.Yes Then
            DELETE(txtuid.Text)
            MsgBox("Delete successfull!")
        Else
            MsgBox("Delete Cancelled! ")
        End If
    End Sub
End Class
