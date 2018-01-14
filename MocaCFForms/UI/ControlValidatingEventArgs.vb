Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Win

    ''' <summary>
    ''' ControlBinderの検証イベント引数
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ControlValidatingEventArgs
        Inherits EventArgs

        Private _Control As Control
        Private _Component As Component
        Private _Validator As FormValidator

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Public Sub New(ByVal ctrl As Component, ByVal validator As FormValidator)
            _Component = ctrl
            If TypeOf ctrl Is Control Then
                _Control = ctrl
            End If
            _Validator = validator
        End Sub

        ''' <summary>
        ''' 検証結果
        ''' </summary>
        ''' <returns></returns>
        Public Property IsValid() As Boolean
            Get
                Return _IsValid
            End Get
            Set(ByVal value As Boolean)
                _IsValid = value
            End Set
        End Property
        Private _IsValid As Boolean

        ''' <summary>
        ''' 検証対象のコントロール
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Control() As Control
            Get
                Return _Control
            End Get
        End Property

        ''' <summary>
        ''' 検証対象のコンポーネント
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Component() As Component
            Get
                Return _Component
            End Get
        End Property

        Public ReadOnly Property Validator() As FormValidator
            Get
                Return _Validator
            End Get
        End Property

    End Class

End Namespace
