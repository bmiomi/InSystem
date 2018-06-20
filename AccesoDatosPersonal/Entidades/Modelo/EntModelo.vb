Public Class EntModelo

    Private _idmodelo As Int16
    Private _nombre As String

    Public Property Idmodelo As Short
        Get
            Return _idmodelo
        End Get
        Set(value As Short)
            _idmodelo = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
End Class
