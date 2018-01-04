Imports System.Windows.Forms
Imports System.Drawing

Namespace Win

    Public MustInherit Class DataGridExColumnBase
        Inherits DataGridTextBoxColumn

        Private _bounds As Rectangle = Rectangle.Empty

        Public Property Owner() As DataGrid
            Get
                Return _owner
            End Get
            Set(ByVal value As DataGrid)
                _owner = value
            End Set
        End Property
        Private _owner As DataGrid

        Public Property [ReadOnly]() As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                invalidate()
            End Set
        End Property
        Private _ReadOnly As Boolean

        Public ReadOnly Property ColumnOrdinal() As Integer
            Get
                If _ColumnOrdinal = 1 And Owner IsNot Nothing Then
                    For Each table As DataGridTableStyle In Owner.TableStyles
                        _ColumnOrdinal = table.GridColumnStyles.IndexOf(Me)
                        If _ColumnOrdinal <> -1 Then
                            Exit For
                        End If
                    Next
                End If
                Return _ColumnOrdinal
            End Get
        End Property
        Private _ColumnOrdinal As Integer

        Public Property AlternatingBackColor() As Color
            Get
                Return _alternatingBackColor
            End Get
            Set(ByVal value As Color)
                If _alternatingBackColor = value Then
                    Return
                End If

                _alternatingBackColor = value
                If _alternatingBrush IsNot Nothing Then
                    _alternatingBrush.Dispose()
                End If
                _alternatingBrush = New SolidBrush(value)
                invalidate()
            End Set
        End Property
        Private _alternatingBackColor As Color = Color.WhiteSmoke
        Private _alternatingBrush As SolidBrush = Nothing

        Public ReadOnly Property StringFormat() As StringFormat
            Get
                If _stringFormat Is Nothing Then
                    _stringFormat = New StringFormat()
                    Alignment = HorizontalAlignment.Left
                End If
                Return _stringFormat
            End Get
        End Property
        Private _stringFormat As StringFormat

        Public Property Alignment() As HorizontalAlignment
            Get
                Return IIf(StringFormat.Alignment = StringAlignment.Center, HorizontalAlignment.Center, _
                           IIf(StringFormat.Alignment = StringAlignment.Far, HorizontalAlignment.Right, HorizontalAlignment.Left))
            End Get
            Set(ByVal value As HorizontalAlignment)
                If Alignment = value Then
                    Return
                End If
                StringFormat.Alignment = IIf(value = HorizontalAlignment.Center, StringAlignment.Center, _
                                             IIf(value = HorizontalAlignment.Right, StringAlignment.Far, StringAlignment.Near))
                invalidate()
            End Set
        End Property

        Public Property NullValue() As Object
            Get
                Return NullText
            End Get
            Set(ByVal value As Object)
                NullText = value.ToString
            End Set
        End Property

        Public ReadOnly Property HostedControl() As Control
            Get
                If _HostedControl Is Nothing And Owner IsNot Nothing Then
                    _HostedControl = CreateHostedControl()

                    _HostedControl.Visible = False
                    _HostedControl.Name = HeaderText
                    _HostedControl.Font = Owner.Font

                    Owner.Controls.Add(_HostedControl)

                    _HostedControl.DataBindings.Add(GetBoundPropertyName(), Owner.DataSource, MappingName, True, DataSourceUpdateMode.OnValidation, NullValue)

                    Dim horisonal As HScrollBar = Nothing

                    For Each c As Control In Owner.Controls
                        If TypeOf c Is HScrollBar Then
                            horisonal = c
                            AddHandler horisonal.ValueChanged, New EventHandler(AddressOf gridScrolled)
                            Exit For
                        End If
                    Next
                End If
                Return _HostedControl
            End Get
        End Property
        Private _HostedControl As Control

        Protected MustOverride Function CreateHostedControl() As Control
        Protected MustOverride Function GetBoundPropertyName() As String

        Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            'MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            Dim textBounds As RectangleF
            Dim cellData As Object

            DrawBackground(g, bounds, rowNum, backBrush)

            bounds.Inflate(-2, -2)

            textBounds = New RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height)

            cellData = PropertyDescriptor.GetValue(source.List(rowNum))

            g.DrawString(formatText(cellData), Owner.Font, foreBrush, textBounds, StringFormat)

            updateHostedControl()
        End Sub

        Protected Function formatText(ByVal cellData As Object) As String
            Dim cellText As String

            If String.IsNullOrEmpty(cellData) Then
                cellText = NullText
            ElseIf TypeOf cellData Is IFormattable Then
                cellText = CType(cellData, IFormattable).ToString(Format, FormatInfo)
            ElseIf TypeOf cellData Is IConvertible Then
                cellText = CType(cellData, IConvertible).ToString(FormatInfo)
            Else
                cellText = cellData.ToString()
            End If
            Return cellText
        End Function

        Protected Sub DrawBackground(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush)
            Dim background As Brush = backBrush

            If _alternatingBrush IsNot Nothing And (rowNum Mod 2) <> 0 And Not Owner.IsSelected(rowNum) Then
                background = _alternatingBrush
            End If
            g.FillRectangle(background, bounds)
        End Sub

        Protected Sub updateHostedControl()
            Dim selectedBounds As Rectangle = Owner.GetCellBounds(Owner.CurrentCell.RowNumber, Owner.CurrentCell.ColumnNumber)

            If [ReadOnly] _
                And ColumnOrdinal = Owner.CurrentCell.ColumnNumber _
                And Owner.HitTest(selectedBounds.Left, selectedBounds.Top).Type = DataGrid.HitTestType.Cell _
                And Owner.HitTest(selectedBounds.Right, selectedBounds.Bottom).Type = DataGrid.HitTestType.Cell Then
                If selectedBounds <> _bounds Then
                    _bounds = selectedBounds

                    HostedControl.Bounds = selectedBounds

                    HostedControl.Focus()
                    HostedControl.Update()
                End If
                If Not HostedControl.Visible Then
                    HostedControl.Show()
                    HostedControl.Focus()
                End If
            ElseIf HostedControl.Visible Then
                HostedControl.Hide()
            End If
        End Sub

        Protected Sub invalidate()
            Owner.Invalidate()
        End Sub

        Private Sub gridScrolled(ByVal sender As Object, ByVal e As EventArgs)
            updateHostedControl()
        End Sub

    End Class

End Namespace
