
Public Class EnLogin

    Private _usuario1 As String
    Private _password1 As String
    Private _Cargo As String



    Public Property Usuario As String
        Get
            Return _usuario1
        End Get
        Set(value As String)
            _usuario1 = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password1
        End Get
        Set(value As String)
            _password1 = value
        End Set
    End Property

    Public Property Cargo As String
        Get
            Return _Cargo
        End Get
        Set(value As String)
            _Cargo = value
        End Set
    End Property
End Class
