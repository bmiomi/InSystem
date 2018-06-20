Public Class Ent_produccion

    Private _codTendido1 As Integer
    Private _fechaTendido1 As Date
    Private _tamanio_base1 As Integer
    Private _c_capas_unitarias1 As Integer
    Private _total_unitario_mts1 As Integer
    Private _c_Rollos1 As Integer
    Private _total_mts_usados1 As Integer
    Private _c_Modelos1 As Integer

    Public Property CodTendido As Integer
        Get
            Return _codTendido1
        End Get
        Set(value As Integer)
            _codTendido1 = value
        End Set
    End Property

    Public Property FechaTendido As Date
        Get
            Return _fechaTendido1
        End Get
        Set(value As Date)
            _fechaTendido1 = value
        End Set
    End Property

    Public Property Tamanio_base As Integer
        Get
            Return _tamanio_base1
        End Get
        Set(value As Integer)
            _tamanio_base1 = value
        End Set
    End Property

    Public Property C_capas_unitarias As Integer
        Get
            Return _c_capas_unitarias1
        End Get
        Set(value As Integer)
            _c_capas_unitarias1 = value
        End Set
    End Property

    Public Property Total_unitario_mts As Integer
        Get
            Return _total_unitario_mts1
        End Get
        Set(value As Integer)
            _total_unitario_mts1 = value
        End Set
    End Property

    Public Property C_Rollos As Integer
        Get
            Return _c_Rollos1
        End Get
        Set(value As Integer)
            _c_Rollos1 = value
        End Set
    End Property

    Public Property Total_mts_usados As Integer
        Get
            Return _total_mts_usados1
        End Get
        Set(value As Integer)
            _total_mts_usados1 = value
        End Set
    End Property

    Public Property C_Modelos As Integer
        Get
            Return _c_Modelos1
        End Get
        Set(value As Integer)
            _c_Modelos1 = value
        End Set
    End Property
End Class
