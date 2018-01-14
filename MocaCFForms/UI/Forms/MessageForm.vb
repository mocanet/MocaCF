Imports System.Drawing
Imports System.Windows.Forms

Namespace Win

    ''' <summary>
    ''' メッセージウィンドウタイプ
    ''' </summary>
    Public Enum MessageType As Integer
        Information
        [Error]
        Warning
        Question
    End Enum

    ''' <summary>
    ''' メッセージウィンドウ
    ''' </summary>
    Public Class MessageForm

#Region " Declare "

        ' InformationBackColor:250, 250, 250
        ' InformationForeColor:26, 26, 26
        ' WarningBackColor:252, 248, 227
        ' WarningForeColor:145, 111, 53
        ' QuestionBackColor:White
        ' QuestionForeColor:64, 64, 64

        Private _messageType As MessageType

        Public Property InformationBackColor() As Color
            Get
                Return _InformationBackColor
            End Get
            Set(ByVal value As Color)
                _InformationBackColor = value
            End Set
        End Property
        Private _InformationBackColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.InformationBackColor)

        Public Property InformationForeColor() As Color
            Get
                Return _InformationForeColor
            End Get
            Set(ByVal value As Color)
                _InformationForeColor = value
            End Set
        End Property
        Private _InformationForeColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.InformationForeColor)

        Public Property ErrorBackColor() As Color
            Get
                Return _ErrorBackColor
            End Get
            Set(ByVal value As Color)
                _ErrorBackColor = value
            End Set
        End Property
        Private _ErrorBackColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.ErrorBackColor)

        Public Property ErrorForeColor() As Color
            Get
                Return _ErrorForeColor
            End Get
            Set(ByVal value As Color)
                _ErrorForeColor = value
            End Set
        End Property
        Private _ErrorForeColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.ErrorForeColor)

        Public Property WarningBackColor() As Color
            Get
                Return _WarningBackColor
            End Get
            Set(ByVal value As Color)
                _WarningBackColor = value
            End Set
        End Property
        Private _WarningBackColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.WarningBackColor)

        Public Property WarningForeColor() As Color
            Get
                Return _WarningForeColor
            End Get
            Set(ByVal value As Color)
                _WarningForeColor = value
            End Set
        End Property
        Private _WarningForeColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.WarningForeColor)

        Public Property QuestionBackColor() As Color
            Get
                Return _QuestionBackColor
            End Get
            Set(ByVal value As Color)
                _QuestionBackColor = value
            End Set
        End Property
        Private _QuestionBackColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.QuestionBackColor)

        Public Property QuestionForeColor() As Color
            Get
                Return _QuestionForeColor
            End Get
            Set(ByVal value As Color)
                _QuestionForeColor = value
            End Set
        End Property
        Private _QuestionForeColor As Color = CoreSettings.Instance.DesignValue(DesignSettingKeys.QuestionForeColor)

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="messageType">メッセージタイプ</param>
        ''' <param name="text">メッセージ</param>
        ''' <param name="caption">タイトル</param>
        Protected Sub New(ByVal messageType As MessageType, ByVal text As String, ByVal caption As String, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton)

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            Location = New Point( _
                Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, _
                Screen.PrimaryScreen.WorkingArea.Height / 2 - Height / 2)

            _messageType = messageType
            lblHeader.Text = caption
            lblMessage.Text = text

            Select Case buttons
                Case MessageBoxButtons.OK
                    btnOK.Text = "O K"

                Case MessageBoxButtons.OKCancel
                    btnOK.Text = "O K"
                    btnCancel.Text = "Cancel"

                Case MessageBoxButtons.YesNo

            End Select
            Select Case defaultButton
                Case MessageBoxDefaultButton.Button1
                    btnOK.Focus()
                Case MessageBoxDefaultButton.Button2
                    btnCancel.Focus()
            End Select
        End Sub

#End Region

