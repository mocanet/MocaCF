
Namespace Win

    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False)> _
    Public Class DisplayNameAttribute
        Inherits Attribute

        Public Sub New(ByVal displayName As String)
            _displayName = displayName
        End Sub

        Public ReadOnly Property DisplayName() As String
            Get
                Return _displayName
            End Get
        End Property
        Private _displayName As String

    End Class

End Namespace
