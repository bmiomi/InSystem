Public Class Ent_Categoria
    Private _idcategoria As Integer
    Private _nombrecategoria As String

    Public Property Idcategoria As Integer
        Get
            Return _idcategoria
        End Get
        Set(value As Integer)
            _idcategoria = value
        End Set
    End Property

    Public Property Nombrecategoria As String
        Get
            Return _nombrecategoria
        End Get
        Set(value As String)
            _nombrecategoria = value
        End Set
    End Property


End Class