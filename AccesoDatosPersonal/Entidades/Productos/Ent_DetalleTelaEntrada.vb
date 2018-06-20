Public Class DetalleTelaEntrada
    Private _ID_DEtalleEntrada As Int16
    Private _Peso As String
    Private _Metraje As String
    Private _CantidadUnitaria As Int16
    Private _IDTelaEntrada As Int16

    Public Property ID_DEtalleEntrada As Short
        Get
            Return _ID_DEtalleEntrada
        End Get
        Set(value As Short)
            _ID_DEtalleEntrada = value
        End Set
    End Property

    Public Property Peso As String
        Get
            Return _Peso
        End Get
        Set(value As String)
            _Peso = value
        End Set
    End Property

    Public Property Metraje As String
        Get
            Return _Metraje
        End Get
        Set(value As String)
            _Metraje = value
        End Set
    End Property

    Public Property CantidadUnitaria As Short
        Get
            Return _CantidadUnitaria
        End Get
        Set(value As Short)
            _CantidadUnitaria = value
        End Set
    End Property

    Public Property IDTelaEntrada As Short
        Get
            Return _IDTelaEntrada
        End Get
        Set(value As Short)
            _IDTelaEntrada = value
        End Set
    End Property

End Class
