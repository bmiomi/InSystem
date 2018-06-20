

Public Class AccesoProvedor
    Private _id_codProvedor As Integer
    Private _codProvedor As String
    Private _RUC As String

    Private _n_Almacen As String
    Private _convencional As Integer
    Private _celular As Integer
    Private _origen As String
    Private _direccion As String

    Public Property CodProvedor As String
        Get
            Return _codProvedor
        End Get
        Set(value As String)
            _codProvedor = value
        End Set
    End Property

    Public Property N_Almacen As String
        Get
            Return _n_Almacen
        End Get
        Set(value As String)
            _n_Almacen = value
        End Set
    End Property

    Public Property Convencional As Integer
        Get
            Return _convencional
        End Get
        Set(value As Integer)
            _convencional = value
        End Set
    End Property

    Public Property Celular As Integer
        Get
            Return _celular
        End Get
        Set(value As Integer)
            _celular = value
        End Set
    End Property

    Public Property Origen As String
        Get
            Return _origen
        End Get
        Set(value As String)
            _origen = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Property Id_codProvedor As Integer
        Get
            Return _id_codProvedor
        End Get
        Set(value As Integer)
            _id_codProvedor = value
        End Set
    End Property

    Public Property RUC As String
        Get
            Return _RUC
        End Get
        Set(value As String)
            _RUC = value
        End Set
    End Property
End Class