#Region " Handles "

        ''' <summary>
        ''' フォームロード
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MessageForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            MyBase.BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.FormBorderColor)

            Select Case _messageType
                Case MessageType.Information
                    pnlMain.BackColor = InformationBackColor
                    Me.ForeColor = InformationForeColor
                    btnCancel.Visible = False
                    btnOK.Dock = DockStyle.Fill
                Case MessageType.Error
                    pnlMain.BackColor = ErrorBackColor
                    Me.ForeColor = ErrorForeColor
                    btnCancel.Visible = False
                    btnOK.Dock = DockStyle.Fill
                Case MessageType.Warning
                    pnlMain.BackColor = WarningBackColor
                    Me.ForeColor = WarningForeColor
                    btnCancel.Visible = False
                    btnOK.Dock = DockStyle.Fill
                Case MessageType.Question
                    pnlMain.BackColor = QuestionBackColor
                    Me.ForeColor = QuestionForeColor
                    btnCancel.Focus()
            End Select
            lblHeader.BackColor = pnlMain.BackColor

            Me.setControlStyle(Me.pnlMain.Controls)
        End Sub

        ''' <summary>
        ''' フォームが初めて表示
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub MessageForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
            Select Case _messageType
                Case MessageType.Information
                Case MessageType.Error
                Case MessageType.Warning
                Case MessageType.Question
            End Select
        End Sub

        ''' <summary>
        ''' OKボタンクリック
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
            OnOK()

            If btnCancel.Visible Then
                DialogResult = Windows.Forms.DialogResult.Yes
            Else
                DialogResult = Windows.Forms.DialogResult.OK
            End If
        End Sub

        ''' <summary>
        ''' キャンセルボタンクリック
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            DialogResult = Windows.Forms.DialogResult.No
        End Sub

#End Region

#Region " Overrides "

        Public Overrides Property ForeColor() As Color
            Get
                Return MyBase.ForeColor
            End Get
            Set(ByVal value As Color)
                MyBase.ForeColor = value
            End Set
        End Property

        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal value As Color)
                MyBase.BackColor = value
                pnlMain.BackColor = value
            End Set
        End Property

#End Region

#Region " Overridable "

        ''' <summary>
        ''' OKボタン処理
        ''' </summary>
        Protected Overridable Sub OnOK()
        End Sub

#End Region

#Region " Method "

#Region " Show "

        Public Overloads Shared Function Show(ByVal message As String) As DialogResult
            Return Show(message, Nothing, MessageType.Information)
        End Function

        Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String) As DialogResult
            Return Show(message, caption, MessageType.Information)
        End Function

        Public Overloads Shared Function ShowError(ByVal message As String) As DialogResult
            Return Show(message, Nothing, MessageType.Error)
        End Function

        Public Overloads Shared Function ShowError(ByVal message As String, ByVal caption As String) As DialogResult
            Return Show(message, caption, MessageType.Error)
        End Function

        Public Overloads Shared Function ShowWarning(ByVal message As String) As DialogResult
            Return Show(message, Nothing, MessageType.Warning)
        End Function

        Public Overloads Shared Function ShowWarning(ByVal message As String, ByVal caption As String) As DialogResult
            Return Show(message, caption, MessageType.Warning)
        End Function

        Public Overloads Shared Function ShowQuestion(ByVal message As String) As DialogResult
            Return Show(message, Nothing, MessageType.Question)
        End Function

        Public Overloads Shared Function ShowQuestion(ByVal message As String, ByVal caption As String) As DialogResult
            Return Show(message, caption, MessageType.Question)
        End Function

        Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal messageType As MessageType) As DialogResult
            Return Show(message, caption, messageType, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1)
        End Function

        Public Overloads Shared Function Show(ByVal message As String, ByVal caption As String, ByVal messageType As MessageType, ByVal buttons As MessageBoxButtons, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
            Using frm As New MessageForm(messageType, message, caption, buttons, defaultButton)
                Try
                    frm.Owner = CoreSettings.Instance.MainForm
                    Return frm.ShowDialog()
                Finally
                End Try
            End Using
        End Function

#End Region

#End Region

    End Class

End Namespace
