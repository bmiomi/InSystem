Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class ProcesoProvedor

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de corte
    Public Function Ingresar_dtos_Provedor_(ByVal datos As AccesoProvedor) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand(" insert into provedor  (id_Provedor,Cod_Provedor,RUC,N_Almacen,Convencional,Celular,Direccion,Origen)
                                                                        values ( @id_Provedor,@Cod_Provedor,@RUC,@N_Almacen,@Convencional,@Celular,@Direccion,@Origen)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_Provedor", MySqlDbType.Int64, 11).Value = datos.Id_codProvedor
            adaptador.InsertCommand.Parameters.Add("@Cod_Provedor", MySqlDbType.String, 11).Value = datos.CodProvedor
            adaptador.InsertCommand.Parameters.Add("@RUC", MySqlDbType.String, 11).Value = datos.RUC
            adaptador.InsertCommand.Parameters.Add("@N_Almacen", MySqlDbType.String).Value = datos.N_Almacen
            adaptador.InsertCommand.Parameters.Add("@Convencional", MySqlDbType.Int64, 11).Value = datos.Convencional
            adaptador.InsertCommand.Parameters.Add("@Celular", MySqlDbType.Int64).Value = datos.Celular
            adaptador.InsertCommand.Parameters.Add("@Direccion", MySqlDbType.String, 11).Value = datos.Direccion
            adaptador.InsertCommand.Parameters.Add("@Origen", MySqlDbType.String).Value = datos.Origen

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion
            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("ahy errror al Insertar los Datos " + ex.Message, MsgBoxStyle.MsgBoxHelp)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function



    'Actualizar datos Proveedor
    Public Function Actualizar_dtos_Provedor_(ByVal datos As AccesoProvedor) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("UPDATE provedor set 
                                                          id_Provedor=@id_Provedor,
                                                            Cod_Provedor=@Cod_Provedor,
                                                            Ruc=@Ruc,
                                                            N_Almacen=@N_Almacen,
                                                            Convencional=@Convencional,
                                                            Celular=@Celular,
                                                            Direccion=@Direccion,
                                                            Origen=@Origen 
                                                        where Cod_Provedor = @Cod_Provedor", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_Provedor", MySqlDbType.Int64, 11).Value = datos.Id_codProvedor
            adaptador.UpdateCommand.Parameters.Add("@Cod_Provedor", MySqlDbType.VarChar, 11).Value = datos.CodProvedor
            adaptador.UpdateCommand.Parameters.Add("@RUC", MySqlDbType.String, 11).Value = datos.RUC
            adaptador.UpdateCommand.Parameters.Add("@N_Almacen", MySqlDbType.VarChar).Value = datos.N_Almacen
            adaptador.UpdateCommand.Parameters.Add("@Convencional", MySqlDbType.Int32, 11).Value = datos.Convencional
            adaptador.UpdateCommand.Parameters.Add("@Celular", MySqlDbType.Int16).Value = datos.Celular
            adaptador.UpdateCommand.Parameters.Add("@Direccion", MySqlDbType.VarChar, 11).Value = datos.Direccion
            adaptador.UpdateCommand.Parameters.Add("@Origen", MySqlDbType.VarChar).Value = datos.Origen


            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("ahy errror al Actualizar los Datos " + ex.Message, MsgBoxStyle.MsgBoxHelp)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    'Eliminar datos de Provedor. 
    Public Function Eliminar_dtos_Provedor(ByVal datos As AccesoProvedor) As Boolean
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from provedor where CodProvedor=@CodProvedor", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@Provedor", MySqlDbType.Int32, 11).Value = datos.CodProvedor
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ahy errror al Actualizar los Datos " + ex.Message, MsgBoxStyle.MsgBoxHelp)
            estado = False
        Finally
            conectar.Cerrar()
        End Try

        Return estado
    End Function

End Class
