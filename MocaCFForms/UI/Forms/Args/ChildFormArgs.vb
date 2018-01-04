
Namespace Win

    ''' <summary>
    ''' 子画面への引数
    ''' </summary>
    Public Class ChildFormArgs

#Region " Declare "

        Private _command As CommandType
        Private _value As Object
        Private _parent As CoreForm

#End Region

#Region " コンストラクタ "

        '''' <summary>
        '''' コンストラクタ
        '''' </summary>
        '''' <param name="args"></param>
        'Public Sub New(ByVal args As SubFormArgs)
        '    Me.New(args.Command, args.Value, args.Parent)
        '    _ReadOnly = args.ReadOnly
        'End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="parent"></param>
        Public Sub New(ByVal value As Object, ByVal parent As CoreForm)
            Me.New(CommandType.None, value, parent)
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="command"></param>
        ''' <param name="value"></param>
        ''' <param name="parent"></param>
        Public Sub New(ByVal command As CommandType, ByVal value As Object, ByVal parent As CoreForm)
            _command = command
            _value = value
            _parent = parent
            _ReadOnly = False
        End Sub

#End Region

#Region " Property "

        ''' <summary>
        ''' 処理区分
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Command() As CommandType
            Get
                Return _command
            End Get
        End Property

        ''' <summary>
        ''' 子画面へ引継ぐデータ
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Value() As Object
            Get
                Return _value
            End Get
        End Property

        ''' <summary>
        ''' 親画面
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Parent() As CoreForm
            Get
                Return _parent
            End Get
        End Property

        ''' <summary>
        ''' 新規追加か？
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsNew() As Boolean
            Get
                Return (Command = CommandType.New)
            End Get
        End Property

        ''' <summary>
        ''' 変更か？
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsEdit() As Boolean
            Get
                Return (Command = CommandType.Edit)
            End Get
        End Property

        ''' <summary>
        ''' 流用か？
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsCopy() As Boolean
            Get
                Return (Command = CommandType.Copy)
            End Get
        End Property

        ''' <summary>
        ''' 読取専用
        ''' </summary>
        ''' <returns></returns>
        Public Property [ReadOnly]() As Boolean
            Get

            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property
        Private _ReadOnly As Boolean

#End Region

#Region " Method "

        ''' <summary>
        ''' 指定された型で Value を返します
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <returns></returns>
        Public Function CValue(Of T)() As T
            Return DirectCast(Value, T)
        End Function

#End Region

    End Class

End Namespace
