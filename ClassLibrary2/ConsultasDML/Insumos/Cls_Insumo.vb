Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class Cls_Insumo

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    Public Function Ingresar_dtosInsumos(ByVal datos As EntInsumo) As Boolean
        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("insert into insumos  values (@idInsumo,@codInsumo,@fkcategoria,@fksubcategoria,@descripcion )", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@idInsumo", MySqlDbType.Int32, 11).Value = datos.Idinsumo
            adaptador.InsertCommand.Parameters.Add("@codinsumo", MySqlDbType.VarChar, 11).Value = datos.CodInsumo
            adaptador.InsertCommand.Parameters.Add("@fkcategoria", MySqlDbType.Int16).Value = datos.Fkcategoria
            adaptador.InsertCommand.Parameters.Add("@fksubcategoria", MySqlDbType.Int16).Value = datos.Fksubcategoria
            adaptador.InsertCommand.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = datos.Descripcion



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
