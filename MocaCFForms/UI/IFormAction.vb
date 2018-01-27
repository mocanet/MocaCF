
Imports Moca.Win

Namespace Win

    ''' <summary>
    ''' 引数無しのメソッド実行時用デリゲート
    ''' </summary>
    ''' <remarks></remarks>
    Public Delegate Sub FormActionExecuteCallback()

    ''' <summary>
    ''' 引数無しのメソッド実行時用デリゲート（ファイル選択あり）
    ''' </summary>
    ''' <param name="selectFileName">選択したファイル名</param>
    Public Delegate Sub FormActionFileSelectExecuteCallback(ByVal selectFileName As String)

    ''' <summary>
    ''' 通常のイベントの引数を使用したメソッド実行用デリゲート
    ''' </summary>
    ''' <param name="sender">イベント実行元</param>
    ''' <param name="e">イベント引数</param>
    ''' <remarks></remarks>
    Public Delegate Sub FormActionEventCallback(ByVal sender As Object, ByVal e As System.EventArgs)

    ''' <summary>
    ''' 通常のイベントの引数を使用したメソッド実行用デリゲート
    ''' </summary>
    ''' <param name="e">イベント引数</param>
    ''' <remarks></remarks>
    Public Delegate Sub FormActionOnEventCallback(ByVal e As System.EventArgs)

    ''' <summary>
    ''' フォームの処理にて実行する処理を変わりに実行するためのインタフェース
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface IFormAction

#Region " Property "

        ''' <summary>
        ''' 画面
        ''' </summary>
        ''' <returns></returns>
        Property Frm() As CoreForm

        '''' <summary>
        '''' 標準グリッド
        '''' </summary>
        '''' <value></value>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Property Grid As C1.Win.C1FlexGrid.C1FlexGrid

#End Region

#Region " カーソル変更あり "

        ''' <summary>
        ''' 引数無しのメソッド実行時(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <remarks></remarks>
        Overloads Sub Execute(ByVal cmd As FormActionExecuteCallback)

        ''' <summary>
        ''' 引数無しのメソッド実行時(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="updateCheck">編集有無問合せ有無</param>
        ''' <remarks></remarks>
        Overloads Sub Execute(ByVal cmd As FormActionExecuteCallback, ByVal updateCheck As Boolean)

        ''' <summary>
        ''' 引数無しのメソッド実行時(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="updateCheck">編集有無問合せ有無</param>
        ''' <param name="caption">メッセージキャプション</param>
        ''' <remarks></remarks>
        Overloads Sub Execute(ByVal cmd As FormActionExecuteCallback, ByVal updateCheck As Boolean, ByVal caption As String)

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="sender">イベント実行元</param>
        ''' <param name="e">イベント引数</param>
        ''' <remarks></remarks>
        Overloads Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As System.EventArgs)

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="sender">イベント実行元</param>
        ''' <param name="e">イベント引数</param>
        ''' <param name="updateCheck">更新チェック</param>
        Overloads Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As System.EventArgs, ByVal updateCheck As Boolean)

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行(カーソル変更あり)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="sender">イベント実行元</param>
        ''' <param name="e">イベント引数</param>
        ''' <param name="updateCheck">更新チェック</param>
        ''' <param name="caption">更新チェック時の処理内容メッセージ</param>
        Overloads Sub Execute(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As System.EventArgs, ByVal updateCheck As Boolean, ByVal caption As String)

#End Region
#Region " カーソル変更なし "

        ''' <summary>
        ''' 引数無しのメソッド実行時(カーソル変更なし)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <remarks></remarks>
        Overloads Sub ExecuteNoCursor(ByVal cmd As FormActionExecuteCallback)

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行(カーソル変更なし)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="e">イベント引数</param>
        ''' <remarks></remarks>
        Overloads Sub ExecuteNoCursor(ByVal cmd As FormActionOnEventCallback, ByVal e As System.EventArgs)

        ''' <summary>
        ''' 通常のイベントの引数を使用したメソッド実行(カーソル変更なし)
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="sender">イベント実行元</param>
        ''' <param name="e">イベント引数</param>
        ''' <remarks></remarks>
        Overloads Sub ExecuteNoCursor(ByVal cmd As FormActionEventCallback, ByVal sender As Object, ByVal e As System.EventArgs)

