Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class _Producto

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
    Public Function Ingresar_dtos_producto_(ByVal datos As Ent_Producto) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into productos values(
                                                                                        @id_MPrima,
                                                                                        @CodMPrima,
                                                                                        @disenio,
                                                                                        @color,
                                                                                        @peso,
                                                                                        @metraje,
                                                                                        @Ancho,
                                                                                        @fkcategoria,
                                                                                        @fksubca
                                                                                       )", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@id_MPrima", MySqlDbType.Int16, 11).Value = datos.id_MPrima
            adaptador.InsertCommand.Parameters.Add("@CodMPrima", MySqlDbType.VarChar, 45).Value = datos.CodMPrima
            adaptador.InsertCommand.Parameters.Add("@disenio", MySqlDbType.VarChar, 45).Value = datos.Disenio
            adaptador.InsertCommand.Parameters.Add("@color", MySqlDbType.VarChar, 45).Value = datos.Color
            adaptador.InsertCommand.Parameters.Add("@peso", MySqlDbType.Int16, 45).Value = datos.Peso
            adaptador.InsertCommand.Parameters.Add("@metraje", MySqlDbType.Int16, 45).Value = datos.Metraje
            adaptador.InsertCommand.Parameters.Add("@Ancho", MySqlDbType.Int16, 45).Value = datos.Ancho
            adaptador.InsertCommand.Parameters.Add("@fkCategoria", MySqlDbType.Int16, 45).Value = datos.FkCategoria
            adaptador.InsertCommand.Parameters.Add("@fksubca", MySqlDbType.Int16, 45).Value = datos.Fksubcategoria


            conectar._conexion.Open()
            adaptador.InsertCommand.Connection = conectar._conexion

            adaptador.InsertCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(String.Format("Error al Ingresar los Datos {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function


    'Actualizar datos
    Public Function Actualizar_dtos_tela_(ByVal datos As Ent_Producto) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()
            adaptador.UpdateCommand = New MySqlCommand("update productos  set 
                                                                            id_MPrima= @id_MPrima,
                                                                            CodMPrima=@CodMPrima,
                                                                            disenio=@disenio,
                                                                            color=@color;
                                                                            peso=@peso,
                                                                            metraje=@metraje,
                                                                            Ancho=@Ancho,
                                                                            fkcategoria=@fkcategoria,
                                                                            fksubcategoria=@fksubcategoria,
                                                                            stockmin=@stockmin", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@id_MPrima", MySqlDbType.Int16, 11).Value = datos.id_MPrima
            adaptador.UpdateCommand.Parameters.Add("@CodMPrima", MySqlDbType.VarChar, 45).Value = datos.CodMPrima
            adaptador.UpdateCommand.Parameters.Add("@disenio", MySqlDbType.VarChar, 45).Value = datos.Color
            adaptador.UpdateCommand.Parameters.Add("@color", MySqlDbType.VarChar, 45).Value = datos.Color
            adaptador.UpdateCommand.Parameters.Add("@peso", MySqlDbType.Int16, 45).Value = datos.Peso
            adaptador.UpdateCommand.Parameters.Add("@metraje", MySqlDbType.Int16, 45).Value = datos.Metraje
            adaptador.UpdateCommand.Parameters.Add("@Ancho", MySqlDbType.Int16, 45).Value = datos.Ancho
            adaptador.UpdateCommand.Parameters.Add("@fkcategoria", MySqlDbType.Int16, 45).Value = datos.Fksubcategoria
            adaptador.UpdateCommand.Parameters.Add("@fkSubcategoria", MySqlDbType.Int16, 45).Value = datos.Fksubcategoria
            adaptador.UpdateCommand.Parameters.Add("@stockmin", MySqlDbType.Int16, 45).Value = datos.Stock


            conectar._conexion.Open()
            adaptador.UpdateCommand.Connection = conectar._conexion
            adaptador.UpdateCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(String.Format("Error al Actualizar los Datos {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function

    'eliminar datos
    Public Function Eliminar_dtos_tela(ByVal datos As Ent_Producto) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from productos where CodMPrima=@CodMPrima", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@CodMPrima", MySqlDbType.Int16, 11).Value = datos.CodMPrima
            conectar._conexion.Open()
            adaptador.DeleteCommand.Connection = conectar._conexion
            adaptador.DeleteCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(String.Format("Error al elimiar el Dato {0}", ex), MsgBoxStyle.Exclamation, "Datos No Ingresador")
            estado = False
        Finally
            conectar.Cerrar()
        End Try
        Return estado
    End Function





















    'consulta Tela para combobox 
    Public comboProducto As New DataTable
    Public Sub ComboPovedor()

        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select N_Almacen from provedor", conectar._conexion)
            adaptador.Fill(comboProducto)
            ' dtvt.Table = combote.Tables(0)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub




    Public gridviw As New DataTable
    Public r As New DataView
    Public Sub GribView()
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select id_Detalle_Entrada , idtelaEntrada,peso,metraje from  detalle_entrada", conectar._conexion)
            adaptador.Fill(gridviw)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            estado = False
        Finally
            conectar.Cerrar()
        End Try

    End Sub

End Class
