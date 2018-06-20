Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports Conexion_Acceso

Public Class LoginClase
    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion



    Private xtsa As String

    Function Consultalogin(user As String, pass As String)
        Dim estado As Boolean = False

        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("SELECT COUNT(*) FROM Login WHERE usuario='" & user & "'and contraseña='" & pass & "'", conectar._conexion)
        conectar._conexion.Open()
        xtsa = adaptador.SelectCommand.ExecuteScalar
        If xtsa = "0" Then
            Return False
        Else
            Return True
        End If
        conectar._conexion.Close()
    End Function


    Function datosregistro(ByVal datos As EnLogin)
        Dim estado As Boolean = True
        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into login (id,usuario,contraseña,cargo )
                                                        values(default,@usuario,@contraseña,@cargo )", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@usuario", MySqlDbType.VarChar, 11).Value = datos.Usuario
            adaptador.InsertCommand.Parameters.Add("@contraseña", MySqlDbType.VarChar, 45).Value = datos.Password
            adaptador.InsertCommand.Parameters.Add("@cargo", MySqlDbType.VarChar, 45).Value = datos.Cargo

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


    Private dataread As MySqlDataReader

    Function Mainc(consultass As String)
        Dim estado As String = Nothing

        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("select Cargo from login where usuario='" & consultass & "'", conectar._conexion)
        conectar._conexion.Open()
        dataread = adaptador.SelectCommand.ExecuteReader

        If dataread.Read() Then
            estado = dataread.GetValue(0).ToString
        End If
        dataread.Close()

        Return estado
    End Function


End Class
