Imports Negocio

Public Class Kardex
    Dim k As New ViewPersonal

    Private Sub Kardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        ''cargo el combobox con una consulta que solo me debuelve el Nombre de producto de la tabla prdocutos

        'k.productardex()
        'ComboBox1.DataSource = k._prokardex
        'ComboBox1.ValueMember = "fkproducto"
        'ComboBox1.DisplayMember = "kardex"

        Cargargrilla()


    End Sub

    Sub Cargargrilla()
        k._kardex.Clear()
        '' cargo en el datagridview toda la tabla de kardex 
        k.Kardex()
        DataGridView1.DataSource = k._kardex

        Dim valor As Int16 = DataGridView1.ColumnCount()

        For i = 0 To valor - 1
            DataGridView1.Columns(i).Width = 70
        Next

        DataGridView1.Columns(2).HeaderText = "Producto"
        DataGridView1.Columns(9).Width = 100
        DataGridView1.Columns(11).Width = 100

        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    End Sub


    Private Sub ComboBox1_TextUpdate(sender As Object, e As EventArgs) Handles ComboBox1.TextUpdate

        Static Dim viewtela As New ViewTela
        Dim filtrado As String = Nothing
        Try
            If ComboBox1.Text <> Nothing Then
                DataGridView1.DataSource = Nothing
                viewtela.KardexVTela(ComboBox1.Text, String.Format("{0:yyyy-MM-dd}", DateTimePicker1.Value), String.Format("{0:yyyy-MM-dd}", DateTimePicker2.Value))
                viewtela._KardexViewtela.RowFilter = " fkproducto like '%" & ComboBox1.Text & "%'"
                DataGridView1.DataSource = viewtela._KardexViewtela
            Else

                Cargargrilla()
            End If
        Catch ex As NullReferenceException
            MsgBox("error")
        End Try

        If viewtela._KardexViewtela.Count = 0 Then
            MessageBox.Show(String.Format("no se encontro datos durante el rango de fecha  {0:yyyy-MM-dd} {0:yyyy-MM-dd} ", DateTimePicker1.Value, DateTimePicker2.Value))
        End If

    End Sub



    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        'Columna 1, posición 0
        If e.ColumnIndex = 3 Then
            Dim row As DataGridViewCell = DataGridView1(e.ColumnIndex, e.RowIndex)

            If row.Value = "Compra" Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(178, 255, 51)
            ElseIf row.Value = "Dev.Compra" Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 51)
            ElseIf row.Value = "Produccion" Then
                DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(255, 100, 51)
            End If

        End If

    End Sub






























    Private isTopPanelDragged As Boolean = False

    Private isWindowMaximized As Boolean = False

    Private offset As Point

    Private _normalWindowSize As Size


    Private _normalWindowLocation As Point = Point.Empty

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        If isTopPanelDragged Then
            Dim newPoint As Point = Panel3.PointToScreen(New Point(e.X, e.Y))
            newPoint.Offset(offset)
            Me.Location = newPoint
            If Me.Location.X > 2 OrElse Me.Location.Y > 2 Then
                If Me.WindowState = FormWindowState.Maximized Then
                    Me.Location = _normalWindowLocation
                    Me.Size = _normalWindowSize

                    isWindowMaximized = False
                End If
            End If
        End If
    End Sub

    Private Sub Panel3_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel3.MouseUp
        isTopPanelDragged = False
        If Me.Location.Y <= 5 Then
            If Not isWindowMaximized Then
                _normalWindowSize = Me.Size
                _normalWindowLocation = Me.Location
                Dim rect As Rectangle = Screen.PrimaryScreen.WorkingArea
                Me.Location = New Point(0, 0)
                Me.Size = New System.Drawing.Size(rect.Width, rect.Height)

                isWindowMaximized = True
            End If
        End If
    End Sub

    Private Sub Panel3_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel3.MouseDown
        If e.Button = MouseButtons.Left Then
            isTopPanelDragged = True
            Dim pointStartPosition As Point = Me.PointToScreen(New Point(e.X, e.Y))
            offset = New Point()
            offset.X = Me.Location.X - pointStartPosition.X
            offset.Y = Me.Location.Y - pointStartPosition.Y
        Else
            isTopPanelDragged = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub

    Private Sub ComboBox1_MouseLeave(sender As Object, e As EventArgs) Handles ComboBox1.MouseLeave


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim exel As New Exportar
        If exel.llenarExcel(DataGridView1) Then
            MessageBox.Show(String.Format("se ha generado el Excel correspondiente a el producto {0} en en rango de fecha  desde {1} asta {2}", ComboBox1.Text, DateTimePicker1.Value, DateTimePicker2.Value), "Informacion", MessageBoxButtons.OK)
        End If
    End Sub

End Class