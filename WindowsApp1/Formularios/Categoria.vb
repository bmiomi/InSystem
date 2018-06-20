Imports MySql.Data.MySqlClient
Imports Negocio
Imports Conexion_Acceso


Public Class Categoria
    Private _Conexion As New MySqlConnection

    Dim categoria As New _Categoria
    Private datosCategoria As New Ent_Categoria

    Dim ViewTela As New ViewTela

    Dim Subcategoria As New SubCategoria
    Private datosSubCategoria As New Ent_SubCategoria

    Private Sub ComboBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating

        If String.IsNullOrEmpty(ComboBox1.Text) Then
            ErrorProvider1.SetError(ComboBox1, "Tiene Campo vacio ,recuerda solo debe estar vacio si vas a selecionar una subcategoria")
            ComboBox1.Focus()
        Else
            ErrorProvider1.SetError(ComboBox1, Nothing)
            datosCategoria.Nombrecategoria = ComboBox1.Text

        End If
    End Sub

    Private Sub TextBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If String.IsNullOrEmpty(TextBox1.Text.TrimStart) Then
            ErrorProvider1.SetError(TextBox1, "Tiene Campo vacio")
            TextBox1.Focus()
        Else
            ErrorProvider1.SetError(TextBox1, Nothing)
            datosSubCategoria.Nombres = TextBox1.Text
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        ComboBox1.FlatStyle = FlatStyle.Popup
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList

        ViewTela.combocate1.Reset()
        ComboBox1.Refresh()

        ViewTela.ComboCategoria1()
        ComboBox1.DataSource = ViewTela.combocate1
        ComboBox1.DisplayMember = "Categoria"
        ComboBox1.ValueMember = "NombreCategoria"
        ComboBox1.SelectedIndex = -1

    End Sub

    Sub habilitar()

        ComboBox1.Enabled = True
        TextBox1.Enabled = True
        RadioButton2.Enabled = True
    End Sub

    Sub desabilitar()

        ComboBox1.Enabled = False
        TextBox1.Enabled = False
        RadioButton2.Enabled = False

    End Sub

    Sub limpiar()

        ComboBox1.FlatStyle = FlatStyle.Standard
        ComboBox1.Text = Nothing
        ComboBox1.DataSource = Nothing
        TextBox1.Clear()
        RadioButton2.Checked = False

    End Sub
    Private Sub btnSCategoria_Click(sender As Object, e As EventArgs) Handles btnSCategoria.Click

        Try

            If btnSCategoria.Text.ToLower = "nuevo" Then

                btnSCategoria.Text = "Guardar"

                habilitar()

            ElseIf btnSCategoria.Text = "Guardar" Then
                btnSCategoria.Text = "Nuevo"

                If RadioButton2.Checked Then

                    datosSubCategoria.IdSubcategorias = ViewTela.SubCAtegoria + 1
                    datosSubCategoria.Nombres = TextBox1.Text
                    'datosSubCategoria.FkCategoria = ViewTela.retrnar(ComboBox1.Text)
                    datosSubCategoria.FkCategoria = ComboBox1.SelectedIndex + 1

                    If Subcategoria.Ingresar_dtos_SubCategoria(datosSubCategoria) Then
                        MessageBox.Show("La Subcategoria se a guardado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("La Subcategoria  nose a exitosamente ", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If


                ElseIf Not RadioButton2.Checked Then


                    datosCategoria.Idcategoria = ViewTela.Categoria + 1
                    datosCategoria.Nombrecategoria = ComboBox1.Text
                    datosSubCategoria.IdSubcategorias = ViewTela.SubCAtegoria + 1
                    datosSubCategoria.Nombres = TextBox1.Text
                    datosSubCategoria.FkCategoria = datosCategoria.Idcategoria

                    If categoria.Ingresar_dtos_Categoria(datosCategoria) And Subcategoria.Ingresar_dtos_SubCategoria(datosSubCategoria) Then
                        MessageBox.Show("Categoria a sido guardada ", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("La categoria  nose a exitosamente ", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If

                End If

                limpiar()
                desabilitar()
            End If


        Catch ex As MySqlException
                MessageBox.Show("los datos No se han logrado guardar  existosamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _Conexion.Close()
            End Try


        'MsgBox(String.Format(" categoria: 
        '                                idCategoria {0} 
        '                                nombrecategoria: {1}  
        '                      subcategoria: 
        '                                 id subcategoria {2}
        '                                 nombre subcategoria {3}
        '                                 fk_categoria: {4}", datosCategoria.Idcategoria, datosCategoria.Nombrecategoria, datosSubCategoria.IdSubcategorias, datosSubCategoria.Nombres, datosSubCategoria.FkCategoria))












    End Sub













    Dim st As Integer
    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox3.DoubleClick
        If st = 0 Then
            Me.WindowState = FormWindowState.Maximized
            st = 1


        ElseIf st = 1 Then
            Me.WindowState = FormWindowState.Normal
            st = 0
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseDown
        ex = e.X

        ey = e.Y

        Arrastre = True
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseMove
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(Personal.MousePosition.X - Me.Location.X - ex, Personal.MousePosition.Y - Me.Location.Y - ey))
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseUp
        Arrastre = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        Main.Label1.Text = Nothing
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub




End Class