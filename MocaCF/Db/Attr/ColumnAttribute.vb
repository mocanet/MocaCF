
Namespace Db.Attr

    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False)> _
    Public Class ColumnAttribute
        Inherits Attribute

        Public Sub New(ByVal columnName As String)
            _columnName = columnName
        End Sub

        Public ReadOnly Property ColumnName() As String
            Get
                Return _columnName
            End Get
        End Property
        Private _columnName As String

    End Class

End Namespace
