
Namespace Win

    Public Class ProgressWindowEventArgs
        Inherits EventArgs

        Private _progress As ProgressWindow
        Private _args As List(Of Object)
        Private _Result As Object

        Public Sub New(ByVal progress As ProgressWindow, ByVal args As IList(Of Object))
            _progress = progress
            _args = args
        End Sub

        Public ReadOnly Property Arguments() As IList(Of Object)
            Get
                Return _args
            End Get
        End Property

        Public ReadOnly Property Progress() As ProgressWindow
            Get
                Return _progress
            End Get
        End Property

        'Public ReadOnly Property IsCancel() As Boolean
        '    Get
        '        Return _progress.IsCancel
        '    End Get
        'End Property

        Public WriteOnly Property Message() As String
            Set(ByVal value As String)
                _progress.Message = value
            End Set
        End Property

        Public Property Result() As Object
            Get
                Return _Result
            End Get
            Set(ByVal value As Object)
                _Result = value
            End Set
        End Property

    End Class

End Namespace
