Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

''' <summary>
''' コア共通設定値など
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class CoreSettings

#Region " Declare "

    ''' <summary>シングルトン用インスタンス</summary>
    Private Shared _instance As CoreSettings

#End Region

#Region " Shared "

    ''' <summary>
    ''' 当クラスのインスタンスを返す。
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function Instance() As CoreSettings
        If _instance Is Nothing Then
            _instance = New CoreSettings()
        End If
        Return _instance
    End Function

#End Region

#Region " Property "

#Region " Resources "

    ''' <summary>
    ''' リソースマネージャー
    ''' </summary>
    ''' <returns></returns>
    Public Property ResourceManager() As Resources.ResourceManager
        Get
            If _ResourceManager Is Nothing Then
                Return My.Resources.ResourceManager
            End If
            Return _ResourceManager
        End Get
        Set(ByVal value As Resources.ResourceManager)
            _ResourceManager = value
        End Set
    End Property
    Private _ResourceManager As Resources.ResourceManager

    ''' <summary>
    ''' デザイン設定
    ''' </summary>
    ''' <returns></returns>
    Public Property DesignManager() As Resources.ResourceManager
        Get
            If _designManager Is Nothing Then
                Return My.Resources.DesignSettings.ResourceManager
            End If
            Return _designManager
        End Get
        Set(ByVal value As Resources.ResourceManager)
            _designManager = value
        End Set
    End Property
    Private _designManager As Resources.ResourceManager

    ''' <summary>
    ''' デザイン設定
    ''' </summary>
    ''' <returns></returns>
    Public Property FormValidateManager() As Resources.ResourceManager
        Get
            If _FormValidateManager Is Nothing Then
                Return My.Resources.MyFormValidate.ResourceManager
            End If
            Return _FormValidateManager
        End Get
        Set(ByVal value As Resources.ResourceManager)
            _FormValidateManager = value
        End Set
    End Property
    Private _FormValidateManager As Resources.ResourceManager

    ''' <summary>
    ''' リソースオブジェクト
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public ReadOnly Property ResourceObject(ByVal key As ResourceKeys) As Object
        Get
            Return ResourceManager.GetObject(key.ToString)
        End Get
    End Property

    ''' <summary>
    ''' アイコン
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Icon() As Icon
        Get
            Return ResourceObject(ResourceKeys.my)
        End Get
    End Property

    ''' <summary>
    ''' タイトル
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Title() As String
        Get
            Dim value As String = ResourceManager.GetString(ResourceKeys.Title.ToString)
            If String.IsNullOrEmpty(value) Then
                Throw New ApplicationException("プロジェクトのリソースに「Title」が存在しませんでした。")
            End If
            If Not String.IsNullOrEmpty(TitleSuffix) Then
                value &= "：" & TitleSuffix
            End If
            Return value
        End Get
    End Property

    ''' <summary>
    ''' ウィンドウタイトル
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property WindowTitle() As String
        Get
            Dim value As String = ResourceManager.GetString(ResourceKeys.WindowTitle.ToString)
            If String.IsNullOrEmpty(value) Then
                Throw New ApplicationException("プロジェクトのリソースに「WindowTitle」が存在しませんでした。")
            End If
            Return value
        End Get
    End Property

    ''' <summary>
    ''' タイトルの接尾語
    ''' </summary>
    ''' <returns></returns>
    Public Property TitleSuffix() As String
        Get
            Return _TitleSuffix
        End Get
        Set(ByVal value As String)
            _TitleSuffix = value
        End Set
    End Property
    Private _TitleSuffix As String

#End Region

    ''' <summary>
    ''' デザイン設定値の取得
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public ReadOnly Property DesignValue(ByVal key As DesignSettingKeys) As Object
        Get
            Dim value As Object
            value = DesignManager.GetObject(key.ToString())

            If key.ToString().ToUpper().EndsWith("Color".ToUpper()) Then
                Dim res() As String = value.ToString().Split(","c)
                value = Color.FromArgb(res(0).Trim(), res(1).Trim(), res(2).Trim())
            End If
            If key.ToString().ToUpper().EndsWith("Size".ToUpper()) Then
                Dim res() As String = value.ToString().Split(","c)
                value = New Drawing.Size(res(0).Trim(), res(1).Trim())
            End If

            Return value
        End Get
    End Property

    Public ReadOnly Property DesignValue(ByVal key As String) As Object
        Get
            Dim value As DesignSettingKeys = [Enum].Parse(GetType(DesignSettingKeys), key, True)
            Return DesignValue(value)
        End Get
    End Property

    ''' <summary>
    ''' 検証設定値の取得
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public ReadOnly Property FormValidateSettings(ByVal key As FormValidateSettingKeys) As Object
        Get
            Dim value As Object
            value = FormValidateManager.GetObject(key.ToString())

            If key.ToString().ToUpper().EndsWith("Color".ToUpper()) Then
                Dim res() As String = value.ToString().Split(","c)
                value = Color.FromArgb(res(0).Trim(), res(1).Trim(), res(2).Trim())
            End If
            If key.ToString().ToUpper().EndsWith("Size".ToUpper()) Then
                Dim res() As String = value.ToString().Split(","c)
                value = New Drawing.Size(res(0).Trim(), res(1).Trim())
            End If

            Return value
        End Get
    End Property

    Public ReadOnly Property FormValidateSettings(ByVal key As String) As Object
        Get
            Dim value As FormValidateSettingKeys = [Enum].Parse(GetType(FormValidateSettingKeys), key, True)
            Return FormValidateSettings(value)
        End Get
    End Property

    ''' <summary>
    ''' メイン画面
    ''' </summary>
    ''' <returns></returns>
    Public Property MainForm() As Form
        Get
            Return _mainForm
        End Get
        Set(ByVal value As Form)
            _mainForm = value
        End Set
    End Property
    Private _mainForm As Form

    ''' <summary>
    ''' ファイルの読み取り専用属性を設定する
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Public Sub SetFileReadOnly(ByVal fileName As String, ByVal value As Boolean)
        Dim fi As FileInfo = New FileInfo(fileName)
        Dim attr As FileAttributes = fi.Attributes

        If value Then
            ' 読み取り専用属性を追加する
            If (attr And FileAttributes.ReadOnly) <> FileAttributes.ReadOnly Then
                fi.Attributes = fi.Attributes Or FileAttributes.ReadOnly
            End If
        Else
            ' 読み取り専用属性を削除する
            If (attr And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                fi.Attributes = fi.Attributes And Not FileAttributes.ReadOnly
            End If
        End If
    End Sub

#End Region

End Class
