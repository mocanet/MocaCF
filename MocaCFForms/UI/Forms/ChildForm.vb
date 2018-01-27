
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Win

    ''' <summary>
    ''' 処理画面
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ChildForm

#Region " Declare "

        ''' <summary>
        ''' 開始処理イベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event Startup(ByVal sender As Object, ByVal e As EventArgs)

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

            FormBorderStyle = Windows.Forms.FormBorderStyle.None
            pnlContents.BackColor = Drawing.Color.Transparent

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            _actionInit()
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="args"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal args As ChildFormArgs)
            Me.New()

            _args = args
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' 親フォーム（現状 <see cref="MainForm"/>）
        ''' </summary>
        ''' <returns></returns>
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Protected Friend Property OwnerForm() As CoreForm
            Get
                If Me.Parent IsNot Nothing Then
                    _ownerForm = Parent
                End If
                Return _ownerForm
            End Get
            Set(ByVal value As CoreForm)
                _ownerForm = value
                _ownerMainForm = DirectCast(_ownerForm, MainForm)
                setControlStyle(pnlContents.Controls)

                action.ExecuteNoCursor(AddressOf OnStartup, EventArgs.Empty)
                'OnStartup(EventArgs.Empty)
            End Set
        End Property
        Private _ownerForm As CoreForm

        ''' <summary>
        ''' 表示開始時のフォーカスコントロール
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StartFocusControl() As Control
            Get
                Return _StartFocusControl
            End Get
            Set(ByVal value As Control)
                _StartFocusControl = value
            End Set
        End Property
        Private _StartFocusControl As Control

        ''' <summary>
        ''' 呼び出し元からの引数
        ''' </summary>
        ''' <returns></returns>
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public ReadOnly Property Args() As ChildFormArgs
            Get
                Return _args
            End Get
        End Property
        Private _args As ChildFormArgs

        ''' <summary>
        ''' アラートメッセージ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property AlertMessage() As AlertMessage
            Get
                Return ownerMainForm.AlertMessage1
            End Get
        End Property

        ''' <summary>
        ''' メインフォームインスタンス
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property ownerMainForm() As MainForm
            Get
                Return _ownerMainForm
            End Get
        End Property
        Private _ownerMainForm As MainForm

#End Region

#Region " Action "

        ''' <summary>
        ''' 初期化
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _actionInit()
            Me.setControlStyle(pnlContents.Controls)
        End Sub

#End Region
#Region " Method "

        ''' <summary>
        ''' 開始処理イベント実行
        ''' </summary>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnStartup(ByVal e As System.EventArgs)
            RaiseEvent Startup(Me, e)
        End Sub

        ''' <summary>
        ''' 当画面の共通リフレッシュ処理
        ''' </summary>
        ''' <remarks>
        ''' 他画面から戻ってきたときに画面の再描画が必要であればここをオーバーライドする
        ''' </remarks>
        Public Overridable Sub RefreshContents(ByVal beforeChild As ChildForm)
        End Sub

        ''' <summary>
        ''' 画面を閉じる（戻るボタンクリックと同等）
        ''' </summary>
        ''' <remarks>
        ''' 標準の Close を上書きしています
        ''' </remarks>
        Public Shadows Sub Close()
            If TypeOf _ownerForm Is MainForm Then
                DirectCast(_ownerForm, MainForm).MyClose()
            End If
        End Sub

        ''' <summary>
        ''' 画面を閉じる（メイン画面から呼ばれる）
        ''' </summary>
        Friend Sub Close2()
            pnlContents.Visible = False
            pnlContents.Dispose()
            pnlContents = Nothing
            MyBase.Close()
        End Sub

#Region " ShowChildForm "

        ''' <summary>
        ''' 画面切替表示
        ''' </summary>
        ''' <param name="typ"></param>
        ''' <remarks></remarks>
        Public Overloads Sub SwitchChildForm(ByVal typ As Type)
            If typ Is Nothing Then
                Return
            End If

            ownerMainForm.SwitchChildForm(typ)
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

            ownerMainForm.ShowChildForm(typ)
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="typ"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal typ As Type, ByVal value As Object)
            If typ Is Nothing Then
                Return
            End If

            ownerMainForm.ShowChildForm(typ, value)
        End Sub

        ''' <summary>
        ''' 画面表示
        ''' </summary>
        ''' <param name="command"></param>
        ''' <param name="typ"></param>
        ''' <param name="value"></param>
        ''' <remarks></remarks>
        Public Overloads Sub ShowChildForm(ByVal command As CommandType, ByVal typ As Type, ByVal value As Object)
            If typ Is Nothing Then
                Return
            End If

            ownerMainForm.ShowChildForm(command, typ, value)
        End Sub

#End Region

#End Region

    End Class

End Namespace
