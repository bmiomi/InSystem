Public Class EntInsumo
    Private _idinsumo As Int16
    Private _codInsumo As String
    Private _fkcategoria As String
    Private _fksubcategoria As String
    Private _descripcion As String

    Public Property CodInsumo As String
        Get
            Return _codInsumo
        End Get
        Set(value As String)
            _codInsumo = value
        End Set
    End Property

    Public Property Fkcategoria As String
        Get
            Return _fkcategoria
        End Get
        Set(value As String)
            _fkcategoria = value
        End Set
    End Property

    Public Property Fksubcategoria As String
        Get
            Return _fksubcategoria
        End Get
        Set(value As String)
            _fksubcategoria = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Idinsumo As Short
        Get
            Return _idinsumo
        End Get
        Set(value As Short)
            _idinsumo = value
        End Set
    End Property
End Class
