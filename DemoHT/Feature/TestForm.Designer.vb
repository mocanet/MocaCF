<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
    Inherits Moca.Win.ChildForm

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ComboBoxEx1 = New Moca.Win.ComboBoxEx
        Me.TextBoxEx1 = New Moca.Win.TextBoxEx
        Me.ActionButton1 = New Moca.Win.ActionButton
        Me.ActionButton2 = New Moca.Win.ActionButton
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.ActionButton2)
        Me.pnlContents.Controls.Add(Me.ComboBoxEx1)
        Me.pnlContents.Controls.Add(Me.TextBoxEx1)
        Me.pnlContents.Controls.Add(Me.ActionButton1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.Location = New System.Drawing.Point(16, 211)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(181, 23)
        Me.ComboBoxEx1.TabIndex = 2
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.Location = New System.Drawing.Point(16, 117)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Size = New System.Drawing.Size(206, 23)
        Me.TextBoxEx1.TabIndex = 0
        Me.TextBoxEx1.TextChangedCompleteDelay = 0
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(16, 146)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(168, 59)
        Me.ActionButton1.TabIndex = 1
        Me.ActionButton1.Text = "ActionButton1"
        Me.ActionButton1.UpdateCheck = False
        Me.ActionButton1.UpdateCheckCaption = Nothing
        '
        'ActionButton2
        '
        Me.ActionButton2.Location = New System.Drawing.Point(35, 6)
        Me.ActionButton2.Name = "ActionButton2"
        Me.ActionButton2.Size = New System.Drawing.Size(168, 59)
        Me.ActionButton2.TabIndex = 3
        Me.ActionButton2.Text = "Process List"
        Me.ActionButton2.UpdateCheck = False
        Me.ActionButton2.UpdateCheckCaption = Nothing
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "TestForm"
        Me.Text = "Test Form"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBoxEx1 As Moca.Win.ComboBoxEx
    Friend WithEvents TextBoxEx1 As Moca.Win.TextBoxEx
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton
    Friend WithEvents ActionButton2 As Moca.Win.ActionButton

End Class
