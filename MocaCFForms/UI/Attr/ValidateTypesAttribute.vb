
'Imports Moca.Util

Namespace Win

    ''' <summary>
    ''' 検証列属性
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False)> _
    Public Class ValidateTypesAttribute
        Inherits Attribute

#Region " コンストラクタ "

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="validateTypes ">検証。省略時は ValidateTypes.None</param>
        ''' <param name="min">最小値検証するときの値</param>
        ''' <param name="max">最大値検証するときの値</param>
        ''' <param name="errorDispControlName">エラー表示するコントロールが別の時のコントロール名</param>
        ''' <param name="tableColumnName">テーブル列名</param>
        ''' <param name="tableDefinitionFieldName">関連するテーブルの列名を取得するテーブル定義フィールド名</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal validateTypes As Util.ValidateTypes, Optional ByVal min As Object = Nothing, Optional ByVal max As Object = Nothing, Optional ByVal errorDispControlName As String = Nothing, Optional ByVal tableColumnName As String = Nothing, Optional ByVal tableDefinitionFieldName As String = Nothing)
            _ValidateTypes = validateTypes
            _Min = min
            _Max = max
            _ErrorDispControlName = errorDispControlName
            _TableColumnName = tableColumnName
            _TableDefinitionFieldName = tableDefinitionFieldName
        End Sub

#End Region

#Region " Property "

        ''' <summary>検証</summary>
        Public Property ValidateTypes() As Util.ValidateTypes
            Get
                Return _ValidateTypes
            End Get
            Set(ByVal value As Util.ValidateTypes)
                _ValidateTypes = value
            End Set
        End Property
        Private _ValidateTypes As Util.ValidateTypes


        ''' <summary> 
        ''' 最小値検証するときの値 
        ''' </summary> 
        Public Property Min() As Object
            Get
                Return _Min
            End Get
            Set(ByVal value As Object)
                _Min = value
            End Set
        End Property
        Private _Min As Object

        ''' <summary> 
        ''' 最大値検証するときの値
        ''' </summary> 
        Public Property Max() As Object
            Get
                Return _Max
            End Get
            Set(ByVal value As Object)
                _Max = value
            End Set
        End Property
        Private _Max As Object

        ''' <summary>
        ''' エラー表示するコントロールが別の時のコントロール名
        ''' </summary>
        ''' <returns></returns>
        Public Property ErrorDispControlName() As String
            Get
                Return _ErrorDispControlName
            End Get
            Set(ByVal value As String)
                _ErrorDispControlName = value
            End Set
        End Property
        Private _ErrorDispControlName As String

        ''' <summary>
        ''' 関連するテーブルの列名
        ''' </summary>
        ''' <returns></returns>
        Public Property TableColumnName() As String
            Get
                Return _TableColumnName
            End Get
            Set(ByVal value As String)
                _TableColumnName = value
            End Set
        End Property
        Private _TableColumnName As String

        ''' <summary>
        ''' 関連するテーブルの列名を取得するテーブル定義フィールド名
        ''' </summary>
        ''' <returns></returns>
        Public Property TableDefinitionFieldName() As String
            Get
                Return _TableDefinitionFieldName
            End Get
            Set(ByVal value As String)
                _TableDefinitionFieldName = value
            End Set
        End Property
        Private _TableDefinitionFieldName As String

#End Region

    End Class

End Namespace
