
Namespace Win

    Public Class ComponentVerifyContext

        Public Sub New(ByVal verify As CustomVerifyCallback, ByVal continueOnVerifyFailure As Boolean)
            _Verify = verify
            _ContinueOnVerifyFailure = continueOnVerifyFailure
        End Sub

        Public ReadOnly Property Verify() As CustomVerifyCallback
            Get
                Return _Verify
            End Get
        End Property
        Private _Verify As CustomVerifyCallback

        Public ReadOnly Property ContinueOnVerifyFailure() As Boolean
            Get
                Return _ContinueOnVerifyFailure
            End Get
        End Property
        Private _ContinueOnVerifyFailure As Boolean

    End Class

End Namespace
