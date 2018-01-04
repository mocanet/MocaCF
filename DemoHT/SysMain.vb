
Imports Moca.Win
Imports Moca

Module SysMain

    Sub Main()
        ' キャッチしきれていない例外を処理する準備
        UIHelper.ApplicationExceptionHandler(New ApplicationExceptionListener())

        ' デザイン系の初期化
        CoreSettings.Instance.ResourceManager = My.Resources.ResourceManager
        'CoreSettings.Instance.DesignManager = My.Resources.DesignSettings.ResourceManager

        Application.Run(New DemoHTForm())
    End Sub

End Module
