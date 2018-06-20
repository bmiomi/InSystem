Public Class AccesoIngresoTela
    Private _IdTelaentrada As Int16
    Private _FkTela As String
    Private _FechaIngreso As Date
    Private _Cantidad_Entrante As Decimal

    Public Property IdTelaentrada As Short
        Get
            Return _IdTelaentrada
        End Get
        Set(value As Short)
            _IdTelaentrada = value
        End Set
    End Property

    Public Property FkTela As String
        Get
            Return _FkTela
        End Get
        Set(value As String)
            _FkTela = value
        End Set
    End Property

    Public Property FechaIngreso As Date
        Get
            Return _FechaIngreso
        End Get
        Set(value As Date)
            _FechaIngreso = value
        End Set
    End Property

    Public Property Cantidad_Entrante As Decimal
        Get
            Return _Cantidad_Entrante
        End Get
        Set(value As Decimal)
            _Cantidad_Entrante = value
        End Set
    End Property
End Class
