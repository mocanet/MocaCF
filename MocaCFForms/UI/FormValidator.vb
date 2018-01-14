
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

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
            _orgBackColor = New Dictionary(Of Control, Color)

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
            'RemoveHandler ctrl.GotFocus, AddressOf _gotFocus
            'RemoveHandler ctrl.LostFocus, AddressOf _lostFocus

            If _orgBackColor.ContainsKey(ctrl) Then
                ctrl.BackColor = _orgBackColor(ctrl)
            Else
                _orgBackColor.Add(ctrl, ctrl.BackColor)
            End If
            'ctrl.BackColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.DefalutControlBackColor)
            ctrl.ForeColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.DefalutControlForeColor)

            If Not TypeOf ctrl Is TextBoxBase Then
                Return
            End If
            If Not CType(ctrl, TextBoxBase).ReadOnly Then
                Return
            End If
        End Sub

        Private _orgBackColor As IDictionary(Of Control, Color)

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

        ''' <summary>
        ''' 検証
        ''' </summary>
        ''' <param name="ctrl">対象のコントロール</param>
        ''' <param name="callback">独自検証するときのデリゲート</param>
        ''' <returns></returns>
        Public Overloads Function IsValid(ByVal ctrl As Control, ByVal callback As CustomVerifyCallback) As Boolean
            Return IsValid(ctrl, ctrl, callback)
        End Function

        ''' <summary>
        ''' 検証
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <param name="msgctrl"></param>
        ''' <returns></returns>
        Public Overloads Function IsValid(ByVal ctrl As Control, ByVal msgctrl As Control) As Boolean
            Return IsValid(ctrl, msgctrl, Nothing)
        End Function

        ''' <summary>
        ''' 検証
        ''' </summary>
        ''' <param name="ctrl">対象のコントロール</param>
        ''' <param name="msgctrl">エラー表示するコントロール</param>
        ''' <param name="callback">独自検証するときのデリゲート</param>
        ''' <returns></returns>
        Public Overloads Function IsValid(ByVal ctrl As Control, ByVal msgctrl As Control, ByVal callback As CustomVerifyCallback) As Boolean
            If callback IsNot Nothing Then
                Return _IsValid(ctrl, msgctrl, callback)
            End If
            If ctrl.DataBindings.Count.Equals(0) Then
                Return _IsValid(ctrl, msgctrl, callback)
            End If

            If ValidTypes.Equals(Util.ValidateTypes.None) Then
                ' エラークリア
                If TypeOf ctrl Is Component Then
                    Me.Clear(msgctrl)
                Else
                    Me.Clear(ctrl, msgctrl)
                End If
                Return True
            End If

            Return _IsValid(ctrl, msgctrl, callback)
        End Function

        ''' <summary>
        ''' 標準的な入力チェックを実行
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' 今のところ：必須、桁数（Max, Min）、日付、半角英数、メール、最小値、数値
        ''' </remarks>
        Private Function _IsValid(ByVal ctrl As Object, ByVal msgctrl As Control, ByVal callback As CustomVerifyCallback) As Boolean
            Dim ret As Util.ValidateTypes

            ' エラークリア
            If TypeOf ctrl Is Component Then
                Me.Clear(msgctrl)
            Else
                Me.Clear(ctrl, msgctrl)
            End If

            If callback IsNot Nothing Then
                Dim msg As String = String.Empty
                msg = callback(ctrl, Me)
                If Not String.IsNullOrEmpty(msg) Then
                    SetMessage(ctrl, msgctrl, msg)
                    Return False
                End If
                Return True
            End If

            ' 値取得
            If ctrl.GetType.GetProperty("Text") IsNot Nothing Then
                Dim cnvCtrl As Control = ctrl
                Me.Value = cnvCtrl.Text
            ElseIf ctrl.GetType.GetProperty("SelectedValue") IsNot Nothing Then
                Dim cnvLst As ListControl = ctrl
                Me.Value = cnvLst.SelectedValue
            End If

            ' チェック実行
            ret = validator.Verify(Me.Value.ToString, Me.ValidTypes, Me.Min, Me.Max)

            ' 必須チェック
            If Not validator.IsValidRequired(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E001)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E001)
                End If
                Return False
            End If

            ' 最大桁数チェック
            If Not validator.IsValidLenghtMax(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E002, Me.Max)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E002, Me.Max)
                End If
                Return False
            End If

            ' 最大バイト数チェック
            If Not validator.IsValidLenghtMaxB(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E003, Me.Max)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E003, Me.Max)
                End If
                Return False
            End If

            ' 最小桁数チェック
            If Not validator.IsValidLenghtMin(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E004, Me.Min)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E004, Me.Min)
                End If
                Return False
            End If

            ' 日付チェック
            If Not validator.IsValidDateFormat(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E005)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E005)
                End If
                Return False
            End If

            ' 半角英数チェック
            If Not validator.IsValidHalfWidthAlphanumeric(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E006)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E006)
                End If
                Return False
            End If

            ' メールチェック
            If Not validator.IsValidMail(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E007)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E007)
                End If
                Return False
            End If

            ' 最小値
            If Not validator.IsValidMinimum(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E008, Me.Min)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E008, Me.Min)
                End If
                Return False
            End If

            ' 最大値
            If Not validator.IsValidMaximum(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E009, Me.Max)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E009, Me.Max)
                End If
                Return False
            End If

            ' 符号付き数値
            If Not validator.IsValidWithNumericSigned(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E010)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E010)
                End If
                Return False
            End If

            ' 数値
            If Not validator.IsValidDecimal(ret) Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E022)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E022)
                End If
                Return False
            End If

            ' ここまでに判定されていないエラー
            If ret <> Util.ValidateTypes.None Then
                If TypeOf ctrl Is Component Then
                    Me.SetMessage(msgctrl, My.Resources.ValidatorMessages.E018)
                Else
                    Me.SetMessage(ctrl, msgctrl, My.Resources.ValidatorMessages.E018)
                End If
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' メッセージ設定
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        Private Overloads Sub SetMessage(ByVal ctrl As Control, ByVal msg As String, ByVal ParamArray args() As String)
            Me.SetMessage(ctrl, ctrl, msg, args)
        End Sub

        ''' <summary>
        ''' メッセージ設定
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <param name="msgCtrl"></param>
        ''' <param name="msg"></param>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Private Overloads Sub SetMessage(ByVal ctrl As Control, ByVal msgCtrl As Control, ByVal msg As String, ByVal ParamArray args() As String)
            Me.Message = String.Format(msg, args)
            SetControlError(ctrl, msgCtrl)
        End Sub

        ''' <summary>
        ''' コントロールのエラーセット
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Public Sub SetControlError(ByVal ctrl As Control)
            SetControlError(ctrl, ctrl)
        End Sub

        ''' <summary>
        ''' コントロールのエラーセット
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Friend Sub SetControlError(ByVal ctrl As Control, ByVal msgCtrl As Control)
            Dim msgOrg As String = Nothing 'Me.ErrorProvider1.GetError(ctrl)
            If Not String.IsNullOrEmpty(msgOrg) Then
                Me.Message = msgOrg & vbCrLf & Me.Message
            End If

            ctrl.BackColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.ErrorControlBackColor)
            ctrl.ForeColor = CoreSettings.Instance.FormValidateSettings(FormValidateSettingKeys.ErrorControlForeColor)

            'Me.ToolTip.SetToolTip(ctrl, Me.Message)
            'AddHandler ctrl.GotFocus, AddressOf _gotFocus
            'AddHandler ctrl.LostFocus, AddressOf _lostFocus
        End Sub

#End Region

    End Class

End Namespace
