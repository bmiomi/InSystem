Imports Negocio


Public Class Main

    ''Dim login As New Login
    Private _main As New LoginClase
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If _main.Mainc(login.xs) = "Bodegero" Then

            Panel5.Enabled = False
            Panel6.Enabled = False
            Panel10.Enabled = False
            Panel13.Enabled = False
            Panel8.Enabled = False
            Panel12.Enabled = False

            Button1.Enabled = False
            Button4.Enabled = False
            Button7.Enabled = False
            Button9.Enabled = False
            Button1.Enabled = False

        End If

    End Sub


    Private Sub CheckForm(form As Form)
        form.TopLevel = False
        form.Location = New Point((Panel3.Width - form.Width) / 2, (Panel3.Height - form.Height) / 2)
        Panel3.Controls.Add(form)
        form.Show()
        form.BringToFront()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Personal"
        Dim frm As Personal = New Personal()
        CheckForm(frm)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Producto"
        Dim frm As Producto = New Producto()
        CheckForm(frm)
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Provedor"

        Dim frm As Provedor = New Provedor()
        CheckForm(frm)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Corte"
        Dim frm As Corte = New Corte()
        CheckForm(frm)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Inventario"
        Dim frm As Bodega = New Bodega()
        CheckForm(frm)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Compra"

        Dim frm As Compra = New Compra()
        CheckForm(frm)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Invenario"

        Dim frm As Insumos = New Insumos()
        CheckForm(frm)
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Asignacion"

        Dim frm As PersonalCorte = New PersonalCorte()
        CheckForm(frm)
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Label1.Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold Or FontStyle.Italic)
        Me.Label1.Text = "Invenario"
        Dim frm As Modelo = New Modelo()
        CheckForm(frm)
    End Sub


    Private Sub Button11_MouseEnter(sender As Object, e As EventArgs) Handles Button11.MouseEnter

        Button11.BackColor = Color.Red
    End Sub

    Private Sub Button10_MouseEnter(sender As Object, e As EventArgs) Handles Button10.MouseEnter

        Panel13.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button9_MouseEnter(sender As Object, e As EventArgs) Handles Button9.MouseEnter

        Panel12.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles Button8.MouseEnter

        Panel11.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter

        Panel10.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter

        Panel9.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter

        Panel4.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter

        Panel8.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter

        Panel6.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Panel7.BackColor = SystemColors.MenuHighlight
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter

        Panel5.BackColor = SystemColors.MenuHighlight

    End Sub

    Private Sub Button11_MouseLeave(sender As Object, e As EventArgs) Handles Button11.MouseLeave

        Button11.BackColor = SystemColors.HotTrack
    End Sub

    Private Sub Button10_MouseLeave(sender As Object, e As EventArgs) Handles Button10.MouseLeave

        Panel13.BackColor = Color.Transparent
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave

        Panel12.BackColor = Color.Transparent
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Panel11.BackColor = Color.Transparent
    End Sub


    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Panel10.BackColor = Color.Transparent
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Panel9.BackColor = Color.Transparent
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Panel4.BackColor = Color.Transparent
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave

        Panel8.BackColor = Color.Transparent
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave

        Panel6.BackColor = Color.Transparent
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave

        Panel7.BackColor = Color.Transparent
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave

        Panel5.BackColor = Color.Transparent

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

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        If isTopPanelDragged Then
            Dim newPoint As Point = Panel2.PointToScreen(New Point(e.X, e.Y))
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

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp
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

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
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

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Control + Keys.E Then
            Button1.PerformClick() 'personal
        ElseIf e.KeyData = Keys.Control + Keys.P Then
            Button2.PerformClick() 'productos
        ElseIf e.KeyData = Keys.Control + Keys.R Then
            Button3.PerformClick() 'provedor
        ElseIf e.KeyData = Keys.Control + Keys.C Then
            Button7.PerformClick() 'compra
        ElseIf e.KeyData = Keys.Control + Keys.I Then
            Button8.PerformClick() ' Insumos
        ElseIf e.KeyData = Keys.Control + Keys.M Then
            Button10.PerformClick() 'Modelo 
        ElseIf e.KeyData = Keys.Control + Keys.D Then
            Button4.PerformClick() 'produccion
        ElseIf e.KeyData = Keys.Control + Keys.A Then
            Button9.PerformClick() 'maquilado
        ElseIf e.KeyData = Keys.Control + Keys.I Then
            Button6.PerformClick() 'Inventario
        ElseIf e.KeyData = Keys.Control + Keys.s Then
            MessageBox.Show("El sistema se Cerrara para efectuarl el cambio de seccion
Esta segurio que dea realizar esa operacion
tenga en cuenta haber guardado todos los datos.")
            If MsgBoxResult.Yes Then
                login.Show()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        End
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = "Inicio"
    End Sub
End Class
