Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class _produccion

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    ''eliminar datos de corte. 
    'Public Function eliminar_dtos_cote(ByVal datos As Ent_produccion) As Boolean
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
    ''guardar datos de corte
    'Public Function ingresar_dtos_Partespiesas_(ByVal datos As Ent_produccion) As Boolean
    '    Dim estado As Boolean = True
    '    Try
    '        conectar.Conex_Global()
    '        adaptador.InsertCommand = New MySqlCommand("insert into partesprendas (CodigoPartesprendas,Frente,Espalda,Mangas,Punios,Canesu,Sesgo) values(@CodigoPartesprendas,@Frente,@Espalda,@Mangas,@Punios,@Canesu,@Sesgo)", conectar._conexion)

    '        adaptador.InsertCommand.Parameters.Add("@CodigoPartesprendas", MySqlDbType.Int32, 11).Value = datos.CodPartespiesas
    '        adaptador.InsertCommand.Parameters.Add("@Frentes", MySqlDbType.VarChar).Value = datos.Frente
    '        adaptador.InsertCommand.Parameters.Add("@Espalda", MySqlDbType.VarChar).Value = datos.Espalda
    '        adaptador.InsertCommand.Parameters.Add("@Mangas", MySqlDbType.VarChar).Value = datos.Mangas
    '        adaptador.InsertCommand.Parameters.Add("@Punios", MySqlDbType.DateTime).Value = datos.Punios
    '        adaptador.InsertCommand.Parameters.Add("@Canesu", MySqlDbType.DateTime).Value = datos.Canesu
    '        adaptador.InsertCommand.Parameters.Add("@sesgo", MySqlDbType.VarChar).Value = datos.Sesgo


    '        conectar._conexion.Open()
    '        adaptador.InsertCommand.Connection = conectar._conexion
    '        adaptador.InsertCommand.ExecuteNonQuery()
    '    Catch ex As MySqlException
    '        MsgBox("ahy errror")
    '        estado = False
    '    Finally
    '        conectar.Cerrar()
    '    End Try
    '    Return estado
    'End Function

    ''actualizar datos corte
    ''Public Function Actualizar_dtos_cortel_(ByVal datos As AccesoPartesPiesas) As Boolean
    ''    Dim estado As Boolean = True
    ''    Try
    ''        conex_Global()
    ''        adaptador.UpdateCommand = New MySqlCommand("UPDATE corte set cod_corte=@cod_corte,modelo_prenda=@modelo_prenda,total_bloques=@total_bloques,fechacorte=@fechacorte,hora=@hora,descripcion,=@descripcion,codinsumo=@codinsumo1,cod_tendido=@cod_tendido where cod_corte@=cod_corte", conexion)

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
