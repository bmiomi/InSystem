Public Class Enti_Tipo
    Private _id1 As Int16
    Private _tipo As String
    Private _fkprocto1 As String
    Private _fkinsumo1 As String


    Public Property Id As Short
        Get
            Return _id1
        End Get
        Set(value As Short)
            _id1 = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property Fkprocto As String
        Get
            Return _fkprocto1
        End Get
        Set(value As String)
            _fkprocto1 = value
        End Set
    End Property

    Public Property Fkinsumo As String
        Get
            Return _fkinsumo1
        End Get
        Set(value As String)
            _fkinsumo1 = value
        End Set
    End Property

End Class
