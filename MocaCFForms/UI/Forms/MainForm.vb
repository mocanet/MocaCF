Imports System.Windows.Forms
Imports System.Drawing
Imports Moca.Util

Namespace Win

    ''' <summary>
    ''' メイン画面
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MainForm

#Region " log4net "
        ''' <summary>log4net logger</summary>
        Private ReadOnly _mylog As Global.log4net.ILog = Global.log4net.LogManager.GetLogger(GetType(MainForm))
#End Region
#Region " Declare "

        Private _childStack As Stack(Of ChildForm)

        Private _LoginFormType As Type

        Private _DefaultChildFormType As Type

        Private _DefaultChildForm As ChildForm

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

            _childStack = New Stack(Of ChildForm)
            _LoginFormType = Nothing
            _DefaultChildFormType = Nothing

            CoreSettings.Instance.MainForm = Me

            Dim sz As Drawing.Size = CoreSettings.Instance.DesignValue(DesignSettingKeys.DefaultWindowSize)
            setWindowSize(sz)
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' メニュー画面（トップ画面）表示時の最大化ボタンの使用可否
        ''' </summary>
        ''' <returns></returns>
        Protected Property LimitterMaximumSize() As Boolean
            Get
                Return _LimitterMaximumSize
            End Get
            Set(ByVal value As Boolean)
                _LimitterMaximumSize = value
            End Set
        End Property
        Private _LimitterMaximumSize As Boolean

        ''' <summary>
        ''' ログイン画面を指定する場合にオーバーライドする
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overridable ReadOnly Property LoginFormType() As Type
            Get
                Return _LoginFormType
            End Get
        End Property

        ''' <summary>
        ''' メニュー画面等のトップ画面を指定する場合にオーバーライドする
        ''' </summary>
        ''' <returns></returns>
        Protected Overridable ReadOnly Property DefaultChildFormType() As Type
            Get
                Return _DefaultChildFormType
            End Get
        End Property

        Protected ReadOnly Property defaultChildForm() As ChildForm
            Get
                If _defaultChildForm Is Nothing Then
                    _defaultChildForm = ClassUtil.NewInstance(DefaultChildFormType)
                End If
                Return _defaultChildForm
            End Get
        End Property

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

            _actionLoad()

            Show()

            pnlMain.Focus()

            MyBase.OnLoad(e)
        End Sub

        ''' <summary>
        ''' フォームを閉じる
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnClosing(e)

            _actionFormClosing(e)
        End Sub

        Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
            If ShortCutKeys.ContainsKey(e.KeyCode) Then
                AlertMessage1.Clear()
            End If
            If e.KeyCode = Keys.Return Then
                ' Return時
                AlertMessage1.Clear()
            End If

            MyBase.OnKeyDown(e)
        End Sub

#End Region

#Region " Action "

        ''' <summary>
        ''' フォームロード
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _actionLoad()
            Me.Text = CoreSettings.Instance.Title

            Me.pnlMain.BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.ContentColor)

            If LoginFormType IsNot Nothing Then
                ShowChildForm(LoginFormType)
                Return
            End If
            _refresh(Nothing)
        End Sub

        ''' <summary>
        ''' フォームを閉じる
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub _actionFormClosing(ByVal e As System.ComponentModel.CancelEventArgs)
            If _childStack.Count.Equals(0) Then
                Return
            End If
            Dim child As ChildForm = _childStack.Peek()
            If child Is Nothing Then
                Return
            End If
            If DefaultChildForm IsNot Nothing Then
                If child.GetType Is DefaultChildForm.GetType Then
                    Return
                End If
            End If
            _childBack()
            e.Cancel = True
        End Sub

#End Region

#Region " Overridable "

        ''' <summary>
        ''' 当画面の共通リフレッシュ処理
        ''' </summary>
        Protected Overridable Sub MainRefresh()
        End Sub

#End Region

#Region " Method "

        ''' <summary>
        ''' 閉じる
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MyClose()
            _childBack()
        End Sub

#Region " Show "

