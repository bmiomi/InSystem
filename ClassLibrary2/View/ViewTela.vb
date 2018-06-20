Imports Conexion_Acceso

Imports MySql.Data.MySqlClient

Public Class ViewTela

    'variable adoptada para todas las funciones de esta clase
    Private adaptador As New MySqlDataAdapter

    Private comando As MySqlCommand
    Private conectar As New BD_Conexion

    Public _KardexViewtela As New DataView
    Public _datasetKardexViewtela As New DataSet

    Public Sub KardexVTela(fkproducto As String, desde As String, asta As String)

        Dim estado = True
        Try
            conectar.Conex_Global()

            adaptador.SelectCommand = New MySqlCommand(
                "						select * from kardex where  fecha >= '" & desde & "' and fecha <= '" & asta & "' and fkproducto  = '" & fkproducto & "';", conectar._conexion)
            adaptador.Fill(_datasetKardexViewtela, "Kardex")
            _KardexViewtela.Table = _datasetKardexViewtela.Tables(0)
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

    ''Consultas para el formulario Compras 

    Public _codIns As New DataTable

    Public Sub ComboInsumo()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from  insucatesub ", conectar._conexion)
            adaptador.Fill(_codIns)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    '' consulta para el formumario de compras
    Public comboproductosNoCompra As New DataTable
    Public Sub ProductosnoexitenteCompra()

        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("Select * from productosnoexistentescompra", conectar._conexion)
            adaptador.Fill(comboproductosNoCompra)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try

    End Sub






    Public Function Insumoid() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()

        adaptador.SelectCommand = New MySqlCommand("SELECT MAX(idinsumo) FROM  insumos", conectar._conexion)

        conectar._conexion.Open()

        adaptador.SelectCommand.Connection = conectar._conexion

        lector = adaptador.SelectCommand.ExecuteReader
        lector.Read()

        If lector.IsDBNull(0) Then

            MsgBox("Se le Proporcinara un Codigo de registro al ser el primer ingreso ", MsgBoxStyle.Information, "Informacion")

        Else
            resultado = lector.GetString(0)

        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function

    ''pertenece al formulario corte
    Public __Modelo As New DataTable
    Public Sub _Modelo()

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select nombre from modelo ", conectar._conexion)
            adaptador.Fill(__Modelo)
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
    'pertenece al formulario producto
    Public ReadOnly tela As New DataTable
    Public Sub Rollos()
        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select * from productos ", conectar._conexion)
            adaptador.Fill(tela)
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




    Public unsumi As New DataTable

    Public Sub Insumo()

        Dim estado = True
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("
                select * from insu_", conectar._conexion)
            adaptador.Fill(unsumi)
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


    Public Function CodigoTendido() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("SELECT MAX( id_MPrima ) FROM Productos ")
        conectar._conexion.Open()
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        If lector.Read Then
            resultado = CInt(Val(lector(0).ToString))
        Else
            MsgBox("No se a encontrado registros")
        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function



    'Codigo  produccion
    Public Function CodigoProduccion() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand(" SELECT MAX(codTendido) FROM produccion ")
        conectar._conexion.Open()
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        If lector.Read Then
            resultado = CInt(Val(lector(0).ToString))
        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function



    'Codigo corte
    Public Function CodigoCorte() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand(" SELECT MAX(codigocorte) FROM corte ")
        conectar._conexion.Open()
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        If lector.Read Then
            resultado = CInt(Val(lector(0).ToString))
        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function

    'Codigo Maquilado
    Public Function CodigoMaquilado() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand(" SELECT MAX(CodMaquilado) FROM detallecortepersonal ")
        conectar._conexion.Open()
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        If lector.Read Then
            resultado = CInt(Val(lector(0).ToString))
        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function


    'Codigo Provedor
    Public Function Codigoprovedor() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        adaptador.SelectCommand = New MySqlCommand("SELECT MAX(id_Provedor) FROM  provedor ", conectar._conexion)
        conectar._conexion.Open()
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        If lector.Read Then
            resultado = CInt(Val(lector(0).ToString))
        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function


    Public _pruevas As New DataTable

    Public Sub Prueva()

        '   Dim resultado As Integer
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("SELECT * FROM  provedor ", conectar._conexion)
            adaptador.Fill(_pruevas)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try

        If _pruevas.Rows.Count <= 0 Then
            MsgBox("NO AHY REGISTROS EN LA BASE DE DATOS.", MsgBoxStyle.Information, "Informacion")
        End If

    End Sub


    Public Function Categoria() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()

        adaptador.SelectCommand = New MySqlCommand("SELECT MAX(id_Categoria) FROM  Categoria", conectar._conexion)

        conectar._conexion.Open()

        adaptador.SelectCommand.Connection = conectar._conexion

        lector = adaptador.SelectCommand.ExecuteReader
        lector.Read()

        If lector.IsDBNull(0) Then

            MsgBox("No Se ha ingresado Datos en Categoria")
        Else
            resultado = lector.GetString(0) 

        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function

    Public Function SubCAtegoria() As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        conectar._conexion.Open()
        adaptador.SelectCommand = New MySqlCommand("SELECT MAX(id_subCategoria) FROM  subCategoria", conectar._conexion)
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        lector.Read()

        If lector.IsDBNull(0) Then

            MsgBox("No Se ha ingresado Datos en SubCategoria")
        Else
            resultado = lector.GetString(0)

        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function

    Public Function retrnar(ByVal valor As String) As Integer
        Dim resultado As Integer
        Dim lector As MySqlDataReader
        conectar.Conex_Global()
        conectar._conexion.Open()
        adaptador.SelectCommand = New MySqlCommand("SELECT id_categoria FROM  Categoria where NombreCategoria='" & valor & "'", conectar._conexion)
        adaptador.SelectCommand.Connection = conectar._conexion
        lector = adaptador.SelectCommand.ExecuteReader
        lector.Read()

        If lector.IsDBNull(0) Then

            MsgBox("No Se ha ingresado Datos en Categoria")
        Else
            resultado = lector.GetString(0)

        End If
        lector.Close()
        conectar._conexion.Close()
        Return resultado
    End Function

    ''select NombreCategoria from Categoria

    Public combocate As New DataTable

    Public Sub ComboCategoria()
        Try
            conectar.Conex_Global()
            '
            adaptador.SelectCommand = New MySqlCommand("Select  NombreCategoria from Categoria where NombreCategoria =" + "'Tela'", conectar._conexion)
            adaptador.Fill(combocate)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    Public combocate1 As New DataTable

    Public Sub ComboCategoria1()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select NombreCategoria from Categoria", conectar._conexion)
            adaptador.Fill(combocate1)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub






    Public _combocateinsumo As New DataTable

    Public Sub ComboCategoriainsumo()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select NombreCategoria from Categoria where NombreCategoria <>" + "'Tela'", conectar._conexion)
            adaptador.Fill(_combocateinsumo)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try

        If _combocateinsumo.Rows Is Nothing Then
            MsgBox("Actual mente su Tabla se encuentra Vacias.", "Informacion", MsgBoxStyle.Information)
        End If

    End Sub



    Public comboSubcate As New DataTable
    Public Sub ComboSubCategoria(valor As String)

        Try
            conectar.Conex_Global()
            Dim sql = "select nombre  from categoria join subcategoria on id_categoria=fkcategoria  where NombreCategoria='" & valor & "'"

            adaptador.SelectCommand = New MySqlCommand(sql, conectar._conexion)
            adaptador.Fill(comboSubcate)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    Public comboSubcateinsum As New DataTable
    Public Sub ComboSubCategoria_(valor As String)

        Try
            conectar.Conex_Global()
            Dim sql = "select nombre  from categoria join subcategoria on id_categoria=fkcategoria  where NombreCategoria='" & valor & "'"

            adaptador.SelectCommand = New MySqlCommand(sql, conectar._conexion)
            adaptador.Fill(comboSubcateinsum)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    Public viiie As New DataTable
    Public Sub Viewsql()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from Itelas", conectar._conexion)
            adaptador.Fill(viiie)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    Public viii As New DataTable
    Public Sub _Viewsql()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select fecha,movimiento,fkinsumo as codInsumo,cantidad,PrecioCompra  from  inventarioinsumo;
 ", conectar._conexion)
            adaptador.Fill(viii)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    'retorna el idcategoria perteneciente a la tabla categoria 
    'para ser ingresado en la tabla producto 
    Public Function IdCategoria()
        Dim variable As Integer
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand =
                New MySqlCommand(" select max(id_categoria) from categoria", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar)

        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()
        Return variable
    End Function


    Public Function IdProvedor(ByVal fkProvedor As String)
        Dim variable As Integer
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select id_Provedor from provedor where N_Almacen='" & fkProvedor & "'", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()

        Return variable
    End Function

    Public comboproduccion As New DataTable

    Public Sub Produccion()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select CodTendido from produccion", conectar._conexion)
            adaptador.Fill(comboproduccion)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    Public modelotable As New DataTable
    Public Sub modelolis()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from modelo ", conectar._conexion)
            adaptador.Fill(modelotable)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub



    Public grillacorte As New DataTable

    Public Sub Produccion(fkproduccion As String)
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select CodigoCorte,nombre,C_uni_prendas
 from corte
join produccion
on CodTendido=fkCodTendido
join modelo ON
idmodelo=fkModelo 
LEFT JOIN detallecortepersonal
on codigocorte=fkcodcorte where CodTendido='" & fkproduccion & "' and  fkCodCorte is  null", conectar._conexion)
            adaptador.Fill(grillacorte)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    Public movimientos As New DataTable

    Public Sub _movimientos()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select N_Almacen from provedor", conectar._conexion)
            adaptador.Fill(combocompra)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    Public combocompra As New DataTable

    Public Sub CombocompraPRovedor()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select N_Almacen from provedor", conectar._conexion)
            adaptador.Fill(combocompra)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub





    Public comboinsumos As New DataTable

    Public Sub Insumos()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select codInsumo,fkProducto from insumos
left JOIN compra
  on codinsumo=fkinsumo
where fkinsumo is null ", conectar._conexion)
            adaptador.Fill(comboinsumos)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub



    Public compracombocabecera As New DataTable

    Public Sub Combocompracabecera(fkprovedor As String)
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from provedor where N_Almacen='" & fkprovedor & "'", conectar._conexion)
            adaptador.Fill(compracombocabecera)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub

    Public compracombo As New DataTable

    Public Sub Combocompras(dato As String)
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select CodMPrima,NombreCategoria,Nombre from productos
join categoria
  on id_Categoria=fkCategoria
JOIN subcategoria
   on id_SubCategoria=fksubca 
where CodMPrima='" & dato & "'", conectar._conexion)

            adaptador.Fill(compracombo)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


       Public compracomboinsumo As New DataTable

    Public Sub _Combocomprasinsumo(dato As String)
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select codInsumo,NombreCategoria,Nombre from insumos
join categoria
  on id_Categoria=fkCategoria
JOIN subcategoria
   on id_SubCategoria=fksubcategoria 
where codInsumo='" & dato & "'", conectar._conexion)

            adaptador.Fill(compracomboinsumo)
            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub



    Public Function Iddetalle_compra()
        Dim variable As Integer
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select max(IDDETALLE) from detallecompra", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar)

        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()
        Return variable
    End Function


    Public Function codProvedor(ByVal fkProvedor As String)
        Dim variable As String = Nothing
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select Cod_Provedor from provedor where N_Almacen = '" & fkProvedor & "'", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToString(adaptador.SelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()

        Return variable
    End Function

    Public Function idtipo(ByVal fkProvedor As String)
        Dim variable As Integer = Nothing
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select id from tipo where tipo = '" & fkProvedor & "'", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToInt16(adaptador.SelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()

        Return variable
    End Function


    Public Function combcategoria(ByVal fkcategoria As String)
        Dim variable As String = Nothing
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select id_Categoria from categoria where NombreCategoria = '" & fkcategoria & "'", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToString(adaptador.SelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()

        Return variable
    End Function

    Public Function combsubcategoria(ByVal fksubcategoria As String)
        Dim variable As String = Nothing
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select id_SubCategoria from subcategoria where Nombre = '" & fksubcategoria & "'", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToString(adaptador.SelectCommand.ExecuteScalar)
        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()

        Return variable
    End Function




    Public Function Idmodelo()
        Dim variable As Integer
        Try

            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand(" select max(idmodelo) from modelo", conectar._conexion)
            conectar._conexion.Open()
            variable = Convert.ToInt32(adaptador.SelectCommand.ExecuteScalar)

        Catch ex As Exception
            MsgBox("No se a encontrado resultados ")

        End Try
        conectar._conexion.Close()
        Return variable
    End Function





    Public codproductos As New DataTable

    Public Sub Comboprod()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from entradabodegaProducto ", conectar._conexion)
            adaptador.Fill(codproductos)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub



    Public codIns As New DataTable

    Public Sub comboInsu()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from EntradaBodegaInsumo ", conectar._conexion)
            adaptador.Fill(codIns)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub



    Public salidaProductos As New DataTable

    Public Sub SalidaMovimientoProducto()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from salidabodegaProducto ", conectar._conexion)
            adaptador.Fill(salidaProductos)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub


    Public SalidaInsumos As New DataTable

    Public Sub SalidaMovimientoInsumos()
        Try
            conectar.Conex_Global()
            adaptador.SelectCommand = New MySqlCommand("select * from SalidaBodegaInsumo ", conectar._conexion)
            adaptador.Fill(salidainsumos)

            conectar._conexion.Open()
            adaptador.SelectCommand.Connection = conectar._conexion
            adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conectar.Cerrar()
        End Try
    End Sub
End Class
