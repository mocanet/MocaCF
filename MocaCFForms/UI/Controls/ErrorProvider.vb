
Imports System.Windows.Forms

Namespace Win

    Public Class ErrorProvider

        Private _errorSet As Dictionary(Of Control, String) = New Dictionary(Of Control, String)()

        Public Sub SetError(ByVal control As Control, ByVal message As String)
            _errorSet.Add(control, message)
        End Sub

        Public Function GetError(ByVal control As Control) As String
            Return _errorSet(control)
        End Function

        Public Sub Clear()
        End Sub

    End Class

End Namespace
