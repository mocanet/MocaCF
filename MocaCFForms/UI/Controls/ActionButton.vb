
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

Namespace Win

#Region " Delegate "

    ''' <summary>
    ''' アクション処理の検証イベントデリゲート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Delegate Sub ActionValidatingEventHandler(ByVal sender As Object, ByVal e As ActionValidatingEventArgs)

#End Region

    ''' <summary>
    ''' ボタンの拡張コントロール
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ActionButton
        Inherits Button

#Region " Declare "

        ''' <summary>フォームの処理にて実行する処理を変わりに実行する</summary>
        Private _action As IFormAction

        ''' <summary>
        ''' クリックイベント前の検証イベント
        ''' </summary>
        Public Event ClickValidating As ActionValidatingEventHandler

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            MultiLine()
        End Sub

#End Region

#Region " Overrides "

        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            If haveAction Then
                Action.Execute(AddressOf _actionClick, Me, e, UpdateCheck, UpdateCheckCaption)
            Else
                _actionClick(Me, e)
            End If
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            _drawRect(Me, True)
        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            MyBase.OnLostFocus(e)
            _drawRect(Me, False)
        End Sub

        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
            MyBase.OnEnabledChanged(e)
            Try
                _isEnabledChange = True
                If Enabled Then
                    BackColor = _backColor
                Else
                    BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.BackColor)
                End If
            Finally
                _isEnabledChange = False
            End Try
        End Sub
        Private _isEnabledChange As Boolean

        Public Overrides Property BackColor() As System.Drawing.Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                MyBase.BackColor = value
                If _isEnabledChange Then
                    Return
                End If
                _backColor = MyBase.BackColor
            End Set
        End Property
        Private _backColor As Color

#End Region

#Region " Overridable "

        Protected Overridable Sub OnClickValidating(ByVal e As ActionValidatingEventArgs)
            RaiseEvent ClickValidating(Me, e)
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' フォームの処理にて実行する処理を変わりに実行する
        ''' </summary>
        ''' <returns></returns>
        Protected ReadOnly Property Action() As IFormAction
            Get
                If _action Is Nothing Then
                    Dim frm As CoreForm = TryCast(UIHelper.FindForm(Me), CoreForm)
                    _action = frm.action
                End If
                Return _action
            End Get
        End Property

        ''' <summary>
        ''' フォームの処理にて実行する処理を変わりに実行するオブジェクト有無
        ''' </summary>
        ''' <returns></returns>
        Protected ReadOnly Property haveAction() As Boolean
            Get
                Return Not (Action Is Nothing)
            End Get
        End Property

        ''' <summary>
        ''' 検証結果
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
        End Property
        Private _IsValid As Boolean

        ''' <summary>
        ''' 変更チェックの有無
        ''' </summary>
        ''' <returns></returns>
        Public Property UpdateCheck() As Boolean
            Get
                Return _UpdateCheck
            End Get
            Set(ByVal value As Boolean)
                _UpdateCheck = value
            End Set
        End Property
        Private _UpdateCheck As Boolean

        ''' <summary>
        ''' 変更チェック時の問合せ文字
        ''' </summary>
        ''' <returns></returns>
        Public Property UpdateCheckCaption() As String
            Get
                Return _UpdateCheckCaption
            End Get
            Set(ByVal value As String)
                _UpdateCheckCaption = value
            End Set
        End Property
        Private _UpdateCheckCaption As String

#End Region
#Region " Method "

        Public Sub PerformClick()
            If Not Visible Then
                Return
            End If
            If Not Enabled Then
                Return
            End If
            Focus()
            OnClick(New EventArgs)
        End Sub

        ''' <summary>
        ''' Visible=false でも Click イベントを実行します。
        ''' </summary>
        Public Sub DoClick()
            Focus()
            OnClick(New EventArgs)
        End Sub

        Public Sub MultiLine()
            Dim pinvoke As New PInvoke
            pinvoke.SetButtonMultiline(Me)
        End Sub

        Private Sub _onClick(ByVal e As EventArgs, ByVal args As ActionValidatingEventArgs)
            OnClickValidating(args)
            _IsValid = args.IsValid
            MyBase.OnClick(e)
        End Sub

        Private Sub _drawRect(ByVal control As Control, ByVal drawmode As Boolean)
            Dim bkcolor As Color
            Dim parent As Control = control.Parent

            Using graph As Graphics = parent.CreateGraphics()
                bkcolor = parent.BackColor

                If drawmode Then
                    '0, 192, 0
                    '0, 0, 255
                    Using pen As Pen = New Pen(Color.FromArgb(0, 0, 255), 3)
                        Dim rect As Rectangle
                        rect = New Rectangle(control.Location.X, control.Location.Y, control.Size.Width, Math.Min(control.Size.Height, (control.ClientSize.Height + 1)))
                        graph.DrawRectangle(pen, rect)
                    End Using
                Else
                    graph.Clear(bkcolor)
                End If
            End Using
        End Sub

        Private Sub _actionClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim args As New ActionValidatingEventArgs
            _onClick(e, args)
        End Sub

#End Region

    End Class

End Namespace
