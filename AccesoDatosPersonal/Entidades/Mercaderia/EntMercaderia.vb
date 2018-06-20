Public Class EntMercaderia

    Private _codmercaderia As String
    Private _Modelo As String
    Private _cantidadD As Int16
    Private _cantidadU As Int16

    Public Property Codmercaderia As String
        Get
            Return _codmercaderia
        End Get
        Set(value As String)
            _codmercaderia = value
        End Set
    End Property

    Public Property Modelo1 As String
        Get
            Return _Modelo
        End Get
        Set(value As String)
            _Modelo = value
        End Set
    End Property

    Public Property CantidadD1 As Short
        Get
            Return _cantidadD
        End Get
        Set(value As Short)
            _cantidadD = value
        End Set
    End Property

    Public Property CantidadU1 As Short
        Get
            Return _cantidadU
        End Get
        Set(value As Short)
            _cantidadU = value
        End Set
    End Property
End Class
