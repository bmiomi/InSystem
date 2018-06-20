
Imports Conexion_Acceso
Imports MySql.Data.MySqlClient
Imports Negocio


Public Class PersonalCorte

    'conexion database
    Dim _conexion As New MySqlConnection
    Dim datos As New Procesopersonalcorte
    Dim entdidad As New Ent_CortePersonal

    Dim ViewTela As New ViewTela

    Dim personal As New ViewPersonal


    Private Sub PersonalCorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ViewTela.CodigoMaquilado() + 1

        ViewTela.Produccion()
        ComboBox6.DataSource = ViewTela.comboproduccion
        ComboBox6.DisplayMember = "produccion"
        ComboBox6.ValueMember = "CodTendido"
        ComboBox6.SelectedIndex = -1


        personal.DatosGridViewPersonal()

        Dim person = personal.Dsperso.Tables(0)
        Dim dr = person.NewRow()
        person.Rows.InsertAt(dr, 0)
        ComboBox3.DataSource = person
        ComboBox3.DisplayMember = "personal"
        ComboBox3.ValueMember = "CI"
        ComboBox3.SelectedIndex = -1



    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        Dim row As MySqlDataReader


        If ComboBox3.SelectedIndex <> -1 Then
            row = personal._consulta(ComboBox3.Text)

            While row.Read
                TextBox2.Text = Convert.ToString(row("Nombre").ToString)
                TextBox4.Text = Convert.ToString(row("Apellido").ToString)
                TextBox3.Text = Convert.ToString(row("direccion").ToString)

            End While
            row.Close()

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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel1.SendToBack()
        Else
            Panel1.BringToFront()
        End If
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        ViewTela.grillacorte.Clear()
        ViewTela.Produccion(ComboBox6.Text)
        DataGridView1.Refresh()
        DataGridView1.DataSource = ViewTela.grillacorte
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Button1.Text.ToLower = "nuevo" Then
            'habilitar()
            Button1.Text = "Guardar"
        Else
            Button1.Text = "Nuevo"

            For Each fila As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToBoolean(fila.Cells("Column1").Value) Then
                    entdidad.Fkcodcorte = fila.Cells(1).Value.ToString()
                    entdidad.CodMAquilado = TextBox1.Text
                    entdidad.Fecha = DateTimePicker1.Value
                    entdidad.FkcodCI = ComboBox3.Text
                End If
            Next


        End If
        Try
            If datos.Ingresar_dtos_cortepersonal_(entdidad) Then
                MessageBox.Show("los datos han sido guardados", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Desahabilitar()
                'limpiar()
            End If
        Catch ex As MySqlException
            MessageBox.Show("los datos No se han logrado guardar  existosamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _conexion.Close()
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        Main.Label1.Text = " "
    End Sub

End Class