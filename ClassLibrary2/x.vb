
Public Class X

    Public Shared _x As String
    Private Shared _y1 As String

    Public Property Y As String
        Get
            Return _y1
        End Get
        Set(value As String)
            _y1 = value
        End Set
    End Property

    Public Property X1 As String
        Get
            Return _x
        End Get
        Set(value As String)
            _x = value
        End Set
    End Property
End Class
