Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Namespace Win

    ''' <summary>
    ''' TextBox コントロール拡張版
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TextBoxEx
        Inherits TextBox

#Region " Declare "

        ''' <summary>イベント</summary>
        Public Event TextChangedComplete(ByVal sender As Object, ByVal e As EventArgs)

        Private Delegate Sub textChangedCompleteDelegate()

        Private _bottomBorderColor As Color
        Private _bottomBorder As Label
        Private _TextChangedCompleteDelay As Integer = 0
        Private _timer As Timer

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            'この呼び出しは、コンポーネント デザイナで必要です。
            InitializeComponent()

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            _timer = New Timer()
            AddHandler _timer.Tick, AddressOf _timer_Tick
        End Sub

        'コンポーネント デザイナで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
        'コンポーネント デザイナを使って変更できます。
        'コード エディタを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Me.SuspendLayout()

            _bottomBorder = New Label()
            With _bottomBorder
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left
                .Height = 1
                .Dock = DockStyle.Bottom
                .Font = Font
                .BackColor = BottomBorderColor
                .Location = New Point(0, 0)
                .Size = New Size(1, 1)
                .Text = String.Empty
                .Name = Me.Name & "BottomBorder"
                .Visible = Not BottomBorderColor.Equals(Color.Empty)
            End With

            Try
                Controls.Add(_bottomBorder)
            Catch ex As Exception
            End Try

            Me.ResumeLayout(False)
        End Sub

#End Region
#Region " Dispose "

        'Component は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()

                    If _bottomBorder IsNot Nothing Then
                        _bottomBorder.Dispose()
                    End If
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

#End Region

#Region " Property "

        Public Property BottomBorderColor() As Color
            Get
                Return _bottomBorderColor
            End Get
            Set(ByVal value As Color)
                _bottomBorderColor = value
                _bottomBorder.BackColor = _bottomBorderColor
                Invalidate()
            End Set
        End Property

        <DefaultValue(0)> _
        Public Property TextChangedCompleteDelay() As Integer
            Get
                Return _TextChangedCompleteDelay
            End Get
            Set(ByVal value As Integer)
                _TextChangedCompleteDelay = value
            End Set
        End Property

        Public Property ImeMode() As PInvoke.ImeMode
            Get
                Return _ImeMode
            End Get
            Set(ByVal value As PInvoke.ImeMode)
                _ImeMode = value
            End Set
        End Property
        Private _ImeMode As PInvoke.ImeMode

#End Region

#Region " Overrides "

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            _bottomBorder.Height = 1
        End Sub

        Private _AddHandler As Boolean

        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)
            MyBase.OnParentChanged(e)

            If _AddHandler Then
                Return
            End If
            If Parent Is Nothing Then
                Return
            End If
            AddHandler Parent.GotFocus, AddressOf _parentGotFocus
            _AddHandler = True
        End Sub

        Private Sub _parentGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            _showBottomBorder()
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
            If UIHelper.DesignMode(Me) Then
                Return
            End If

            If TextChangedCompleteDelay.Equals(0) Then
                _timer.Enabled = False
            Else
                _timer.Interval = TextChangedCompleteDelay
                If _timer.Enabled Then
                    _timer.Enabled = False
                End If
                _timer.Enabled = True
            End If

            MyBase.OnTextChanged(e)
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            Dim pinvoke As New PInvoke
            pinvoke.SetImeMode(Me, _ImeMode)

            Me.SelectAll()

            MyBase.OnGotFocus(e)
        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            If Not TextChangedCompleteDelay.Equals(0) Then
                If _timer.Enabled Then
                    _timer.Enabled = False
                    OnTextChangedComplete(EventArgs.Empty)
                End If
                '_timer.Enabled = False
                'OnTextChangedComplete(EventArgs.Empty)
            End If

            MyBase.OnLostFocus(e)
        End Sub

        Protected Overridable Sub OnTextChangedComplete(ByVal e As EventArgs)
            RaiseEvent TextChangedComplete(Me, e)
        End Sub

#End Region
#Region " Method "

        Private Sub _showBottomBorder()
            Try
                If _bottomBorder.Parent IsNot Nothing Then
                    Return
                End If
                If _bottomBorderColor.Equals(Color.Empty) Then
                    _bottomBorder.Visible = False
                    Return
                End If

                _bottomBorder.Visible = True
                _bottomBorder.Dock = DockStyle.None
                _bottomBorder.Top = Me.Top + Me.Height - 1
                _bottomBorder.Left = Me.Left
                _bottomBorder.Width = Me.Width
                Parent.Controls.Add(_bottomBorder)
                _bottomBorder.BringToFront()
            Catch ex As System.ObjectDisposedException
                ' 画面を閉じると発生してしまうが回避方法がつかめないので Try-Catch
            End Try
        End Sub

        Private Sub _timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            _timer.Enabled = False
            Dim method As textChangedCompleteDelegate
            method = AddressOf _OnTextChangedComplete
            BeginInvoke(method)
        End Sub

        Private Sub _OnTextChangedComplete()
            OnTextChangedComplete(EventArgs.Empty)
        End Sub

#End Region

    End Class

End Namespace
