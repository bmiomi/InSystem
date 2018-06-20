Imports Conexion_Acceso

Imports MySql.Data.MySqlClient
Imports Negocio


Public Class Corte

    Dim Conexion As New ProcesoCorte
    Dim datos As New AccesoCorte
    Dim _conexion As New MySqlConnection
    Dim view As New ViewTela

    Dim prduccion As New Produccion
    Dim datosp As New Ent_produccion

    Sub habilitar()
        txttipoprenda.Enabled = False
        TextBox2.Enabled = True
        TextBox1.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Sub Desahabilitar()
        TextBox1.Enabled = False
        txttipoprenda.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
    End Sub

    Sub limpiar()
        TextBox3.Clear()
        txttipoprenda.Clear()
        TextBox1.ResetText()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        Main.Label1.Text = "Home"
    End Sub

    Private Sub Corte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim cmb = New DataGridViewComboBoxColumn

        DataGridView1.ColumnCount = 2

        DataGridView1.Columns(0).Name = "CodCorte"
        DataGridView1.Columns(0).Width = 90


        DataGridView1.Columns(1).Name = "Prendas Unitarias"
        DataGridView1.Columns(1).Width = 130

        cmb.HeaderText = "Modelo"
        cmb.Name = "cmb"
        cmb.MaxDropDownItems = 4
        view._Modelo()
        cmb.DataSource = view.__Modelo
        cmb.ValueMember = "nombre"
        DataGridView1.Columns.Add(cmb)
        DataGridView1.Columns(2).Width = 270


        TextBox2.Text = view.CodigoProduccion() + 1

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

        If TextBox3.Text = Nothing Then
            TextBox3.Text = 0
        ElseIf TextBox4.Text = Nothing Then
            TextBox4.Text = 0
        End If
        Label6.Text = Val(TextBox4.Text) * Val(TextBox3.Text)
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextAlignChanged

        If TextBox3.Text = Nothing Then
            TextBox3.Text = 0
        ElseIf TextBox4.Text = Nothing Then
            TextBox4.Text = 0
        End If
        Label6.Text = Val(TextBox4.Text) * Val(TextBox3.Text)
    End Sub


    Private Sub txttipoprenda_TextChanged(sender As Object, e As EventArgs) Handles txttipoprenda.TextChanged
        If Label6.Text = Nothing Then
            Label6.Text = 0
        ElseIf txttipoprenda.Text = Nothing Then
            txttipoprenda.Text = 0
        End If
        Label7.Text = Val(Label6.Text) * Val(txttipoprenda.Text)
    End Sub


    Private Sub Label6_TextChanged(sender As Object, e As EventArgs) Handles Label6.TextChanged
        If Label6.Text = Nothing Then
            Label6.Text = 0
        ElseIf txttipoprenda.Text = Nothing Then
            txttipoprenda.Text = 0
        End If
        Label7.Text = Val(Label6.Text) * Val(txttipoprenda.Text)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            If TextBox1.Text = 0 Then
                MsgBox("Debes tener una cantidad de modelos establecida para generar el corte de produccion")
                CheckBox1.Checked = False
            Else
                Dim h As Integer
                Dim X = view.CodigoCorte
                For h = 0 To TextBox1.Text - 1
                    X += 1
                    DataGridView1.Rows.Add(X, txttipoprenda.Text * TextBox4.Text, Nothing)

                Next
            End If

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidateChildren() = True Then
            MsgBox("debe llenar los campos para proceder a guardar")
        Else
            If Button1.Text.ToLower = "nuevo" Then
                habilitar()
                Button1.Text = "Guardar"
            Else
                Button1.Text = "Nuevo"

                datosp.CodTendido = TextBox2.Text
                datosp.FechaTendido = DateTimePicker1.Value
                MsgBox(datosp.FechaTendido)
                datosp.Tamanio_base = TextBox3.Text
                datosp.C_capas_unitarias = TextBox4.Text
                datosp.Total_unitario_mts = Label6.Text
                datosp.C_Modelos = TextBox1.Text
                datosp.C_Rollos = txttipoprenda.Text
                datosp.Total_mts_usados = Label7.Text
            End If
            Try
                If prduccion.ingresar_dtos_produccion(datosp) Then

                    For i = 0 To DataGridView1.Rows.Count - 1
                        Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                        datos.CodigoCorte = row.Cells(0).Value
                        datos.C_uni_prendas = row.Cells(1).Value
                        datos.FkCodTendido = TextBox2.Text
                        datos.ModeloPrenda = 1
                        Conexion.Ingresar_dtos_corte_(datos)
                    Next

                    MessageBox.Show("los datos han sido guardados", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Desahabilitar()
                    limpiar()
                End If
            Catch ex As MySqlException
                MessageBox.Show("los datos No se han logrado guardar  existosamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


End Class


