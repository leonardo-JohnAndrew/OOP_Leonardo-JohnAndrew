Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim reportdoc As New ReportDocument
        reportdoc.Load("C:\Users\ITLAB-15\source\repos\OOP_Leonardo,JohnAndrew\reportByID.rpt")
        Dim pdef As ParameterFieldDefinition
        Dim pdefs As ParameterFieldDefinitions
        Dim pvalues As New ParameterValues
        Dim pdvalue As New ParameterDiscreteValue
        pdvalue.Value = Convert.ToInt32(Form1.txtuid.Text)
        pdefs = reportdoc.DataDefinition.ParameterFields
        pdef = pdefs.Item("StudID")
        pvalues = pdef.CurrentValues
        pvalues.Clear()
        pvalues.Add(pdvalue)
        pdef.ApplyCurrentValues(pvalues)
        idviewer.ReportSource = reportdoc
        idviewer.Refresh()

    End Sub
End Class