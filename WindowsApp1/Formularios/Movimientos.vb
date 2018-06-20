Imports Negocio
Public Class Movimientos
    Dim x As New X
    Public entrada As New Conexion_Acceso.EntidadEntrada

    Private Sub Entradaform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim view As New ViewTela
        view.CombocompraPRovedor()


        ComboBox3.DataSource = view.combocompra
        ComboBox3.DisplayMember = "provedor"
        ComboBox3.ValueMember = "N_Almacen"
        ComboBox3.SelectedIndex = -1

        Movimientos()
    End Sub

    Sub Movimientos()

        If x.X1 = "Entrada" Then
            GroupBox1.Text = "Entrada de productos/Insumos"
            Label1.Text = x.Y
            EntradaProductos_insumos()

        ElseIf x.X1 = "Salida" Then
            GroupBox1.Text = "Salida de productos/Insumos"
            Label1.Text = x.Y
            salidaInsumo_Productos()
        Else
            GroupBox1.Text = "ajuste de productos/Insumos"
            Label1.Text = x.Y
        End If


        Label7.Text = " Administrador"

    End Sub

    Sub EntradaProductos_insumos()

        Dim vitela As New ViewTela

        If x.Y = "PRODUCTOS" Then

            vitela.Comboprod()
            ComboBox1.DataSource = vitela.codproductos
            ComboBox1.DisplayMember = "Productos"
            ComboBox1.ValueMember = "CodMPrima"

        ElseIf x.Y = "INSUMOS" Then

            vitela.comboInsu()
            ComboBox1.DataSource = vitela.codIns
            ComboBox1.DisplayMember = "Insumos"
            ComboBox1.ValueMember = "CodInsumo"

        Else
            ComboBox1.DataSource = Nothing

        End If

    End Sub

    Sub SalidaInsumo_Productos()

        Dim vitela As New ViewTela

        If x.Y = "PRODUCTOS" Then

            vitela.SalidaMovimientoProducto()
            ComboBox1.DataSource = vitela.salidaProductos
            ComboBox1.DisplayMember = "Productos"
            ComboBox1.ValueMember = "fkproducto"

        ElseIf x.Y = "INSUMOS" Then

            vitela.SalidaMovimientoInsumos()
            ComboBox1.DataSource = vitela.salidainsumos
            ComboBox1.DisplayMember = "Insumos"
            ComboBox1.ValueMember = "fkinsumo"

        Else
            ComboBox1.DataSource = Nothing

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        entrada.Movimiento = x.X1
        entrada.PrecioCompra = TextBox2.Text
        entrada.Fkproducto = ComboBox1.Text
        entrada.Fecha = DateTimePicker1.Value
        entrada.Concepto = ComboBox2.Text
        entrada.Usuario = Label7.Text
        entrada.cantidad = TextBox1.Text
        entrada.Proveedor = ComboBox3.Text

        MsgBox(String.Format("  Movimiento: {0} 
                                fecha: {1}
                                Concepto: {2}
                                proveedor: {3}
                                producto: {4}
                                cantidad: {5}
                                precio compra: {6}
                                Reponsable: {7}",
                                entrada.Movimiento, entrada.Fecha, entrada.Concepto,
                                entrada.Proveedor, entrada.Fkproducto, entrada.cantidad,
                                entrada.PrecioCompra, entrada.Usuario))


        Dim datos As New Entrada
        If x.Y = "PRODUCTOS" Then

            If datos.Ingresar_EntradaProductos(entrada) Then
                MsgBox("Registro ingresado con exito")
            Else
                MsgBox("no se a logrado guardar el Registro ")

            End If
        ElseIf x.Y = "INSUMOS" Then

            If datos.Ingresar_EntradaInsumos(entrada) Then
                MsgBox("Registro ingresado con exito")
            Else
                MsgBox("no se a logrado guardar el Registro ")
            End If
        End If

    End Sub
    Private Sub Celular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class