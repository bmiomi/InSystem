Imports MySql.Data.MySqlClient
Imports Negocio

Public Class Personal
    Dim _conexion As New MySqlConnection
    Dim procesopersonal As New ProcesoPersonas
    Dim datospersonal As New Conexion_Acceso.AccesoPersonal
    Dim vistapersonal As New ViewPersonal

    'variable global
    Dim cadena As String

    Public filtrado As String

    'limpiar Elementos
    Public Sub Limpiar()
        TxtNombre.Clear() : TxtApellido.Clear() : txtDireccion.Clear()
        txtCelular.Clear() : txtConvenecional.Clear()
        txtCI.Clear()

    End Sub
    'Habilirar Elementos
    Private Sub Habilitar_Click()
        TxtNombre.Enabled = True : TxtApellido.Enabled = True : txtDireccion.Enabled = True : txtCelular.Enabled = True
        txtConvenecional.Enabled = True : txtCI.Enabled = True : M.Enabled = True : F.Enabled = True
    End Sub
    'Desabilirar Elementos
    Private Sub Desabilitar_Click()
        TxtNombre.Enabled = False : TxtApellido.Enabled = False : txtDireccion.Enabled = False : txtCelular.Enabled = False
        txtConvenecional.Enabled = False : txtCI.Enabled = False : M.Enabled = False : F.Enabled = False
    End Sub

    'verificar controles vacios

    Public Function validablancos(ByVal controlesForm As Object)
        Dim valor As Boolean = False

        For Each _textbox As Control In GroupBox2.Controls
            If TypeOf _textbox Is TextBox AndAlso _textbox.Text = String.Empty Then
                _textbox.BackColor = Color.FromArgb(236, 77, 77)
                valor = True
            ElseIf _textbox.Text Is String.Empty Then
                _textbox.BackColor = Color.White

            End If
        Next

        For Each _txt As Control In GroupBox3.Controls
            If TypeOf _txt Is TextBox AndAlso _txt.Text = String.Empty Then
                _txt.BackColor = Color.FromArgb(236, 77, 77)
                valor = True
            ElseIf _txt.Text <> String.Empty Then
                _txt.BackColor = Color.White
            End If
        Next
        Return valor
    End Function


    Public Function retornar(ByVal controlesForm As Object)
        Dim valor As Boolean = False

        For Each _textbox As Control In GroupBox2.Controls
            If TypeOf _textbox Is TextBox Then
                _textbox.BackColor = Color.White
            End If
        Next

        For Each _txt As Control In GroupBox3.Controls
            If TypeOf _txt Is TextBox Then
                _txt.BackColor = Color.White
            End If
        Next
        Return valor
    End Function


    'Validar Objetos
    Private Sub Codig_validating(sender As Object, e As EventArgs) Handles txtCI.Validating


        If txtCI.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCI, "Ingrese la Cedula de Ciudadania")
            txtCI.Focus()

        ElseIf txtCI.Text.Length <> 10 Then

            MsgBox("la cedula de identidad debe contener 10 digitos", MsgBoxStyle.Information, "Validador de Campos")
            txtCI.Focus()
        Else
        datospersonal.CI = txtCI.Text
        ErrorProvider1.SetError(txtCI, Nothing)
        End If
    End Sub

    Private Sub Nombre_validating(sender As Object, e As EventArgs) Handles TxtNombre.Validating
        If TxtNombre.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtNombre, "Debes ingresar su Nombre")
            TxtNombre.Focus()
        Else
            datospersonal.Nombre = TxtNombre.Text
            ErrorProvider1.SetError(TxtNombre, Nothing)
        End If
    End Sub

    Private Sub Apelllido_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtApellido.Validating
        If TxtApellido.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtApellido, "Debes ingresar su Apellido")
            TxtApellido.Focus()
        Else
            datospersonal.Apellido = TxtApellido.Text
            ErrorProvider1.SetError(TxtApellido, Nothing)
        End If

    End Sub

    Private Sub Direccion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDireccion.Validating
        If txtDireccion.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtDireccion, "Debes ingresar su Direccion")
            txtDireccion.Focus()
        Else
            datospersonal.Direccion = txtDireccion.Text
            ErrorProvider1.SetError(txtDireccion, Nothing)
        End If
    End Sub

    Private Sub Celular_TextChanged(sender As Object, e As EventArgs) Handles txtCelular.Validating
        If txtCelular.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCelular, "Debes ingresar su Telefono Celular")
            txtCelular.Focus()
        ElseIf txtCelular.Text.Length <> 10 Then
            MsgBox("El numero de Celular no contiene los 10 digitos establecidos", MsgBoxStyle.Information, "Validador de Campos")
            txtCelular.Focus()
        Else
            datospersonal.Celular = txtCelular.Text
            ErrorProvider1.SetError(txtCelular, Nothing)
        End If

    End Sub

    Private Sub Conven_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtConvenecional.Validating
        If txtConvenecional.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtConvenecional, "Debes ingresar su Telefono Convencional")
            txtConvenecional.Focus()
        ElseIf txtConvenecional.Text.Length <> 7 Then
            MsgBox("El numero de convenciona no contiene los 7 digitos establecidos", MsgBoxStyle.Information, "Validador de Campos")
            txtConvenecional.Focus()

        Else
            datospersonal.Convencional = txtConvenecional.Text
            ErrorProvider1.SetError(txtConvenecional, Nothing)
        End If
    End Sub

    Private Sub M_CheckedChanged(sender As Object, e As EventArgs) Handles M.Click
        If M.Checked = False Then
            ErrorProvider1.SetError(M, "Debes ingresarun sexo")
            txtConvenecional.Focus()
        Else
            datospersonal.Sexo = M.Text
            ErrorProvider1.SetError(M, Nothing)
        End If
    End Sub


    Private Sub f_CheckedChanged(sender As Object, e As EventArgs) Handles F.Click
        If F.Checked = False Then
            ErrorProvider1.SetError(F, "Debes ingresarun sexo")
            F.Focus()
        Else
            datospersonal.Sexo = F.Text
            ErrorProvider1.SetError(F, Nothing)
        End If
    End Sub


    'Validar sexo
    Private Function sexo()
        If M.Checked Then
            Return M.Text
        ElseIf F.Checked Then
            Return F.Text
        End If
    End Function

    'validador de Numeros
    Private Sub Celular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCelular.KeyPress, txtConvenecional.KeyPress, txtCI.KeyPress
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

    'validador de Texto
    Private Sub Nombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtApellido.KeyPress, TxtNombre.KeyPress
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


    'Button Nuevo and Guardar
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click

        If Nuevo.Text.ToLower = "nuevo" Then

            Habilitar_Click()
            Nuevo.Text = "Guardar"
            btModificar.Text = "Cancelar"

        ElseIf Nuevo.Text = "Cancelar" Then

            Habilitar_Click()
            splass.PerformClick()
            Limpiar()
            Nuevo.Text = "Nuevo"
            btModificar.Text = "Modificar"
        ElseIf validablancos(GroupBox1) = True Then '' tiene que ser falso para pasar este restricion
            MsgBox("DEBE LLENAR TODOS LOS CAMPOS REMARCADOS PARA DESPUES PROCEDER A GUARDAR.", MessageBoxIcon.Information, "Error al Inserar Datos")

        ElseIf vistapersonal.consulta(txtCI.Text) = True Then
            MsgBox("La Cedula de Identidad que a ingresado coincide con un registro ya guardado anteriormente, verificar y luego proceder a guardar", MessageBoxIcon.Asterisk, "Datos redundantes")
            txtCI.BackColor = Color.Yellow

        Else

            Nuevo.Text = "nuevo"
            Try
                If procesopersonal.Ingresar_dtos_personal_(datospersonal) Then
                    MessageBox.Show("Los datos han sido guardados", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Desabilitar_Click()
                End If
            Catch ex As MySqlException
                MessageBox.Show("Los datos NO se han guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try

            btModificar.Text = "Modificar"
            Desabilitar_Click()

        End If

    End Sub


    'Button Modificar
    Private Sub BtModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click

        ''''
        Try
            '''' Cuando el boton Modicar Cambie su Nombre a Cancelar los texbox volveran a tomar su valor inicial.
            If btModificar.Text = "Cancelar" Then

                Desabilitar_Click()
                Limpiar()
                btModificar.Text = "Modificar"
                Nuevo.Text = "Nuevo"
                retornar(GroupBox1)

                '''' Cuando el boton Modicar Cambie su Nombre a  Modificar se activara el datagrib  asu vez  los botones invertiran sus textos. 
            ElseIf btModificar.Text = "Modificar" Then

                splass.PerformClick()
                Habilitar_Click()
                Nuevo.Text = "Cancelar"
                btModificar.Text = "Guardar"


                '''' Cuando el boton Modicar Cambie su Nombre a  Guardar  se guardara los datos .

            ElseIf btModificar.Text = "Guardar" Then
                ' splass.PerformClick()

                datospersonal.CI = txtCI.Text
                datospersonal.Apellido = TxtApellido.Text
                datospersonal.Nombre = TxtNombre.Text
                datospersonal.Direccion = txtDireccion.Text
                datospersonal.Convencional = txtConvenecional.Text
                datospersonal.Celular = txtCelular.Text
                datospersonal.Sexo = sexo()

                If procesopersonal.Actualizar_dtos_personal_(datospersonal) Then
                    MessageBox.Show("los datos han sido Actualizados", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Desabilitar_Click()
                    btModificar.Text = "Modificar"
                    Nuevo.Text = "Nuevo"
                Else
                    MessageBox.Show("los datos no han sido Actualizados", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        Catch ex As MySqlException
            MsgBox("Error duranre en ingreso de datos ", ex.ToString)

        End Try

    End Sub
    'Button Eliminar 
    Private Sub ELIMINAR_Click(sender As Object, e As EventArgs)

        If txtCelular.Text = Nothing Then
            MessageBox.Show("Debe Contener Algun Registros para proceder a eliminar", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ''Modificar esto 
            datospersonal.CI = txtCI.Text
            Nuevo.Text = "Nuevo"
            btModificar.Text = "Modificar"

            Try
                If procesopersonal.Eliminar_dtos_personal(datospersonal) Then
                    MessageBox.Show("Los Datos han sido Eliminados", "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpiar()
                    Desabilitar_Click()
                End If
            Catch ex As MySqlException
                MessageBox.Show("los datos NO se han Eliminado", "guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try
        End If


    End Sub



    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim renglon As Integer = DataGridView1.CurrentCell.RowIndex

        txtCI.Text = Me.DataGridView1.Item(0, renglon).Value()
        TxtNombre.Text = Me.DataGridView1.Item(1, renglon).Value()
        TxtApellido.Text = Me.DataGridView1.Item(2, renglon).Value()
        txtCelular.Text = Me.DataGridView1.Item(3, renglon).Value()
        txtConvenecional.Text = Me.DataGridView1.Item(4, renglon).Value()
        If Me.DataGridView1.Item(5, renglon).Value() = "M" Then
            M.Checked = True
        ElseIf Me.DataGridView1.Item(5, renglon).Value() = "F" Then
            F.Checked = True
        End If
        txtDireccion.Text = Me.DataGridView1.Item(6, renglon).Value()

        ' btModificar.PerformClick()
    End Sub

    Private Sub RadioButton1__(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If RadioButton1.Checked = True Then
            TextBox2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2__(sender As Object, e As EventArgs) Handles RadioButton2.Click
        If RadioButton2.Checked = True Then
            TextBox2.Enabled = True
        End If
    End Sub

    ''Buscar Registros
    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            If RadioButton1.Checked Then
                filtrado = "CI "
            End If
            If RadioButton2.Checked Then
                filtrado = "Nombre"
            End If
            vistapersonal.dvperso.RowFilter = String.Concat("CONVERT(", filtrado, ",System.String) LIKE '%", TextBox2.Text, "%'")
        Catch ex As NullReferenceException
            MsgBox(String.Format("No se ha encontrado Resultado sobre {0}", TextBox2.Text))
        End Try

    End Sub

    'estilos formulario
    'Button SplitLayaout
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles splass.Click

        If splass.Text = ">>" Then
            splass.Text = "<<"

            While (Panel2.Height <= 320 And Me.Height <= 683 And GroupBox5.Height <= 346)
                Panel2.Height += 1
                Me.Height += 1
                GroupBox5.Height += 1
            End While

            If Panel2.Height = 313 And Me.Height = 684 And GroupBox5.Height = 342 Then

                vistapersonal.Dsperso.Reset()
                DataGridView1.Refresh()
                vistapersonal.DatosGridViewPersonal()
                DataGridView1.DataSource = vistapersonal.dvperso
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel2.Height > 19 And (Me.Height > 397) And GroupBox5.Height > 55)
                Panel2.Height -= 1
                Me.Height -= 1
                GroupBox5.Height -= 1
            End While
        End If
    End Sub



    Dim valorAntiguo As String


    Private Sub txtCI_TextChanged(sender As Object, e As EventArgs) Handles txtCI.TextChanged

        If btModificar.Text = "Guardar" And txtCI.Text <> Nothing Then

            valorAntiguo = DataGridView1.Item(0, 0).Value


            If txtCI.Text <> valorAntiguo Then
                datospersonal.CI = txtCI.Text
            End If
        End If
    End Sub




    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Dim mes As New Main
        mes.Label1.Text = "Home"
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

End Class