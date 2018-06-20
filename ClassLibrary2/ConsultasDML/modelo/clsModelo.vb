Imports MySql.Data.MySqlClient
Imports Conexion_Acceso
Public Class clsModelo



    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    Public Function Ingresar_dtosmodelo(ByVal datos As EntModelo) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("insert into modelo  values (@idmodelo,@nombre )", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@idmodelo", MySqlDbType.Int32, 11).Value = datos.Idmodelo
            adaptador.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 11).Value = datos.Nombre



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
End Class
