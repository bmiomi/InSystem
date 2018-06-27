Imports Negocio
Public Class Registro

    Private loginC As New LoginClase
    Private datos As New Conexion_Acceso.EnLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Or String.IsNullOrEmpty(TextBox3.Text) Then
            MsgBox("Campos vacios Intente llenandos los Campos.")
        Else

            If loginC.datosregistro(datos) Then
                MsgBox("Gracias por registrarte en nuestra plataforma", MessageBoxIcon.Information, "Informacion")
            End If
        End If


    End Sub


    Private Sub TextBox3_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox3.Validating
        If TextBox3.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextBox3, "Ingrese una contraseña")
            TextBox3.Focus()
        Else
            datos.Password = TextBox3.Text
            ErrorProvider1.SetError(TextBox3, Nothing)
        End If
    End Sub

    Private Sub TextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If TextBox1.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextBox1, "Ingrese un Usuario con el cual se identificara")
            TextBox1.Focus()
        Else
            datos.Usuario = TextBox1.Text
            ErrorProvider1.SetError(TextBox1, Nothing)
        End If
    End Sub

    Private Sub TextBox2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        If TextBox2.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextBox2, "Ingrese el cargo con el que desempeñara la funcion en el sitema")
            TextBox2.Focus()
        Else
            datos.Cargo = TextBox2.Text
            ErrorProvider1.SetError(TextBox2, Nothing)
        End If
    End Sub


    Private isTopPanelDragged As Boolean = False

    Private isLeftPanelDragged As Boolean = False

    Private isRightPanelDragged As Boolean = False

    Private isBottomPanelDragged As Boolean = False

    Private isTopBorderPanelDragged As Boolean = False

    Private isWindowMaximized As Boolean = False

    Private offset As Point

    Private _normalWindowSize As Size


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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Registro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Location = New Point(602, 250)
    End Sub


End Class