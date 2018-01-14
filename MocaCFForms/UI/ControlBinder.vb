Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Namespace Win

#Region " Delegate "

    ''' <summary>
    ''' アクション処理の検証イベントデリゲート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Delegate Sub ControlValidatingEventHandler(ByVal sender As Object, ByVal e As ControlValidatingEventArgs)

#End Region

    ''' <summary>
    ''' モデルとコントロールのバインダー
    ''' </summary>
    ''' <typeparam name="TTable"></typeparam>
    ''' <typeparam name="TRow"></typeparam>
    ''' <remarks></remarks>
    Public Class ControlBinder(Of TTable, TRow)
        Implements IDisposable, IControlBinder

#Region " Decalre "

        Private _dataBinder As DataBinder
        Private _dt As TTable
        Private _controls As IDictionary(Of Component, BindComponentContext)

        ''' <summary>入力チェック</summary>
        Private _validator As FormValidator

        Private _ImportRow As Reflection.MethodInfo
        Private _newRowMethod As Reflection.MethodInfo
        Private _addRowMethod As Reflection.MethodInfo

#End Region

        ''' <summary>
        ''' コントロールの検証
        ''' </summary>
        Public Event VerifyControl As ControlValidatingEventHandler

#Region " コンストラクタ "

        Public Sub New(ByVal frm As CoreForm, ByVal dataTableType As Type, ByVal copyRow As TRow)
            _validator = New FormValidator(frm)
            _controls = New Dictionary(Of Component, BindComponentContext)

            Dim typ As Type
            typ = GetType(TRow)
            _ImportRow = dataTableType.GetMethod("ImportRow", New Type() {GetType(DataRow)})
            _newRowMethod = dataTableType.GetMethod("New" & typ.Name)
            _addRowMethod = dataTableType.GetMethod("Add" & typ.Name, New Type() {GetType(TRow)})

            If copyRow Is Nothing Then
                _dt = Util.ClassUtil.NewInstance(dataTableType)
                Dim row As TRow
                row = _newRowMethod.Invoke(_dt, New Object() {})
                _addRowMethod.Invoke(_dt, New Object() {row})
            Else
                Dim obj As Object = copyRow
                Dim dt As Object = CType(obj, DataRow).Table.Clone()
                _dt = dt
                _ImportRow.Invoke(_dt, New Object() {copyRow})
            End If

            'Dim dtObj As Object = _dt
            'CType(dtObj, DataTable).AcceptChanges()

            _dataBinder = New DataBinder()
            _dataBinder.DataSource = _dt
            _dataBinder.Position = 0
            AcceptChanges()
        End Sub

        Public Sub New(ByVal frm As CoreForm, ByVal dataTableType As Type)
            Me.New(frm, dataTableType, Nothing)
        End Sub

#End Region

#Region " Implements IDisposable "

        Private disposedValue As Boolean = False        ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: 他の状態を解放します (マネージ オブジェクト)。
                End If

                ' TODO: ユーザー独自の状態を解放します (アンマネージ オブジェクト)。
                ' TODO: 大きなフィールドを null に設定します。

                _dataBinder.Dispose()
                _validator.Dispose()
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#End Region
#Region " Implements IControlBinder "

        Public Property RequiredBackColor() As System.Drawing.Color Implements IControlBinder.RequiredBackColor
            Get
                Return _requiredBackColor
            End Get
            Set(ByVal value As System.Drawing.Color)
                _requiredBackColor = value
            End Set
        End Property
        Private _requiredBackColor As Color

#End Region

#Region " Property "

        Public ReadOnly Property BindSrc() As BindingSource
            Get
                Return _dataBinder.BindSrc
            End Get
        End Property

        Protected ReadOnly Property dataSource() As DataTable
            Get
                Return _dataBinder.DataSource
            End Get
        End Property
#End Region

#Region " Methods "

#Region " Entity get/set "

        ''' <summary>
        ''' バインドしたエンティティを返す
        ''' </summary>
        ''' <returns></returns>
        Public Function GetEntity() As TRow
            Return _dataBinder.CurrentEntity(Of TRow)()
        End Function

        ''' <summary>
        ''' バインドするエンティティを設定する
        ''' </summary>
        ''' <param name="row"></param>
        Public Sub SetEntity(ByVal row As TRow)
            _ImportRow.Invoke(_dt, New Object() {row})
            _dataBinder.BindSrc.RemoveAt(0)
            AcceptChanges()
        End Sub

