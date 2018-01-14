
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Win

    Public Class AlertMessage
        Inherits Control

#Region " Declare"

        ''' <summary>ウィンドウアニメーション</summary>
        Private _animateWindow As AnimateWindow

        Private _DefaultMessageBackColor As Color = Color.FromArgb(95, 187, 242)
        Private _DefaultMessageForeColor As Color = Color.FromArgb(51, 51, 51)
        Private _ErrorBackColor As Color = Color.FromArgb(220, 60, 0)
        Private _ErrorForeColor As Color = Color.White
        Private _SuccessBackColor As Color = Color.FromArgb(70, 136, 71)
        Private _SuccessForeColor As Color = Color.White
        Private _WarnBackColor As Color = Color.FromArgb(255, 211, 92)
        Private _WarnForeColor As Color = Color.FromArgb(51, 51, 51)
        Private _DirectionType As AnimateWindow.DirectionType = AnimateWindow.DirectionType.Top
        Private _AutoCloseSecond As Integer = 4
        Private _FullClickClose As Boolean = True
        Private _font As Font = MyBase.Font
        Private _text As String
        Private _format As New StringFormat()

        Friend WithEvents Timer1 As System.Windows.Forms.Timer

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            Me.TabStop = False

            _format.Alignment = StringAlignment.Center
            _format.LineAlignment = StringAlignment.Center

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            Clear()

            _animateWindow = New AnimateWindow
        End Sub

        Private Sub InitializeComponent()
            Me.Timer1 = New System.Windows.Forms.Timer
            Me.SuspendLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' デフォルトの背景色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultMessageBackColor() As Color
            Get
                Return _DefaultMessageBackColor
            End Get
            Set(ByVal value As Color)
                _DefaultMessageBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' デフォルトの文字色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DefaultMessageForeColor() As Color
            Get
                Return _DefaultMessageForeColor
            End Get
            Set(ByVal value As Color)
                _DefaultMessageForeColor = value
            End Set
        End Property

        ''' <summary>
        ''' エラー時の背景色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ErrorBackColor() As Color
            Get
                Return _ErrorBackColor
            End Get
            Set(ByVal value As Color)
                _ErrorBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' エラー時の文字色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ErrorForeColor() As Color
            Get
                Return _ErrorForeColor
            End Get
            Set(ByVal value As Color)
                _ErrorForeColor = value
            End Set
        End Property

        ''' <summary>
        ''' 正常時の背景色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuccessBackColor() As Color
            Get
                Return _SuccessBackColor
            End Get
            Set(ByVal value As Color)
                _SuccessBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' 正常時の文字色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SuccessForeColor() As Color
            Get
                Return _SuccessForeColor
            End Get
            Set(ByVal value As Color)
                _SuccessForeColor = value
            End Set
        End Property

        ''' <summary>
        ''' 警告時の背景色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WarnBackColor() As Color
            Get
                Return _WarnBackColor
            End Get
            Set(ByVal value As Color)
                _WarnBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' 警告時の文字色
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WarnForeColor() As Color
            Get
                Return _WarnForeColor
            End Get
            Set(ByVal value As Color)
                _WarnForeColor = value
            End Set
        End Property

        ''' <summary>
        ''' メッセージ内容
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' フォント
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Property Font() As Font
            Get
                Return _font
            End Get
            Set(ByVal value As Font)
                _font = value
                Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' アニメーションの方向
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DefaultValue(AnimateWindow.DirectionType.Top)> _
        Public Property DirectionType() As AnimateWindow.DirectionType
            Get
                Return _DirectionType
            End Get
            Set(ByVal value As AnimateWindow.DirectionType)
                _DirectionType = value
            End Set
        End Property

        <DefaultValue(True)> _
        Public Property FullClickClose() As Boolean
            Get
                Return _FullClickClose
            End Get
            Set(ByVal value As Boolean)
                _FullClickClose = value
            End Set
        End Property

        <DefaultValue(4)> _
        Public Property AutoCloseSecond() As Integer
            Get
                Return _AutoCloseSecond
            End Get
            Set(ByVal value As Integer)
                _AutoCloseSecond = value
            End Set
        End Property

        Public Shadows Property Visible() As Boolean
            Get
                Return MyBase.Visible
            End Get
            Set(ByVal value As Boolean)
                MyBase.Visible = value
                If UIHelper.DesignMode(Me) Then
                    Return
                End If
                OnVisibleChanged()
            End Set
        End Property

#End Region

#Region " Handles "

        Private Sub AlertMessage3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
            _alertClose()
        End Sub

        Private Sub Timer_TicK(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
            _alertClose()
        End Sub

        Private Sub _alertClose()
            Timer1.Enabled = False

            Dim dt As AnimateWindow.DirectionType
            Select Case _DirectionType
                Case AnimateWindow.DirectionType.Top
                    dt = AnimateWindow.DirectionType.Bottom
                Case AnimateWindow.DirectionType.Bottom
                    dt = AnimateWindow.DirectionType.Top
                Case AnimateWindow.DirectionType.Left
                    dt = AnimateWindow.DirectionType.Right
                Case AnimateWindow.DirectionType.Right
                    dt = AnimateWindow.DirectionType.Left
            End Select

            _animateWindow.SlideClose(Me, dt)
            Clear()
        End Sub

        Protected Sub OnVisibleChanged()
            If MyBase.Visible Then
                Return
            End If
            If Parent IsNot Nothing Then
                Parent.Refresh()
            End If
        End Sub

#End Region

#Region " Method "

        ''' <summary>
        ''' アラートクリア
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Clear()
            Me.BackColor = _DefaultMessageBackColor
            Me.ForeColor = _DefaultMessageForeColor
            Me.Visible = False
            Timer1.Enabled = False
        End Sub

        ''' <summary>
        ''' 情報アラート
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Public Sub Info(ByVal msg As String, ByVal ParamArray args() As String)
            Info(_AutoCloseSecond, msg, args)
        End Sub

        ''' <summary>
        ''' 情報アラート
        ''' </summary>
        ''' <param name="second"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        Public Sub Info(ByVal second As Integer, ByVal msg As String, ByVal ParamArray args() As String)
            _showAlert(second, _DefaultMessageBackColor, _DefaultMessageForeColor, msg, args)
        End Sub

        ''' <summary>
        ''' 正常アラート
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Public Sub Success(ByVal msg As String, ByVal ParamArray args() As String)
            Success(_AutoCloseSecond, msg, args)
        End Sub

        ''' <summary>
        ''' 正常アラート
        ''' </summary>
        ''' <param name="second"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        Public Sub Success(ByVal second As Integer, ByVal msg As String, ByVal ParamArray args() As String)
            _showAlert(second, _SuccessBackColor, _SuccessForeColor, msg, args)
        End Sub

        ''' <summary>
        ''' エラーアラート
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Public Sub [Error](ByVal msg As String, ByVal ParamArray args() As String)
            [Error](_AutoCloseSecond, msg, args)
        End Sub

        ''' <summary>
        ''' エラーアラート
        ''' </summary>
        ''' <param name="second"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        Public Sub [Error](ByVal second As Integer, ByVal msg As String, ByVal ParamArray args() As String)
            _showAlert(second, _ErrorBackColor, _ErrorForeColor, msg, args)
        End Sub

        ''' <summary>
        ''' ワーニングアラート
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Public Sub Warn(ByVal msg As String, ByVal ParamArray args() As String)
            Warn(_AutoCloseSecond, msg, args)
        End Sub

        ''' <summary>
        ''' ワーニングアラート
        ''' </summary>
        ''' <param name="second"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        Public Sub Warn(ByVal second As Integer, ByVal msg As String, ByVal ParamArray args() As String)
            _showAlert(second, _WarnBackColor, _WarnForeColor, msg, args)
        End Sub

        ''' <summary>
        ''' アラートを表示
        ''' </summary>
        ''' <param name="second"></param>
        ''' <param name="labelBackColor"></param>
        ''' <param name="labelForeColor"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Private Sub _showAlert(ByVal second As Integer, ByVal labelBackColor As Color, ByVal labelForeColor As Color, ByVal msg As String, ByVal ParamArray args() As String)
            Me.BackColor = labelBackColor
            Me.ForeColor = labelForeColor
            Me.Text = String.Format(msg, args)

            Me.BringToFront()
            _animateWindow.Slide(Me, _DirectionType)

            Me.Refresh()
            Me.Parent.Focus()
            If second.Equals(0) Then
                Return
            End If
            Timer1.Interval = second * 1000
            Timer1.Enabled = False
            Timer1.Enabled = True
        End Sub

#End Region

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            _draw(e.Graphics, e.ClipRectangle)
        End Sub

        Private Sub _draw(ByVal g As Graphics, ByVal rect As Rectangle)
            Dim brush As New SolidBrush(Me.ForeColor)
            _drawString(Text, Font, brush, g, rect, _format)
        End Sub

        Private Sub _drawString(ByVal text As String, ByVal font As Font, _
            ByVal brush As SolidBrush, ByVal g As Graphics, _
            ByVal rec As Rectangle, ByVal format As StringFormat)

            If text.IndexOf(vbCrLf) < 0 Then
                ' 一行
                g.DrawString(text, font, brush, rec, format)
                Return
            End If

            ' 複数行

            Dim strArray() As String
            strArray = text.Split(vbCrLf)

            Dim lineSize As SizeF = g.MeasureString(strArray(0), font)
            Dim lineRec As New Rectangle
            lineRec = rec
            lineRec.Height = lineSize.Height

            Dim firstLineTop As Integer
            Select Case format.LineAlignment

                Case StringAlignment.Near
                    firstLineTop = rec.Top

                Case StringAlignment.Center
                    firstLineTop = (rec.Height / 2) - ((lineSize.Height * strArray.Length) / 2) + rec.Top

                Case StringAlignment.Far
                    firstLineTop = (rec.Height) - (lineSize.Height * (strArray.Length)) + rec.Top
            End Select

            format.LineAlignment = StringAlignment.Near

            For ii As Integer = 0 To strArray.Length - 1
                lineRec.Location = New Point(lineRec.Left, (lineSize.Height * ii) + firstLineTop)
                g.DrawString(strArray(ii), font, brush, lineRec, format)
            Next
        End Sub

    End Class

End Namespace
