
Public Class ThreadStatus

    Private cancelled As Boolean

    Private syncObj As Object = New Object()

    Public Sub Cancel()
        SyncLock syncObj
            cancelled = True
        End SyncLock
    End Sub

    Public ReadOnly Property IsCancelPending() As Boolean
        Get
            SyncLock syncObj
                Return cancelled
            End SyncLock
        End Get
    End Property

End Class
