Imports System.Windows.Forms
Imports Moca.Win

Namespace Win

    Public Class DataColumnSettingEventArgs
        Inherits EventArgs

        ''' <summary>列位置</summary>
        Public Property Index() As Integer
            Get

            End Get
            Set(ByVal value As Integer)

            End Set
        End Property
        Private _Index As Integer

        ''' <summary>列情報</summary>
        Public Property Column() As DataGridColumnStyle
            Get
                Return _Column
            End Get
            Set(ByVal value As DataGridColumnStyle)
                _Column = value
            End Set
        End Property
        Private _Column As DataGridColumnStyle

        ''' <summary>プロパティ</summary>
        Public Property Attribute() As ColumnStyleAttribute
            Get
                Return _Attribute
            End Get
            Set(ByVal value As ColumnStyleAttribute)
                _Attribute = value
            End Set
        End Property
        Private _Attribute As ColumnStyleAttribute

        ''' <summary>テキストボックスのときは DataGridExTextBoxColumn。違うときは Nothing</summary>
        Public ReadOnly Property TextBox() As DataGridExTextBoxColumn
            Get
                Return TryCast(Me.Column, DataGridExTextBoxColumn)
            End Get
        End Property

    End Class

End Namespace
