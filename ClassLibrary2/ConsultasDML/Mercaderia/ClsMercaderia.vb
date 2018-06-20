Imports MySql.Data.MySqlClient
Imports Conexion_Acceso
Public Class ClsMercaderia

    Dim conectar As New BD_Conexion
    Dim adaptador As New MySqlDataAdapter

    Public Function Ingreso_Mercadera(datos As EntMercaderia)
        Dim estado = False
        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into Mercaderia values(default,@CodMercaderia,
                                                                                              @fkModelo,
                                                                                              @CantidadD,
                                                                                              @CantidadU)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@CodMercaderia", MySqlDbType.VarChar, 2).Value = datos.Codmercaderia
            adaptador.InsertCommand.Parameters.Add("@fkModelo", MySqlDbType.VarChar, 7).Value = datos.Modelo1
            adaptador.InsertCommand.Parameters.Add("@CantidadD", MySqlDbType.VarChar, 45).Value = datos.CantidadD1
            adaptador.InsertCommand.Parameters.Add("@CantidadU", MySqlDbType.VarChar, 45).Value = datos.CantidadD1


            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
            estado = True
        Catch ex As MySqlException
            MsgBox("Error al Ingresar los Datos")
        Finally
            conectar.Cerrar()
        End Try

        Return estado
    End Function


End Class
