﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Public Class ValidatorMessages
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Moca.ValidatorMessages", GetType(ValidatorMessages).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Public Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  処理中にエラーが発生しました に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E000() As String
            Get
                Return ResourceManager.GetString("E000", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  必須項目です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E001() As String
            Get
                Return ResourceManager.GetString("E001", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}文字以内で入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E002() As String
            Get
                Return ResourceManager.GetString("E002", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}バイト以内で入力です
        '''【半角:1バイト 全角:2バイト】 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E003() As String
            Get
                Return ResourceManager.GetString("E003", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}文字以上で入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E004() As String
            Get
                Return ResourceManager.GetString("E004", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  日付入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E005() As String
            Get
                Return ResourceManager.GetString("E005", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  半角英数入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E006() As String
            Get
                Return ResourceManager.GetString("E006", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  メールアドレス入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E007() As String
            Get
                Return ResourceManager.GetString("E007", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}以上の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E008() As String
            Get
                Return ResourceManager.GetString("E008", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}以下の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E009() As String
            Get
                Return ResourceManager.GetString("E009", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  数値入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E010() As String
            Get
                Return ResourceManager.GetString("E010", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  個人コードまたはパスワードが不正です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E011() As String
            Get
                Return ResourceManager.GetString("E011", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  個人コードの入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E012() As String
            Get
                Return ResourceManager.GetString("E012", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  個人コードが未登録です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E013() As String
            Get
                Return ResourceManager.GetString("E013", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  パスワードの期限切れです に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E014() As String
            Get
                Return ResourceManager.GetString("E014", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  パスワードが違うようです に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E015() As String
            Get
                Return ResourceManager.GetString("E015", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  権限がありません に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E016() As String
            Get
                Return ResourceManager.GetString("E016", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  データが存在しません に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E017() As String
            Get
                Return ResourceManager.GetString("E017", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  入力誤りです に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E018() As String
            Get
                Return ResourceManager.GetString("E018", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  データを入力してください に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E019() As String
            Get
                Return ResourceManager.GetString("E019", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}より大きい数値の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E020() As String
            Get
                Return ResourceManager.GetString("E020", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}より小さい数値の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E021() As String
            Get
                Return ResourceManager.GetString("E021", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  符号なし数値の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E022() As String
            Get
                Return ResourceManager.GetString("E022", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  {0}より大きい日付の入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E023() As String
            Get
                Return ResourceManager.GetString("E023", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  このユーザーは使用できません に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E024() As String
            Get
                Return ResourceManager.GetString("E024", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  整数{0}桁，小数{1}桁入力です に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Public Shared ReadOnly Property E025() As String
            Get
                Return ResourceManager.GetString("E025", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
