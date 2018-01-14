
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Moca.Util
Imports Moca.Win
Imports System.Reflection
Imports Moca.Db.Attr
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' DataGrid コントロール拡張版
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DataGridEx
        Inherits DataGrid
        Implements ISupportInitialize

#Region " Declare "

        ''' <summary>グリッドの列定義列挙</summary>
        Private _columnCaptions As [Enum]

        Private _tableStyle As System.Windows.Forms.DataGridTableStyle

#Region " Events "

        ''' <summary>
        ''' DataColumn の列情報設定イベント
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Public Event DataColumnSetting(ByVal sender As Object, ByVal e As DataColumnSettingEventArgs)

#End Region

#End Region

#Region " Implements ISupportInitialize "

        Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit
        End Sub

        Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit
        End Sub

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            If UIHelper.DesignMode(Me) Then
                Return
            End If

            _tableStyle = New System.Windows.Forms.DataGridTableStyle

            Dim fi As Reflection.FieldInfo = Me.GetType().GetField("m_sbVert", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.GetField Or Reflection.BindingFlags.Instance)
            _VScrollBar = CType(fi.GetValue(Me), VScrollBar)
        End Sub

#End Region

        Protected Overrides Sub OnCurrentCellChanged(ByVal e As System.EventArgs)
            If DataSource IsNot Nothing Then
                If Not DataSource.Rows.Count.Equals(0) Then
                    ClearSelected()
                    [Select](CurrentCell.RowNumber)
                End If
            End If

            MyBase.OnCurrentCellChanged(e)
        End Sub

        Public Sub ClearSelected()
            If DataSource Is Nothing Then
                Return
            End If

            For ii As Integer = 0 To DataSource.Rows.Count - 1
                UnSelect(ii)
            Next
        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            If DataSource IsNot Nothing Then
                If Not DataSource.Rows.Count.Equals(0) Then
                    [Select](CurrentCell.RowNumber)
                End If
            End If

            MyBase.OnLostFocus(e)
        End Sub

        Public Shadows Property DataSource() As DataTable
            Get
                Return MyBase.DataSource
            End Get
            Set(ByVal value As DataTable)
                MyBase.DataSource = value
                If value Is Nothing Then
                    Return
                End If
                _tableStyle.MappingName = value.TableName
                TableStyles.Clear()
                TableStyles.Add(_tableStyle)
            End Set
        End Property

#Region " Property "

        ''' <summary>
        ''' グリッドの列定義列挙
        ''' </summary>
        Public Property Columns() As [Enum]
            Get
                Return _columnCaptions
            End Get
            Set(ByVal value As [Enum])
                _columnCaptions = value
                If value Is Nothing Then
                    Return
                End If
                ' 列セットアップ
                _setColumns()
            End Set
        End Property

        Public Property AlterNatingColor() As Color
            Get
                Return _alternatingColor
            End Get
            Set(ByVal value As Color)
                _alternatingColor = value
            End Set
        End Property
        Private _alternatingColor As Color = Color.WhiteSmoke

        Public ReadOnly Property TableStyle() As DataGridTableStyle
            Get
                Return _tableStyle
            End Get
        End Property

        Public ReadOnly Property VScrollBar() As VScrollBar
            Get
                Return _VScrollBar
            End Get
        End Property
        Private _VScrollBar As VScrollBar

#End Region

#Region " Method "

        Public Sub ScrollUp()
            VScrollBar.Value -= Me.VisibleRowCount

            '[Select](VScrollBar.Value)
            CurrentCell = New DataGridCell(VScrollBar.Value, 0)
        End Sub

        Public Sub ScrollDown()
            VScrollBar.Value += Me.VisibleRowCount

            '[Select](VScrollBar.Value)
            CurrentCell = New DataGridCell(VScrollBar.Value, 0)
        End Sub

        ''' <summary>
        ''' データテーブルの列定義設定
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub _setColumns()
            Dim args As DataColumnSettingEventArgs

            _tableStyle.GridColumnStyles.Clear()
            Me.TableStyles.Clear()

            args = New DataColumnSettingEventArgs

            For Each value As [Enum] In VBUtil.GetValues(Me.Columns)
                Dim caption As String
                Dim mappingName As String
                Dim typ As Type
                Dim field As FieldInfo

                typ = value.GetType()
                field = typ.GetField(value.ToString())

                caption = value.ToString
                Dim attrTitle As DisplayNameAttribute
                attrTitle = ClassUtil.GetCustomAttribute(Of DisplayNameAttribute)(field)
                If attrTitle IsNot Nothing Then
                    caption = attrTitle.DisplayName
                End If

                mappingName = value.ToString
                Dim attrCol As ColumnAttribute
                attrCol = ClassUtil.GetCustomAttribute(Of ColumnAttribute)(field)
                If attrCol IsNot Nothing Then
                    mappingName = attrCol.ColumnName
                End If

                Dim attrColStyle As ColumnStyleAttribute
                attrColStyle = ClassUtil.GetCustomAttribute(Of ColumnStyleAttribute)(field)
                If attrColStyle Is Nothing Then
                    attrColStyle = New ColumnStyleAttribute()
                End If

                'TODO: カスタムがうまく動かないので標準で実装中
                'Dim column As New DataGridExTextBoxColumn
                Dim column As New DataGridTextBoxColumn
                With column
                    '.Owner = Me
                    .HeaderText = caption
                    .MappingName = mappingName
                    .FormatInfo = Nothing
                    .Format = attrColStyle.Format
                    .NullText = attrColStyle.NullValue
                    '.Alignment = attrColStyle.Align
                    If attrColStyle.Width >= 0 Then
                        .Width = attrColStyle.Width
                    End If
                    '.AlternatingBackColor = _alternatingColor
                    '.ReadOnly = True
                End With
                Dim ii As Integer
                ii = _tableStyle.GridColumnStyles.Add(column)

                ' 列のデフォルト値やその他設定
                args.Index = ii
                args.Column = column
                args.Attribute = attrColStyle
                RaiseEvent DataColumnSetting(Me, args)
            Next
        End Sub

#End Region

    End Class

End Namespace
