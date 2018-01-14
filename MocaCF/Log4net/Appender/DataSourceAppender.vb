
Imports System.Reflection
Imports Moca.Util

Namespace Log4net.Appender

    Public Class DataSourceAppender
        Inherits Global.log4net.Appender.AppenderSkeleton

        Public Property TableAdapterType() As String
            Get
                Return _tableAdapterType
            End Get
            Set(ByVal value As String)
                _tableAdapterType = value
            End Set
        End Property
        Private _tableAdapterType As String

        Public Sub AddParameter(ByVal parameter As DataSourceAppenderParameter)
            _Parameter.Add(parameter)
        End Sub

        Private _Parameter As ArrayList

        Protected Overloads Overrides Sub Append(ByVal loggingEvent As Global.log4net.Core.LoggingEvent)
            Dim ta As System.ComponentModel.Component
            Dim typ As Type

            typ = Assembly.GetExecutingAssembly().GetType(TableAdapterType)
            ta = ClassUtil.NewInstance(typ)

            Dim values As New ArrayList(_Parameter.Count)
            For Each param As DataSourceAppenderParameter In _Parameter
                Dim value As Object
                value = param.Layout.Format(loggingEvent)
                values.Add(value)
            Next
            Dim method As MethodInfo
            method = ta.GetType().GetMethod("Insert", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public)
            Try
                method.Invoke(ta, values.ToArray())
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)
            End Try
        End Sub

        Public Sub New()
            _Parameter = New ArrayList
        End Sub

    End Class

End Namespace
