
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
        End Sub

#End Region

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
                .Visible = True
            End With

            Try
                Controls.Add(_bottomBorder)
            Catch ex As Exception
            End Try

            Me.ResumeLayout(False)
        End Sub

#Region " Property "

        Public Property BottomBorderColor() As Color
            Get
                Return _bottomBorderColor
            End Get
            Set(ByVal value As Color)
                _bottomBorderColor = value
                _bottomBorder.BackColor = _bottomBorderColor
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
            AddHandler Parent.GotFocus, AddressOf _parentGotFocus
            _AddHandler = True
        End Sub

        Private Sub _parentGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
            ShowBottomBorder()
        End Sub

#End Region

        Private Sub ShowBottomBorder()
            Try
                If _bottomBorder.Parent IsNot Nothing Then
                    Return
                End If
                If _bottomBorderColor.Equals(Color.Empty) Then
                    Return
                End If

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


        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim g As Graphics = e.Graphics
            Dim brush As New SolidBrush(Color.Black)
            Dim format As New StringFormat()

            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center
            xDrawString(Text, Font, brush, g, e.ClipRectangle, format)

            'MyBase.OnPaint(e)
        End Sub

        Private Sub xDrawString(ByVal text As String, ByVal font As Font, _
            ByVal brush As SolidBrush, ByVal g As Graphics, _
            ByVal rec As Rectangle, ByVal format As StringFormat)

            If text.IndexOf(vbLf) > 0 Then
                'Multi Line
                'Make array of lines
                Dim strArray() As String
                strArray = text.Split(vbLf)

                'make a new rec the size of one line
                Dim lineSize As SizeF = g.MeasureString(strArray(0), font)
                Dim lineRec As New Rectangle
                lineRec = rec
                lineRec.Height = lineSize.Height

                'Set the top of the first line
                Dim firstLineTop As Integer
                Select Case format.LineAlignment

                    Case StringAlignment.Near
                        firstLineTop = rec.Top

                    Case StringAlignment.Center
                        firstLineTop = (rec.Height / 2) - ((lineSize.Height * strArray.Length) / 2) + rec.Top

                    Case StringAlignment.Far
                        firstLineTop = (rec.Height) - (lineSize.Height * (strArray.Length)) + rec.Top
                End Select

                'Draw all lines
                Dim i As Integer
                format.LineAlignment = StringAlignment.Near

                For i = 0 To strArray.Length - 1
                    lineRec.Location = New Point(lineRec.Left, (lineSize.Height * i) + firstLineTop)
                    g.DrawString(strArray(i), font, brush, lineRec, format)
                Next

            Else
                'One line
                g.DrawString(text, font, brush, rec, format)
            End If

        End Sub

    End Class

End Namespace