#End Region

#Region " GetChanges "

        ''' <summary>
        ''' 変更行のみ返す
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function GetChanges() As DataTable
            Dim dt As DataTable

            BindSrc.EndEdit()

            If _dataBinder.BindSrc.DataSource IsNot Nothing Then
                dt = dataSource.GetChanges()
            Else
                dt = Util.ClassUtil.NewInstance(GetType(TTable))
            End If

            Return dt
        End Function

        'Public Overloads Function GetChanges() As IList
        '    Dim lst As IList = New List(Of TRow)

        '    If _dataBinder.BindSrc.DataSource IsNot Nothing Then
        '        lst = (From item As Object In CType(_dataBinder.BindSrc.DataSource, DataTable).Rows _
        '               Where (CType(item, DataRow).RowState <> DataRowState.Unchanged) _
        '               Select item).ToList
        '    End If

        '    Return lst
        'End Function

#End Region

        ''' <summary>
        ''' 変更をコミットする
        ''' </summary>
        Public Sub AcceptChanges()
            _dataBinder.AcceptChanges()
        End Sub

        ''' <summary>
        ''' 変更を元に戻す
        ''' </summary>
        Public Sub RejectChanges()
            _dataBinder.RejectChanges()
        End Sub

        ''' <summary>
        ''' 変更されたかどうか
        ''' </summary>
        ''' <returns></returns>
        Public Function HasChanges() As Boolean
            Dim dt As DataTable
            dt = GetChanges()
            If dt Is Nothing Then
                Return False
            End If
            Return (Not dt.Rows.Count.Equals(0))
        End Function

