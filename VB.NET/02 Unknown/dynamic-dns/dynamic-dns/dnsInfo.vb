Public Class dnsInfo


    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property


    Private _updateUrl As String
    Public Property UpdateURL() As String
        Get
            Return _updateUrl
        End Get
        Set(ByVal value As String)
            _updateUrl = value
        End Set
    End Property



End Class
