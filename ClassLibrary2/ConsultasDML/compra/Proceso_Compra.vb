Imports MySql.Data.MySqlClient
Imports Conexion_Acceso
Public Class Proceso_Compra
    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_Compra_(ByVal datos As Ent_Compra) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into compra values( default,
                                                                                    @tipodocumento,
                                                                                    @NDocumento,
                                                                                    @tipocompra,
                                                                                    @fecha,
                                                                                    @cantidad,
                                                                                    @Valor_Unitario,
                                                                                    @fkProvedor,
                                                                                    @fktipo,
                                                                                    @fkdetalleCompra,
                                                                                    @fkproducto,
                                                                                    @fkinsumo
                                                                                   )", conectar._conexion)
            adaptador.InsertCommand.Parameters.Add("@tipodocumento", MySqlDbType.VarChar, 45).Value = datos.Tipodocumento
            adaptador.InsertCommand.Parameters.Add("@NDocumento", MySqlDbType.Int16, 45).Value = datos.Numerodocumento
            adaptador.InsertCommand.Parameters.Add("@tipocompra", MySqlDbType.VarChar, 45).Value = datos.Tipocompra
            adaptador.InsertCommand.Parameters.Add("@fecha", MySqlDbType.Date).Value = datos.Fecha
            adaptador.InsertCommand.Parameters.Add("@cantidad", MySqlDbType.Decimal, 4).Value = datos.Cantidad
            adaptador.InsertCommand.Parameters.Add("@Valor_Unitario", MySqlDbType.Decimal, 4).Value = datos.ValorUnitario
            adaptador.InsertCommand.Parameters.Add("@fkProvedor", MySqlDbType.VarChar, 45).Value = datos.Fkprovedor
            adaptador.InsertCommand.Parameters.Add("@fktipo", MySqlDbType.Int16, 45).Value = datos.Fktipo
            adaptador.InsertCommand.Parameters.Add("@fkdetalleCompra", MySqlDbType.Int16, 45).Value = datos.Fkdetallecompra
            adaptador.InsertCommand.Parameters.Add("@fkProducto", MySqlDbType.VarChar, 45).Value = datos.Fkproducto
            adaptador.InsertCommand.Parameters.Add("@fkinsumo", MySqlDbType.VarChar, 45).Value = datos.Fkinsumo


            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("error al ingresar los datos", MsgBoxStyle.Exclamation, ex.ToString)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'Actualizar datos
    Public Function Actualizar_dtos_compra_(ByVal datos As Ent_Compra) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()


            adaptador.UpdateCommand = New MySqlCommand("UPDATE compra set Idcompra=@Idcompra,fecha=@fecha,catidad=@catidad,Valor_Unitario=@Valor_Unitario,fktipo=@fktipo,fkdetalleCompra=@fkdetalleCompra,fkProvedor=@fkProvedor,fkProducto=@fkProducto, tipodocumento=@tipodocumento,NumeroDocumento=@NumeroDocumento,tipocompra=@tipocompra where Idcompra=@Idcompra", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@Idcompra", MySqlDbType.VarChar, 11).Value = datos.Idcompra
            adaptador.UpdateCommand.Parameters.Add("@fecha", MySqlDbType.VarChar, 45).Value = datos.Fecha
            adaptador.UpdateCommand.Parameters.Add("@catidad", MySqlDbType.VarChar, 45).Value = datos.Cantidad
            adaptador.UpdateCommand.Parameters.Add("@Valor_Unitario", MySqlDbType.VarChar, 10).Value = datos.ValorUnitario
            adaptador.UpdateCommand.Parameters.Add("@fktipo", MySqlDbType.VarChar, 45).Value = datos.Fktipo
            adaptador.UpdateCommand.Parameters.Add("@fkdetalleCompra", MySqlDbType.VarChar, 45).Value = datos.Fkdetallecompra
            adaptador.UpdateCommand.Parameters.Add("@fkProvedor", MySqlDbType.VarChar, 45).Value = datos.Fkprovedor
            adaptador.UpdateCommand.Parameters.Add("@fkProducto", MySqlDbType.VarChar, 45).Value = datos.Fkproducto
            adaptador.UpdateCommand.Parameters.Add("@tipodocumento", MySqlDbType.VarChar, 45).Value = datos.Tipodocumento
            adaptador.UpdateCommand.Parameters.Add("@Numerodocumento", MySqlDbType.Int16, 45).Value = datos.Numerodocumento
            adaptador.UpdateCommand.Parameters.Add("@tipocompra", MySqlDbType.VarChar, 45).Value = datos.Tipocompra


            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("Error al actualizar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos_compra(ByVal datos As AccesoPersonal) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from compra where Idcompra=@Idcompra", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@CI", MySqlDbType.Int32, 11).Value = datos.CI
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error al eliminar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    Public Function ActializarCI_dtos_personal(ByVal datos As String, ByVal dato2 As Integer)

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand(" UPDATE personal set CI = " & datos & " where CI=@CI", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@CI", MySqlDbType.Int32, 11).Value = dato2
            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error al eliminar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado

    End Function
End Class
