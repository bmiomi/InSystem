Public Class EntidadEntrada

    Private _movimiento As String

    Private _precioCompra1 As Integer
    Private _fkproducto1 As String
    Private _fecha1 As Date
    Private _concepto1 As String
    Private _usuario1 As String
    Private _cantidad As Integer
    Private _proveedor1 As String

    Public Property PrecioCompra As Integer
        Get
            Return _precioCompra1
        End Get
        Set(value As Integer)
            _precioCompra1 = value
        End Set
    End Property

    Public Property Fkproducto As String
        Get
            Return _fkproducto1
        End Get
        Set(value As String)
            _fkproducto1 = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha1
        End Get
        Set(value As Date)
            _fecha1 = value
        End Set
    End Property

    Public Property Concepto As String
        Get
            Return _concepto1
        End Get
        Set(value As String)
            _concepto1 = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario1
        End Get
        Set(value As String)
            _usuario1 = value
        End Set
    End Property

    Public Property cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property Proveedor As String
        Get
            Return _proveedor1
        End Get
        Set(value As String)
            _proveedor1 = value
        End Set
    End Property

    Public Property Movimiento As String
        Get
            Return _movimiento
        End Get
        Set(value As String)
            _movimiento = value
        End Set
    End Property
End Class
