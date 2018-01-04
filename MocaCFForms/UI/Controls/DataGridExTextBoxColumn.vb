
Namespace Win

    Public Class DataGridExTextBoxColumn
        Inherits DataGridExColumnBase

        Public ReadOnly Property TextBox() As TextBoxEx
            Get
                Return HostedControl
            End Get
        End Property

        Protected Overrides Function CreateHostedControl() As System.Windows.Forms.Control
            Dim txt As TextBoxEx = New TextBoxEx
            txt.BorderStyle = Windows.Forms.BorderStyle.None
            txt.Multiline = True
            txt.TextAlign = Alignment
            'txt.ReadOnly = [ReadOnly]
            Return txt
        End Function

        Protected Overrides Function GetBoundPropertyName() As String
            Return "Text"
        End Function

    End Class

End Namespace
