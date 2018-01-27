
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Win

    Public Class MLabel
        Inherits Control

#Region " コンストラクタ "

        Public Sub New()
            TextAlign = TextAlignment.TopLeft
            MyBase.TabStop = False
            MyBase.TabIndex = 0
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

        Public Shadows Property Enabled() As Boolean
            Get
                Return MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)
                MyBase.Enabled = value
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

        Public Shadows Property BackColor() As Color
            Get
                Return _BackColor
            End Get
            Set(ByVal value As Color)
                _BackColor = value
                If Not _BackColor.Equals(Color.Transparent) Then
                    MyBase.BackColor = value
                End If
                Invalidate()
            End Set
        End Property
        Private _BackColor As Color

        <DefaultValue(False)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Shadows ReadOnly Property TabStop() As Boolean
            Get
                Return MyBase.TabStop
            End Get
        End Property

        <DefaultValue(-1)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Shadows ReadOnly Property TabIndex() As Integer
            Get
                Return MyBase.TabIndex
            End Get
        End Property

#End Region

#Region " Overrides "

        Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaintBackground(e)
            If _BackColor.Equals(Color.Transparent) Then
                UIHelper.FillRectangle(e.Graphics, _BackColor, Me.ClientRectangle)
            End If
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim c As Color = Me.ForeColor
            If Not Me.Enabled Then
                c = Color.Gray
            End If
            Using brush As New SolidBrush(c)
                Dim border As Integer = BorderWidth * 2
                Dim rect As New Rectangle(Me.ClientRectangle.X + BorderWidth, _
                                          Me.ClientRectangle.Y + BorderWidth, _
                                          Me.ClientRectangle.Width - border, _
                                          Me.ClientRectangle.Height - border)
                UIHelper.DrawString(Text, Font, brush, e.Graphics, rect, Me.TextAlign)
                UIHelper.DrawRectangle(e.Graphics, BorderWidth, BorderColor, Me.ClientRectangle)
            End Using
            MyBase.OnPaint(e)
        End Sub

#End Region

#Region " Method "

#End Region

    End Class

End Namespace
