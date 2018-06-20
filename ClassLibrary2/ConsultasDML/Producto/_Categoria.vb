Imports Conexion_Acceso
Imports MySql.Data.MySqlClient

Public Class _Categoria

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'Guardar datos de personal
    Public Function Ingresar_dtos_Categoria(ByVal datos As Ent_Categoria) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into categoria  values(@id_categoria,
                                                                                      @NombreCategoria)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_categoria", MySqlDbType.VarChar, 11).Value = datos.Idcategoria
            adaptador.InsertCommand.Parameters.Add("@NombreCategoria", MySqlDbType.VarChar, 45).Value = datos.Nombrecategoria

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion
            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(String.Format("Error al Ingresar los Datos {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


















    'Actualizar datos
    Public Function Actualizar_dtos_Categoria(ByVal datos As Ent_Categoria) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("UPDATE  tela set id_Detalle_entrada=@id_Detalle_entrada,peso=@peso,,Metraje=@Metraje,cant_Unitaria=@cant_unitaria,idtelaEntrada=@idtelaEntrada where id_Detalle_entrada=@id_Detalle_entrada", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_categoria", MySqlDbType.VarChar, 11).Value = datos.Idcategoria
            adaptador.UpdateCommand.Parameters.Add("@NombreCategoria", MySqlDbType.VarChar, 45).Value = datos.Nombrecategoria


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
    Public Function Eliminar_dtos_Categoria(ByVal datos As DetalleTelaEntrada) As Boolean

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
