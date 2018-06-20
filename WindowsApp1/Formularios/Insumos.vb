
Imports MySql.Data.MySqlClient
Imports Negocio


Public Class Insumos
    Dim _conexion As New MySqlConnection
    Dim entinsumos As New Cls_Insumo
    Dim ViewTela As New ViewTela
    Dim datos As New Conexion_Acceso.EntInsumo

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "INS00000" & Str(ViewTela.Insumoid) + 1
        datos.CodInsumo = TextBox1.Text

        TxT_Categoria.Refresh()
        ViewTela.ComboCategoriainsumo()
        TxT_Categoria.DataSource = ViewTela._combocateinsumo
        TxT_Categoria.DisplayMember = "Categoria"
        TxT_Categoria.ValueMember = "NombreCategoria"
        TxT_Categoria.SelectedIndex = -1


    End Sub

    Private Sub TxT_Categoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxT_Categoria.SelectedIndexChanged
        If TxT_Categoria.SelectedIndex <> -1 Then
            ViewTela.comboSubcateinsum.Rows.Clear()

            ViewTela.ComboSubCategoria_(TxT_Categoria.Text)
            txtsubcategoria.DataSource = ViewTela.comboSubcateinsum
            txtsubcategoria.DisplayMember = "SubCategoria"
            txtsubcategoria.ValueMember = "Nombre"
            txtsubcategoria.SelectedIndex = -1
        End If
    End Sub



    Private Sub txtsubcategoria_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtsubcategoria.Validating

        If String.IsNullOrEmpty(txtsubcategoria.Text) Then
            ErrorProvider1.SetError(txtsubcategoria, "Debe Seleccionar una Subcategoria")
            txtsubcategoria.Focus()
        Else
            ErrorProvider1.SetError(txtsubcategoria, Nothing)
            datos.Fksubcategoria = ViewTela.combsubcategoria(txtsubcategoria.Text)
        End If
    End Sub

    Private Sub txtcategoria_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxT_Categoria.Validating

        If String.IsNullOrEmpty(TxT_Categoria.Text) Then
            ErrorProvider1.SetError(TxT_Categoria, "Debe seleccionar una Categoria")
            TxT_Categoria.Focus()
        Else
            ErrorProvider1.SetError(TxT_Categoria, Nothing)

            datos.Fkcategoria = ViewTela.combcategoria(TxT_Categoria.Text)
        End If


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim reporteinsu As New reporteInsum
        reporteinsu.Show()
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
    Sub Habilitar()
        txtsubcategoria.Enabled = True
        TxT_Categoria.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Sub Desahabilitar()
        txtsubcategoria.Enabled = False
        TxT_Categoria.Enabled = False
        TextBox2.Enabled = False
    End Sub

    Sub limpiar()
        txtsubcategoria.ResetText()
        TxT_Categoria.ResetText()
        TextBox2.Clear()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Nuevo.Click


        'datos.Idinsumo = ViewTelas.Insumoid() + 1
        'datos.CodInsumo = TextBox1.Text

        'datos.Fkcategoria = ViewTela.combcategoria(TxT_Categoria.Text)

        'datos.Fksubcategoria = ViewTela.combsubcategoria(txtsubcategoria.Text)

        datos.Descripcion = TextBox2.Text

        If Nuevo.Text = "Nuevo" Then
            Habilitar()
            Nuevo.Text = "Guardar"

        ElseIf Nuevo.Text = "Guardar" Then
            Nuevo.Text = "Nuevo"
            Try
                If entinsumos.Ingresar_dtosInsumos(datos) Then
                    MessageBox.Show("Los datos han sido guardados", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                    Desahabilitar()
                End If
            Catch ex As MySqlException
                MessageBox.Show("Los datos NO se han guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try

            btModificar.Text = "Modificar"
            Desahabilitar()

        End If
    End Sub

    Private Sub splass_Click(sender As Object, e As EventArgs) Handles splass.Click

        If splass.Text = ">>" Then
            splass.Text = "<<"

            'sea menor
            While (Panel2.Height <= 242 And Me.Height <= 563 And GroupBox6.Height <= 274)
                Panel2.Height += 1
                Me.Height += 1
                GroupBox6.Height += 1
            End While

            If Panel2.Height = 243 And Me.Height = 543 And GroupBox6.Height = 263 Then

                ViewTela.unsumi.Clear()

                DataGridView1.Refresh()
                ViewTela.Insumo()
                DataGridView1.DataSource = ViewTela.unsumi
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel2.Height > 27 And (Me.Height > 327) And GroupBox6.Height > 47)
                Panel2.Height -= 1
                Me.Height -= 1
                GroupBox6.Height -= 1
            End While
        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cate As New Categoria
        cate.Show()
    End Sub
End Class