#End Region
#Region " ファイル選択画面表示 "

        ''' <summary>
        ''' ファイル選択画面を表示したあと指定したメソッドを実行する
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="applicationName">アプリケーション名</param>
        ''' <param name="extension">拡張子</param>
        Overloads Sub ExecuteSelectFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension() As String)

        ''' <summary>
        ''' 保存ファイル指定画面を表示したあと指定したメソッドを実行する
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="applicationName">アプリケーション名</param>
        ''' <param name="extension">拡張子</param>
        ''' <remarks></remarks>
        Overloads Sub ExecuteSaveFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension As String)

        ''' <summary>
        ''' 保存ファイル指定画面を表示したあと指定したメソッドを実行する
        ''' </summary>
        ''' <param name="cmd">実行するメソッド</param>
        ''' <param name="applicationName">アプリケーション名</param>
        ''' <param name="extension">拡張子</param>
        ''' <param name="defaultFileName">デフォルトで表示するファイル名</param>
        ''' <remarks></remarks>
        Overloads Sub ExecuteSaveFile(ByVal cmd As FormActionFileSelectExecuteCallback, ByVal applicationName As String, ByVal extension As String, ByVal defaultFileName As String)

#End Region
#Region " 進捗状況画面表示 "

        ''' <summary>
        ''' 進捗状況画面表示
        ''' </summary>
        ''' <param name="handler">処理のメソッド</param>
        ''' <param name="message">処理中に表示するメッセージ</param>
        ''' <param name="args">処理のメソッドへ引数として渡したい値</param>
        ''' <remarks></remarks>
        Overloads Function ExecuteProgress(ByVal handler As EventHandler(Of ProgressWindowEventArgs), _
                                           ByVal message As String, _
                                           ByVal ParamArray args As Object()) As Object

        ''' <summary>
        ''' 進捗状況画面表示（コールバックあり）
        ''' </summary>
        ''' <param name="handler">処理のメソッド</param>
        ''' <param name="message">処理中に表示するメッセージ</param>
        ''' <param name="condition"></param>
        ''' <param name="successCallback"></param>
        ''' <param name="errorCallback"></param>
        ''' <param name="args">処理のメソッドへ引数として渡したい値</param>
        ''' <returns></returns>
        Overloads Function ExecuteProgress(ByVal handler As EventHandler(Of ProgressWindowEventArgs), _
                                 ByVal message As String, _
                                 ByVal condition As Func(Of Object(), Boolean), _
                                 ByVal successCallback As ProgressWindow.OwnerMethodInvoker, _
                                 ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, _
                                 ByVal ParamArray args As Object() _
                                 ) As Object

        ''' <summary>
        ''' 進捗状況画面表示（キャンセルあり）
        ''' </summary>
        ''' <param name="handler">処理のメソッド</param>
        ''' <param name="message">処理中に表示するメッセージ</param>
        ''' <param name="args">処理のメソッドへ引数として渡したい値</param>
        ''' <returns></returns>
        Overloads Function ExecuteProgressCanCancel(ByVal handler As EventHandler(Of ProgressWindowEventArgs), _
                                           ByVal message As String, _
                                           ByVal ParamArray args As Object()) As Object

        ''' <summary>
        ''' 進捗状況画面表示（キャンセルあり、コールバックあり）
        ''' </summary>
        ''' <param name="handler">処理のメソッド</param>
        ''' <param name="message">処理中に表示するメッセージ</param>
        ''' <param name="condition"></param>
        ''' <param name="successCallback"></param>
        ''' <param name="errorCallback"></param>
        ''' <param name="args">処理のメソッドへ引数として渡したい値</param>
        ''' <returns></returns>
        Overloads Function ExecuteProgressCanCancel(ByVal handler As EventHandler(Of ProgressWindowEventArgs), _
                                 ByVal message As String, _
                                 ByVal condition As Func(Of Object(), Boolean), _
                                 ByVal successCallback As ProgressWindow.OwnerMethodInvoker, _
                                 ByVal errorCallback As ProgressWindow.OwnerMethodInvoker, _
                                 ByVal ParamArray args As Object() _
                                 ) As Object
#End Region
#Region " Etc "

        ''' <summary>
        ''' レイアウト ロジックを一時的に中断
        ''' </summary>
        Sub SuspendLayout()

        ''' <summary>
        ''' 通常のレイアウト ロジックを再開
        ''' </summary>
        Sub ResumeLayout()

#End Region

    End Interface

End Namespace
