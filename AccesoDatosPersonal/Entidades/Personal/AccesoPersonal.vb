Public Class AccesoPersonal

    Public _CI As String
    Public _Nombre As String
    Public _Apellido As String
    Public _Celular As String
    Public _Convencional As String
    Public _Sexo As Char
    Public _Direccion As String
    Private _cargo As String

    Public Property CI As String
        Get
            Return _CI
        End Get
        Set(value As String)
            _CI = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _Apellido
        End Get
        Set(value As String)
            _Apellido = value
        End Set
    End Property

    Public Property Celular As String
        Get
            Return _Celular
        End Get
        Set(value As String)
            _Celular = value
        End Set
    End Property

    Public Property Convencional As String
        Get
            Return _Convencional
        End Get
        Set(value As String)
            _Convencional = value
        End Set
    End Property

    Public Property Sexo As Char
        Get
            Return _Sexo
        End Get
        Set(value As Char)
            _Sexo = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Cargo As String
        Get
            Return _cargo
        End Get
        Set(value As String)
            _cargo = value
        End Set
    End Property
End Class
