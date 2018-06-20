Imports Negocio
Imports MySql.Data.MySqlClient
Public Class Modelo




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
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub
    Sub Desahabilitar()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub

    Sub limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Dim view As New ViewTela
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Dim entmodelo As New clsModelo
        Dim _conexion As New MySqlConnection
        Dim dato As New Conexion_Acceso.EntModelo


        dato.Idmodelo = TextBox2.Text
        dato.Nombre = TextBox1.Text

        If Nuevo.Text = "Nuevo" Then
            Habilitar()
            Nuevo.Text = "Guardar"

        ElseIf Nuevo.Text = "Guardar" Then
            Nuevo.Text = "Nuevo"
            Try
                If entmodelo.Ingresar_dtosmodelo(dato) Then
                    MessageBox.Show("Los datos han sido guardados", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()
                    Desahabilitar()
                End If
            Catch ex As MySqlException
                MessageBox.Show("Los datos NO se han guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try

            Desahabilitar()

        End If

    End Sub

    Private Sub Modelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox2.Text = Val(view.Idmodelo()) + 1
    End Sub




    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles splass.Click

        If splass.Text = ">>" Then
            splass.Text = "<<"

            While (Panel2.Height <= 173 And Me.Height <= 391 And GroupBox3.Height <= 192)
                Panel2.Height += 1
                Me.Height += 1
                GroupBox3.Height += 1
            End While


            If Panel2.Height = 172 And Me.Height = 392 And GroupBox3.Height = 192 Then
                view.modelotable.Clear()
                DataGridView1.Refresh()
                view.modelolis()
                DataGridView1.DataSource = view.modelotable
                TextBox2.CharacterCasing = CharacterCasing.Upper
            End If

        ElseIf splass.Text = "<<" Then
            splass.Text = ">>"
            While (Panel2.Height > 26 And (Me.Height > 246) And GroupBox3.Height > 45)
                Panel2.Height -= 1
                Me.Height -= 1
                GroupBox3.Height -= 1
            End While
        End If
    End Sub
End Class