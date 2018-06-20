Imports MySql.Data.MySqlClient
Imports Conexion_Acceso



Public Class Procesopersonalcorte


    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_cortepersonal_(ByVal datos As Ent_CortePersonal) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into detallecortepersonal (CodMaquilado,Fecha,fkCodCI,fkCodCorte)
                                                        values(@CodMaquilado,@Fecha,@fkCodCI,@fkCodCorte)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@CodMaquilado", MySqlDbType.Int16, 2).Value = datos.CodMAquilado
            adaptador.InsertCommand.Parameters.Add("@Fecha", MySqlDbType.Date, 7).Value = datos.Fecha
            adaptador.InsertCommand.Parameters.Add("@fkCodCI", MySqlDbType.Int16, 45).Value = datos.FkcodCI
            adaptador.InsertCommand.Parameters.Add("@fkCodCorte", MySqlDbType.Int16, 45).Value = datos.Fkcodcorte

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



End Class