#Region " ShowChildForm "

        Public Overloads Sub SwitchChildForm(ByVal typ As Type)
            If _childStack.Count.Equals(0) Then
                Return
            End If
            Dim child As ChildForm = _childStack.Peek()
            If child Is Nothing Then
                Return
            End If

            ' 編集あり？
            If child.IsUpdate Then
                ' 確認
                If UIHelper.ShowQuestionMessageBox(My.Resources.Messages.Q003, New String() {"前の画面へ移動"}) = DialogResult.No Then
                    Return
                End If
            End If

            _childStack.Pop()

            ShowChildForm(typ)

            child.Close2()
            child = Nothing
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="typ"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal typ As Type)
            If typ Is Nothing Then
                Return
            End If

            Dim frm As ChildForm
            frm = ClassUtil.NewInstance(typ)
            ShowChildForm(frm)
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="typ"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal typ As Type, ByVal value As Object)
            Dim frm As ChildForm

            If value IsNot Nothing Then
                Dim args As New ChildFormArgs(value, Me)
                frm = ClassUtil.NewInstance(typ, New Object() {args})
            Else
                frm = ClassUtil.NewInstance(typ)
            End If

            ShowChildForm(frm)
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="typ"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal command As CommandType, ByVal typ As Type, ByVal value As Object)
            Dim frm As ChildForm

            If Not command.Equals(CommandType.None) Or value IsNot Nothing Then
                Dim args As New ChildFormArgs(command, value, Me)
                frm = ClassUtil.NewInstance(typ, New Object() {args})
            Else
                frm = ClassUtil.NewInstance(typ)
            End If

            ShowChildForm(frm)
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="frm"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal frm As ChildForm)
            If DefaultChildForm IsNot Nothing Then
                If frm.GetType Is DefaultChildForm.GetType Then
                    _childBack()
                    Return
                End If
            End If

            Dim child As ChildForm = Nothing
            Try
                Me.pnlMain.Visible = False
                If Not _childStack.Count.Equals(0) Then
                    child = _childStack.Peek()
                    child.pnlContents.Visible = False
                End If
                If DefaultChildForm IsNot Nothing Then
                    DefaultChildForm.pnlContents.Visible = False
                End If

                child = frm
                child.Dock = DockStyle.Fill
                child.Width = Me.pnlMain.Width
                child.Height = Me.pnlMain.Height
                Me.Text = String.Format(CoreSettings.Instance.WindowTitle, CoreSettings.Instance.Title, child.Text)
                Me.ShortCutKeys = child.ShortCutKeys
                'pnlMain.Controls.Add(child.pnlContents)
                child.pnlContents.Parent = pnlMain
                child.OwnerForm = Me

                _childStack.Push(child)
            Finally
                AlertMessage1.Clear()
                pnlMain.Visible = True
                child.pnlContents.Focus()
                If child.StartFocusControl IsNot Nothing Then
                    child.StartFocusControl.Focus()
                End If
            End Try

        End Sub

#End Region

        ''' <summary>
        ''' 指定されたデフォルトの子画面表示
        ''' </summary>
        Protected Sub ShowDefaultChildForm()
            If DefaultChildForm Is Nothing Then
                Return
            End If

            Try
                Me.pnlMain.Visible = False
                If Not Me.pnlMain.Controls.Contains(DefaultChildForm.pnlContents) Then
                    DefaultChildForm.Dock = DockStyle.Fill
                    DefaultChildForm.Width = Me.pnlMain.Width
                    DefaultChildForm.Height = Me.pnlMain.Height
                    DefaultChildForm.OwnerForm = Me
                    'pnlMain.Controls.Add(DefaultChildForm.pnlContents)
                    DefaultChildForm.pnlContents.Parent = pnlMain
                End If
                Me.Text = String.Format(CoreSettings.Instance.WindowTitle, CoreSettings.Instance.Title, DefaultChildForm.Text)
                Me.ShortCutKeys = DefaultChildForm.ShortCutKeys
                DefaultChildForm.pnlContents.Visible = True
            Finally
                AlertMessage1.Clear()
                pnlMain.Visible = True
                DefaultChildForm.pnlContents.Focus()
                If DefaultChildForm.StartFocusControl IsNot Nothing Then
                    DefaultChildForm.StartFocusControl.Focus()
                End If
            End Try
        End Sub

        ''' <summary>
        ''' 子画面から戻る
        ''' </summary>
        Private Sub _childBack()
            If _childStack.Count.Equals(0) Then
                Return
            End If
            Dim child As ChildForm = _childStack.Peek()
            If child Is Nothing Then
                Return
            End If

            ' 編集あり？
            If child.IsUpdate Then
                ' 確認
                If UIHelper.ShowQuestionMessageBox(My.Resources.Messages.Q003, New String() {"前の画面へ移動"}) = DialogResult.No Then
                    Return
                End If
            End If

            _childStack.Pop()

            _refresh(child)

            child.Close2()
            child = Nothing
        End Sub

        ''' <summary>
        ''' 当画面の共通リフレッシュ処理
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _refresh(ByVal beforeChild As ChildForm)
            If Not _childStack.Count.Equals(0) Then
                Dim child As ChildForm = _childStack.Peek()
                Me.Text = String.Format(CoreSettings.Instance.WindowTitle, CoreSettings.Instance.Title, child.Text)
                Me.ShortCutKeys = child.ShortCutKeys
                child.pnlContents.Visible = True
                child.pnlContents.BringToFront()
                child.pnlContents.Focus()
                child.RefreshContents(beforeChild)
                Return
            End If

            Me.Text = CoreSettings.Instance.Title

            ShowDefaultChildForm()

            MainRefresh()

            If Me.WindowState = FormWindowState.Maximized Then
                Return
            End If
            Dim sz As Size = CoreSettings.Instance.DesignValue(DesignSettingKeys.DefaultWindowSize)
            If sz.Height > Screen.PrimaryScreen.WorkingArea.Height Then
                sz.Height = Screen.PrimaryScreen.WorkingArea.Height
            End If
            Me.setWindowSize(sz)
        End Sub

#End Region

#End Region

    End Class

End Namespace
