
Imports System.Windows.Forms
Imports System.Drawing

Namespace Win

#Region " Delegate "

    ''' <summary>
    ''' 検証を独自で行うときのデリゲート
    ''' </summary>
    ''' <param name="ctrl">対象のコントロール</param>
    ''' <param name="validator">検証内容</param>
    ''' <returns>エラーメッセージ</returns>
    Public Delegate Function CustomVerifyCallback(ByVal ctrl As Control, ByVal validator As FormValidator) As String

    '''' <summary>
    '''' グリッドのセル検証を独自で行うときのデリゲート
    '''' </summary>
    '''' <param name="cell">対象のセルコントロール</param>
    '''' <param name="validator">検証内容</param>
    '''' <returns>エラーメッセージ</returns>
    'Public Delegate Function CustomCellVerifyCallback(ByVal cell As DataGridViewCell, ByVal validator As FormValidator) As String

    '''' <summary>
    '''' グリッドの行検証を独自で行うときのデリゲート
    '''' </summary>
    '''' <param name="row"></param>
    '''' <param name="validator"></param>
    '''' <returns></returns>
    'Public Delegate Function CustomRowVerifyCallback(ByVal row As DataGridViewRow, ByVal validator As FormValidator) As String

#End Region

    ''' <summary>
    ''' 画面項目の検証
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FormValidator
        Implements IDisposable

#Region " Declare "

        Protected validator As Util.Validator

        Private _frm As Form

        Private _value As Object

        Private _validTypes As Util.ValidateTypes

        Private _min As Object

        Private _max As Object

        Private _messageVisible As Boolean

        Private _message As String

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="frm"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal frm As Form)
            _frm = frm

            validator = New Util.Validator

            Me.DefalutControlBackColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.DefalutControlBackColor)
            Me.DefalutControlForeColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.DefalutControlForeColor)
            Me.ErrorControlBackColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.ErrorControlBackColor)
            Me.ErrorControlForeColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.ErrorControlForeColor)
        End Sub

#End Region

#Region " IDisposable Support "
        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: 他の状態を解放します (マネージ オブジェクト)。
                End If

                ' TODO: ユーザー独自の状態を解放します (アンマネージ オブジェクト)。
                ' TODO: 大きなフィールドを null に設定します。

                'ToolTip.Dispose()
                'ErrorProvider1.Dispose()
            End If
            Me.disposedValue = True
        End Sub

        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#Region " Property "

        ''' <summary>
        ''' コントロールのデフォルトの背景色
        ''' </summary>
        ''' <returns></returns>
        Public Property DefalutControlBackColor() As Color
            Get
                Return _DefalutControlBackColor
            End Get
            Set(ByVal value As Color)
                _DefalutControlBackColor = value
            End Set
        End Property
        Private _DefalutControlBackColor As Color

        ''' <summary>
        ''' コントロールのデフォルトの文字色
        ''' </summary>
        ''' <returns></returns>
        Public Property DefalutControlForeColor() As Color
            Get
                Return _DefalutControlForeColor
            End Get
            Set(ByVal value As Color)
                _DefalutControlForeColor = value
            End Set
        End Property
        Private _DefalutControlForeColor As Color

        ''' <summary>
        ''' コントロールのエラーの背景色
        ''' </summary>
        ''' <returns></returns>
        Public Property ErrorControlBackColor() As Color
            Get
                Return _ErrorControlBackColor
            End Get
            Set(ByVal value As Color)
                _ErrorControlBackColor = value
            End Set
        End Property
        Private _ErrorControlBackColor As Color

        ''' <summary>
        ''' コントロールのエラーの文字色
        ''' </summary>
        ''' <returns></returns>
        Public Property ErrorControlForeColor() As Color
            Get
                Return _ErrorControlForeColor
            End Get
            Set(ByVal value As Color)
                _ErrorControlForeColor = value
            End Set
        End Property
        Private _ErrorControlForeColor As Color

        ''' <summary> 
        ''' 検証する種別 
        ''' </summary> 
        Public Property ValidTypes() As Util.ValidateTypes
            Get
                Return Me._validTypes
            End Get
            Set(ByVal value As Util.ValidateTypes)
                Me._validTypes = value
                _value = Nothing
                _message = String.Empty
                _min = Nothing
                _max = Nothing
            End Set
        End Property

        ''' <summary>
        ''' あえて検証から除外する種別 
        ''' </summary>
        ''' <returns></returns>
        Public Property IgnoreValidTypes() As Util.ValidateTypes
            Get
                Return _IgnoreValidTypes
            End Get
            Set(ByVal value As Util.ValidateTypes)
                _IgnoreValidTypes = value
            End Set
        End Property
        Private _IgnoreValidTypes As Util.ValidateTypes

        ''' <summary> 
        ''' 検証時の最少数
        ''' </summary> 
        Public Property Min() As Object
            Get
                Return Me._min
            End Get
            Set(ByVal value As Object)
                Me._min = value
            End Set
        End Property

        ''' <summary> 
        ''' 検証時の最大数
        ''' </summary> 
        Public Property Max() As Object
            Get
                Return Me._max
            End Get
            Set(ByVal value As Object)
                Me._max = value
            End Set
        End Property

        ''' <summary> 
        ''' メッセージの表示・非表示
        ''' </summary> 
        Public Property MessageVisible() As Boolean
            Get
                Return Me._messageVisible
            End Get
            Set(ByVal value As Boolean)
                Me._messageVisible = value
            End Set
        End Property

        ''' <summary> 
        ''' メッセージ
        ''' </summary> 
        Public Property Message() As String
            Get
                Return Me._message
            End Get
            Set(ByVal value As String)
                Me._message = value
            End Set
        End Property

        ''' <summary> 
        ''' 検証した値
        ''' </summary> 
        Public Property Value() As Object
            Get
                Return IIf(Me._value Is Nothing, String.Empty, Me._value)
            End Get
            Set(ByVal value As Object)
                Me._value = value
            End Set
        End Property

#End Region

#Region " Method "

        ''' <summary>
        ''' コントロールのエラークリアー
        ''' </summary>
        ''' <param name="msgCtrl"></param>
        Public Sub Clear(ByVal msgCtrl As Control)
            Me.Clear(msgCtrl, msgCtrl)
        End Sub

        ''' <summary>
        ''' コントロールのエラークリアー
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Friend Sub Clear(ByVal ctrl As Control, ByVal msgCtrl As Control)
            If ctrl Is Nothing Then
                Return
            End If

            'Me.ErrorProvider1.SetError(msgCtrl, String.Empty)

            'Me.ToolTip.SetToolTip(ctrl, String.Empty)
            RemoveHandler ctrl.GotFocus, AddressOf _gotFocus
            RemoveHandler ctrl.LostFocus, AddressOf _lostFocus
            If Not TypeOf ctrl Is TextBoxBase Then
                Return
            End If
            If Not CType(ctrl, TextBoxBase).ReadOnly Then
                Return
            End If
            ctrl.BackColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.DefalutControlBackColor)
        End Sub

        ''' <summary>
        ''' エラーセットされたコントロールのGotFocusイベントハンドル
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub _gotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim ctrl As Control
            'Dim msg As String
            ctrl = DirectCast(sender, Control)
            'msg = Me.ToolTip.GetToolTip(ctrl)
            'Me.ToolTip.Show(msg, ctrl, New Point(0, ctrl.Height), Me.ToolTipDuration)
        End Sub

        ''' <summary>
        ''' エラーセットされたコントロールのLostFocusイベントハンドル
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub _lostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'Me.ToolTip.Hide(sender)
        End Sub

#End Region

    End Class

End Namespace
