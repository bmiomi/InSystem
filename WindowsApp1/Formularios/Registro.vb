Imports Negocio
Public Class Registro
    Dim drag As Boolean
    Private loginC As New LoginClase
    Private datos As New Conexion_Acceso.EnLogin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If String.IsNullOrEmpty(datos.Usuario) Or String.IsNullOrEmpty(datos.Cargo) Or String.IsNullOrEmpty(datos.Password) Then
            MsgBox("Campos vacios Intente llenandos los Campos.")
        Else
            If loginC.datosregistro(datos) Then
                MsgBox("Registro Existo,Gracias por registrarte en nuestra plataforma", MessageBoxIcon.Information, "Informacion")
                TextBox1.Clear() : TextBox2.Clear() :
                TextBox3.Clear()
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



    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, TextBox3.KeyDown
        With TextBox1
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With

        With TextBox2
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With

        With TextBox3
            If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown, TextBox2.MouseDown, TextBox3.MouseDown
        drag = True

        With TextBox1
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End If

            With TextBox2
                If .Text = "Cargo" And .ForeColor = Color.Gray Then
                    .SelectionStart = .TextLength
                    .SelectionLength = 0
                    .SelectionStart = 0
                    .ScrollToCaret()
                End If

                With TextBox3
                    If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                        .SelectionStart = .TextLength
                        .SelectionLength = 0
                        .SelectionStart = 0
                        .ScrollToCaret()
                    End If
                End With
            End With
        End With
    End Sub

    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseMove, TextBox2.MouseMove, TextBox3.MouseMove
        If drag Then
            With TextBox1
                If .Text = "Usuario" And .ForeColor = Color.Gray Then
                    TextBox1.Select(0, 0)
                End If
            End With
        End If

        If drag Then
            With TextBox2
                If .Text = "Cargo" And .ForeColor = Color.Gray Then
                    TextBox2.Select(0, 0)
                End If
            End With
        End If

        If drag Then
            With TextBox3
                If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                    TextBox3.Select(0, 0)
                End If
            End With
        End If
    End Sub


    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseUp, TextBox2.MouseUp
        drag = False
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

        With TextBox1
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With

        With TextBox2
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With

        With TextBox3
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged, TextBox3.TextChanged, TextBox1.TextChanged

        With TextBox1
            If .Text = "" Then
                .Text = "Usuario"
                .ForeColor = Color.Gray
            End If
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 7 Then
                If StrReverse(StrReverse(.Text).Remove(7)) = "Usuario" Then
                    .Text = .Text.Remove(.TextLength - 7)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With

        With TextBox2
            If .Text = "" Then
                .Text = "Cargo"
                .ForeColor = Color.Gray
            End If
            If .Text = "Cargo" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 5 Then
                If StrReverse(StrReverse(.Text).Remove(5)) = "Cargo" Then
                    .Text = .Text.Remove(.TextLength - 5)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With


        With TextBox3

            If .Text = "" Then
                .Text = "Contraseña"
                .ForeColor = Color.Gray
            End If
            If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 10 Then
                If StrReverse(StrReverse(.Text).Remove(10)) = "Contraseña" Then
                    .Text = .Text.Remove(.TextLength - 10)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If

        End With
    End Sub
End Class