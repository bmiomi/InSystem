Imports MySql.Data.MySqlClient
Imports Negocio

Public Class Compra


    Private _conexion As New MySqlConnection

    Private procesoCompra As New Proceso_Compra
    Private procesotipo As New Tipo_Proceso
    Private procesodetalle As New DetalleCompra_

    Private datoscompra As New Conexion_Acceso.Ent_Compra
    Private datosdetallecompra As New Conexion_Acceso.Ent_Detalle
    Private datostipo As New Conexion_Acceso.Enti_Tipo

    Dim view As New ViewTela

    Private Sub Compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load, ErrorProvider1.RightToLeftChanged

        'ComboBox1.DataSource = Nothing


        view.combocompra.Clear()
        view.CombocompraPRovedor()
        ComboBox1.DataSource = view.combocompra
        ComboBox1.DisplayMember = "provedor"
        ComboBox1.ValueMember = "N_Almacen"


    End Sub


    Sub DesHabilitar_Click()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        numeodocumento.Enabled = False
        txtcantidad.Enabled = False
        txtpreciokilo.Enabled = False
        tipodecompra.Enabled = False
        tipodocumento.Enabled = False
        DateTimePicker1.Enabled = False

    End Sub


    Sub Habilitar_Click()
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        numeodocumento.Enabled = True
        txtcantidad.Enabled = True
        txtpreciokilo.Enabled = True
        tipodocumento.Enabled = True
        DateTimePicker1.Enabled = True
        tipodecompra.Enabled = True
    End Sub

    Sub limpiar()

        txtcantidad.Clear()
        txtpreciokilo.Clear()
        TxtSubtotal.Clear()
        txttotal.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        RichTextBox1.Clear()
        numeodocumento.Clear()
        'ComboBox1.DataSource = Nothing
        'ComboBox1.Text = Nothing

        ComboBox2.DataSource = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.DataSource = Nothing
        ComboBox3.Text = Nothing
        tipodecompra.Text = Nothing
        tipodocumento.Text = Nothing

        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click

        If Nuevo.Text.ToLower = "nuevo" Then

            Habilitar_Click()
            Nuevo.Text = "Guardar"
            btModificar.Text = "Cancelar"

        ElseIf Nuevo.Text = "Cancelar" Then

            Nuevo.Text = "Nuevo"
            btModificar.Text = "Modificar"

        ElseIf Nuevo.Text = "Guardar" Then
            Nuevo.Text = "nuevo"


            Try

                'detalle de compra
                datosdetallecompra.Subtotal = TxtSubtotal.Text
                datosdetallecompra.Iva = TextBox1.Text
                datosdetallecompra.ValorTotal = t



                If procesodetalle.Ingresar_dtos_detalleCompra_(datosdetallecompra) Then

                    ' compra
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If ComboBox3.SelectedIndex = 0 Then
                            datoscompra.Fkproducto = row.Cells(0).Value
                        Else
                            datoscompra.Fkinsumo = row.Cells(0).Value
                        End If

                        datoscompra.Cantidad = CDec(row.Cells(3).Value)
                        datoscompra.ValorUnitario = CDec(row.Cells(4).Value)

                        datoscompra.Fecha = DateTimePicker1.Value
                        datoscompra.Fkprovedor = view.codProvedor(ComboBox1.Text)
                        datoscompra.Fktipo = view.idtipo(ComboBox3.Text)

                        datoscompra.Fkdetallecompra = CInt(view.Iddetalle_compra)

                        datoscompra.Tipodocumento = tipodocumento.Text
                        datoscompra.Numerodocumento = numeodocumento.Text
                        datoscompra.Tipocompra = tipodecompra.Text

                        procesoCompra.Ingresar_dtos_Compra_(datoscompra)



                    Next


                    MessageBox.Show("Los datos han sido guardados", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    limpiar()

                End If
            Catch ex As MySqlException
                MessageBox.Show("Los datos NO se han guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _conexion.Close()
            End Try

            btModificar.Text = "Modificar"
            ''   Desabilitar_Click()

        End If
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text <> "System.Data.DataRowView" Then

            view.Combocompracabecera(ComboBox1.Text)
            Dim row As DataRow = view.compracombocabecera.Rows(view.compracombocabecera.Rows.Count - 1)

            Dim value As Object


            value = row.Item("Ruc")
            If value Is DBNull.Value Then
                Label11.Text = String.Empty
            Else
                Label11.Refresh()
                Label11.Text = CStr(value)
            End If

            value = row.Item("N_Almacen")
            If value Is DBNull.Value Then
                Label12.Text = String.Empty
            Else
                Label12.Refresh()
                Label12.Text = CStr(value)
            End If

            value = row.Item("Direccion")
            If value Is DBNull.Value Then
                Label17.Text = String.Empty
            Else
                Label17.Refresh()
                Label17.Text = CStr(value)
            End If

            value = row.Item("Convencional")
            If value Is DBNull.Value Then
                Label14.Text = String.Empty
            Else
                Label14.Refresh()
                Label14.Text = CStr(value)
            End If

            value = row.Item("Origen")
            If value Is DBNull.Value Then
                Label18.Text = String.Empty
            Else
                Label18.Refresh()
                Label18.Text = CStr(value)
            End If

            value = row.Item("Celular")
            If value Is DBNull.Value Then
                Label19.Text = String.Empty
            Else
                Label19.Refresh()
                Label19.Text = CStr(value)
            End If
        End If

    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        If ComboBox3.SelectedIndex = 0 Then
            ComboBox2.Items.Clear()
            view.comboproductosNoCompra.Clear()
            view.ProductosnoexitenteCompra()
            For Each row As DataRow In view.comboproductosNoCompra.Rows
                ComboBox2.Items.Add(String.Format("{0}|{1}|{2}", row("codMprima").ToString, row("categoria").ToString, row("tipo").ToString))
            Next
        Else
            ComboBox2.Items.Clear()
            view._codIns.Clear()
            view.ComboInsumo()
            For Each row As DataRow In view._codIns.Rows
                ComboBox2.Items.Add(String.Format("{0}|{1}|{2}", row("CodInsumo").ToString, row("categoria").ToString, row("Tipo").ToString))
            Next
            Label1.Text = "Precio"
        End If
    End Sub

    Function Recorrer()
        Dim recorrertexto = ComboBox2.Text
        Dim ArrCadena() As String = recorrertexto.Split("|")
        Return ArrCadena(0)
    End Function

    Sub calcular()
        Dim total As Double = 0
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In DataGridView1.Rows
            total += Convert.ToDouble(fila.Cells("Column4").Value)
        Next
        TxtSubtotal.Text = Convert.ToString(total)

        Dim iva = Convert.ToDouble(TxtSubtotal.Text) * 0.12
        TextBox1.Text = Convert.ToString(iva)

        t = Convert.ToDecimal(TextBox1.Text) + Convert.ToDecimal(TxtSubtotal.Text)
        TextBox2.Text = Convert.ToString(t)
        Dim x As New Letras()
        RichTextBox1.Text = "El valor de la compra es de : " & x.Letras(TextBox2.Text)

    End Sub

    Dim t As Decimal
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If txtcantidad.Text = Nothing Then


            MsgBox("No se puede realizar los calculos respectivos revisite que haya ingresado los valores de compra")
        ElseIf txtpreciokilo.Text = Nothing Then
            MsgBox("No se puede realizar los calculos respectivos revisite que haya ingresado los valores de compra")

        Else


            If ComboBox3.SelectedIndex = 0 Then
                'directa
                view.Combocompras(Recorrer)

                Dim rows As Integer = view.compracombo.Rows.Count
                Dim categoria = Nothing
                Dim nombre = Nothing

                For Each row As DataRow In view.compracombo.Rows
                    categoria = CStr(row("Nombre"))
                    nombre = CStr(row("NombreCategoria"))
                Next
                DataGridView1.Rows.Add(Recorrer, nombre, categoria, txtcantidad.Text, txtpreciokilo.Text, txttotal.Text)
                calcular()

            ElseIf ComboBox3.SelectedIndex = 1 Then
                'indirecta
                view._Combocomprasinsumo(Recorrer)
                Dim rows As Integer = view.compracomboinsumo.Rows.Count
                Dim categoria = Nothing
                Dim nombre = Nothing

                For Each row As DataRow In view.compracomboinsumo.Rows
                    categoria = CStr(row("Nombre"))
                    nombre = CStr(row("NombreCategoria"))
                Next
                DataGridView1.Rows.Add(Recorrer, nombre, categoria, txtcantidad.Text, txtpreciokilo.Text, txttotal.Text)
                calcular()
            Else

                MessageBox.Show("No se puede ingresar los datos debido a que no se ha indicado lo que se agregara ", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If


    End Sub


    Private Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click

        limpiar()
        DataGridView1.Rows.Clear()
        DesHabilitar_Click()
        Nuevo.Text = "Nuevo"


    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click

        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No ahy registro para eliminar")
        Else

            Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)

        End If

        Dim total As Double = 0
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In DataGridView1.Rows
            total += Convert.ToDouble(fila.Cells("Column4").Value)
        Next
        TxtSubtotal.Text = Convert.ToString(total)

        Dim iva = Convert.ToDouble(TxtSubtotal.Text) * 0.12
        TextBox1.Text = Convert.ToString(iva)

        t = Convert.ToDecimal(TextBox1.Text) + Convert.ToDecimal(TxtSubtotal.Text)
        TextBox2.Text = Convert.ToString(t)

    End Sub

    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        Dim total As Decimal
        Dim cantidad As Decimal
        Dim preciokilo As Decimal

        cantidad = CDec(Val(txtcantidad.Text))
        preciokilo = CDec(Val(txtpreciokilo.Text))

        total = cantidad * preciokilo
        txttotal.Text = FormatNumber(total, 2)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        txttotal.Text = Val(TextBox1.Text) + Val(TxtSubtotal.Text)
    End Sub

    Private Sub txtpreciokilo_TextChanged(sender As Object, e As EventArgs) Handles txtpreciokilo.TextChanged
        'valor total de comppras
        Dim total As Decimal
        Dim cantidad As Decimal
        Dim preciokilo As Decimal

        cantidad = CDec(Val(txtcantidad.Text))
        preciokilo = CDec(Val(txtpreciokilo.Text))

        total = cantidad * preciokilo
        txttotal.Text = FormatNumber(total, 2)

    End Sub

    'validador de Numeros
    Private Sub Cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles numeodocumento.KeyPress, txtcantidad.KeyPress

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
    'decimal 
    Private Sub txtpreciokilo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpreciokilo.KeyPress

        Dim numero As Decimal = Nothing
        Dim cadena As String = Nothing
        Try
            cadena = TextBox1.Text
            numero = Convert.ToDecimal(e.KeyChar.ToString)

        Catch ex As Exception
            If e.KeyChar <> "." Or e.KeyChar.Equals(vbBack) Then
                e.Handled = True
            Else

                If (cadena.LastIndexOf(".") > 0) Then
                    e.Handled = True
                End If
            End If
        End Try
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
        Main.Label1.Text = " "
    End Sub


End Class