#Region " Clear "

        ''' <summary>
        ''' 全てのコントロールの値を初期化する
        ''' </summary>
        Public Sub Clear()
            For Each ctrl As BindComponentContext In _controls.Values
                If TypeOf ctrl.TargetControl Is Control Then
                    clearControl(ctrl)
                Else
                    clearComponent(ctrl)
                End If
            Next
            AcceptChanges()
        End Sub

        ''' <summary>
        ''' コンポーネント及びエラーのクリア
        ''' </summary>
        ''' <param name="ctrl"></param>
        Protected Sub clearComponent(ByVal ctrl As BindComponentContext)
            Dim target As Component = ctrl.TargetControl
            'If TypeOf target Is RadioButtonGroup Then
            '    Dim rbg As RadioButtonGroup = target
            '    rbg.SelectedValue = Nothing
            'End If

            If ctrl.MessageControl Is Nothing Then
                'TODO: 未実装。どう実装するか検討が必要
            Else
                _validator.Clear(ctrl.MessageControl)
            End If
        End Sub

        ''' <summary>
        ''' コントロールテキスト及びエラーのクリア
        ''' </summary>
        ''' <param name="ctrl"></param>
        Protected Sub clearControl(ByVal ctrl As BindComponentContext)
            Dim target As Control = ctrl.TargetControl
            If Not TypeOf target Is ButtonBase Then
                If TypeOf target Is ComboBox Then
                    Dim cbo As ComboBox = target
                    If cbo.DataBindings.Count.Equals(0) Then
                        cbo.SelectedIndex = -1
                    Else
                        cbo.SelectedIndex = -1
                        cbo.SelectedItem = cbo.DataBindings.Item(0).DataSourceNullValue
                        If cbo.DataBindings(0).PropertyName.Equals("Text") Then
                            cbo.Text = String.Empty
                        End If
                        cbo.Refresh()
                    End If
                Else
                    target.Text = Nothing
                    Dim b As Binding = target.DataBindings.Item(0)
                    Dim source As BindingSource = b.DataSource
                    Dim bindingField As String = b.BindingMemberInfo.BindingField
                    Dim dataSourceNullValue As Object = b.DataSourceNullValue
                    Dim drv As DataRowView = source.Current
                    drv.Row(bindingField) = dataSourceNullValue
                End If
            End If

            If ctrl.MessageControl Is Nothing Then
                _validator.Clear(target)
            Else
                _validator.Clear(ctrl.MessageControl)
            End If
        End Sub

#End Region

#Region " Binding "

#Region " TextBox "

        Public Overloads Function Binding(ByVal ctrl As TextBox, ByVal dataMember As String) As BindComponentContext
            _dataBinder.DataBinding(ctrl, dataMember)
            Return _binding(ctrl, False)
        End Function

#End Region
#Region " Label "

        Public Overloads Function Binding(ByVal ctrl As Label, ByVal dataMember As String) As BindComponentContext
            Return Binding(ctrl, dataMember, String.Empty)
        End Function

        Public Overloads Function Binding(ByVal ctrl As Label, ByVal dataMember As String, ByVal formatString As String) As BindComponentContext
            Return Binding(ctrl, dataMember, formatString, Nothing)
        End Function

        Public Overloads Function Binding(ByVal ctrl As Label, ByVal dataMember As String, ByVal formatString As String, ByVal dataSourceNullValue As Object) As BindComponentContext
            _dataBinder.DataBinding(ctrl, dataMember, dataSourceNullValue, Nothing, formatString)
            Return _binding(ctrl, False)
        End Function

#End Region
#Region " ComboBox "

        Public Overloads Function Binding(ByVal ctrl As ComboBox, ByVal dataMember As String) As BindComponentContext
            _dataBinder.DataBinding(ctrl, dataMember)
            Return _binding(ctrl, False)
        End Function

#End Region
#Region " CheckBox "

        Public Overloads Function Binding(ByVal ctrl As CheckBox, ByVal dataMember As String) As BindComponentContext
            _dataBinder.DataBinding(ctrl, dataMember)
            Return _binding(ctrl, False)
        End Function

#End Region
#Region " NumericUpDown "

        Public Overloads Function Binding(ByVal ctrl As NumericUpDown, ByVal dataMember As String) As BindComponentContext
            _dataBinder.DataBinding(ctrl, dataMember)
            Return _binding(ctrl, False)
        End Function

#End Region

        ''' <summary>
        ''' コントロールとモデルをバインドする
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <param name="required"></param>
        Private Overloads Function _binding(ByVal ctrl As Component, ByVal required As Boolean) As BindComponentContext
            Dim bc As New BindComponentContext(Me, ctrl, ctrl, required)
            _controls.Add(ctrl, bc)
            Return bc
        End Function

#End Region

        ''' <summary>
        ''' 入力値検証
        ''' </summary>
        ''' <returns>ErrorIconAlignment.MiddleRight で検証します</returns>
        Public Function Verify() As Boolean
            Dim rc As Boolean = True

            For Each ctrl As BindComponentContext In _controls.Values
                _validator.ValidTypes = Util.ValidateTypes.None
                _validator.IgnoreValidTypes = Util.ValidateTypes.None

                If TypeOf ctrl.TargetControl Is Control Then
                    If ctrl.Required Then
                        _validator.ValidTypes = Util.ValidateTypes.Required
                    Else
                        _validator.IgnoreValidTypes = Util.ValidateTypes.Required
                    End If
                    If Not _validator.IsValid(CType(ctrl.TargetControl, Control), ctrl.MessageControl) Then
                        rc = False
                        Continue For
                    End If
                End If
                'If TypeOf ctrl.TargetControl Is RadioButtonGroup Then
                '    Dim rbg As RadioButtonGroup = ctrl.TargetControl
                '    If ctrl.Required Then
                '        _validator.ValidTypes = ValidateTypes.Required
                '    Else
                '        _validator.IgnoreValidTypes = ValidateTypes.Required
                '    End If
                '    If Not _validator.IsValid(rbg, ctrl.MessageControl) Then
                '        rc = False
                '        Continue For
                '    End If
                'End If

                For Each verifyContext As ComponentVerifyContext In ctrl.Verify
                    If Not _validator.IsValid(ctrl.TargetControl, verifyContext.Verify) Then
                        rc = False
                        If verifyContext.ContinueOnVerifyFailure Then
                            Continue For
                        End If
                        Exit For
                    End If
                Next

                Dim e As New ControlValidatingEventArgs(ctrl.TargetControl, _validator)
                e.IsValid = True
                OnVerifyControl(e)
                If Not e.IsValid Then
                    rc = False
                End If
                If rc Then
                    Continue For
                End If
                If ctrl.ContinueOnVerifyFailure Then
                    Continue For
                End If
                Exit For
            Next

            Return rc
        End Function

        ''' <summary>
        ''' 検証イベント
        ''' </summary>
        ''' <param name="e"></param>
        Protected Overridable Sub OnVerifyControl(ByVal e As ControlValidatingEventArgs)
            RaiseEvent VerifyControl(Me, e)
        End Sub

#End Region

    End Class

End Namespace
