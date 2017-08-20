Public Class ErrorViewModel
    Public Property RequestId() As String
        Get
            Return m_RequestId
        End Get
        Set
            m_RequestId = Value
        End Set
    End Property
    Private m_RequestId As String

    Public Function ShowRequestId() As Boolean
        Return Not String.IsNullOrEmpty(RequestId)
    End Function
End Class