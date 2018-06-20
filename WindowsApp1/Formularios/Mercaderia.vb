Imports Negocio
Public Class Mercaderia
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If Val(TextBox2.Text) >= 12 Then
            MsgBox("Usted puede Ingresar entre un rangos de 0 a 11 unidades")
            TextBox2.Text = 0

        End If

    End Sub

    Sub Limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox2.ResetText()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim clsmercaderia As New ClsMercaderia
        Dim datos As New Conexion_Acceso.EntMercaderia With {
            .Codmercaderia = TextBox1.Text,
            .Modelo1 = ComboBox2.Text,
            .CantidadU1 = TextBox2.Text,
            .CantidadD1 = TextBox3.Text
        }

        If clsmercaderia.Ingreso_Mercadera(datos) Then
            MsgBox("Datos Guardados ")
            limpiar()
        Else
            MsgBox("No se Ingreso los Datos")
        End If
    End Sub

    Private Sub splass_Click(sender As Object, e As EventArgs) Handles splass.Click
        Dim view As New ViewPersonal
        If splass.Text = ">>" Then
            splass.Text = "<<"

            While (Panel3.Height <= 172 And Me.Height <= 353 And GroupBox6.Height <= 192)
                Panel3.Height += 1
                Me.Height += 1
                GroupBox6.Height += 1
            End While


            If Panel3.Height = 169 And Me.Height = 354 And GroupBox6.Height = 189 Then
                view._Mercaderia.Clear()
                DataGridView1.Refresh()
                view.Mercaderia()
                DataGridView1.DataSource = view._Mercaderia
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel3.Height > 29 And (Me.Height > 214) And GroupBox6.Height > 49)
                Panel3.Height -= 1
                Me.Height -= 1
                GroupBox6.Height -= 1
            End While
        End If
    End Sub

    Private Sub Cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress, TextBox2.KeyPress

        If Trim(Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private isTopPanelDragged As Boolean = False
    Private isBottomPanelDragged As Boolean = False
    Private isLeftPanelDragged As Boolean = False
    Private isRightPanelDragged As Boolean = False
    Private isWindowMaximized As Boolean = False

    Private _normalWindowSize As Size
    Private offset As Point
    Private _normalWindowLocation As Point = Point.Empty

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If isTopPanelDragged Then
            Dim newPoint As Point = Panel1.PointToScreen(New Point(e.X, e.Y))
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

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
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

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
        Main.Label1.Text = " "
    End Sub

End Class