Imports System.Windows.Forms

Namespace Win

    <AttributeUsage(AttributeTargets.Property Or AttributeTargets.Field, AllowMultiple:=False)> _
    Public Class ColumnStyleAttribute
        Inherits Attribute

#Region " コンストラクタ "

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="width">表示幅。省略時はGrid標準</param>
        ''' <param name="align">表示位置</param>
        ''' <param name="format">表示フォーマット式</param>
        ''' <param name="cellType">セルの種類</param>
        ''' <param name="wordWrap">改行の有無</param>
        ''' <param name="nullValue">Nullのときの値</param>
        ''' <remarks></remarks>
        Public Sub New(Optional ByVal width As Integer = -1, _
                       Optional ByVal align As HorizontalAlignment = HorizontalAlignment.Left, _
                       Optional ByVal format As String = "", _
                       Optional ByVal cellType As CellType = CellType.TextBox, _
                       Optional ByVal wordWrap As Boolean = False, _
                       Optional ByVal nullValue As Object = "" _
                       )
            Me.Width = width
            Me.Align = align
            Me.Format = format
            Me.CellType = cellType
            Me.WordWrap = wordWrap
            Me.NullValue = IIf(nullValue Is Nothing, String.Empty, nullValue)
        End Sub

#End Region

#Region " Property "

        ''' <summary>表示幅</summary>
        Public Property Width() As Integer
            Get
                Return _Width
            End Get
            Set(ByVal value As Integer)
                _Width = value
            End Set
        End Property
        Private _Width As Integer

        ''' <summary>表示位置</summary>
        Public Property Align() As HorizontalAlignment
            Get
                Return _Align
            End Get
            Set(ByVal value As HorizontalAlignment)
                _Align = value
            End Set
        End Property
        Private _Align As HorizontalAlignment

        ''' <summary>表示フォーマット式</summary>
        Public Property Format() As String
            Get
                Return _Format
            End Get
            Set(ByVal value As String)
                _Format = value
            End Set
        End Property
        Private _Format As String

        ''' <summary>セルの種類</summary>
        Public Property CellType() As CellType
            Get
                Return _CellType
            End Get
            Set(ByVal value As CellType)
                _CellType = value
            End Set
        End Property
        Private _CellType As CellType

        ''' <summary>改行の有無</summary>
        Public Property WordWrap() As Boolean
            Get
                Return _WordWrap
            End Get
            Set(ByVal value As Boolean)
                _WordWrap = value
            End Set
        End Property
        Private _WordWrap As Boolean

        ''' <summary>Nullのときの値</summary>
        Public Property NullValue() As Object
            Get
                Return _NullValue
            End Get
            Set(ByVal value As Object)
                _NullValue = value
            End Set
        End Property
        Private _NullValue As Object

#End Region

    End Class

End Namespace
