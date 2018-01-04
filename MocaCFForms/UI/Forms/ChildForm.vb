Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Win

    Public Class ChildForm

#Region " Declare "

        Private _ownerForm As CoreForm

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

            If DesignMode Then
                Return
            End If

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
            End Set
        End Property

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

#End Region

#Region " Handles "

        Private Sub ChildForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Me.setControlStyle(pnlContents.Controls)
        End Sub

        Private Sub pnlContents_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlContents.ParentChanged
            If Me.Equals(pnlContents.Parent) Then
                Return
            End If
        End Sub

#End Region

#Region " Method "

        Private _args As ChildFormArgs

        Friend Sub SetArgs(ByVal args As ChildFormArgs)
            _args = args
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
            'If TypeOf _ownerForm Is SubForm Then
            '    _ownerForm.Close()
            'End If
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

            _mainForm.ShowChildForm(typ)
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

            _mainForm.ShowChildForm(typ, value)
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

            _mainForm.ShowChildForm(command, typ, value)
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

        Private ReadOnly Property _mainForm() As MainForm
            Get
                Return DirectCast(OwnerForm, Moca.Win.MainForm)
            End Get
        End Property

#End Region

    End Class

End Namespace
