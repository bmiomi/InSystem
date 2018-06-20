Imports MySql.Data.MySqlClient
Imports Conexion_Acceso
Public Class DetalleCompra_


    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_detalleCompra_(ByVal datos As Ent_Detalle) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into detallecompra (IVA,SUBTOTAL,TOTAL )
                                                        values(@IVA,@SUBTOTAL,@TOTAL)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@IVA", MySqlDbType.Decimal, 2).Value = datos.Iva
            adaptador.InsertCommand.Parameters.Add("@SUBTOTAL", MySqlDbType.Decimal, 7).Value = datos.Subtotal
            adaptador.InsertCommand.Parameters.Add("@TOTAL", MySqlDbType.Decimal, 45).Value = datos.ValorTotal

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("Error al ingresar los datos", MsgBoxStyle.Exclamation, ex)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


End Class
