Imports Conexion_Acceso
Imports MySql.Data.MySqlClient

Public Class ProcesoIngresoTela

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_Ingresotela_(ByVal datos As AccesoIngresoTela) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into tela_entrada (id_telaEntrada,fk_tela,fch_entrada,cant_entrada)
                                                        values(@id_telaEntrada,@fk_tela,fch_entrada,cant_entrante)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_telaEntrada", MySqlDbType.Int16, 11).Value = datos.IdTelaentrada
            adaptador.InsertCommand.Parameters.Add("@fk_tela", MySqlDbType.VarChar, 45).Value = datos.FkTela
            adaptador.InsertCommand.Parameters.Add("@fch_entrada", MySqlDbType.Date, 11).Value = datos.FechaIngreso
            adaptador.InsertCommand.Parameters.Add("@cant_entrada", MySqlDbType.Int16, 45).Value = datos.Cantidad_Entrante


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
    Public Function Actualizar_dtos_tela_(ByVal datos As AccesoIngresoTela) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("UPDATE  tela_entrada set id_telaEntrada=@id_telaEntrada,fk_tela=@fk_tela,fch_entrada=@fch_entrada,cant_entrad=@cant_entrad where id_telaEntrada=@id_telaEntrada", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_telaEntrada", MySqlDbType.VarChar, 11).Value = datos.IdTelaentrada
            adaptador.UpdateCommand.Parameters.Add("@fk_tela", MySqlDbType.VarChar, 45).Value = datos.FkTela
            adaptador.UpdateCommand.Parameters.Add("@fch_entrada", MySqlDbType.VarChar, 11).Value = datos.FechaIngreso
            adaptador.UpdateCommand.Parameters.Add("@cant_entrad", MySqlDbType.VarChar, 45).Value = datos.Cantidad_Entrante


            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox("error al actualizar los datos")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos_tela(ByVal datos As AccesoIngresoTela) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from tela_entrada where id_telaEntrada=@id_telaEntrada", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@id_telaEntrada", MySqlDbType.Int32, 11).Value = datos.IdTelaentrada
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



End Class
