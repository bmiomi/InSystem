Public Class Ent_SubCategoria

    Private _idSubcategorias As Integer
    Private _nombres As String
    Private _Descripcion As String
    Private _fkCategoria As String

    Public Property IdSubcategorias As Integer
        Get
            Return _idSubcategorias
        End Get
        Set(value As Integer)
            _idSubcategorias = value
        End Set
    End Property

    Public Property Nombres As String
        Get
            Return _nombres
        End Get
        Set(value As String)
            _nombres = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property FkCategoria As String
        Get
            Return _fkCategoria
        End Get
        Set(value As String)
            _fkCategoria = value
        End Set
    End Property
End Class
