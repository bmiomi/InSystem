Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Public Class BD_Conexion

    'VARIABLE CADENA 
    Public cadena As String

    'VARIABLE DE CONEXION
    Public _conexion As New MySqlConnection


    'CONEXION GLOBAL 
    Public Sub Conex_Global()
        Dim estado = True
        Try
            cadena = ("server=localhost;user id=root;password=Rous;database=mns;SslMode=none;port=3306")
            _conexion = New MySqlConnection(cadena)
        Catch ex As MySqlException
            MsgBox("Error al conectar base de datos.")
            estado = False
        End Try
    End Sub

    'CERRAR CONEXION GLOBAL
    Public Sub Cerrar()
        _conexion.Close()
    End Sub








End Class
