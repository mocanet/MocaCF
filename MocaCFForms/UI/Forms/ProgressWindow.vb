Imports System.Windows.Forms

Namespace Win

    Public Class ProgressWindow

        Private _win As ProgressWindowForm

        Friend Args As List(Of Object)
        Friend Method As EventHandler(Of ProgressWindowEventArgs)
        Friend Condition As Func(Of Object(), Boolean)
        Friend SuccessCallback As ProgressWindow.OwnerMethodInvoker
        Friend ErrorCallback As ProgressWindow.OwnerMethodInvoker
        Friend Delegate Sub MethodInvoker(Of T)(ByVal arg1 As T)
        Friend Delegate Sub SubMethodInvoker()
        Public Delegate Sub OwnerMethodInvoker(ByVal values() As Object)

        Public Shared Function Show(ByVal owner As Form, ByVal handler As EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal canCancel As Boolean, ByVal ParamArray args As Object()) As Object
            Dim progress As New ProgressWindow()
            Dim param() As Object = args
            If args Is Nothing Then
                param = New Object() {}
            End If
            Return progress._show(owner, handler, Nothing, Nothing, Nothing, message, canCancel, New List(Of Object)(param))
        End Function

        Public Shared Function Show(ByVal owner As Form, ByVal handler As EventHandler(Of ProgressWindowEventArgs), ByVal message As String, ByVal canCancel As Boolean, ByVal condition As Func(Of Object(), Boolean), ByVal successCallback As ProgressWindow.OwnerMethodInvoker, ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, ByVal ParamArray args As Object()) As Object
            Dim progress As New ProgressWindow()
            Dim param() As Object = args
            If args Is Nothing Then
                param = New Object() {}
            End If
            Return progress._show(owner, handler, condition, successCallback, errorCallback, message, canCancel, New List(Of Object)(param))
        End Function

        Public WriteOnly Property Value() As Integer
            Set(ByVal value As Integer)
                _win.Invoke(New MethodInvoker(Of Integer)(AddressOf _win.Value), value)
            End Set
        End Property

        Public WriteOnly Property Minimum() As Integer
            Set(ByVal value As Integer)
                _win.Invoke(New MethodInvoker(Of Integer)(AddressOf _win.Minimum), value)
            End Set
        End Property

        Public WriteOnly Property Maximum() As Integer
            Set(ByVal value As Integer)
                _win.Invoke(New MethodInvoker(Of Integer)(AddressOf _win.Maximum), value)
            End Set
        End Property

        'Public ReadOnly Property IsCancel() As Boolean
        '    Get
        '        Return _win.IsCancel
        '    End Get
        'End Property

        Public WriteOnly Property [Step]() As Integer
            Set(ByVal value As Integer)
                _win.Invoke(New MethodInvoker(Of Integer)(AddressOf _win.Step), value)
            End Set
        End Property

        Public Sub PerformStep()
            _win.Invoke(New SubMethodInvoker(AddressOf _win.PerformStep), Nothing)
        End Sub

        Public WriteOnly Property Message() As String
            Set(ByVal value As String)
                _win.Invoke(New MethodInvoker(Of String)(AddressOf _win.SetMessage), value)
            End Set
        End Property

        Public Sub Cancel()
            _win.Invoke(New SubMethodInvoker(AddressOf _win.Close), Nothing)
        End Sub

        Public Function MethodInvoke(ByVal method As Func(Of Object(), Boolean), ByVal values() As Object)
            Return Me._owner.Invoke(method, New Object() {values})
        End Function

        Public Function MethodInvoke(ByVal method As OwnerMethodInvoker, ByVal values() As Object)
            Return Me._owner.Invoke(method, New Object() {values})
        End Function

        Private _owner As Form
        Friend Sub Exec(ByVal sender As Object, ByVal e As ProgressWindowEventArgs)
            Me._win.Invoke(New MethodInvoker(Of ProgressWindowEventArgs)(AddressOf _hoge), e)
        End Sub

        Private Sub _hoge(ByVal e As ProgressWindowEventArgs)
            Me.Method(Me, e)
        End Sub

        Private Function _show(ByVal owner As Form, _
                               ByVal handler As EventHandler(Of ProgressWindowEventArgs), _
                               ByVal condition As Func(Of Object(), Boolean), _
                               ByVal successCallback As ProgressWindow.OwnerMethodInvoker, _
                               ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, _
                               ByVal message As String, _
                               ByVal canCancel As Boolean, _
                               ByVal args As List(Of Object) _
                               ) As Object
            If handler Is Nothing Then
                Throw New ArgumentException("実行するメソッドが指定されていません。", "ProgressWindow")
            End If
            If String.IsNullOrEmpty(message) Then
                message = "処理中…"
            End If

            Me._owner = owner
            Me.Method = handler
            Me.Condition = condition
            Me.SuccessCallback = successCallback
            Me.ErrorCallback = errorCallback
            Me.Args = args

            _win = New ProgressWindowForm(Me, owner)
            _win.lblMessage.Text = message
            '_win.btnCancel.Visible = canCancel

            _win.ShowDialog()

            Dim result As Object = _win.Result
            Dim err As Exception = _win.Err

            _win.Dispose()

            If err IsNot Nothing Then
                Throw err
            End If

            Return result
        End Function

    End Class

End Namespace
