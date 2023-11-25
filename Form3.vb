Public Class Form3
    Private Sub studentinfo_Load(sender As Object, e As EventArgs) Handles studentinfo.Load
        studentinfo.ReportSource = student1
        studentinfo.Refresh()

    End Sub
End Class