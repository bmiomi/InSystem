
Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class Produccion

    Public datospartespiezas As New DataTable
    Public dtvpartespiesas As New DataView
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    Public Sub Consulta_bodega()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("Select codMPrima FROM productos", conectar._conexion)
            adaptador.Fill(datospartespiezas)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    'guardar datos de corte
    Public Function ingresar_dtos_produccion(ByVal datos As Ent_produccion) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("insert into produccion  values( @CodTendido,@FechaTendido,@tamanio_base,@C_capas_unitarias,@total_unitario_mts, @C_Rollos,@Total_mts_usados,@C_Modelos)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@CodTendido", MySqlDbType.Int32, 11).Value = datos.CodTendido
            adaptador.InsertCommand.Parameters.Add("@FechaTendido", MySqlDbType.DateTime).Value = datos.FechaTendido
            adaptador.InsertCommand.Parameters.Add("@tamanio_base", MySqlDbType.VarChar).Value = datos.Tamanio_base
            adaptador.InsertCommand.Parameters.Add("@C_capas_unitarias", MySqlDbType.VarChar).Value = datos.C_capas_unitarias
            adaptador.InsertCommand.Parameters.Add("@total_unitario_mts", MySqlDbType.Int16).Value = datos.Total_unitario_mts
            adaptador.InsertCommand.Parameters.Add("@C_Rollos", MySqlDbType.Int16).Value = datos.C_Rollos
            adaptador.InsertCommand.Parameters.Add("@Total_mts_usados", MySqlDbType.VarChar).Value = datos.Total_mts_usados
            adaptador.InsertCommand.Parameters.Add("@C_Modelos", MySqlDbType.VarChar).Value = datos.C_Modelos

            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion
            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("ahy errror")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    'Public Function eliminar_dtos_produccion(ByVal datos As Ent_produccion) As Boolean
    '    Dim estado = True
    '    Try
    '        conectar.Conex_Global()
    '        adaptador.DeleteCommand = New MySqlCommand("Delete from partespiesas where partespiesas=@codpartespiesas", conectar._conexion)
    '        adaptador.DeleteCommand.Parameters.Add("@partespiesas", MySqlDbType.Int32, 11).Value = datos.CodPartespiesas
    '        conectar._conexion.Open()
    '        adaptador.DeleteCommand.Connection = conectar._conexion
    '        adaptador.DeleteCommand.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        estado = False
    '    Finally
    '        conectar.Cerrar()
    '    End Try

    '    Return estado
    'End Function


    'actualizar datos corte
    'Public Function Actualizar_dtos_produccion(ByVal datos As Ent_produccion) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conex_Global()
    '        adaptador.UpdateCommand = New MySqlCommand("UPDATE corte set cod_corte=@cod_corte,modelo_prenda=@modelo_prenda,total_bloques=@total_bloques,fechacorte=@fechacorte,hora=@hora,descripcion,=@descripcion,codinsumo=@codinsumo1,cod_tendido=@cod_tendido where cod_corte@=cod_corte", conexion)

    '        adaptador.UpdateCommand.Parameters.Add("@cod_corte", MySqlDbType.Int32, 11).Value = datos.codcorte
    '        adaptador.UpdateCommand.Parameters.Add("@tipo_prenda", MySqlDbType.VarChar).Value = datos.tipo
    '        adaptador.UpdateCommand.Parameters.Add("@frente", MySqlDbType.VarChar).Value = datos.fren
    '        adaptador.UpdateCommand.Parameters.Add("@espalda", MySqlDbType.VarChar).Value = datos.espa
    '        adaptador.UpdateCommand.Parameters.Add("@otros", MySqlDbType.VarChar).Value = datos.otr
    '        adaptador.UpdateCommand.Parameters.Add("@total_bloques", MySqlDbType.Int32).Value = datos.total_bloqu
    '        adaptador.UpdateCommand.Parameters.Add("@fechacorte", MySqlDbType.DateTime).Value = datos.fecha_inici
    '        adaptador.UpdateCommand.Parameters.Add("@descripcion", MySqlDbType.String).Value = datos.descrition
    '        adaptador.UpdateCommand.Parameters.Add("@modelo_prenda", MySqlDbType.VarChar).Value = datos.mode_prend
    '        adaptador.UpdateCommand.Parameters.Add("@cod_tendido", MySqlDbType.Int32).Value = datos.codtendi
    '        adaptador.UpdateCommand.Parameters.Add("@codinsumo1", MySqlDbType.Int32).Value = datos.codsum

    '        conexion.Open()
    '        adaptador.UpdateCommand.Connection = conexion
    '        adaptador.UpdateCommand.ExecuteNonQuery()
    '    Catch ex As MySqlException
    '        MessageBox.Show(ex.Message)
    '        estado = False
    '    Finally
    '        cerrar()
    '    End Try
    '    Return estado
    'End Function
End Class
