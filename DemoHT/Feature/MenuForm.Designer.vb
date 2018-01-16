<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Me.TextBoxEx1 = New Moca.Win.TextBoxEx
        Me.ActionButton4 = New Moca.Win.ActionButton
        Me.ActionButton5 = New Moca.Win.ActionButton
        Me.ActionButton6 = New Moca.Win.ActionButton
        Me.ActionButton7 = New Moca.Win.ActionButton
        Me.MLabel1 = New Moca.Win.MLabel
        Me.pnlContents.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContents
        '
        Me.pnlContents.Controls.Add(Me.MLabel1)
        Me.pnlContents.Controls.Add(Me.ActionButton7)
        Me.pnlContents.Controls.Add(Me.ActionButton6)
        Me.pnlContents.Controls.Add(Me.ActionButton5)
        Me.pnlContents.Controls.Add(Me.ActionButton4)
        Me.pnlContents.Controls.Add(Me.TextBoxEx1)
        Me.pnlContents.Controls.Add(Me.ActionButton3)
        Me.pnlContents.Controls.Add(Me.ActionButton2)
        Me.pnlContents.Controls.Add(Me.ActionButton1)
        Me.pnlContents.Size = New System.Drawing.Size(238, 295)
        '
        'ActionButton1
        '
        Me.ActionButton1.Location = New System.Drawing.Point(29, 80)
        Me.ActionButton1.Name = "ActionButton1"
        Me.ActionButton1.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton1.TabIndex = 1
        Me.ActionButton1.Text = "Test Form"
        Me.ActionButton1.UpdateCheck = False
        Me.ActionButton1.UpdateCheckCaption = Nothing
        '
        'ActionButton2
        '
        Me.ActionButton2.Location = New System.Drawing.Point(29, 128)
        Me.ActionButton2.Name = "ActionButton2"
        Me.ActionButton2.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton2.TabIndex = 2
        Me.ActionButton2.Text = "ActionButton2"
        Me.ActionButton2.UpdateCheck = False
        Me.ActionButton2.UpdateCheckCaption = Nothing
        '
        'ActionButton3
        '
        Me.ActionButton3.Location = New System.Drawing.Point(29, 172)
        Me.ActionButton3.Name = "ActionButton3"
        Me.ActionButton3.Size = New System.Drawing.Size(180, 38)
        Me.ActionButton3.TabIndex = 3
        Me.ActionButton3.Text = "ActionButton3"
        Me.ActionButton3.UpdateCheck = False
        Me.ActionButton3.UpdateCheckCaption = Nothing
        '
        'TextBoxEx1
        '
        Me.TextBoxEx1.BottomBorderColor = System.Drawing.Color.Empty
        Me.TextBoxEx1.Location = New System.Drawing.Point(29, 51)
        Me.TextBoxEx1.Name = "TextBoxEx1"
        Me.TextBoxEx1.Size = New System.Drawing.Size(180, 23)
        Me.TextBoxEx1.TabIndex = 0
        Me.TextBoxEx1.TextChangedCompleteDelay = 0
        '
        'ActionButton4
        '
        Me.ActionButton4.Location = New System.Drawing.Point(29, 216)
        Me.ActionButton4.Name = "ActionButton4"
        Me.ActionButton4.Size = New System.Drawing.Size(87, 31)
        Me.ActionButton4.TabIndex = 4
        Me.ActionButton4.Text = "Warning"
        Me.ActionButton4.UpdateCheck = False
        Me.ActionButton4.UpdateCheckCaption = Nothing
        '
        'ActionButton5
        '
        Me.ActionButton5.Location = New System.Drawing.Point(122, 216)
        Me.ActionButton5.Name = "ActionButton5"
        Me.ActionButton5.Size = New System.Drawing.Size(87, 31)
        Me.ActionButton5.TabIndex = 5
        Me.ActionButton5.Text = "Error"
        Me.ActionButton5.UpdateCheck = False
        Me.ActionButton5.UpdateCheckCaption = Nothing
        '
        'ActionButton6
        '
        Me.ActionButton6.Location = New System.Drawing.Point(29, 253)
        Me.ActionButton6.Name = "ActionButton6"
        Me.ActionButton6.Size = New System.Drawing.Size(87, 31)
        Me.ActionButton6.TabIndex = 6
        Me.ActionButton6.Text = "Question"
        Me.ActionButton6.UpdateCheck = False
        Me.ActionButton6.UpdateCheckCaption = Nothing
        '
        'ActionButton7
        '
        Me.ActionButton7.Location = New System.Drawing.Point(122, 253)
        Me.ActionButton7.Name = "ActionButton7"
        Me.ActionButton7.Size = New System.Drawing.Size(87, 31)
        Me.ActionButton7.TabIndex = 7
        Me.ActionButton7.Text = "Information"
        Me.ActionButton7.UpdateCheck = False
        Me.ActionButton7.UpdateCheckCaption = Nothing
        '
        'MLabel1
        '
        Me.MLabel1.BorderColor = System.Drawing.Color.Gray
        Me.MLabel1.BorderWidth = 2
        Me.MLabel1.Location = New System.Drawing.Point(29, 3)
        Me.MLabel1.Name = "MLabel1"
        Me.MLabel1.Size = New System.Drawing.Size(180, 42)
        Me.MLabel1.TabIndex = 8
        Me.MLabel1.Text = "MLabel1"
        Me.MLabel1.TextAlign = Moca.TextAlignment.MiddleCenter
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(238, 295)
        Me.Name = "MenuForm"
        Me.pnlContents.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ActionButton1 As Moca.Win.ActionButton
    Friend WithEvents ActionButton3 As Moca.Win.ActionButton
    Friend WithEvents ActionButton2 As Moca.Win.ActionButton
    Friend WithEvents TextBoxEx1 As Moca.Win.TextBoxEx
    Friend WithEvents ActionButton7 As Moca.Win.ActionButton
    Friend WithEvents ActionButton6 As Moca.Win.ActionButton
    Friend WithEvents ActionButton5 As Moca.Win.ActionButton
    Friend WithEvents ActionButton4 As Moca.Win.ActionButton
    Friend WithEvents MLabel1 As Moca.Win.MLabel

End Class
