
Imports Conexion_Acceso
Imports MySql.Data.MySqlClient

Public Class ProcesoDetalleTela

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_detalletela_(ByVal datos As DetalleTelaEntrada) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into tela (id_Detalle_entrada,peso,Metraje,cant_Unitaria,idtelaEntrada)
                                                        values(@id_Detalle_entrada,@peso,@Metraje,@cant_Unitaria,@idtelaEntrada)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_Detalle_entrada", MySqlDbType.VarChar, 11).Value = datos.ID_DEtalleEntrada

            adaptador.InsertCommand.Parameters.Add("@peso", MySqlDbType.VarChar, 45).Value = datos.Peso
            adaptador.InsertCommand.Parameters.Add("@Metraje", MySqlDbType.VarChar, 11).Value = datos.Metraje
            adaptador.InsertCommand.Parameters.Add("@cant_Unitaria", MySqlDbType.VarChar, 45).Value = datos.CantidadUnitaria
            adaptador.InsertCommand.Parameters.Add("@idtelaEntrada", MySqlDbType.VarChar, 45).Value = datos.IDTelaEntrada

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

    'Actualizar datos
    Public Function Actualizar_dtos__detalletela_(ByVal datos As DetalleTelaEntrada) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("UPDATE  tela set id_Detalle_entrada=@id_Detalle_entrada,peso=@peso,,Metraje=@Metraje,cant_Unitaria=@cant_unitaria,idtelaEntrada=@idtelaEntrada where id_Detalle_entrada=@id_Detalle_entrada", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_Detalle_entrada", MySqlDbType.VarChar, 11).Value = datos.ID_DEtalleEntrada
            adaptador.UpdateCommand.Parameters.Add("@peso", MySqlDbType.VarChar, 45).Value = datos.Peso
            adaptador.UpdateCommand.Parameters.Add("@Metraje", MySqlDbType.VarChar, 11).Value = datos.Metraje
            adaptador.UpdateCommand.Parameters.Add("@cant_Unitaria", MySqlDbType.VarChar, 45).Value = datos.CantidadUnitaria
            adaptador.UpdateCommand.Parameters.Add("@idtelaEntrada", MySqlDbType.VarChar, 45).Value = datos.IDTelaEntrada


            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("error al actualizar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos__detalletela(ByVal datos As DetalleTelaEntrada) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from personal where id_Detalle_entrada=@id_Detalle_entrada", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@id_Detalle_entrada", MySqlDbType.Int32, 11).Value = datos.ID_DEtalleEntrada
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


End Class
