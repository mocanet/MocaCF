
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' バインドコンポーネントコンテキスト
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BindComponentContext

#Region " Declare "

        Private _bindCtrl As IControlBinder

        Private _lstVerify As IList(Of ComponentVerifyContext)

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        Private Sub New()
            _lstVerify = New List(Of ComponentVerifyContext)
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="bindCtrl"></param>
        ''' <param name="ctrl"></param>
        ''' <param name="msgCtrl"></param>
        ''' <param name="required"></param>
        Friend Sub New(ByVal bindCtrl As IControlBinder, ByVal ctrl As Component, ByVal msgCtrl As Control, ByVal required As Boolean)
            Me.New()

            _bindCtrl = bindCtrl
            _TargetControl = ctrl
            _MessageControl = msgCtrl

            If MessageControl Is Nothing Then
                _MessageControl = TargetControl
            End If

            Dim bc As IBindableComponent = ctrl
            Dim bind As Binding = DirectCast(bc.DataBindings(0), Binding)
            Dim bSource As BindingSource = bind.DataSource
            Dim dataSource As Object = bSource.Current()
            Dim propName As String = bind.BindingMemberInfo.BindingField

            _ModelProperty = dataSource.GetType.GetProperty(propName)
            If _ModelProperty IsNot Nothing Then
                _ValueValidateTypes = Util.ClassUtil.GetCustomAttribute(Of Win.ValidateTypesAttribute)(ModelProperty)
            End If
            Me.Required = required

            If Not TypeOf ctrl Is Control Then
                Return
            End If

            ' 編集時の変更有無判定
            Dim wCtrl As Control = ctrl
            NormalBackColor = wCtrl.BackColor
            'AddHandler wCtrl.Validated, AddressOf _ctrlValidated
            'AddHandler wCtrl.TextChanged, AddressOf _ctrlTextChanged
            AddHandler wCtrl.EnabledChanged, AddressOf _ctrlEnabledChanged
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' バインド対象のコンポーネント
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property TargetControl() As Component
            Get
                Return _TargetControl
            End Get
        End Property
        Private _TargetControl As Component

        ''' <summary>
        ''' メッセージを割り当てるコントロール
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property MessageControl() As Control
            Get
                Return _MessageControl
            End Get
        End Property
        Private _MessageControl As Control

        ''' <summary>
        ''' バインドするモデルのプロパティ情報
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ModelProperty() As PropertyInfo
            Get
                Return _ModelProperty
            End Get
        End Property
        Private _ModelProperty As PropertyInfo

        ''' <summary>
        ''' 入力値の検証種類
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property ValueValidateTypes() As Win.ValidateTypesAttribute
            Get
                Return _ValueValidateTypes
            End Get
        End Property
        Private _ValueValidateTypes As Win.ValidateTypesAttribute

        ''' <summary>
        ''' 必須入力のコントロールかどうか
        ''' </summary>
        ''' <returns></returns>
        Public Property Required() As Boolean
            Get
                Return _Required
            End Get
            Set(ByVal value As Boolean)
                _Required = value
            End Set
        End Property
        Private _Required As Boolean

        ''' <summary>
        ''' 通常時の背景色
        ''' </summary>
        ''' <returns></returns>
        Public Property NormalBackColor() As Color
            Get
                Return _NormalBackColor
            End Get
            Set(ByVal value As Color)
                _NormalBackColor = value
            End Set
        End Property
        Private _NormalBackColor As Color

        Public Property ContinueOnVerifyFailure() As Boolean
            Get
                Return _ContinueOnVerifyFailure
            End Get
            Set(ByVal value As Boolean)
                _ContinueOnVerifyFailure = value
            End Set
        End Property
        Private _ContinueOnVerifyFailure As Boolean

#End Region

#Region " Methods "

        ''' <summary>
        ''' コントロールの Validated イベント処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub _ctrlValidated(ByVal sender As Object, ByVal e As EventArgs)
            Dim bc As IBindableComponent = sender
            If bc.DataBindings.Count.Equals(0) Then
                Return
            End If
            Dim bind As Binding = DirectCast(bc.DataBindings(0), Binding)
            Dim bSource As BindingSource = bind.DataSource
            'Dim dataSource As Win.RowModelBase = bSource.Current()
            Dim dataSource As DataRowView = bSource.Current()
            Dim propName As String = bind.BindingMemberInfo.BindingField
            'Dim org As Win.RowModelBase = dataSource.GetOriginal()
            'Dim cur As Win.RowModelBase = dataSource
            Dim cur As DataRow = dataSource.Row

            If cur.RowState <> DataRowState.Unchanged Then
                Return
            End If

            'Dim value As Object = org.GetType().GetProperty(propName).GetValue(org, Nothing)
            Dim value As Object = cur.GetType.GetProperty("Item").GetValue(cur, New Object() {propName, DataRowVersion.Original})
            Dim newValue As Object = cur.GetType.GetProperty(propName).GetValue(cur, Nothing)

            If IsDBNull(newValue) Then
                If value Is Nothing Then
                    Return
                End If
            End If
            If newValue Is Nothing Then
                If value Is Nothing Then
                    Return
                End If
            End If
            If value = newValue Then
                Return
            End If

            cur.SetModified()
        End Sub

        ''' <summary>
        ''' コントロールの TextChanged イベント処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub _ctrlTextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim bc As IBindableComponent = sender
            Dim bind As Binding = DirectCast(bc.DataBindings(0), Binding)
            Dim bSource As BindingSource = bind.DataSource
            'Dim dataSource As Win.RowModelBase = bSource.Current()
            Dim dataSource As DataRowView = bSource.Current()
            Dim propName As String = bind.BindingMemberInfo.BindingField
            'Dim cur As Win.RowModelBase = dataSource
            'Dim org As Win.RowModelBase = dataSource.GetOriginal()
            Dim cur As DataRow = dataSource.Row

            If cur.RowState <> DataRowState.Unchanged Then
                Return
            End If

            'Dim value As Object = cur.GetType.GetProperty(propName).GetValue(cur, Nothing)
            Dim value As Object = cur.GetType.GetProperty("Item").GetValue(cur, New Object() {propName, DataRowVersion.Original})
            Dim ctrl As Control = sender
            Dim newValue As Object = ctrl.Text

            If IsDBNull(newValue) Then
                If value Is Nothing Then
                    Return
                End If
            End If
            If newValue Is Nothing Then
                If value Is Nothing Then
                    Return
                End If
            End If
            If value = newValue Then
                Return
            End If

            cur.SetModified()
        End Sub

        ''' <summary>
        ''' コントロールの EnabledChanged イベント処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub _ctrlEnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim ctrl As Control = sender
            If ctrl.Enabled Then
                If Required Then
                    ctrl.BackColor = _bindCtrl.RequiredBackColor
                Else
                    ctrl.BackColor = NormalBackColor
                End If
            Else
                ctrl.BackColor = NormalBackColor
            End If
        End Sub

#End Region

        Public ReadOnly Property Verify() As IList(Of ComponentVerifyContext)
            Get
                Return _lstVerify
            End Get
        End Property

        Public Function AddVerify(ByVal func As CustomVerifyCallback) As BindComponentContext
            Return AddVerify(func, True)
        End Function

        Public Function AddVerify(ByVal func As CustomVerifyCallback, ByVal continueOnVerifyFailure As Boolean) As BindComponentContext
            _lstVerify.Add(New ComponentVerifyContext(func, continueOnVerifyFailure))
            Return Me
        End Function

    End Class

End Namespace
