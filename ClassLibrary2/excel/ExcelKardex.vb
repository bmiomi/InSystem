Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Public Class Exportar

    Function llenarExcel(ByVal ElGrid As DataGridView) As Boolean

        ElGrid.Columns(0).Name = "No."
        ElGrid.Columns(1).Name = "Fecha"
        ElGrid.Columns(2).Name = "Producto"
        ElGrid.Columns(3).Name = "Detalle"
        ElGrid.Columns(4).Name = "Cantidad Entrdada"
        ElGrid.Columns(5).Name = "Precion Entrdada"
        ElGrid.Columns(6).Name = "Total Entrdada"
        ElGrid.Columns(7).Name = "Cantidad Salida"
        ElGrid.Columns(8).Name = "Precio Salida"
        ElGrid.Columns(9).Name = "Total Salida"
        ElGrid.Columns(10).Name = "Cantidad Existente"
        ElGrid.Columns(11).Name = "Precio Existente"
        ElGrid.Columns(12).Name = "Total Existente"


        'Creamos las variables

        Dim exApp As New Microsoft.Office.Interop.Excel.Application

        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook

        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try

            'Añadimos el Libro al programa, y la hoja al libro

            exLibro = exApp.Workbooks.Add

            exHoja = exLibro.Worksheets.Add()

            ' ¿Cuantas columnas y cuantas filas?

            Dim NCol As Integer = ElGrid.ColumnCount

            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas

            'y vamos escribiendo.

            For i As Integer = 1 To NCol

                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString

            Next

            For Fila As Integer = 0 To NRow - 1

                For Col As Integer = 0 To NCol - 1

                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Item(Col, Fila).Value

                Next

            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna

            'se ajuste al texto

            exHoja.Rows.Item(1).Font.Bold = 1

            exHoja.Rows.Item(1).HorizontalAlignment = 3

            exHoja.Columns.AutoFit()

            'Aplicación visible

            exApp.Application.Visible = True

            exHoja = Nothing

            exLibro = Nothing

            exApp = Nothing

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

            Return False

        End Try

        Return True

    End Function
End Class