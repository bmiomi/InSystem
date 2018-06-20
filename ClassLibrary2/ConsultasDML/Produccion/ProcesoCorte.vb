
Imports MySql.Data.MySqlClient
Imports Conexion_Acceso


Public Class ProcesoCorte

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'eliminar datos de corte. 
    Public Function eliminar_dtos_cote(ByVal datos As AccesoCorte) As Boolean
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from corte where cod_corte=@cod_corte", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@cod_corte", MySqlDbType.Int32, 11).Value = datos.CodigoCorte
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            estado = False
        Finally
            conectar.Cerrar()
        End Try

        Return estado
    End Function
    'guardar datos de corte
    Public Function Ingresar_dtos_corte_(ByVal datos As AccesoCorte) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand(" insert into corte (CodigoCorte,FKcodtendido,fkmodelo,C_uni_prendas) 
                                                         values (@CodigoCorte,@FKcodtendido,@fkmodelo,@C_uni_prendas)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@CodigoCorte", MySqlDbType.String).Value = datos.CodigoCorte
            adaptador.InsertCommand.Parameters.Add("@FKcodtendido", MySqlDbType.String).Value = datos.FkCodTendido
            adaptador.InsertCommand.Parameters.Add("@fkmodelo", MySqlDbType.Int16).Value = datos.ModeloPrenda
            adaptador.InsertCommand.Parameters.Add("@C_uni_prendas", MySqlDbType.Int16).Value = datos.C_uni_prendas

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion
            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("ahy errror", MsgBoxStyle.MsgBoxHelp)
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function
    ''actualizar datos corte
    'Public Function Actualizar_dtos_cortel_(ByVal datos As AccesoCorte) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar.Conex_Global()
    '        adaptador.UpdateCommand = New MySqlCommand("UPDATE corte set cod_corte=@cod_corte,texturaprenda=@texturaprenda,tipoprenda=@tipoprenda,modelo_prenda=@modelo_prenda,fechainicial=@fechainicial,FKpartepiesas=@FkPartepiesas where cod_corte@=cod_corte", conectar._conexion)

    '        adaptador.UpdateCommand.Parameters.Add("@cod_corte", MySqlDbType.Int32, 11).Value = datos.CodigoCorte
    '        adaptador.UpdateCommand.Parameters.Add("@texturaprenda", MySqlDbType.VarChar).Value = datos.TexturaPrenda
    '        adaptador.UpdateCommand.Parameters.Add("@tipoprenda", MySqlDbType.VarChar).Value = datos.TipoPrenda
    '        adaptador.UpdateCommand.Parameters.Add("@modeloprenda", MySqlDbType.VarChar).Value = datos.ModeloPrenda
    '        adaptador.UpdateCommand.Parameters.Add("@fechainicial", MySqlDbType.VarChar).Value = datos.FechaPrenda
    '        adaptador.UpdateCommand.Parameters.Add("@FKparteprendas", MySqlDbType.VarChar).Value = datos.FkPartePrenda

    '        conectar._conexion.Open()
    '        adaptador.UpdateCommand.Connection = conectar._conexion
    '        adaptador.UpdateCommand.ExecuteNonQuery()
    '    Catch ex As MySqlException
    '        MsgBox(ex.Message)
    '        estado = False
    '    Finally
    '        conectar.Cerrar()
    '    End Try
    '    Return estado
    'End Function


End Class
