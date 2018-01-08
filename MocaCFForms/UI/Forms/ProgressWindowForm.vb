
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' プログレスウィンドウ
    ''' </summary>
    Public Class ProgressWindowForm

#Region " Declare "

        Private _progress As ProgressWindow
        Private _owner As Form

        'Private worker As New BackgroundWorker
        Private worker2 As Threading.Thread

        Private _result As Object

#End Region

#Region " Property "

        Public ReadOnly Property Result() As Object
            Get
                Return _result
            End Get
        End Property

        Private _err As Exception
        Public ReadOnly Property Err() As Exception
            Get
                Return _err
            End Get
        End Property

        'Public ReadOnly Property IsCancel() As Boolean
        '    Get
        '        Return worker.CancellationPending
        '    End Get
        'End Property

#End Region

#Region " コンストラクタ "

        Public Sub New(ByVal progress As ProgressWindow, ByVal owner As Form)

            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()

            ' InitializeComponent() 呼び出しの後で初期化を追加します。

            Location = New Point( _
                Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2, _
                Screen.PrimaryScreen.WorkingArea.Height / 2 - Height / 2)

            Me.TopMost = True
            Me._progress = progress
            _owner = owner
        End Sub

#End Region

#Region " Handles "

        Private Sub ProgressWindowForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me.BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.FormBorderColor)
            Me.pnlMain.BackColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.ContentColor)
            Me.lblMessage.ForeColor = CoreSettings.Instance.DesignValue(DesignSettingKeys.PrimaryTextColor)

            Show()
            Application.DoEvents()

            ProgressWindow_Shown(sender, e)
        End Sub

        Private Sub ProgressWindow_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
            If DesignMode Then
                Return
            End If

            'worker.WorkerSupportsCancellation = btnCancel.Visible

            Dim status As New ThreadStatus()
            worker2 = New Threading.Thread(AddressOf onDoWork2)
            worker2.IsBackground = True
            worker2.Start()

            'AddHandler worker.DoWork, AddressOf onDoWork
            'AddHandler worker.RunWorkerCompleted, AddressOf onRunWorkerCompleted
            'worker.RunWorkerAsync()
        End Sub

        'Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        '    Cancel()
        'End Sub

#End Region

        Private idx As Integer = 0
        Private _Maximum As Integer = 7
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            If idx.Equals(0) Then
                ProgressBar1.Minimum = 0
                ProgressBar1.Maximum = _Maximum
            End If

            ProgressBar1.Value = idx

            idx += 1
            If idx > _Maximum Then
                idx = 0
            End If
        End Sub

        Private Sub onDoWork2()
            Dim args As New ProgressWindowEventArgs(Me._progress, Me._progress.Args)
            If Me._progress.Method Is Nothing Then
                Return
            End If

            Me._progress.Method(Me, args)

            'If worker.CancellationPending Then
            '    e.Cancel = True
            '    Return
            'End If

            If _progress.Condition IsNot Nothing Then
                Dim values() As Object = _progress.Args.ToArray
                If _progress.MethodInvoke(_progress.Condition, values) Then
                    _progress.MethodInvoke(_progress.SuccessCallback, values)
                Else
                    _progress.MethodInvoke(_progress.ErrorCallback, values)
                End If
            End If

            _result = args.Result

            Invoke(New MethodInvoker(AddressOf _runWorkerCompleted))
        End Sub
        Friend Delegate Sub MethodInvoker()

        Private Sub _runWorkerCompleted()
            Timer1.Enabled = False
            Me.Close()
        End Sub

        Private Sub onDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            Dim args As New ProgressWindowEventArgs(Me._progress, Me._progress.Args)
            If Me._progress.Method Is Nothing Then
                Return
            End If

            Me._progress.Method(Me, args)

            'If worker.CancellationPending Then
            '    e.Cancel = True
            '    Return
            'End If

            If _progress.Condition IsNot Nothing Then
                Dim values() As Object = _progress.Args.ToArray
                If _progress.MethodInvoke(_progress.Condition, values) Then
                    _progress.MethodInvoke(_progress.SuccessCallback, values)
                Else
                    _progress.MethodInvoke(_progress.ErrorCallback, values)
                End If
            End If

            _result = args.Result

            e.Result = _result
        End Sub

        Private Sub onRunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            Timer1.Enabled = False
            _err = e.Error
            Me.Close()
        End Sub

        Public Sub Value(ByVal val As Integer)
            Me.ProgressBar1.Value = val
        End Sub

        Public Sub Minimum(ByVal value As Integer)
            Me.ProgressBar1.Minimum = value
        End Sub

        Public Sub Maximum(ByVal value As Integer)
            Me.ProgressBar1.Maximum = value
        End Sub

        Public Sub [Step](ByVal value As Integer)
            ProgressBar1.Value = value
        End Sub

        Public Sub PerformStep()
            ProgressBar1.Value += 1
        End Sub

        Friend Sub SetMessage(ByVal message As String)
            Me.lblMessage.Text = message
        End Sub

        'Friend Sub Cancel()
        '    worker.CancelAsync()
        'End Sub

    End Class

End Namespace
