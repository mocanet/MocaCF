<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.ActionButton5 = New Moca.Win.ActionButton
        Me.ActionButton6 = New Moca.Win.ActionButton
        Me.ActionButton7 = New Moca.Win.ActionButton
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.ActionButton7)
        Me.pnlContents.Controls.Add(Me.ActionButton6)
        Me.pnlContents.Controls.Add(Me.ActionButton5)
        Me.pnlContents.Controls.Add(Me.ActionButton4)
        Me.pnlContents.Controls.Add(Me.ActionButton3)
        Me.pnlContents.Controls.Add(Me.ActionButton2)
        Me.pnlContents.Controls.Add(Me.ActionButton1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(31, 72)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton1.TabIndex = 2
        Me.ActionButton1.Text = "Test Form"
        Me.ActionButton1.UpdateCheck = False
        Me.ActionButton1.UpdateCheckCaption = Nothing
        '
        'ActionButton2
        '
        Me.ActionButton2.Location = New System.Drawing.Point(31, 116)
        Me.ActionButton2.Name = "ActionButton2"
        Me.ActionButton2.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton2.TabIndex = 3
        Me.ActionButton2.Text = "Test Form"
        Me.ActionButton2.UpdateCheck = False
        Me.ActionButton2.UpdateCheckCaption = Nothing
        '
        'ActionButton3
        '
        Me.ActionButton3.Location = New System.Drawing.Point(31, 160)
        Me.ActionButton3.Name = "ActionButton3"
        Me.ActionButton3.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton3.TabIndex = 4
        Me.ActionButton3.Text = "Test Form"
        Me.ActionButton3.UpdateCheck = False
        Me.ActionButton3.UpdateCheckCaption = Nothing
        '
        'ActionButton4
        '
        Me.ActionButton4.BackColor = System.Drawing.Color.Red
        Me.ActionButton4.ForeColor = System.Drawing.Color.White
        Me.ActionButton4.Location = New System.Drawing.Point(4, 245)
        Me.ActionButton4.Name = "ActionButton4"
        Me.ActionButton4.Size = New System.Drawing.Size(50, 38)
        Me.ActionButton4.TabIndex = 5
        Me.ActionButton4.Tag = "noauto"
        Me.ActionButton4.Text = "Test Form"
        Me.ActionButton4.UpdateCheck = False
        Me.ActionButton4.UpdateCheckCaption = Nothing
        '
        'ActionButton5
        '
        Me.ActionButton5.BackColor = System.Drawing.Color.Blue
        Me.ActionButton5.ForeColor = System.Drawing.Color.White
        Me.ActionButton5.Location = New System.Drawing.Point(64, 245)
        Me.ActionButton5.Name = "ActionButton5"
        Me.ActionButton5.Size = New System.Drawing.Size(50, 38)
        Me.ActionButton5.TabIndex = 6
        Me.ActionButton5.Tag = "noauto"
        Me.ActionButton5.Text = "Test Form"
        Me.ActionButton5.UpdateCheck = False
        Me.ActionButton5.UpdateCheckCaption = Nothing
        '
        'ActionButton6
        '
        Me.ActionButton6.BackColor = System.Drawing.Color.Lime
        Me.ActionButton6.Location = New System.Drawing.Point(124, 245)
        Me.ActionButton6.Name = "ActionButton6"
        Me.ActionButton6.Size = New System.Drawing.Size(50, 38)
        Me.ActionButton6.TabIndex = 7
        Me.ActionButton6.Tag = "noauto"
        Me.ActionButton6.Text = "Test Form"
        Me.ActionButton6.UpdateCheck = False
        Me.ActionButton6.UpdateCheckCaption = Nothing
        '
        'ActionButton7
        '
        Me.ActionButton7.BackColor = System.Drawing.Color.Yellow
        Me.ActionButton7.Location = New System.Drawing.Point(184, 245)
        Me.ActionButton7.Name = "ActionButton7"
        Me.ActionButton7.Size = New System.Drawing.Size(50, 38)
        Me.ActionButton7.TabIndex = 8
        Me.ActionButton7.Tag = "noauto"
        Me.ActionButton7.Text = "Test Form"
        Me.ActionButton7.UpdateCheck = False
        Me.ActionButton7.UpdateCheckCaption = Nothing
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.ControlBox = True
        Me.Name = "LoginForm"
        Me.Text = "Login"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton
    Friend WithEvents ActionButton3 As Moca.Win.ActionButton
    Friend WithEvents ActionButton2 As Moca.Win.ActionButton
    Friend WithEvents ActionButton6 As Moca.Win.ActionButton
    Friend WithEvents ActionButton5 As Moca.Win.ActionButton
    Friend WithEvents ActionButton4 As Moca.Win.ActionButton
    Friend WithEvents ActionButton7 As Moca.Win.ActionButton

End Class
