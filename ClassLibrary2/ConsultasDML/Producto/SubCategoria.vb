Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class SubCategoria
    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_SubCategoria(ByVal datos As Ent_SubCategoria) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into Subcategoria  values (  @id_Subcategoria,
                                                                                           @Nombre,
                                                                                           @fkcategoria)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_Subcategoria", MySqlDbType.Int16, 11).Value = datos.IdSubcategorias
            adaptador.InsertCommand.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = datos.Nombres
            adaptador.InsertCommand.Parameters.Add("@fkcategoria", MySqlDbType.Int16, 11).Value = datos.FkCategoria

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
    Public Function Actualizar_dtos_SubCategoria(ByVal datos As Ent_SubCategoria) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("UPDATE  SubCategoria set id_SubCategoria=@id_SubCategoria,Nombre=@Nombre,,Descripcion=@Descripcion,fkCategoria=@fkCategoria where id_SubCategoria=@id_SubCategoria", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_Subcategoria", MySqlDbType.VarChar, 11).Value = datos.IdSubcategorias
            adaptador.UpdateCommand.Parameters.Add("@NombreCategoria", MySqlDbType.VarChar, 45).Value = datos.Nombres
            adaptador.UpdateCommand.Parameters.Add("@descripcion", MySqlDbType.VarChar, 11).Value = datos.Descripcion
            adaptador.UpdateCommand.Parameters.Add("@fkCategoria", MySqlDbType.Int16, 11).Value = datos.FkCategoria

            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(String.Format("Error al actualizar los Datos {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos_SubCategoria(ByVal datos As DetalleTelaEntrada) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from SubCategoria where id_Subcategoria=@id_Subcategoria", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@id_Subcategoria", MySqlDbType.Int32, 11).Value = datos.ID_DEtalleEntrada
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(String.Format("Error al elimiar los Datos {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function



End Class
