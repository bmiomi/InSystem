Public Class Reporteproducto



    Private Sub Reporteproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ObjReporte As New ReporteProductos

        CrystalReportViewer1.ReportSource = ObjReporte



    End Sub
End Class