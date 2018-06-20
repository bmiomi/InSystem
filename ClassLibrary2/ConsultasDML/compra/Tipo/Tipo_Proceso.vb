Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class Tipo_Proceso
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_tipo_(ByVal datos As Enti_Tipo) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into values(@id,@tipo,@fkproductos@,fkinsumos)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = datos.Id
            adaptador.InsertCommand.Parameters.Add("@tipo", MySqlDbType.VarChar, 45).Value = datos.Tipo
            adaptador.InsertCommand.Parameters.Add("@fkproductos", MySqlDbType.VarChar, 45).Value = datos.Fkprocto
            adaptador.InsertCommand.Parameters.Add("@insumo", MySqlDbType.VarChar, 10).Value = datos.Fkinsumo

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

    'Actualizar datos
    Public Function Actualizar_dtos_tipo_(ByVal datos As Enti_Tipo) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()


            adaptador.UpdateCommand = New MySqlCommand("UPDATE compra set Idcompra=@Idcompra,fecha=@fecha,catidad=@catidad,Valor_Unitario=@Valor_Unitario,Subtotal=@Subtotal,Iva=@Iva,Valor_Total=@Valor_Total,fkProvedor=@fkProvedor,fktipo=@fktipo where CI=@CI", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id", MySqlDbType.VarChar, 11).Value = datos.Id
            adaptador.InsertCommand.Parameters.Add("@tipo", MySqlDbType.VarChar, 45).Value = datos.Tipo
            adaptador.InsertCommand.Parameters.Add("@fkproductos", MySqlDbType.VarChar, 45).Value = datos.Fkprocto
            adaptador.InsertCommand.Parameters.Add("@insumo", MySqlDbType.VarChar, 10).Value = datos.Fkinsumo

            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("Error al actualizar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos_tipo(ByVal datos As Enti_Tipo) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from compra where Idcompra=@Idcompra", conectar._conexion)
            '  adaptador.DeleteCommand.Parameters.Add("@CI", MySqlDbType.Int32, 11).Value = datos.CI
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error al eliminar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    Public Function ActializarCI_dtos_personal(ByVal datos As String, ByVal dato2 As Integer)

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand(" UPDATE personal set CI = " & datos & " where CI=@CI", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@CI", MySqlDbType.Int32, 11).Value = dato2
            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("error al eliminar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado

    End Function
End Class
