Imports MySql.Data.MySqlClient
Imports Conexion_Acceso
Public Class Entrada

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_EntradaProductos(ByVal datos As EntidadEntrada) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into inventarioTelas (id_Inventario,movimiento,PrecioCompra,fkproducto,fecha,Concepto,usuario,cantidad,Proveedor)
                                                                       values(default,@movimiento,@PrecioCompra,@fkproducto,@fecha,@Concepto,@usuario,@cantidad,@Proveedor)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@movimiento", MySqlDbType.VarChar, 7).Value = datos.Movimiento
            adaptador.InsertCommand.Parameters.Add("@PrecioCompra", MySqlDbType.Int16, 7).Value = datos.PrecioCompra
            adaptador.InsertCommand.Parameters.Add("@fkproducto", MySqlDbType.VarChar, 45).Value = datos.Fkproducto
            adaptador.InsertCommand.Parameters.Add("@fecha", MySqlDbType.DateTime, 45).Value = datos.Fecha
            adaptador.InsertCommand.Parameters.Add("@Concepto", MySqlDbType.VarChar, 45).Value = datos.Concepto
            adaptador.InsertCommand.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = datos.Usuario
            adaptador.InsertCommand.Parameters.Add("@cantidad", MySqlDbType.Int16, 45).Value = datos.cantidad
            adaptador.InsertCommand.Parameters.Add("@Proveedor", MySqlDbType.VarChar, 45).Value = datos.Proveedor

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("error al ingresar los datos", MsgBoxStyle.Exclamation, ex)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    'guardar datos de personal
    Public Function Ingresar_EntradaInsumos(ByVal datos As EntidadEntrada) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into inventarioInsumo (idInvenInsumo,movimiento,PrecioCompra,fkinsumo,fecha,Concepto,usuario,cantidad,Proveedor)
                                                                       values(default,@movimiento,@PrecioCompra,@fkinsumo,@fecha,@Concepto,@usuario,@cantidad,@Proveedor)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@movimiento", MySqlDbType.VarChar, 7).Value = datos.Movimiento
            adaptador.InsertCommand.Parameters.Add("@PrecioCompra", MySqlDbType.Int16, 7).Value = datos.PrecioCompra
            adaptador.InsertCommand.Parameters.Add("@fkinsumo", MySqlDbType.VarChar, 45).Value = datos.Fkproducto
            adaptador.InsertCommand.Parameters.Add("@fecha", MySqlDbType.DateTime, 45).Value = datos.Fecha
            adaptador.InsertCommand.Parameters.Add("@Concepto", MySqlDbType.VarChar, 45).Value = datos.Concepto
            adaptador.InsertCommand.Parameters.Add("@usuario", MySqlDbType.VarChar, 45).Value = datos.Usuario
            adaptador.InsertCommand.Parameters.Add("@cantidad", MySqlDbType.Int16, 45).Value = datos.cantidad
            adaptador.InsertCommand.Parameters.Add("@Proveedor", MySqlDbType.VarChar, 45).Value = datos.Proveedor

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("error al ingresar los datos", MsgBoxStyle.Exclamation, ex)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

End Class
