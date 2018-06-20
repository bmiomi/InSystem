Public Class Ent_Producto

    Private _id_MPrima As String
    Private _CodMPrima As String
    Private _disenio As String
    Private _color As String
    Private _peso As Integer
    Private _metraje As Integer
    Private _ancho As Decimal
    Private _fkCategoria As Integer
    Private _fksubcategoria As Integer
    Private _stock As Integer


    Public Property id_MPrima As String
        Get
            Return _id_MPrima
        End Get
        Set(value As String)
            _id_MPrima = value
        End Set
    End Property
    Public Property CodMPrima As String
        Get
            Return _CodMPrima
        End Get
        Set(value As String)
            _CodMPrima = value
        End Set
    End Property


    Public Property FkCategoria As Integer
        Get
            Return _fkCategoria
        End Get
        Set(value As Integer)
            _fkCategoria = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _color
        End Get
        Set(value As String)
            _color = value
        End Set
    End Property

    Public Property Peso As Integer
        Get
            Return _peso
        End Get
        Set(value As Integer)
            _peso = value
        End Set
    End Property

    Public Property Metraje As Integer
        Get
            Return _metraje
        End Get
        Set(value As Integer)
            _metraje = value
        End Set
    End Property

    Public Property Ancho As Decimal
        Get
            Return _ancho
        End Get
        Set(value As Decimal)
            _ancho = value
        End Set
    End Property

    Public Property Fksubcategoria As Integer
        Get
            Return _fksubcategoria
        End Get
        Set(value As Integer)
            _fksubcategoria = value
        End Set
    End Property

    Public Property Stock As Integer
        Get
            Return _stock
        End Get
        Set(value As Integer)
            _stock = value
        End Set
    End Property

    Public Property Disenio As String
        Get
            Return _disenio
        End Get
        Set(value As String)
            _disenio = value
        End Set
    End Property

End Class
