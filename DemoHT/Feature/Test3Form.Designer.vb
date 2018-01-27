<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Test3Form
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
        Me.ActionButton1 = New Moca.Win.ActionButton
        Me.ActionButton2 = New Moca.Win.ActionButton
        Me.ActionButton3 = New Moca.Win.ActionButton
        Me.ActionButton4 = New Moca.Win.ActionButton
        Me.MLabel1 = New Moca.Win.MLabel
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.MLabel1)
        Me.pnlContents.Controls.Add(Me.ActionButton4)
        Me.pnlContents.Controls.Add(Me.ActionButton3)
        Me.pnlContents.Controls.Add(Me.ActionButton2)
        Me.pnlContents.Controls.Add(Me.ActionButton1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(42, 16)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(153, 55)
        Me.ActionButton1.TabIndex = 0
        Me.ActionButton1.Text = "ExecuteProgress"
        Me.ActionButton1.UpdateCheck = False
        Me.ActionButton1.UpdateCheckCaption = Nothing
        '
        'ActionButton2
        '
        Me.ActionButton2.Location = New System.Drawing.Point(43, 77)
        Me.ActionButton2.Name = "ActionButton2"
        Me.ActionButton2.Size = New System.Drawing.Size(153, 55)
        Me.ActionButton2.TabIndex = 1
        Me.ActionButton2.UpdateCheck = False
        Me.ActionButton2.UpdateCheckCaption = Nothing
        '
        'ActionButton3
        '
        Me.ActionButton3.Location = New System.Drawing.Point(43, 138)
        Me.ActionButton3.Name = "ActionButton3"
        Me.ActionButton3.Size = New System.Drawing.Size(153, 55)
        Me.ActionButton3.TabIndex = 2
        Me.ActionButton3.Text = "ExecuteSelectFile"
        Me.ActionButton3.UpdateCheck = False
        Me.ActionButton3.UpdateCheckCaption = Nothing
        '
        'ActionButton4
        '
        Me.ActionButton4.Location = New System.Drawing.Point(43, 199)
        Me.ActionButton4.Name = "ActionButton4"
        Me.ActionButton4.Size = New System.Drawing.Size(153, 55)
        Me.ActionButton4.TabIndex = 3
        Me.ActionButton4.Text = "ExecuteSaveFile"
        Me.ActionButton4.UpdateCheck = False
        Me.ActionButton4.UpdateCheckCaption = Nothing
        '
        'MLabel1
        '
        Me.MLabel1.BorderColor = System.Drawing.Color.Empty
        Me.MLabel1.BorderWidth = 1
        Me.MLabel1.Location = New System.Drawing.Point(43, 260)
        Me.MLabel1.Name = "MLabel1"
        Me.MLabel1.Size = New System.Drawing.Size(152, 16)
        Me.MLabel1.TabIndex = 4
        Me.MLabel1.Text = "MLabel1"
        Me.MLabel1.TextAlign = Moca.TextAlignment.TopCenter
        '
        'Test3Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "Test3Form"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton
    Friend WithEvents ActionButton4 As Moca.Win.ActionButton
    Friend WithEvents ActionButton3 As Moca.Win.ActionButton
    Friend WithEvents ActionButton2 As Moca.Win.ActionButton
    Friend WithEvents MLabel1 As Moca.Win.MLabel

End Class
