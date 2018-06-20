Public Class Ent_Detalle

    Private _subtotal As Decimal
    Private _iva As Decimal
    Private _valorTotal As Decimal

    Public Property Subtotal As Decimal
        Get
            Return _subtotal
        End Get
        Set(value As Decimal)
            _subtotal = value
        End Set
    End Property

    Public Property Iva As Decimal
        Get
            Return _iva
        End Get
        Set(value As Decimal)
            _iva = value
        End Set
    End Property

    Public Property ValorTotal As Decimal
        Get
            Return _valorTotal
        End Get
        Set(value As Decimal)
            _valorTotal = value
        End Set
    End Property

End Class
