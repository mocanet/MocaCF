Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' 画面のベース
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CoreForm

#Region " Declare "

        ''' <summary>デザイン適用外</summary>
        Protected Const NoAuto As String = "noauto"

        Protected keyMode As Int32 = 0   ' 0:タブ移動モード 1:入力モード

        ''' <summary>アクション処理</summary>
        Protected Friend action As IFormAction

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()

            ' この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            _actionInit()
        End Sub

#End Region

#Region " Overrides "

        ''' <summary>
        ''' フォームロード
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            If UIHelper.DesignMode(Me) Then
                Return
            End If

            action.Execute(AddressOf _actionLoad, Me, e)
        End Sub

        Private _isLoaded As Boolean
        Private _isShown As Boolean

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            MyBase.OnActivated(e)

            If Not _isLoaded Then
                Return
            End If
            If _isShown Then
                Return
            End If

            _isShown = True
            _isLoaded = False
            OnShown(New EventArgs())
        End Sub
        Public Event Shown(ByVal sender As Object, ByVal e As EventArgs)

        Protected Overridable Sub OnShown(ByVal e As EventArgs)
            RaiseEvent Shown(Me, e)
        End Sub

        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            action.Execute(AddressOf _actionClosing, Me, e)
        End Sub

        Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
            action.Execute(AddressOf _actionClosed, Me, e)
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' 更新ありかどうか
        ''' </summary>
        ''' <returns></returns>
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Overridable ReadOnly Property IsUpdate() As Boolean
            Get
                Return _IsUpdate
            End Get
        End Property
        Private _IsUpdate As Boolean

#End Region

#Region " Handles "

        Private Sub CoreForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Debug.WriteLine(String.Format("KeyCode={0}, KeyData={1}, KeyValue={2}", e.KeyCode, e.KeyData, e.KeyValue))

            If _shortCutKeys.ContainsKey(e.KeyCode) Then
                Dim btn As ActionButton
                btn = _shortCutKeys(e.KeyCode)
                If btn IsNot Nothing Then
                    btn.PerformClick()
                    e.Handled = True
                    Return
                End If
            End If

            Dim ctrl As Control = TryCast(sender, Control)
            Dim focusedControl As Control = _getFocusedControl(ctrl)

            If TypeOf focusedControl Is TextBox Or _
                TypeOf focusedControl Is ComboBox Or _
                TypeOf focusedControl Is DataGrid Or _
                TypeOf focusedControl Is NumericUpDown Then
                If e.KeyCode = Keys.Return Then
                    ' Return時
                    'DrawRect(focusedControl, False)
                    Me.SelectNextControl(focusedControl, True, True, True, True)
                    Dim newfocusedControl As Control = _getFocusedControl(ctrl)
                    ' フォーカスコントロール
                    'DrawRect(newfocusedControl, True)
                    e.Handled = True
                End If
            End If

            If TypeOf focusedControl Is Button Then
                If e.KeyCode = Keys.Return Then
                    ' Return時
                    Return
                End If
                ' コントロール
                If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = (Keys.LButton Or Keys.Back) Then
                    ' ↓、→時
                    If keyMode = 0 Then
                        'DrawRect(focusedControl, False)
                        Me.SelectNextControl(focusedControl, True, True, True, True)
                        Dim newfocusedControl As Control = _getFocusedControl(ctrl)
                        ' フォーカスコントロール
                        'DrawRect(newfocusedControl, True)
                        e.Handled = True
                    End If
                ElseIf e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Left Then
                    ' ↑、←時
                    If keyMode = 0 Then
                        'DrawRect(focusedControl, False)
                        Me.SelectNextControl(focusedControl, False, True, True, True)
                        Dim newfocusedControl As Control = _getFocusedControl(ctrl)
                        ' フォーカスコントロール
                        'DrawRect(newfocusedControl, True)
                        e.Handled = True
                    End If
                End If
            End If
        End Sub

#End Region

#Region " Action "

        ''' <summary>
        ''' 初期化
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _actionInit()
            action = New FormAction()
            _enterKeys = New Dictionary(Of Control, ActionButton)
            _shortCutKeys = New Dictionary(Of ShortcutKey, ActionButton)

            action.Frm = Me
        End Sub

        ''' <summary>
        ''' フォームロード
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _actionLoad(ByVal sender As Object, ByVal e As System.EventArgs)
            _isLoaded = True
            _isShown = False

            Me.Icon = CoreSettings.Instance.Icon
            Me.ForeColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.PrimaryTextColor)
            Me.BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.BackColor)

            setControlStyle(Me.Controls)

            MyBase.OnLoad(e)
        End Sub

        Private Sub _actionClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)
        End Sub

        Private Sub _actionClosed(ByVal sender As Object, ByVal e As System.EventArgs)
            MyBase.OnClosed(e)
        End Sub

