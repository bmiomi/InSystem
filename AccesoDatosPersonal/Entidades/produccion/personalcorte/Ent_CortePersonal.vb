Public Class Ent_CortePersonal

    Private _codMAquilado As Integer
    Private _fecha As Date
    Private _fkcodcorte As String
    Private _fkcodCI As Integer


    Public Property CodMAquilado As Integer
        Get
            Return _codMAquilado
        End Get
        Set(value As Integer)
            _codMAquilado = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Fkcodcorte As String
        Get
            Return _fkcodcorte
        End Get
        Set(value As String)
            _fkcodcorte = value
        End Set
    End Property

    Public Property FkcodCI As Integer
        Get
            Return _fkcodCI
        End Get
        Set(value As Integer)
            _fkcodCI = value
        End Set
    End Property


End Class
