Public Class Ent_Compra

    Private _idcompra As Integer
    Private _fecha As Date
    Private _cantidad As Decimal
    Private _valorUnitario As Decimal

    Private _fkprovedor As String
    Private _fktipo As Integer
    Private _fkdetallecompra As String
    Private _fkproducto As String
    Private _fkinsumo As String
    Private _tipodocumento As String
    Private _numerodocumento As Int16
    Private _tipocompra As String

    Public Property Idcompra As Integer
        Get
            Return _idcompra
        End Get
        Set(value As Integer)
            _idcompra = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get
        Set(value As Decimal)
            _cantidad = value
        End Set
    End Property

    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get
        Set(value As Decimal)
            _valorUnitario = value
        End Set
    End Property

    Public Property Fkprovedor As String
        Get
            Return _fkprovedor
        End Get
        Set(value As String)
            _fkprovedor = value
        End Set
    End Property

    Public Property Fktipo As Integer
        Get
            Return _fktipo
        End Get
        Set(value As Integer)
            _fktipo = value
        End Set
    End Property

    Public Property Fkproducto As String
        Get
            Return _fkproducto
        End Get
        Set(value As String)
            _fkproducto = value
        End Set
    End Property

    Public Property Fkdetallecompra As String
        Get
            Return _fkdetallecompra
        End Get
        Set(value As String)
            _fkdetallecompra = value
        End Set
    End Property

    Public Property Fkinsumo As String
        Get
            Return _fkinsumo
        End Get
        Set(value As String)
            _fkinsumo = value
        End Set
    End Property

    Public Property Tipodocumento As String
        Get
            Return _tipodocumento
        End Get
        Set(value As String)
            _tipodocumento = value
        End Set
    End Property

    Public Property Numerodocumento As Short
        Get
            Return _numerodocumento
        End Get
        Set(value As Short)
            _numerodocumento = value
        End Set
    End Property

    Public Property Tipocompra As String
        Get
            Return _tipocompra
        End Get
        Set(value As String)
            _tipocompra = value
        End Set
    End Property
End Class
