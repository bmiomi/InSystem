Imports MySql.Data.MySqlClient
Imports Conexion_Acceso

Public Class ViewPersonal

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter
    Private conectar As New BD_Conexion


    Public Dsperso As New DataSet
    Public dvperso As New DataView

    Public Sub DatosGridViewPersonal()

        Dim estado = True

        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("SELECT * FROM personal", conectar._conexion)
            adaptador.Fill(Dsperso, "personal")
            dvperso.Table = Dsperso.Tables(0)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
                adaptador.SelectCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                estado = False
            Finally
                conectar.Cerrar()
            End Try


        If dvperso.Table.Rows.Count <= 0 Then
            MsgBox("NO AHY REGISTROS EN LA BASE DE DATOS.", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub

    ''' obtener atrabes del data set el nombre de la tabla personal

    Public xtsa As MySqlDataReader

    Function consulta(consultass As String)
        Dim estado As Boolean = False

        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("select CI from personal where CI='" & consultass & "'", conectar._conexion)
        conectar._conexion.Open()
        xtsa = adaptador.SelectCommand.ExecuteReader
        If xtsa.Read() Then
            estado = True
        End If
        xtsa.Close()

        Return estado
    End Function

    Public tsa As MySqlDataReader

    Function _consulta(consultass As String)


        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("select Nombre,Apellido,direccion from personal where CI='" & consultass & "'", conectar._conexion)
        conectar._conexion.Open()
        tsa = adaptador.SelectCommand.ExecuteReader

        Dim valor = tsa

        Return valor
    End Function





    ' es responsable de gestionar de forma eficiente las conexiones a la base de datos,
    'abriéndolas y cerrándolas según sea necesario. El adaptador de datos se crea instanciando un objeto
    'de la clase MySqlDataAdapter. El objeto MySqlDataAdapter tiene dos métodos principales: Fill que lee
    'datos en el conjunto de datos y Update, que escribe datos del conjunto de datos en la base de datos. 





    Public _kardex As New DataTable

    Public Sub Kardex()
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from kardex", conectar._conexion)
            adaptador.Fill(_kardex)
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


    Public _prokardex As New DataTable

    Public Sub productardex()
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select DISTINCT fkproducto from kardex", conectar._conexion)
            adaptador.Fill(_prokardex)
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



    Public _Mercaderia As New DataTable

    Public Sub Mercaderia()
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select  * from Mercaderia", conectar._conexion)
            adaptador.Fill(_Mercaderia)
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
