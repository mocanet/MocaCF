Imports System.Windows.Forms


Namespace Win

    Public Class DataBinder

#Region " Declare "

        ''' <summary>フォームのデータ ソースをカプセル化</summary>
        Private _bindSrc As BindingSource

        'Private _ds As DataSet

        Private _lst As Object

#End Region
#Region " プロパティ "

        Public Property BindSrc() As System.Windows.Forms.BindingSource
            Get
                If _bindSrc Is Nothing Then
                    _bindSrc = New BindingSource()
                End If
                Return Me._bindSrc
            End Get
            Set(ByVal value As System.Windows.Forms.BindingSource)
                Me._bindSrc = value
            End Set
        End Property

        ''' <summary>
        ''' バインドするデータソース
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataSource() As Object
            Get
                Return Me.BindSrc.DataSource
            End Get
            Set(ByVal value As Object)
                _lst = value

                Me.BindSrc.DataSource = value
                AcceptChanges()
            End Set
        End Property

        ''' <summary>
        ''' バインドするデータソースのメンバ名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DataMember() As String
            Get
                Return Me.BindSrc.DataMember
            End Get
            Set(ByVal value As String)
                Me.BindSrc.DataMember = value
            End Set
        End Property

        ''' <summary>
        ''' 現在行位置
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Position() As Integer
            Get
                Return Me.BindSrc.CurrencyManager.Position
            End Get
            Set(ByVal value As Integer)
                Me.BindSrc.CurrencyManager.Position = value
            End Set
        End Property

        ''' <summary>
        ''' 現在行データ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentRow() As DataRow
            Get
                If _current Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf _current Is DataRowView Then
                    Throw New ApplicationException("TypeOf Is Not DataRowView")
                End If
                Return DirectCast(_current, DataRowView).Row
            End Get
        End Property

        ''' <summary>
        ''' 現在行データ
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CurrentEntity(Of T)() As T
            If _current Is Nothing Then
                Return Nothing
            End If
            Return DirectCast(_current, T)
        End Function

        ''' <summary>
        ''' 現在行データ
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property _current() As Object
            Get
                If Me.BindSrc.Current Is Nothing Then
                    Return Nothing
                End If
                Return DirectCast(Me.BindSrc.Current, DataRowView).Row
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property _currentEditableObject() As System.ComponentModel.IEditableObject
            Get
                Return DirectCast(Me.BindSrc.Current, System.ComponentModel.IEditableObject)
            End Get
        End Property

#End Region
#Region " データ編集状態制御 "

        ''' <summary>
        ''' 現在行の編集終了
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EndCurrentEdit()
            Me.BindSrc.CurrencyManager.EndCurrentEdit()
            Me._currentEditableObject.EndEdit()
        End Sub

        ''' <summary>
        ''' 現在行の編集終了
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EndEdit()
            If _currentEditableObject Is Nothing Then
                Return
            End If
            Me._currentEditableObject.EndEdit()
        End Sub

        ''' <summary>
        ''' 新しい行、削除された行、変更された行などの変更があるかどうかを示す値を取得します。
        ''' </summary>
        ''' <returns>変更がある場合は true。それ以外の場合は false。</returns>
        ''' <remarks></remarks>
        Public Function HasChanges() As Boolean
            If _lst Is Nothing Then
                Return False
            End If
            If TypeOf _lst Is DataTable Then
                Return CType(_lst, DataTable).DataSet.HasChanges
            Else
                Throw New ApplicationException()
            End If
        End Function

        ''' <summary>
        ''' データソース全体の変更をコミットする 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        Public Sub AcceptChanges()
            Me.BindSrc.EndEdit()
            Dim dt As DataTable = Me.BindSrc.DataSource
            dt.AcceptChanges()
        End Sub

        ''' <summary>
        ''' 現在行の変更をコミットする 
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        Public Sub AcceptChangesRow()
            Me._currentEditableObject.EndEdit()
        End Sub

        ''' <summary>
        ''' データソース全体で前回 AcceptChanges を呼び出した以降にこのデータに対して行われたすべての変更をロールバックします。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RejectChanges()
            Me.BindSrc.CancelEdit()
        End Sub

        ''' <summary>
        ''' 現在行で前回 AcceptChanges を呼び出した以降にこのデータに対して行われたすべての変更をロールバックします。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RejectChangesRow()
            Me._currentEditableObject.CancelEdit()
        End Sub

#End Region
#Region " データ移動制御 "

        ''' <summary>
        ''' リストの次の項目に移動します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveNext()
            Me.BindSrc.MoveNext()
        End Sub

        ''' <summary>
        ''' リストの前の項目に移動します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MovePrevious()
            Me.BindSrc.MovePrevious()
        End Sub

        ''' <summary>
        ''' リストの最初の項目に移動します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveFirst()
            Me.BindSrc.MoveFirst()
        End Sub

        ''' <summary>
        ''' リストの最後の項目に移動します。
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveLast()
            Me.BindSrc.MoveLast()
        End Sub

