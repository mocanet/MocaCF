
Imports System.Windows.Forms
Imports System.Drawing

Namespace Win

    ''' <summary>
    ''' Label コントロール拡張版
    ''' </summary>
    ''' <remarks></remarks>
    Public Class LabelEx
        Inherits Label

#Region " Declare "

        Private _bottomBorderColor As Color
        Private _bottomBorder As Label

#End Region

#Region " コンストラクタ "

        ''' <summary>
        ''' デフォルトコンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()

            'この呼び出しは、コンポーネント デザイナで必要です。
            InitializeComponent()

            If UIHelper.DesignMode(Me) Then
                Return
            End If
        End Sub

        'Component は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()

                    If _bottomBorder IsNot Nothing Then
                        _bottomBorder.Dispose()
                    End If
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'コンポーネント デザイナで必要です。
        Private components As System.ComponentModel.IContainer

        'メモ: 以下のプロシージャはコンポーネント デザイナで必要です。
        'コンポーネント デザイナを使って変更できます。
        'コード エディタを使って変更しないでください。
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Me.SuspendLayout()

            _bottomBorder = New Label()
            With _bottomBorder
                .Anchor = AnchorStyles.Top Or AnchorStyles.Left
                .Height = 1
                .Dock = DockStyle.Bottom
                .Font = Font
                .BackColor = BottomBorderColor
                .Location = New Point(0, 0)
                .Size = New Size(1, 1)
                .Text = String.Empty
                .Name = Me.Name & "BottomBorder"
                .Visible = Not BottomBorderColor.Equals(Color.Empty)
            End With

            Try
                Controls.Add(_bottomBorder)
                _bottomBorder.Visible = True
            Catch ex As Exception
            End Try

            Me.ResumeLayout(False)
        End Sub

#End Region

#Region " Property "

        Public Property BottomBorderColor() As Color
            Get
                Return _bottomBorderColor
            End Get
            Set(ByVal value As Color)
                _bottomBorderColor = value
                _bottomBorder.BackColor = _bottomBorderColor
                Invalidate()
            End Set
        End Property

#End Region

#Region " Overrides "

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            _bottomBorder.Height = 1
        End Sub

        Private _AddHandler As Boolean

        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)
            MyBase.OnParentChanged(e)

            If _AddHandler Then
                Return
            End If
            If Parent Is Nothing Then
                Return
            End If
            _showBottomBorder()
            AddHandler Parent.GotFocus, AddressOf _parentGotFocus
            _AddHandler = True
        End Sub

        Private Sub _parentGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            _showBottomBorder()
        End Sub

#End Region

        Private Sub _showBottomBorder()
            Try
                If Parent Is Nothing Then
                    Return
                End If
                If _bottomBorder.Parent IsNot Nothing Then
                    Return
                End If
                If _bottomBorderColor.Equals(Color.Empty) Then
                    _bottomBorder.Visible = False
                    Return
                End If
                'If Not Visible Then
                '    Return
                'End If

                _bottomBorder.Visible = True
                _bottomBorder.Dock = DockStyle.None
                _bottomBorder.Top = Me.Top + Me.Height - 1
                _bottomBorder.Left = Me.Left
                _bottomBorder.Width = Me.Width
                Parent.Controls.Add(_bottomBorder)
                _bottomBorder.BringToFront()
            Catch ex As System.ObjectDisposedException
                ' 画面を閉じると発生してしまうが回避方法がつかめないので Try-Catch
            End Try
        End Sub

    End Class

End Namespace
