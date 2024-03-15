using System;
using System.Text;
using Serilog;
using Microsoft.Extensions.Configuration;

using Serilog.Events;
using System.ComponentModel;
using System.Reflection;


namespace NuvoControl.Common;


/// <summary>
/// Helper class to collect logger and console output methods for complex
/// structures, like endpoint collection as example.
/// </summary>
public class LogHelper
{
    private static NuvoControlLogger _logger = null;

    /// <summary>
    /// Converts enumeratiion from (custom) LogLevel to Serilog LogEventLevel enumartion.
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    private static LogEventLevel ConvertToLogEventLevel(LogLevel level)
    {
        FieldInfo fi = level.GetType().GetField(level.ToString());
        DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes(
              typeof(DescriptionAttribute), false);

        // DayOfWeek inputAsEnum = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), inputString);
        string inputString = (attributes.Length > 0) ? attributes[0].Description : level.ToString();
        LogEventLevel inputAsEnum = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), inputString);
        return inputAsEnum;
    }

    /// <summary>
    /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
    /// sending the output to <see cref="Console.Out" />.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="e">An optional <see cref="Exception" /> associated with the message.</param>
    private static void WriteInternal(LogLevel level, object message, Exception e)
    {
        // Print to the appropriate destination
        //Console.Out.WriteLine(message.ToString());
        LogEventLevel outLevel = ConvertToLogEventLevel(level);
        Serilog.Log.Write(outLevel, message.ToString(), e);
    }

    /// <summary>
    /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
    /// sending the output to <see cref="Console.Out" />.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="args">The arguments to be inserted in placeholders in message.</param>        
    private static void WriteInternal(LogLevel level, object message, params object[] args)
    {
        // Print to the appropriate destination
        //Console.Out.WriteLine(message.ToString());
        LogEventLevel outLevel = ConvertToLogEventLevel(level);
        Serilog.Log.Write(outLevel, message.ToString(), args);
    }


    private class NuvoControlLogger : ILog
    {
        public NuvoControlLogger()
        {
            //TODO: Implement to read-out Serilog configuration from config file

            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //Serilog.Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            var configuration = new ConfigurationBuilder()
                .Build();

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            Serilog.Log.Information("Logger created ...");
        }

        public void Trace(string format, params object[] args)
        {
            WriteInternal(LogLevel.Trace, format, args);
        }

        public void Debug(string format, params object[] args)
        {
            WriteInternal(LogLevel.Debug, format, args);
        }

        public void Info(string format, params object[] args)
        {
            WriteInternal(LogLevel.Info, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            WriteInternal(LogLevel.Warn, format, args);
        }

        public void Error(string format, params object[] args)
        {
            WriteInternal(LogLevel.Error, format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            WriteInternal(LogLevel.Fatal, format, args);
        }

    }

    ///////////////////////////////////////////////////

    // (Mainly) copied from  Common.Logging (3rd party project)

    #region Deprecated methods and interfaces from Common.Logging to be backward compatible

    #region LogLevel
    /// <summary>
    /// The 7 possible logging levels.
    /// The description contians the mapping to Serilog level, defined in LogEventLevel enumeration.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// All logging levels
        /// </summary>
        [Description("Verbose")]  All = 0,
        /// <summary>
        /// A trace logging level
        /// </summary>
        [Description("Verbose")] Trace = 1,
        /// <summary>
        /// A debug logging level
        /// </summary>
        [Description("Debug")] Debug = 2,
        /// <summary>
        /// A info logging level
        /// </summary>
        [Description("Information")] Info = 3,
        /// <summary>
        /// A warn logging level
        /// </summary>
        [Description("Warning")] Warn = 4,
        /// <summary>
        /// An error logging level
        /// </summary>
        [Description("Error")] Error = 5,
        /// <summary>
        /// A fatal logging level
        /// </summary>
        [Description("Fatal")] Fatal = 6,
        /// <summary>
        /// Do not log anything.
        /// </summary>
        //[Description("(Off)")] Off = 7,
    }
    #endregion

    #region ILog Interface
    public interface ILog
    {

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Trace(string format, params object[] args);

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Debug(string format, params object[] args);

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Info(string format, params object[] args);

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Warn(string format, params object[] args);

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Error"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Error(string format, params object[] args);

        /// <summary>
        /// Log a message with the <see cref="LogLevel.Trace"/> level.
        /// </summary>
        /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
        /// <param name="args">the list of format arguments</param>
        void Fatal(string format, params object[] args);

    }
    #endregion

    #region LogManager
    /// <summary>
    /// Static class to access logger instance.
    /// Use GetCurrentClassLogger() to get current logger instance.
    /// </summary>
    public static class LogManager
    {

        public static ILog GetCurrentClassLogger()
        {
            if( _logger == null )
            {
                _logger = new NuvoControlLogger();
            }
            return _logger;
        }

        public static void ReleaseCurrentClassLogger()
        {
            if (_logger != null)
            {
                // Finally, once just before the application exits...
                Serilog.Log.CloseAndFlush();
            }
            _logger = null; 
        } 
    }
    #endregion

    #endregion

    ///////////////////////////////////////////////////

    // Theres is a "in-build" console logger, which is switched-off per default. It can be enabled by set command line option "-v" (for verbose).
    #region Verbose Mode
    /*
    The six logging levels used by Log are (in order): 
        1.trace (the least serious)
        2.debug
        3.info
        4.warn
        5.error
        6.fatal (the most serious)
    */

    /// <summary>
    /// Global minimum level, for verbose mode.
    /// E.g. if minimum level is set to "info"; all messages of level "info" and higher ("warn", "error", "fatal") are shown
    /// </summary>
    private static LogLevel _minVerboseLogLevel = LogLevel.All;

    /// <summary>
    /// Public accessor for minimum level for verbose mode.
    /// </summary>
    public static LogLevel MinVerboseLogLevel
    {
        get { return LogHelper._minVerboseLogLevel; }
    }


    /// <summary>
    /// Global verbose mode, per default switched-off
    /// </summary>
    private static bool _verbose = false;

    /// <summary>
    /// Set all options, passed with command line options.
    /// </summary>
    /// <param name="options">Options passed with command line options.</param>
    public static void SetOptions(CommonOptions options)
    {
        _verbose = options.verbose;
        _minVerboseLogLevel = options.minVerboseLevel;
    }

    #endregion

    /// <summary>
    /// Logs a message in a "standard" way to console and Logger.
    /// </summary>
    /// <param name="logLevel">Log Level to log</param>
    /// <param name="strMessage">Message to log.</param>
    /// <param name="args"></param>
    private static void LogInternal(LogLevel logLevel, string strMessage, params object[] args)
    {
        ILog logger = LogManager.GetCurrentClassLogger();

        if (_verbose && (logLevel >= _minVerboseLogLevel | logLevel == LogLevel.All))
        {
            // Theres is a "in-build" console logger, which is switched-off per default. It can be enabled by set command line option "-v" (for verbose).
            string strFormattedMessage = string.Format(strMessage, args);
            Console.WriteLine(String.Format("{0} [{1}] {2}", DateTime.Now.ToString(), logLevel.ToString()[0], strFormattedMessage));
        }

        WriteInternal(logLevel, strMessage, args);

    }

    /// <summary>
    /// Logs a message in a "standard" way to console and Logger.
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="strMessage">Message to log.</param>
    public static void Log(LogLevel logLevel, string strMessage)
    {
        LogInternal(logLevel, strMessage);
    }

    /// <summary>
    /// Logs a message in a "standard" way to console and Logger.
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="strMessage">Message to log.</param>
    /// <param name="args"></param>
    public static void Log(LogLevel logLevel, string strMessage, params object[] args)
    {
        LogInternal(logLevel, strMessage, args);
    }

    /// <summary>
    /// Logs an application startup message in a "standard" way to console and Logger.
    /// </summary>
    /// <param name="strStartMessage"></param>
    public static void LogAppStart(string strStartMessage)
    {
        Log(LogLevel.All, "**** {0} started. *******", strStartMessage);
        Log(LogLevel.Info, ">>> Starting {0}  --- Assembly Version={1} / Deployment Version={2} / Product Version={3} ... ", strStartMessage, "n/a", "n/a", "(tbf)" /*Application.ProductVersion*/);
        //Console.WriteLine(">>> Starting Server Console  --- Assembly Version={0} / Deployment Version={1} / Product Version={2} (using .NET 4.0) ... ",
        //    AppInfoHelper.getAssemblyVersion(), AppInfoHelper.getDeploymentVersion(), Application.ProductVersion);
        Log(LogLevel.Info, "    Linux={0} / Detected environment: {1}", EnvironmentHelper.isRunningOnLinux(), EnvironmentHelper.getOperatingSystem());
    }

    /// <summary>
    /// Logs an exception in a "standard" way to console and Logger.
    /// </summary>
    /// <param name="strMessage">Message to log.</param>
    /// <param name="exc">Exception to log.</param>
    public static void LogException(string strMessage, Exception exc)
    {
        Log(LogLevel.Fatal, "----------------\nException! {0} [{1}]\n----------------\n", strMessage, exc.ToString());
    }

    /// <summary>
    /// Logs the command line arguments in a "standard" way to console and logger.
    /// </summary>
    /// <param name="args">Arguments passed by command line.</param>
    public static void LogArgs(string[] args)
    {
        string strargs = "";
        foreach (string arg in args)
        {
            strargs += arg;
            strargs += " ";
        }
        Log(LogLevel.Info, "    Command line arguments: {0}\n", strargs);
    }

}
