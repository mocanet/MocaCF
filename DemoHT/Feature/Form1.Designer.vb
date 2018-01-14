<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer
    private mainMenu1 As System.Windows.Forms.MainMenu

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタでこのプロシージャを変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.ActionButton1 = New Moca.Win.ActionButton
        Me.ComboBoxEx1 = New Moca.Win.ComboBoxEx
        Me.DataGridEx1 = New Moca.Win.DataGridEx
        Me.LabelEx1 = New Moca.Win.LabelEx
        Me.NumericUpDownEx1 = New Moca.Win.NumericUpDownEx
        Me.TextBoxEx1 = New Moca.Win.TextBoxEx
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(51, 322)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(236, 87)
        Me.ActionButton1.TabIndex = 0
        Me.ActionButton1.Text = "ActionButton1"
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.Location = New System.Drawing.Point(51, 251)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(167, 23)
        Me.ComboBoxEx1.TabIndex = 1
        '
        'DataGridEx1
        '
        Me.DataGridEx1.AlterNatingColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridEx1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridEx1.Columns = Nothing
        Me.DataGridEx1.DataSource = Nothing
        Me.DataGridEx1.Location = New System.Drawing.Point(353, 199)
        Me.DataGridEx1.Name = "DataGridEx1"
        Me.DataGridEx1.Size = New System.Drawing.Size(250, 169)
        Me.DataGridEx1.TabIndex = 2
        '
        'LabelEx1
        '
        Me.LabelEx1.BottomBorderColor = System.Drawing.Color.Empty
        Me.LabelEx1.Location = New System.Drawing.Point(391, 108)
        Me.LabelEx1.Name = "LabelEx1"
        Me.LabelEx1.Size = New System.Drawing.Size(194, 66)
        Me.LabelEx1.Text = "LabelEx1"
        '
        'NumericUpDownEx1
        '
        Me.NumericUpDownEx1.Location = New System.Drawing.Point(395, 31)
        Me.NumericUpDownEx1.Name = "NumericUpDownEx1"
        Me.NumericUpDownEx1.Size = New System.Drawing.Size(189, 24)
        Me.NumericUpDownEx1.TabIndex = 4
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.Location = New System.Drawing.Point(214, 92)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Size = New System.Drawing.Size(154, 23)
        Me.TextBoxEx1.TabIndex = 5
        Me.TextBoxEx1.TextChangedCompleteDelay = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.TextBoxEx1)
        Me.Controls.Add(Me.NumericUpDownEx1)
        Me.Controls.Add(Me.LabelEx1)
        Me.Controls.Add(Me.DataGridEx1)
        Me.Controls.Add(Me.ComboBoxEx1)
        Me.Controls.Add(Me.ActionButton1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton
    Friend WithEvents ComboBoxEx1 As Moca.Win.ComboBoxEx
    Friend WithEvents DataGridEx1 As Moca.Win.DataGridEx
    Friend WithEvents LabelEx1 As Moca.Win.LabelEx
    Friend WithEvents NumericUpDownEx1 As Moca.Win.NumericUpDownEx
    Friend WithEvents TextBoxEx1 As Moca.Win.TextBoxEx

End Class
