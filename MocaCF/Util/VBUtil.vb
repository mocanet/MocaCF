
Imports System.IO
Imports System.Text
Imports System.Reflection

Namespace Util

    ''' <summary>
    ''' VB.NET 便利メソッド集
    ''' </summary>
    ''' <remarks></remarks>
    Public Class VBUtil

        ''' <summary>正規表現のメタ文字集</summary>
        Private Const C_REGEX_META As String = ".,^,$,[,],*,+,?,|,(,)"
        ''' <summary>正規表現のメタ文字集配列</summary>
        Private Shared _regexMeata() As String = C_REGEX_META.Split(CChar(","))

        Public Shared ReadOnly Property AppPath() As String
            Get
                Return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
            End Get
        End Property

        ''' <summary>
        ''' 指定されたフォルダが存在するかを判定する
        ''' </summary>
        ''' <param name="path">対象となるフォルダ</param>
        ''' <returns>True:存在する、False:存在しない</returns>
        ''' <remarks>
        ''' </remarks>
        Public Shared Function ExistsDir(ByVal path As String) As Boolean
            Return ExistsDir(path, False)
        End Function

        ''' <summary>
        ''' 指定されたフォルダが存在するかを判定し、存在しない時は作成するかどうか指定できる
        ''' </summary>
        ''' <param name="path">対象となるフォルダ</param>
        ''' <param name="autoMake">存在しないときの動作<br/>True:作成する、False:作成しない</param>
        ''' <returns>True:存在する、False:存在しない</returns>
        ''' <remarks>
        ''' </remarks>
        Public Shared Function ExistsDir(ByVal path As String, ByVal autoMake As Boolean) As Boolean
            If Not Directory.Exists(path) Then
                If autoMake Then
                    Directory.CreateDirectory(path)
                End If
            End If
            Return Directory.Exists(path)
        End Function

        ''' <summary>
        ''' 正規表現のメタ文字をエスケープする
        ''' </summary>
        ''' <param name="value">正規表現文字列</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function RegexMeataEscape(ByVal value As String) As String
            For Each meta As String In _regexMeata
                value = value.Replace(meta, "\" & meta)
            Next
            Return value
        End Function

#Region "　LeftB メソッド　"

        ''' <summary>
        ''' 文字列の左端から指定したバイト数分の文字列を返します。
        ''' </summary>
        ''' <param name="stTarget">取り出す元になる文字列。</param>
        ''' <param name="iByteSize">取り出すバイト数。</param>
        ''' <returns>左端から指定されたバイト数分の文字列。</returns>
        Public Shared Function LeftB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
            Return MidB(stTarget, 1, iByteSize)
        End Function

#End Region

#Region "　MidB メソッド (+1)　"

        ' ''' <summary>
        ' ''' 文字列の指定されたバイト位置以降のすべての文字列を返します。
        ' ''' </summary>
        ' ''' <param name="stTarget">取り出す元になる文字列。</param>
        ' ''' <param name="iStart">取り出しを開始する位置。</param>
        ' ''' <returns>指定されたバイト位置以降のすべての文字列。</returns>
        'Public Shared Function MidB(ByVal stTarget As String, ByVal iStart As Integer) As String
        '	Dim hEncoding As Encoding = Encoding.GetEncoding("Shift_JIS")
        '	Dim bBytes As Byte() = hEncoding.GetBytes(stTarget)

        '	Return hEncoding.GetString(bBytes, iStart - 1, bBytes.Length - iStart + 1)
        'End Function

        ' ''' <summary>
        ' ''' 文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。
        ' ''' </summary>
        ' ''' <param name="stTarget">取り出す元になる文字列。</param>
        ' ''' <param name="iStart">取り出しを開始する位置。</param>
        ' ''' <param name="iByteSize">取り出すバイト数。</param>
        ' ''' <returns>指定されたバイト位置から指定されたバイト数分の文字列。</returns>
        'Public Shared Function MidB _
        '(ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        '	Dim hEncoding As Encoding = Encoding.GetEncoding("Shift_JIS")
        '	Dim bBytes As Byte() = hEncoding.GetBytes(stTarget)

        '	Return hEncoding.GetString(bBytes, iStart - 1, iByteSize)
        'End Function

        ''' <summary>
        ''' 文字列の指定されたバイト位置以降のすべての文字列を返します。
        ''' </summary>
        ''' <param name="value">取り出す元になる文字列。</param>
        ''' <param name="startPos">取り出しを開始する位置。</param>
        ''' <returns>指定されたバイト位置以降のすべての文字列。</returns>
        Public Shared Function MidB(ByVal value As String, ByVal startPos As Integer) As String
            Dim enc As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim getLength As Integer = enc.GetByteCount(value) - startPos + 1
            Return MidB(value, startPos, getLength)
        End Function

        ''' <summary>
        ''' 文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。
        ''' </summary>
        ''' <param name="value">取り出す元になる文字列。</param>
        ''' <param name="startPos">取り出しを開始する位置。</param>
        ''' <param name="getLength">取り出すバイト数。</param>
        ''' <returns>指定されたバイト位置から指定されたバイト数分の文字列。</returns>
        Public Shared Function MidB(ByVal value As String, ByVal startPos As Integer, ByVal getLength As Integer) As String
            If value Is Nothing OrElse value.Length = 0 Then
                Return String.Empty
            End If

            Dim rc As String
            Dim enc As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim bytes As Byte() = enc.GetBytes(value)
            Dim len As Integer = enc.GetByteCount(value) - startPos + 1
            If getLength > len Then
                getLength = len
            End If

            '▼切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。

            rc = enc.GetString(bytes, startPos - 1, getLength)
            Dim rcLength As Integer = enc.GetByteCount(rc)

            If getLength = rcLength - 1 Then
                Return rc.Substring(0, rc.Length - 1)
            End If

            Return rc
        End Function

#End Region

#Region "　RightB メソッド　"

        ''' <summary>
        ''' 文字列の右端から指定されたバイト数分の文字列を返します。
        ''' </summary>
        ''' <param name="stTarget">取り出す元になる文字列。</param>
        ''' <param name="iByteSize">取り出すバイト数。</param>
        ''' <returns>右端から指定されたバイト数分の文字列。</returns>
        Public Shared Function RightB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
            Dim hEncoding As Encoding = Encoding.GetEncoding("Shift_JIS")
            Dim bBytes As Byte() = hEncoding.GetBytes(stTarget)

            Return hEncoding.GetString(bBytes, bBytes.Length - iByteSize, iByteSize)
        End Function

#End Region

#Region "　LenB メソッド　"

        ''' <summary>
        ''' 半角 1 バイト、全角 2 バイトとして、指定された文字列のバイト数を返します。
        ''' </summary>
        ''' <param name="stTarget">バイト数取得の対象となる文字列。</param>
        ''' <returns>半角 1 バイト、全角 2 バイトでカウントされたバイト数。</returns>
        Public Shared Function LenB(ByVal stTarget As String) As Integer
            Return Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
        End Function

#End Region

        ''' <summary>
        ''' 文字列を文字コードを表す整数値に変換する
        ''' </summary>
        ''' <param name="targetValue">変換対象の文字列</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        Public Shared Function CAsc(ByVal targetValue As String) As String
            Dim beforeData As String
            Dim afterData As String
            Dim chrValue As String
            Dim ii As Integer

            beforeData = targetValue
            afterData = ""
            If Len(beforeData) <> 0& Then
                For ii = 1 To Len(beforeData)
                    chrValue = String.Empty
                    'chrValue = Hex(Asc(Mid$(beforeData, ii, 1)))
                    chrValue = CStr(Asc(Mid$(beforeData, ii, 1)))
                    afterData = afterData & chrValue
                Next
            Else
                afterData = "0"
            End If

            Return afterData
        End Function

        Public Shared Function GetValues(ByVal enumeration As [Enum]) As IEnumerable(Of [Enum])
            Dim lst As List(Of [Enum]) = New List(Of [Enum])
            For Each fieldInfo As Reflection.FieldInfo In enumeration.GetType().GetFields(BindingFlags.Static Or BindingFlags.Public)
                lst.Add(fieldInfo.GetValue(enumeration))
            Next
            Return lst
        End Function

    End Class

End Namespace
