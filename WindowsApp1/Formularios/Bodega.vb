Imports Negocio
Public Class Bodega
    Dim viewtela As New ViewTela


    Private Sub Bodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Entrada")
        ComboBox2.Items.Add("Salida")
        ComboBox2.Items.Add("Ajuste")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim y As New X

        If ComboBox1.SelectedIndex = 0 Then 'producto
            viewtela.viiie.Clear()
            viewtela.Viewsql()
            DataGridView1.DataSource = viewtela.viiie
            DataGridView1.Columns(1).Width = 119
            y.Y = ComboBox1.Text
        ElseIf ComboBox1.SelectedIndex = 1 Then
            y.Y = ComboBox1.Text
            viewtela.viii.Clear()

            viewtela._Viewsql()
            DataGridView1.DataSource = viewtela.viii
        End If

    End Sub
    '' x1 es entrada salida o ajuste
    '' y es producto o insumo

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Dim frm As New Movimientos
        Dim X1 As New X

        If ComboBox2.SelectedIndex = 0 Then
            X1.X1 = "Entrada"
            frm.Show()
        ElseIf combobox2.SelectedIndex = 1 Then
            X1.X1 = "Salida"
            frm.Show()
        ElseIf ComboBox2.SelectedIndex = 2 Then
            X1.X1 = "Ajuste"
            frm.Show()
        Else
            MsgBox("No disponible")
        End If

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        Main.Label1.Text = Nothing
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim kardex As New Kardex
        kardex.Show()
    End Sub
End Class