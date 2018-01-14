
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Win

    Public Class MLabel
        Inherits Control

#Region " コンストラクタ "

        Public Sub New()
            TextAlign = TextAlignment.TopLeft
        End Sub

#End Region

#Region " Property "

        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                Invalidate()
            End Set
        End Property

        <DefaultValue(TextAlignment.TopLeft)> _
        Public Property TextAlign() As TextAlignment
            Get
                Return _TextAlign
            End Get
            Set(ByVal value As TextAlignment)
                _TextAlign = value
                Invalidate()
            End Set
        End Property
        Private _TextAlign As TextAlignment

        Public Property BorderColor() As Color
            Get
                Return _BorderColor
            End Get
            Set(ByVal value As Color)
                _BorderColor = value
                Invalidate()
            End Set
        End Property
        Private _BorderColor As Color = Color.Empty

        <DefaultValue(1)> _
        Public Property BorderWidth() As Integer
            Get
                Return _BorderWidth
            End Get
            Set(ByVal value As Integer)
                _BorderWidth = value
                Invalidate()
            End Set
        End Property
        Private _BorderWidth As Integer = 1

#End Region

#Region " Overrides "

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Using brush As New SolidBrush(Me.ForeColor)
                UIHelper.DrawString(Text, Font, brush, e.Graphics, Me.ClientRectangle, Me.TextAlign)
                UIHelper.DrawRectangle(e.Graphics, BorderWidth, BorderColor, Me.ClientRectangle)
            End Using
        End Sub

#End Region

#Region " Method "

#End Region

    End Class

End Namespace
