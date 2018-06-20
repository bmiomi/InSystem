Imports MySql.Data.MySqlClient
Imports Negocio

Public Class Login

    Public login As New LoginClase
    Public datos As New Conexion_Acceso.EnLogin



    Dim drag As Boolean
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        With TextBox1
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With

        With TextBox2
            .SelectionStart = .TextLength
            .SelectionLength = 0
            .SelectionStart = 0
            .ScrollToCaret()
        End With


    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown
        With TextBox1
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With

        With TextBox2
            If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then
                    e.Handled = True
                End If
            End If
        End With
    End Sub

    Private Sub TextBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDown, TextBox2.MouseDown
        drag = True
        With TextBox1
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                .SelectionStart = .TextLength
                .SelectionLength = 0
                .SelectionStart = 0
                .ScrollToCaret()
            End If

            With TextBox2
                If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                    .SelectionStart = .TextLength
                    .SelectionLength = 0
                    .SelectionStart = 0
                    .ScrollToCaret()
                End If
            End With
        End With
    End Sub

    Private Sub TextBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseMove, TextBox2.MouseMove
        If drag Then
            With TextBox1
                If .Text = "Usuario" And .ForeColor = Color.Gray Then
                    TextBox1.Select(0, 0)
                End If
            End With
        End If

        If drag Then
            With TextBox2
                If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                    TextBox1.Select(0, 0)
                End If
            End With
        End If
    End Sub

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseUp, TextBox2.MouseUp
        drag = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged
        With TextBox1
            If .Text = "" Then
                .Text = "Usuario"
                .ForeColor = Color.Gray
            End If
            If .Text = "Usuario" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 7 Then
                If StrReverse(StrReverse(.Text).Remove(7)) = "Usuario" Then
                    .Text = .Text.Remove(.TextLength - 7)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If
        End With


        With TextBox2

            If .Text = "" Then
                .Text = "Contraseña"
                .ForeColor = Color.Gray
            End If
            If .Text = "Contraseña" And .ForeColor = Color.Gray Then
                .ShortcutsEnabled = False
            Else
                .ShortcutsEnabled = True
            End If

            If .TextLength > 10 Then
                If StrReverse(StrReverse(.Text).Remove(10)) = "Contraseña" Then
                    .Text = .Text.Remove(.TextLength - 10)
                    .ForeColor = Color.Black
                    .SelectionStart = .TextLength
                    .ScrollToCaret()
                End If
            End If

        End With

    End Sub

    Dim Intententos As Integer = 0
    Public xs As String

    Function d()
        Dim x As Integer

        For x = 0 To 100
            CircularProgressBar1.Value = x
        Next

        Return CircularProgressBar1.Value
    End Function



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CircularProgressBar1.AnimationSpeed = 5000

        If CircularProgressBar1.Maximum Then
            d()
        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CircularProgressBar1.Value = 1
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        If Intententos < 3 Then
            xs = TextBox1.Text

            If TextBox1.Text <> "Usuario" And TextBox2.Text <> "Contraseña" Then
                datos.Usuario = TextBox1.Text
                If login.Consultalogin(TextBox1.Text, TextBox2.Text) Then

                    MsgBox(String.Format("Bienvenido al Sistema: {0}", TextBox1.Text))
                    Dim frm As Main = New Main()
                    frm.Show()
                    Me.Hide()

                Else
                    MessageBox.Show(String.Format("Intentos: {0}
Usuario O Contraseña Invalidos ", Intententos), " Error de Autentificacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    Intententos += 1
                End If
            End If
        Else
            MessageBox.Show(String.Format("Intentos: {0} No ha Ingresado su usuario o contraseña Correctamente ", Intententos), "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Contrasena = InputBox("Ingrese su Usuario.")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim reg As New Registro
        reg.Show()

    End Sub
End Class