#End Region
#Region " データバインディング "

        ''' <summary>
        ''' Label のデータバインディング
        ''' </summary>
        ''' <param name="ctrl">Label</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks></remarks>
        Public Sub DataBinding(ByVal ctrl As Label, ByVal dataMember As String, Optional ByVal dataSourceNullValue As Object = Nothing, Optional ByVal nullValue As Object = Nothing, Optional ByVal formatString As String = "")
            '_dataBinding(ctrl, "Text", dataMember, dataSourceNullValue, nullValue, formatString)
            _dataBinding(ctrl, "Text", dataMember, True, dataSourceNullValue, nullValue, formatString)
        End Sub

        ''' <summary>
        ''' TextBox のデータバインディング
        ''' </summary>
        ''' <param name="ctrl">TextBox</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks></remarks>
        Public Sub DataBinding(ByVal ctrl As TextBox, ByVal dataMember As String, Optional ByVal dataSourceNullValue As Object = Nothing, Optional ByVal nullValue As Object = Nothing, Optional ByVal formatString As String = "")
            _dataBinding(ctrl, "Text", dataMember, dataSourceNullValue, nullValue, formatString)
        End Sub

        ''' <summary>
        ''' ComboBox のデータバインディング
        ''' </summary>
        ''' <param name="ctrl">ComboBox</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks></remarks>
        Public Sub DataBinding(ByVal ctrl As ComboBox, ByVal dataMember As String, Optional ByVal dataSourceNullValue As Object = Nothing, Optional ByVal nullValue As Object = Nothing)
            Dim propertyName As String
            If ctrl.DropDownStyle = ComboBoxStyle.DropDownList Then
                If ctrl.DataSource Is Nothing Then
                    propertyName = "SelectedItem"
                Else
                    propertyName = "SelectedValue"
                End If
            Else
                propertyName = "Text"
            End If
            _dataBinding(ctrl, propertyName, dataMember, True, dataSourceNullValue, nullValue)
        End Sub

        ''' <summary>
        ''' CheckBox のデータバインディング
        ''' </summary>
        ''' <param name="ctrl">CheckBox</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks></remarks>
        Public Sub DataBinding(ByVal ctrl As CheckBox, ByVal dataMember As String, Optional ByVal dataSourceNullValue As Object = Nothing, Optional ByVal nullValue As Object = Nothing)
            _dataBinding(ctrl, "Checked", dataMember, True, dataSourceNullValue, nullValue)
            '_dataBinding(ctrl, "CheckState", dataMember, True, dataSourceNullValue, nullValue)
        End Sub

        ''' <summary>
        ''' NumericUpDown のデータバインディング
        ''' </summary>
        ''' <param name="ctrl">NumericUpDown</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks></remarks>
        Public Sub DataBinding(ByVal ctrl As NumericUpDown, ByVal dataMember As String, Optional ByVal dataSourceNullValue As Object = Nothing, Optional ByVal nullValue As Object = Nothing, Optional ByVal formatString As String = "")
            _dataBinding(ctrl, "Value", dataMember, True, dataSourceNullValue, nullValue, formatString)
        End Sub

        ''' <summary>
        ''' データバインディングする
        ''' </summary>
        ''' <param name="obj">対象のコントロール</param>
        ''' <param name="propertyName">バインドするコントロールのプロパティ名</param>
        ''' <param name="dataMember">バインドするデータソースの項目名</param>
        ''' <param name="dataSourceNullValue">コントロールの値が null 参照 (Visual Basic では Nothing) または空の場合にデータ ソースに格納される値を取得または設定します。 </param>
        ''' <param name="nullValue">データ ソースに <see cref="DBNull"/> 値が格納されている場合にコントロール プロパティとして設定される <see cref="Object" /> を取得または設定します。</param>
        ''' <remarks>
        ''' コントロール プロパティの値が変更されるたびに、データ ソースが更新されます。
        ''' </remarks>
        Private Sub _dataBinding(ByVal obj As IBindableComponent, ByVal propertyName As String, ByVal dataMember As String, ByVal dataSourceNullValue As Object, ByVal nullValue As Object, Optional ByVal formatString As String = "")
            Dim bind As Binding
            bind = New Binding(propertyName, Me.BindSrc, dataMember)
            bind.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            bind.NullValue = nullValue
            bind.DataSourceNullValue = Nothing
            If dataSourceNullValue IsNot Nothing Then
                bind.DataSourceNullValue = dataSourceNullValue
            End If
            bind.FormattingEnabled = False
            If formatString.Length > 0 Then
                bind.FormattingEnabled = True
                bind.FormatString = formatString
            End If
            obj.DataBindings.Add(bind)
        End Sub

        Private Sub _dataBinding(ByVal obj As IBindableComponent, ByVal propertyName As String, ByVal dataMember As String, ByVal formattingEnabled As Boolean, ByVal dataSourceNullValue As Object, ByVal nullValue As Object, Optional ByVal formatString As String = "")
            Dim bind As Binding
            bind = New Binding(propertyName, Me.BindSrc, dataMember)
            bind.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            bind.NullValue = nullValue
            bind.DataSourceNullValue = Nothing
            If dataSourceNullValue IsNot Nothing Then
                bind.DataSourceNullValue = dataSourceNullValue
            End If
            bind.FormattingEnabled = formattingEnabled
            If formatString.Length > 0 Then
                bind.FormatString = formatString
            End If
            obj.DataBindings.Add(bind)
        End Sub

#End Region
#Region " Event "

        ''' <summary>
        ''' 値が変更されているときに発生します
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event ColumnChanging(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)

#End Region
#Region " Private Method "

        ''' <summary>
        ''' 値が変更されているときに発生します
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub _rowChanging(ByVal sender As Object, ByVal e As DataColumnChangeEventArgs)
            RaiseEvent ColumnChanging(sender, e)
        End Sub

#End Region

    End Class

End Namespace
