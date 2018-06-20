
Imports Conexion_Acceso
Imports MySql.Data.MySqlClient
Imports Negocio


Public Class Producto
    'conexion database
    Dim _conexion As New MySqlConnection

    'variabales 
    Private datosproducto As New Ent_Producto
    Private datoCategoria As New Ent_Categoria
    Private datosubCategoria As New Ent_SubCategoria

    Dim ViewTela As New ViewTela
    Dim procesoproducto As New _Producto

    Dim procesoingresotela As New ProcesoIngresoTela
    Dim procesodetalletela As New ProcesoDetalleTela
    Dim datosdetalletela As New DetalleTelaEntrada
    Dim datosIngresotela As New AccesoIngresoTela

    Dim a As String

    Private Sub Tela_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Codigo Producto
        datosproducto.id_MPrima = CInt(Str(ViewTela.CodigoTendido())) + 1
        datosproducto.CodMPrima = "P00000" & datosproducto.id_MPrima 'cod Provedor
        txtcodgotela.Text = datosproducto.CodMPrima


        'Categoria 
        'Combobox

        TxT_Categoria.Refresh()

        ViewTela.ComboCategoria()
        TxT_Categoria.DataSource = ViewTela.combocate
        TxT_Categoria.DisplayMember = "Categoria"
        TxT_Categoria.ValueMember = "NombreCategoria"
        TxT_Categoria.SelectedIndex = -1


    End Sub


    'Habilitar elementos
    Sub Habilitar()

        TxT_Categoria.Enabled = True
        txtSubCategoria.Enabled = True
        txtmetraje.Enabled = True
        txtpeso.Enabled = True
        txtAncho.Enabled = True
        Descripcion.Enabled = True
        TextBox2.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True


    End Sub

    'Desahabilitar elementos
    Sub Deshabilitar()
        TxT_Categoria.Enabled = False
        txtSubCategoria.Enabled = False
        txtmetraje.Enabled = False
        txtpeso.Enabled = False
        txtAncho.Enabled = False
        Descripcion.Enabled = False
        TextBox2.Enabled = False

        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        '' TextBox1.Enabled = False

    End Sub

    'Limpiar elementos
    Sub Limpiar()

        txtcodgotela.ResetText()
        TxT_Categoria.Refresh()
        txtSubCategoria.Refresh()

        Descripcion.Refresh()
        ''   TextBox1.ResetText()
        txtpeso.ResetText()
        txtmetraje.ResetText()
        txtAncho.ResetText()
        TextBox2.ResetText()

    End Sub

    'validar solo numeros.
    Private Sub Celular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpeso.KeyPress, txtmetraje.KeyPress, TextBox2.KeyPress, txtAncho.KeyPress
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

    Private Sub TXTsubCATEGORIA_validating(sender As Object, e As EventArgs) Handles txtSubCategoria.Validating
        If txtSubCategoria.Text.Trim = Nothing Then
            ErrorProvider1.SetError(txtSubCategoria, "Seleccione una Subcategoria")
            txtSubCategoria.Focus()
        Else
            datosproducto.Fksubcategoria = txtSubCategoria.SelectedIndex
            ErrorProvider1.SetError(txtSubCategoria, Nothing)
        End If
    End Sub

    Private Sub TXTCATEGORIA_validating(sender As Object, e As EventArgs) Handles TxT_Categoria.Validating
        If TxT_Categoria.Text.Trim = Nothing Then
            ErrorProvider1.SetError(TxT_Categoria, "Ingrese una categoria")
            TxT_Categoria.Focus()
        Else
            datosproducto.FkCategoria = TxT_Categoria.SelectedIndex
            ErrorProvider1.SetError(TxT_Categoria, Nothing)
        End If
    End Sub

    Private Sub txtpeso_validating(sender As Object, e As EventArgs) Handles txtpeso.Validating
        If txtpeso.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtpeso, "Ingrese el peso ")
            txtpeso.Focus()
        Else
            datosproducto.FkCategoria = txtpeso.Text
            ErrorProvider1.SetError(txtpeso, Nothing)
        End If
    End Sub

    Private Sub txt_metraje(sender As Object, e As EventArgs) Handles txtmetraje.Validating
        If txtmetraje.Text.Trim = Nothing Then
            ErrorProvider1.SetError(txtmetraje, "Ingrese el metraje correspondiente.")
            txtmetraje.Focus()
        Else
            datosproducto.FkCategoria = txtmetraje.Text
            ErrorProvider1.SetError(txtmetraje, Nothing)
        End If
    End Sub

    Private Sub TextBox2_validating(sender As Object, e As EventArgs) Handles TextBox2.Validating
        If TextBox2.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextBox2, "Ingrese el rendimiento del producto.")
            TextBox2.Focus()
        Else
            datosproducto.FkCategoria = TextBox2.Text
            ErrorProvider1.SetError(TextBox2, Nothing)
        End If
    End Sub

    Private Sub txtAncho_validating(sender As Object, e As EventArgs) Handles txtAncho.Validating
        If txtAncho.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtAncho, "Ingrese el ancho del producto.")
            txtAncho.Focus()
        Else
            datosproducto.Ancho = txtAncho.Text
            ErrorProvider1.SetError(txtAncho, Nothing)
        End If
    End Sub


    Private Sub RadioButton_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles RadioButton1.Validating, RadioButton2.Validating
        If RadioButton1.Checked Then

            datosproducto.Disenio = RadioButton1.Text

        ElseIf RadioButton2.Checked Then

            datosproducto.Disenio = RadioButton2.Text

        End If
    End Sub

    'button Guardar 
    Private Sub GuardarTela_Click(sender As Object, e As EventArgs) Handles GuardarTela.Click


        If GuardarTela.Text.ToLower = "nuevo" Then
            Habilitar()
            GuardarTela.Text = "Guardar"
            Modificar.Text = "Cancelar"

            datosproducto.id_MPrima = CInt(Str(ViewTela.CodigoTendido())) + 1
            datosproducto.CodMPrima = "P00000" & datosproducto.id_MPrima 'cod Provedor
            txtcodgotela.Text = datosproducto.CodMPrima

        ElseIf ValidateChildren() = False Then

            MsgBox("DEBE LLENAR TODOS LOS CAMPOS PARA DESPUES PROCEDER A GUARDAR.", MessageBoxIcon.Information, "Error al Inserar Datos")

        Else

            GuardarTela.Text = "Nuevo"


            datosproducto.Color = TextBox1.Text
            datosproducto.FkCategoria = TxT_Categoria.SelectedIndex + 1

            datosproducto.Fksubcategoria = txtSubCategoria.SelectedIndex + 1

            datosproducto.Ancho = txtAncho.Text
            datosproducto.Metraje = txtmetraje.Text
            datosproducto.Peso = txtpeso.Text


            Try
                If procesoproducto.Ingresar_dtos_producto_(datosproducto) Then
                    MessageBox.Show("Los Datos han sido Guardados", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Deshabilitar()
                End If

            Catch ex As MySqlException
                MessageBox.Show("Los datos NO se han Guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try

        End If


    End Sub

    'button Modificar
    Private Sub Modificar_Click(sender As Object, e As EventArgs) Handles Modificar.Click

        If Modificar.Text = "Cancelar" Then

            Deshabilitar()
            Limpiar()

            Modificar.Text = "Modificar"
            GuardarTela.Text = "Nuevo"

        ElseIf Modificar.Text = "Modificar" Then

            splass.PerformClick()
            Habilitar()
            GuardarTela.Text = "Cancelar"
            Modificar.Text = "Guardar"

        ElseIf Modificar.Text = "Guardar" Then

            splass.PerformClick()
            Try
                If procesoproducto.Ingresar_dtos_producto_(datosproducto) Then
                    MessageBox.Show("los datos han sido Actualizados", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Deshabilitar()
                    Modificar.Text = "Modificar"
                    GuardarTela.Text = "Nuevo"
                Else
                    MessageBox.Show("los datos no han sido Actualizados", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Catch ex As MySqlException
                MsgBox("Error duranre en ingreso de datos ", ex.ToString)

            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim renglon As Integer = DataGridView1.CurrentCell.RowIndex

        TxT_Categoria.Text = Me.DataGridView1.Item(1, renglon).Value()
        txtSubCategoria.Text = Me.DataGridView1.Item(2, renglon).Value()
        If Me.DataGridView1.Item(3, renglon).Value() = "estampado" Then

            RadioButton2.Checked = True
        Else
            RadioButton1.Checked = True
        End If
        '  TextBox2.Text = Me.DataGridView1.Item(, renglon).Value()

        txtmetraje.Text = Me.DataGridView1.Item(4, renglon).Value()
        txtAncho.Text = Me.DataGridView1.Item(5, renglon).Value()
        txtpeso.Text = Me.DataGridView1.Item(6, renglon).Value()

        Modificar.PerformClick()
    End Sub

    'llamado al Formulario provedor 
    Private Sub Nuevo_Click(sender As Object, e As EventArgs)
        Dim Provedor As New Provedor
        Provedor.Show()
    End Sub

    'llamado al Formulario Categoria 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim categoria As New Categoria
        categoria.Show()
    End Sub


    Private Sub TxT_Categoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxT_Categoria.SelectedIndexChanged

        ViewTela.comboSubcate.Rows.Clear()
        If TxT_Categoria.SelectedIndex <> -1 Then

            ViewTela.ComboSubCategoria(TxT_Categoria.Text)
            txtSubCategoria.DataSource = ViewTela.comboSubcate
            txtSubCategoria.DisplayMember = "SubCategoria"
            txtSubCategoria.ValueMember = "Nombre"
            txtSubCategoria.SelectedIndex = -1
        End If


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            datosproducto.Color = RadioButton1.Text
            Label1.Visible = True
            TextBox1.Visible = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            datosproducto.Color = RadioButton2.Text
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles splass.Click

        If splass.Text = ">>" Then
            splass.Text = "<<"

            While (Panel2.Height <= 320 And Me.Height <= 683 And GroupBox3.Height <= 346)
                Panel2.Height += 1
                Me.Height += 1
                GroupBox3.Height += 1
            End While

            If Panel2.Height = 303 And Me.Height = 684 And GroupBox3.Height = 332 Then

                ViewTela.tela.Clear()
                DataGridView1.Refresh()
                ViewTela.Rollos()
                DataGridView1.DataSource = ViewTela.tela
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel2.Height > 19 And (Me.Height > 397) And GroupBox3.Height > 55)
                Panel2.Height -= 1
                Me.Height -= 1
                GroupBox3.Height -= 1
            End While
        End If
    End Sub



    Private isTopPanelDragged As Boolean = False

    Private isLeftPanelDragged As Boolean = False

    Private isRightPanelDragged As Boolean = False

    Private isBottomPanelDragged As Boolean = False

    Private isWindowMaximized As Boolean = False

    Private offset As Point

    Private _normalWindowSize As Size


    Private _normalWindowLocation As Point = Point.Empty

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If isTopPanelDragged Then
            Dim newPoint As Point = Panel1.PointToScreen(New Point(e.X, e.Y))
            newPoint.Offset(offset)
            Me.Location = newPoint
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub

    Private Sub Descripcion_TextChanged(sender As Object, e As EventArgs) Handles Descripcion.TextChanged
        txtAncho.Text = " "
    End Sub

    Private Sub txtpeso_validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpeso.Validating

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim reporte As New Reporteproducto
        reporte.Show()
    End Sub

End Class