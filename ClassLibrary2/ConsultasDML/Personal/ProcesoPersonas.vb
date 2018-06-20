Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class ProcesoPersonas

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion

    'guardar datos de personal
        Public Function Ingresar_dtos_personal_(ByVal datos As AccesoPersonal) As Boolean
        Dim estado As Boolean = True

        Try

            conectar.Conex_Global()
            adaptador.InsertCommand = New MySqlCommand("Insert into personal (CI,Nombre,Apellido,Celular,Convencional,Sexo,Direccion)
                                                        values(@CI,@Nombre,@Apellido,@Celular,@Convencional,@Sexo,@Direccion)", conectar._conexion)

            adaptador.InsertCommand.Parameters.Add("@CI", MySqlDbType.VarChar, 11).Value = datos.CI
            adaptador.InsertCommand.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = datos.Nombre
            adaptador.InsertCommand.Parameters.Add("@Apellido", MySqlDbType.VarChar, 45).Value = datos.Apellido
            adaptador.InsertCommand.Parameters.Add("@Celular", MySqlDbType.VarChar, 10).Value = datos.Celular
            adaptador.InsertCommand.Parameters.Add("@Convencional", MySqlDbType.VarChar, 7).Value = datos.Convencional
            adaptador.InsertCommand.Parameters.Add("@Sexo", MySqlDbType.VarChar, 2).Value = datos.Sexo
            adaptador.InsertCommand.Parameters.Add("@Direccion", MySqlDbType.VarChar, 45).Value = datos.Direccion

            'adaptador.InsertCommand.Parameters.Add("@picture", MySqlDbType.LongBlob).Value = datos.picture
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
    Public Function Actualizar_dtos_personal_(ByVal datos As AccesoPersonal) As Boolean

        Dim estado As Boolean = True
        Try
            conectar.Conex_Global()


            adaptador.UpdateCommand = New MySqlCommand("UPDATE personal set CI=@CI,Nombre=@Nombre,Apellido=@Apellido,Celular=@Celular,Convencional=@Convencional,Sexo=@Sexo,Direccion=@Direccion where CI=@CI", conectar._conexion)

            adaptador.UpdateCommand.Parameters.Add("@CI", MySqlDbType.VarChar, 11).Value = datos.CI
            adaptador.UpdateCommand.Parameters.Add("@Nombre", MySqlDbType.VarChar, 45).Value = datos.Nombre
            adaptador.UpdateCommand.Parameters.Add("@Apellido", MySqlDbType.VarChar, 45).Value = datos.Apellido
            adaptador.UpdateCommand.Parameters.Add("@Celular", MySqlDbType.Int64, 7).Value = datos.Celular
            adaptador.UpdateCommand.Parameters.Add("@Convencional", MySqlDbType.Int64, 10).Value = datos.Convencional
            adaptador.UpdateCommand.Parameters.Add("@Sexo", MySqlDbType.VarChar, 2).Value = datos.Sexo
            adaptador.UpdateCommand.Parameters.Add("@Direccion", MySqlDbType.VarChar, 45).Value = datos.Direccion

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
    Public Function Eliminar_dtos_personal(ByVal datos As AccesoPersonal) As Boolean

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.DeleteCommand = New MySqlCommand("Delete from personal where CI=@CI", conectar._conexion)
            adaptador.DeleteCommand.Parameters.Add("@CI", MySqlDbType.Int32, 11).Value = datos.CI
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




    Dim dateread As MySqlDataReader

    'Public Function ActializarC_s_personal(ByVal CI As String, ByVal nb As String, ByVal AP As String, ByVal CB As String, ByVal CL As String, ByVal SX As String, ByVal Dir As String)
    '    Dim x As Boolean = False
    '    Dim nombre As String
    '    Dim apellido As String
    '    Dim cedula As Integer
    '    Dim direccion As String
    '    Dim convencional As Integer
    '    Dim celular As Integer
    '    Dim sexo As String

    '    Dim estado = True
    '    Try

    '        conectar.Conex_Global()
    '        adaptador.SelectCommand = New MySqlCommand("select * from personal where CI ='" & CI & "'", conectar._conexion)
    '        conectar._conexion.Open()
    '        dateread = adaptador.SelectCommand.ExecuteReader

    '        If dateread.HasRows Then

    '            While dateread.Read()
    '                cedula = dateread(0).ToString()
    '                nombre = dateread(1).ToString()
    '                apellido = dateread(2).ToString()
    '                celular = dateread(3).ToString()
    '                convencional = dateread(4).ToString()
    '                sexo = dateread(5).ToString()
    '                direccion = dateread(5).ToString()
    '            End While

    '        Else
    '            MsgBox("no se tiene registros")
    '        End If

    '        If CI = celular Then
    '        ElseIf nb = nombre Then
    '        ElseIf AP = apellido Then
    '        ElseIf CB = convencional Then
    '        ElseIf CL = celular Then
    '        ElseIf SX = sexo Then
    '        ElseIf Dir = direccion Then



    '        End If

    '    Catch ex As Exception
    '        MsgBox("error al eliminar los datos", ex.ToString)
    '        estado = False
    '    Finally
    '        conectar.Cerrar()
    '    End Try
    '    Return estado
    'End Function
End Class
