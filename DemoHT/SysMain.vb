
Imports Moca.Win
Imports Moca
Imports System.IO

Module SysMain

    Sub Main()
        Log4netConfigure()

        ' キャッチしきれていない例外を処理する準備
        UIHelper.ApplicationExceptionHandler(New ApplicationExceptionListener())

        ' デザイン系の初期化
        CoreSettings.Instance.ResourceManager = My.Resources.ResourceManager
        'CoreSettings.Instance.DesignManager = My.Resources.DesignSettings.ResourceManager

        Try
            Dim frm As Form = New DemoHTForm()
            Application.Run(frm)
        Finally
            log4net.LogManager.Shutdown()

            Debug.WriteLine("終了！")
        End Try
    End Sub

    Sub Log4netConfigure()
        'Dim SqlCeAppender As New log4net.Appender.AdoNetAppender()
        'SqlCeAppender.Name = "SqlCeAppender"
        'SqlCeAppender.BufferSize = 0
        'SqlCeAppender.ConnectionType = "System.Data.SqlServerCe.SqlCeConnection, System.Data.SqlServerCe"
        ''SqlCeAppender.ConnectionString = String.Format("Data Source='{0}\DemoHT.sdf';", Util.VBUtil.AppPath).Replace("\", "\\")
        'SqlCeAppender.ConnectionString = "Data Source='DemoHT.sdf';"
        ''appender.CommandType = Data.CommandType.TableDirect
        'SqlCeAppender.CommandText = "INSERT INTO log4net ([Date],[Message]) VALUES (@log_date, @message)"

        'Dim param As log4net.Appender.AdoNetAppenderParameter
        'param = New log4net.Appender.AdoNetAppenderParameter()
        'param.ParameterName = "@log_date"
        'param.DbType = Data.DbType.DateTime
        'param.Layout = New log4net.Layout.RawTimeStampLayout()
        'SqlCeAppender.AddParameter(param)

        'param = New log4net.Appender.AdoNetAppenderParameter()
        'param.ParameterName = "@message"
        'param.DbType = Data.DbType.String
        'param.Size = 2000
        'param.Layout = New log4net.Layout.Layout2RawLayoutAdapter(New log4net.Layout.PatternLayout("%message"))
        'SqlCeAppender.AddParameter(param)

        'Dim filter As log4net.Filter.LevelRangeFilter
        'filter = New log4net.Filter.LevelRangeFilter()
        'filter.LevelMin = log4net.Core.Level.Info
        'filter.LevelMax = log4net.Core.Level.Fatal
        'SqlCeAppender.AddFilter(filter)

        'log4net.Config.BasicConfigurator.Configure(SqlCeAppender)

        Dim DebugAppender As New log4net.Appender.DebugAppender
        DebugAppender.Name = "DebugAppender"
        DebugAppender.Layout = New log4net.Layout.PatternLayout("@%-5level&gt;&gt; [%class.%method.%line] %message%newline")
        log4net.Config.BasicConfigurator.Configure(DebugAppender)

        Dim DataSourceAppender As New Moca.Log4net.Appender.DataSourceAppender
        DataSourceAppender.Name = "DataSourceAppender"
        DataSourceAppender.TableAdapterType = "DemoHT.DemoHTDataSetTableAdapters.log4netTableAdapter, DemoHT"

        Dim param As Moca.Log4net.Appender.DataSourceAppenderParameter
        param = New Moca.Log4net.Appender.DataSourceAppenderParameter()
        param.ParameterName = "LogDate"
        param.Layout = New log4net.Layout.RawTimeStampLayout()
        DataSourceAppender.AddParameter(param)

        param = New Moca.Log4net.Appender.DataSourceAppenderParameter()
        param.ParameterName = "thread"
        param.Layout = New log4net.Layout.Layout2RawLayoutAdapter(New log4net.Layout.PatternLayout("%t"))
        DataSourceAppender.AddParameter(param)

        param = New Moca.Log4net.Appender.DataSourceAppenderParameter()
        param.ParameterName = "log_level"
        param.Layout = New log4net.Layout.Layout2RawLayoutAdapter(New log4net.Layout.PatternLayout("%level"))
        DataSourceAppender.AddParameter(param)

        param = New Moca.Log4net.Appender.DataSourceAppenderParameter()
        param.ParameterName = "message"
        param.Layout = New log4net.Layout.Layout2RawLayoutAdapter(New log4net.Layout.PatternLayout("%message"))
        DataSourceAppender.AddParameter(param)

        param = New Moca.Log4net.Appender.DataSourceAppenderParameter()
        param.ParameterName = "exception"
        param.Layout = New log4net.Layout.Layout2RawLayoutAdapter(New log4net.Layout.PatternLayout("%exception"))
        DataSourceAppender.AddParameter(param)

        log4net.Config.BasicConfigurator.Configure(DataSourceAppender)

        'log4net.Config.XmlConfigurator.Configure(New FileInfo(Util.VBUtil.AppPath & "\log4net.config"))
    End Sub

End Module

