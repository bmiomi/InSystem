Imports MySql.Data.MySqlClient
Imports Negocio
Public Class Provedor

    Dim Conexion As New ProcesoProvedor
    Dim datos As New Conexion_Acceso.AccesoProvedor
    Dim _conexion As New MySqlConnection
    Dim view As New ViewTela


    Sub Habilitar()
        TxtNomAlmacen.Enabled = True
        TxTOrigen.Enabled = True
        TxTDireccion.Enabled = True
        TxtConvencional.Enabled = True
        TxtCelular.Enabled = True
        TextBox1.Enabled = True
    End Sub
    Sub Desahabilitar()
        TxtNomAlmacen.Enabled = False
        TxTOrigen.Enabled = False
        TxtConvencional.Enabled = False
        TxtCelular.Enabled = False
        TxTDireccion.Enabled = False
        TextBox1.Enabled = False

    End Sub
    Sub Limpiar()
        TxtCodProvedor.Clear()
        TxtNomAlmacen.Clear()
        TxtCelular.Clear()
        TxTDireccion.Clear()
        TxTOrigen.Clear()
        TxtConvencional.Clear()
        TextBox1.Clear()
    End Sub

    'Validar Objetos 

    Private Sub Provedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datos.Id_codProvedor = CInt(view.Codigoprovedor) + 1 'id provedor

        datos.CodProvedor = "P000000" & datos.Id_codProvedor 'cod Provedor
        TxtCodProvedor.Text = datos.CodProvedor
    End Sub

    Private Sub texbox2(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        Dim filtrado As String

        If RadioButton1.Checked Then
                filtrado = "Ruc"
            End If

        If RadioButton2.Checked Then
            filtrado = "N_Almacen"
        End If

        view._dataview.RowFilter = filtrado + " LIKE '%" + TextBox2.Text + "%'"


    End Sub


    Private Sub TxTOrigen_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxTOrigen.Validating

        If TxTOrigen.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxTOrigen, "Ingrese Lugar o Ciudad  de donde es el Proveedor")
            TxTOrigen.Focus()
        Else
            datos.Origen = TxTOrigen.Text
            ErrorProvider1.SetError(TxTOrigen, Nothing)
        End If
    End Sub


    Private Sub TxtNomAlmacen_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNomAlmacen.Validating

        If TxtNomAlmacen.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtNomAlmacen, "Ingrese el nombre del Almacen")
            TxtNomAlmacen.Focus()
        Else
            datos.N_Almacen = TxtNomAlmacen.Text
            ErrorProvider1.SetError(TxtNomAlmacen, Nothing)
        End If
    End Sub


    Private Sub TxTDireccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxTDireccion.Validating

        If TxTDireccion.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxTDireccion, "Ingrese la Direccion proveniente del Almacen")
            TxTDireccion.Focus()
        Else
            datos.Direccion = TxTDireccion.Text
            ErrorProvider1.SetError(TxTDireccion, Nothing)
        End If
    End Sub


    Private Sub TxtConvencional_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtConvencional.Validating

        If TxtConvencional.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtConvencional, "Ingrese un numero convencional ")
            TxtConvencional.Focus()
        Else
            datos.Convencional = TxtConvencional.Text
            ErrorProvider1.SetError(TxtConvencional, Nothing)
        End If
    End Sub


    Private Sub TxtCelular_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCelular.Validating

        If TxtCelular.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtCelular, "Ingrese un numero de Celular ")
            TxtCelular.Focus()
        Else
            datos.Celular = TxtCelular.Text
            ErrorProvider1.SetError(TxtCelular, Nothing)
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Validating

        If TextBox1.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextBox1, "Ingrese un numero de RUC ")
            TextBox1.Focus()
        Else
            datos.RUC = TextBox1.Text
            ErrorProvider1.SetError(TextBox1, Nothing)
        End If
    End Sub
    'Button Nuevo and Guardar

    Private Sub Nuevo_Guardar_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        If Nuevo.Text.ToLower = "nuevo" Then
            Habilitar()
            Nuevo.Text = "Guardar"
            Modificar.Text = "Cancelar"

        ElseIf Nuevo.Text = "Cancelar" Then
            Limpiar()
            Desahabilitar()
            Nuevo.Text = "Nuevo"

        ElseIf Controles(GroupBox1) = True Then
            ValidateChildren()
            MsgBox("DEBE LLENAR TODOS LOS CAMPOS REMARCADOS PARA DESPUES PROCEDER A GUARDAR.", MessageBoxIcon.Information, "Error al Inserar Datos")


        Else

            Nuevo.Text = "Nuevo"

            datos.CodProvedor = TxtCodProvedor.Text
            datos.N_Almacen = TxtNomAlmacen.Text
            datos.RUC = TextBox1.Text
            datos.Direccion = TxTOrigen.Text
            datos.Convencional = TxtConvencional.Text
            datos.Celular = TxtCelular.Text
            datos.Origen = TxTOrigen.Text

            Try
                If Conexion.Ingresar_dtos_Provedor_(datos) Then
                    MessageBox.Show("los datos han sido guardados", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Desahabilitar()
                End If
            Catch ex As MySqlException
                MessageBox.Show("los datos No se han logrado guardar  existosamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try
        End If
    End Sub

    'button Modificar
    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click

        If Modificar.Text = "Cancelar" Then

            Desahabilitar()
            Modificar.Text = "Modificar"
            Nuevo.Text = "Nuevo"

        ElseIf Modificar.Text = "Modificar" Then

            splass.PerformClick()
            Habilitar()
            Nuevo.Text = "Cancelar"
            Modificar.Text = "Guardar"

        ElseIf Modificar.Text = "Guardar" Then

            datos.CodProvedor = TxtCodProvedor.Text
            datos.N_Almacen = TxtNomAlmacen.Text
            datos.RUC = TextBox1.Text
            datos.Direccion = TxTDireccion.Text
            datos.Convencional = TxtConvencional.Text
            datos.Celular = TxtCelular.Text
            datos.Origen = TxTOrigen.Text

            If Conexion.Actualizar_dtos_Provedor_(datos) Then
                MessageBox.Show("los datos han sido Actualizados", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Limpiar()
                Desahabilitar()
                Modificar.Text = "Modificar"
                Nuevo.Text = "Nuevo"
            End If
        End If
        'view.Prueva()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim renglon As Integer = DataGridView1.CurrentCell.RowIndex

        TxtCodProvedor.Text = Me.DataGridView1.Item(1, renglon).Value()
        TextBox1.Text = Me.DataGridView1.Item(2, renglon).Value()
        TxtNomAlmacen.Text = Me.DataGridView1.Item(3, renglon).Value()
        TxtConvencional.Text = Me.DataGridView1.Item(4, renglon).Value()
        TxtCelular.Text = Me.DataGridView1.Item(5, renglon).Value()
        TxTDireccion.Text = Me.DataGridView1.Item(6, renglon).Value()
        TxTOrigen.Text = Me.DataGridView1.Item(7, renglon).Value()

        ' Modificar.PerformClick()
    End Sub
    'splass
    Private Sub splass_Click(sender As Object, e As EventArgs) Handles splass.Click

        If splass.Text = ">>" Then
            splass.Text = "<<"

            'sea menor
            While (Panel2.Height <= 320 And Me.Height <= 683 And GroupBox6.Height <= 346)
                Panel2.Height += 1
                Me.Height += 1
                GroupBox6.Height += 1
            End While
            TextBox2.Enabled = True

            If Panel2.Height = 319 And Me.Height = 613 And GroupBox6.Height = 347 Then

                view._pruevas.Clear()
                DataGridView1.Refresh()
                view.Prueva()
                DataGridView1.DataSource = view._dataview
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel2.Height > 19 And (Me.Height > 321) And GroupBox6.Height > 55)
                Panel2.Height -= 1
                Me.Height -= 1
                GroupBox6.Height -= 1
            End While
        End If
    End Sub
    'Cerrar
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        '  Main.Label1.Text = "Home"
    End Sub

    'validador de Numeros
    Private Sub Ruc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TxtCelular.KeyPress, TxtConvencional.KeyPress
        If Trim(Char.IsDigit(e.KeyChar)) Then
            e.Handled = False
        ElseIf Trim(Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        ElseIf Trim(Char.IsSeparator(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'validador de Texto
    Private Sub Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxTDireccion.KeyPress, TxtNomAlmacen.KeyPress, TxTOrigen.KeyPress
        If Trim(Char.IsLetter(e.KeyChar)) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    'verificar controles vacios
    Public Function Controles(ByVal controlesForm As Object)
        Dim valor As Boolean = False

        For Each _textbox As Control In GroupBox2.Controls
            If TypeOf _textbox Is TextBox AndAlso _textbox.Text = String.Empty Then
                _textbox.BackColor = Color.Red
                valor = True
            Else
                _textbox.BackColor = Color.White
            End If
        Next

        For Each _txt As Control In GroupBox3.Controls
            If TypeOf _txt Is TextBox AndAlso _txt.Text = String.Empty Then
                _txt.BackColor = Color.Red
                valor = True
            Else
                _txt.BackColor = Color.White
            End If
        Next

        Return valor
    End Function



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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class