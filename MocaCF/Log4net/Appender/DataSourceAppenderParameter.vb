
Imports log4net.Layout

Namespace Log4net.Appender

    Public Class DataSourceAppenderParameter

        Public Property ParameterName() As String
            Get
                Return _ParameterName
            End Get
            Set(ByVal value As String)
                _ParameterName = value
            End Set
        End Property
        Private _ParameterName As String

        Public Property Layout() As IRawLayout
            Get
                Return _Layout
            End Get
            Set(ByVal value As IRawLayout)
                _Layout = value
            End Set
        End Property
        Private _Layout As IRawLayout

    End Class

End Namespace
