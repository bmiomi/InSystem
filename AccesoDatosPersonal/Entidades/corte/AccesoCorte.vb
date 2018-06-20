Public Class AccesoCorte
    Private _CodigoCorte As String
    Private _ModeloPrenda As Integer
    Private _fkCodTendido As String
    Private _C_uni_prendas As Integer


    Public Property CodigoCorte As String
        Get
            Return _CodigoCorte
        End Get
        Set(value As String)
            _CodigoCorte = value
        End Set
    End Property

    Public Property ModeloPrenda As Integer
        Get
            Return _ModeloPrenda
        End Get
        Set(value As Integer)
            _ModeloPrenda = value
        End Set
    End Property

    Public Property FkCodTendido As String
        Get
            Return _fkCodTendido
        End Get
        Set(value As String)
            _fkCodTendido = value
        End Set
    End Property

    Public Property C_uni_prendas As Integer
        Get
            Return _C_uni_prendas
        End Get
        Set(value As Integer)
            _C_uni_prendas = value
        End Set
    End Property
End Class