#End Region
#Region " Method "

        Private Function _getFocusedControl(ByVal parent As Control) As Control
            If parent.Focused Then
                Return parent
            End If
            For Each ctrl As Control In parent.Controls
                Dim focusedControl As Control = _getFocusedControl(ctrl)
                If focusedControl IsNot Nothing Then
                    Return focusedControl
                End If
            Next
            Return Nothing
        End Function

        Private Sub DrawRect(ByVal control As Control, ByVal drawmode As Boolean)
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

        ''' <summary>
        ''' ウィンドウ配置
        ''' </summary>
        ''' <param name="formSize"></param>
        ''' <remarks></remarks>
        Protected Sub setWindowSize(ByVal formSize As Drawing.Size)
            setWindowSize(Me, formSize)
        End Sub

        ''' <summary>
        ''' ウィンドウ配置
        ''' </summary>
        ''' <param name="frm"></param>
        ''' <param name="formSize"></param>
        ''' <remarks></remarks>
        Protected Sub setWindowSize(ByVal frm As Form, ByVal formSize As Drawing.Size)
            frm.Size = formSize
        End Sub

        ''' <summary>
        ''' テキストボックスでEnterキーが押されたときに指定されたボタンをクリックする
        ''' </summary>
        ''' <param name="btn"></param>
        ''' <param name="txts"></param>
        Protected Sub setEnterKeyAction(ByVal btn As ActionButton, ByVal ParamArray txts() As Control)
            For Each txt As Control In txts
                _enterKeys.Add(txt, btn)
                AddHandler txt.KeyDown, AddressOf _txt_KeyDown
            Next
        End Sub

        Private Sub _txt_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If Not e.KeyCode.Equals(Keys.Enter) Then
                Return
            End If

            Dim btn As ActionButton = DirectCast(_enterKeys(sender), ActionButton)
            btn.PerformClick()
        End Sub

        Private _enterKeys As IDictionary(Of Control, ActionButton)

        ''' <summary>
        ''' ショートカットキーの設定
        ''' </summary>
        ''' <param name="key"></param>
        ''' <param name="btn"></param>
        ''' <remarks>
        ''' 既に設定済のときは再設定になる。
        ''' </remarks>
        Protected Sub setShortCut(ByVal key As ShortcutKey, ByVal btn As ActionButton)
            If _shortCutKeys.ContainsKey(key) Then
                _shortCutKeys(key) = btn
            Else
                _shortCutKeys.Add(key, btn)
            End If
        End Sub

        Friend Property ShortCutKeys() As IDictionary(Of ShortcutKey, ActionButton)
            Get
                Return _shortCutKeys
            End Get
            Set(ByVal value As IDictionary(Of ShortcutKey, ActionButton))
                _shortCutKeys = value
            End Set
        End Property

        Private _shortCutKeys As IDictionary(Of ShortcutKey, ActionButton)

#Region " setControlStyle "

        ''' <summary>
        ''' コントロールスタイル設定
        ''' </summary>
        ''' <param name="controls">コントロールのコレクション</param>
        ''' <remarks></remarks>
        Protected Sub setControlStyle(ByVal controls As Control.ControlCollection)
            For Each ctrl As Control In controls
                setControlStyle(ctrl)
            Next
        End Sub

        ''' <summary>
        ''' コントロールスタイル設定
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks></remarks>
        Protected Sub setControlStyle(ByVal ctrl As Control)
            If TypeOf ctrl.Tag Is String Then
                If ctrl.Tag = NoAuto Then
                    Return
                End If
            End If
            If TypeOf ctrl Is Panel Then
                Dim pnl As Panel = DirectCast(ctrl, Panel)
                setControlStyle(pnl.Controls)
                Return
            End If
            If TypeOf ctrl Is TabControl Then
                Dim tab As TabControl = DirectCast(ctrl, TabControl)
                For Each page As TabPage In tab.TabPages
                    setControlStyle(page.Controls)
                Next
                Return
            End If
            If TypeOf ctrl Is UserControl Then
                Dim usr As UserControl = ctrl
                setControlStyle(usr.Controls)
                Return
            End If

            If TypeOf ctrl Is Button Then
                _setControlStyle(ctrl)
            End If
            If TypeOf ctrl Is Label Then
            End If
            If TypeOf ctrl Is TextBoxBase Then
            End If
            If TypeOf ctrl Is RadioButton Then
            End If
            If TypeOf ctrl Is CheckBox Then
            End If
            If TypeOf ctrl Is ListControl Then
            End If
            If TypeOf ctrl Is DateTimePicker Then
            End If
        End Sub

        Private Sub _setControlStyle(ByVal btn As Button)
            Dim backColor As Color
            Dim foreColor As Color

            backColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.ActionButtonBackColor)
            foreColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.ActionButtonForeColor)

            Select Case btn.Name
                Case "btnF1", "btnF2", "btnF3", "btnF4"
                    backColor = CoreSettings.Instance.DesignValue(btn.Name & "BackColor")
                    foreColor = CoreSettings.Instance.DesignValue(btn.Name & "ForeColor")
                Case "btnLogoff"
                    backColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.btnLogoffBackColor)
                    foreColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.btnLogoffForeColor)
                Case Else
            End Select

            btn.BackColor = backColor
            btn.ForeColor = foreColor
        End Sub

#End Region

#End Region

    End Class

End Namespace
