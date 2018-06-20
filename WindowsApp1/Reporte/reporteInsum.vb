Public Class reporteInsum



    Private Sub reporteInsum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjReporte As New CrystalReport1
        CrystalReportViewer1.ReportSource = ObjReporte

    End Sub






End Class