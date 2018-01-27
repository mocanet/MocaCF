
#Region " Enum ResourceKeys "

''' <summary>
''' リソースのキー値
''' </summary>
Public Enum ResourceKeys As Integer
    my
    Title
    WindowTitle
End Enum

#End Region
#Region " Enum DesignSettingKeys "

Public Enum DesignSettingKeys As Integer
    PrimaryTextColor
    BackColor

    DefaultWindowSize

    ContentColor

    ActionButtonBackColor
    ActionButtonForeColor

    btnF1BackColor
    btnF1ForeColor

    btnF2BackColor
    btnF2ForeColor

    btnF3BackColor
    btnF3ForeColor

    btnF4BackColor
    btnF4ForeColor

    btnLogoffBackColor
    btnLogoffForeColor

    FormBorderColor
    HeaderFont

    InformationBackColor
    InformationForeColor
    ErrorBackColor
    ErrorForeColor
    WarningBackColor
    WarningForeColor
    QuestionBackColor
    QuestionForeColor

    FocusColor
End Enum

#End Region
#Region " Enum FormValidateSettingKeys "

Public Enum FormValidateSettingKeys As Integer
    DefalutControlBackColor
    DefalutControlForeColor
    ErrorControlBackColor
    ErrorControlForeColor
End Enum

#End Region

#Region " Enum CommandType "

''' <summary>
''' 処理区分
''' </summary>
Public Enum CommandType As Integer
    ''' <summary>None</summary>
    None
    ''' <summary>変更</summary>
    Edit
    ''' <summary>追加</summary>
    [New]
    ''' <summary>流用</summary>
    Copy
End Enum

#End Region

#Region "セルの種類 "

''' <summary>
''' セルのコントロール種別
''' </summary>
''' <remarks></remarks>
Public Enum CellType As Integer
    ''' <summary>チェックボックス</summary>
    CheckBox
    ''' <summary>コンボボックス</summary>
    ComboBox
    ''' <summary>カレンダー</summary>
    Calendar
    ''' <summary>テキストボックス</summary>
    TextBox
    ''' <summary>アップダウンボタン</summary>
    UpDown
End Enum

#End Region

Module [Declare]

End Module
