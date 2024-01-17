﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
//using System.ServiceModel.Discovery;
using System.Windows.Forms;
using static NuvoControl.Common.LogHelper;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json; // required for AddJsonFile(), loaded with Microsoft.Extensions.Configuration.Json

using FormatMessageCallback = System.Action<NuvoControl.Common.FormatMessageHandler>;
using static System.Windows.Forms.DataFormats;


namespace NuvoControl.Common
{
    // Copied from  Common.Logging (3rd party project)
    public delegate string FormatMessageHandler(string format, params object[] args);


    /// <summary>
    /// Helper class to collect logger and console output methods for complex
    /// structures, like endpoint collection as example.
    /// </summary>
    public class LogHelper
    {
        private static NuvoControlLogger _logger = new NuvoControlLogger();


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
            //TODO send message to SeriLog logger
            Console.Out.WriteLine(message.ToString());
        }


        private class NuvoControlLogger : ILog
        {
            public NuvoControlLogger()
            {
                Write = new WriteHandler(WriteInternal);

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                Serilog.Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

                Serilog.Log.Information("Logger created ...");
            }

            public void Debug(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Debug, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }

            public void Error(object message, Exception exception)
            {
                Write(LogLevel.Error, message, exception);
                //Serilog.Log.Error(message.ToString(), exception);
            }

            public void Error(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Error, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }

            public void Error(FormatMessageCallback formatMessageCallback, Exception exception)
            {
                Write(LogLevel.Error, new FormatMessageCallbackFormattedMessage(formatMessageCallback), exception);
            }

            public void ErrorFormat(string format, params object[] args)
            {
                Write(LogLevel.Error, new StringFormatFormattedMessage(null, format, args), null);
                //Serilog.Log.Error(format, args);
            }

            public void Fatal(object message, Exception exception)
            {
                Write(LogLevel.Fatal, message, exception);
                //Serilog.Log.Fatal(message.ToString(), exception);
            }

            public void Fatal(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Fatal, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }

            public void Info(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Info, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }

            public void Trace(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Trace, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }

            public void TraceFormat(string format, params object[] args)
            {
                //TODO Write(LogLevel.Trace, new StringFormatFormattedMessage(formatProvider, format, args), null);
            }

            public void Warn(object message, Exception exception)
            {
                //TODO Write(LogLevel.Warn, new FormatMessageCallbackFormattedMessage(formatMessageCallback), exception);
                //Serilog.Log.Warning(message.ToString(), exception);
            }

            public void Warn(FormatMessageCallback formatMessageCallback)
            {
                Write(LogLevel.Warn, new FormatMessageCallbackFormattedMessage(formatMessageCallback), null);
            }
        }

        ///////////////////////////////////////////////////

        // Copied from  Common.Logging (3rd party project)


        /// <summary>
        /// Represents a method responsible for writing a message to the log system.
        /// </summary>
        protected delegate void WriteHandler(LogLevel level, object message, Exception exception);

        /// <summary>
        /// Holds the method for writing a message to the log system.
        /// </summary>
        private static WriteHandler Write;


        #region FormatMessageCallbackFormattedMessage

        private class FormatMessageCallbackFormattedMessage
        {
            private volatile string cachedMessage;

            private readonly IFormatProvider formatProvider;
            private readonly FormatMessageCallback formatMessageCallback;

            public FormatMessageCallbackFormattedMessage(FormatMessageCallback formatMessageCallback)
            {
                this.formatMessageCallback = formatMessageCallback;
            }

            public FormatMessageCallbackFormattedMessage(IFormatProvider formatProvider, FormatMessageCallback formatMessageCallback)
            {
                this.formatProvider = formatProvider;
                this.formatMessageCallback = formatMessageCallback;
            }

            public override string ToString()
            {
                if (cachedMessage == null && formatMessageCallback != null)
                {
                    formatMessageCallback(new FormatMessageHandler(FormatMessage));
                }
                return cachedMessage;
            }

            private string FormatMessage(string format, params object[] args)
            {
                cachedMessage = string.Format(formatProvider, format, args);
                return cachedMessage;
            }
        }

        #endregion

        #region StringFormatFormattedMessage

        private class StringFormatFormattedMessage
        {
            private volatile string cachedMessage;

            private readonly IFormatProvider FormatProvider;
            private readonly string Message;
            private readonly object[] Args;

            public StringFormatFormattedMessage(IFormatProvider formatProvider, string message, params object[] args)
            {
                FormatProvider = formatProvider;
                Message = message;
                Args = args;
            }

            public override string ToString()
            {
                if (cachedMessage == null)
                {
                    cachedMessage = string.Format(FormatProvider, Message, Args);
                }
                return cachedMessage;
            }
        }

        #endregion


        #region LogLevel
        /// <summary>
        /// The 7 possible logging levels
        /// </summary>
        /// <author>Gilles Bayon</author>
        public enum LogLevel
        {
            /// <summary>
            /// All logging levels
            /// </summary>
            All = 0,
            /// <summary>
            /// A trace logging level
            /// </summary>
            Trace = 1,
            /// <summary>
            /// A debug logging level
            /// </summary>
            Debug = 2,
            /// <summary>
            /// A info logging level
            /// </summary>
            Info = 3,
            /// <summary>
            /// A warn logging level
            /// </summary>
            Warn = 4,
            /// <summary>
            /// An error logging level
            /// </summary>
            Error = 5,
            /// <summary>
            /// A fatal logging level
            /// </summary>
            Fatal = 6,
            /// <summary>
            /// Do not log anything.
            /// </summary>
            Off = 7,
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
            void TraceFormat(string format, params object[] args);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Trace"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Trace(FormatMessageCallback formatMessageCallback);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Debug"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Debug(FormatMessageCallback formatMessageCallback);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Info"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Info(FormatMessageCallback formatMessageCallback);

            /// <summary>
            /// Log a message object with the <see cref="LogLevel.Warn"/> level including
            /// the stack trace of the <see cref="Exception"/> passed
            /// as a parameter.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log, including its stack trace.</param>
            void Warn(object message, Exception exception);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Warn"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Warn(FormatMessageCallback formatMessageCallback);

            /// <summary>
            /// Log a message object with the <see cref="LogLevel.Error"/> level including
            /// the stack trace of the <see cref="Exception"/> passed
            /// as a parameter.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log, including its stack trace.</param>
            void Error(object message, Exception exception);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Error"/> level.
            /// </summary>
            /// <param name="format">The format of the message object to log.<see cref="string.Format(string,object[])"/> </param>
            /// <param name="args">the list of format arguments</param>
            void ErrorFormat(string format, params object[] args);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Error"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Error(FormatMessageCallback formatMessageCallback);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Error"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            /// <param name="exception">The exception to log, including its stack trace.</param>
            void Error(FormatMessageCallback formatMessageCallback, Exception exception);

            /// <summary>
            /// Log a message object with the <see cref="LogLevel.Fatal"/> level including
            /// the stack trace of the <see cref="Exception"/> passed
            /// as a parameter.
            /// </summary>
            /// <param name="message">The message object to log.</param>
            /// <param name="exception">The exception to log, including its stack trace.</param>
            void Fatal(object message, Exception exception);

            /// <summary>
            /// Log a message with the <see cref="LogLevel.Fatal"/> level using a callback to obtain the message
            /// </summary>
            /// <remarks>
            /// Using this method avoids the cost of creating a message and evaluating message arguments 
            /// that probably won't be logged due to loglevel settings.
            /// </remarks>
            /// <param name="formatMessageCallback">A callback used by the logger to obtain the message if log level is matched</param>
            void Fatal(FormatMessageCallback formatMessageCallback);

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
                return _logger;
            }

        }
        #endregion

        ///////////////////////////////////////////////////

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
            set { LogHelper._minVerboseLogLevel = value; }
        }


        /// <summary>
        /// Global verbose mode, per default switched-off
        /// </summary>
        private static bool _verbose = false;

        /// <summary>
        /// Public accessor for verbose mode
        /// </summary>
        public static bool Verbose
        {
            get { return LogHelper._verbose; }
            set { LogHelper._verbose = value; }
        }

        /// <summary>
        /// Set all options, passed with command line options.
        /// </summary>
        /// <param name="options">Options passed with command line options.</param>
        public static void SetOptions(CommonOptions options)
        {
            Verbose = options.verbose;
            MinVerboseLogLevel = options.minVerboseLevel;
        }

        #endregion

        /// <summary>
        /// Logs a message in a "standard" way to console and Logger.
        /// </summary>
        /// <param name="strMessage">Message to log.</param>
        public static void Log(LogLevel logLevel, string strMessage)
        {
            Log(logLevel, strMessage, LogManager.GetCurrentClassLogger());
        }

        /// <summary>
        /// Logs a message in a "standard" way to console and Logger.
        /// </summary>
        /// <param name="logLevel">Log Level to log</param>
        /// <param name="strMessage">Message to log.</param>
        /// <param name="logger">Logger to log the message.</param>
        public static void Log(LogLevel logLevel, string strMessage, ILog logger)
        {
            if (Verbose && (logLevel >= _minVerboseLogLevel | logLevel == LogLevel.All) )
            {
                Console.WriteLine(String.Format("{0} [{1}] {2}", DateTime.Now.ToString(), logLevel.ToString()[0], strMessage));
            }

            switch (logLevel)
            {
                // All Level
                case LogLevel.All:
                    // Log "All Level" as "Info"
                    logger.Info(m => m(strMessage));
                    break;
                // 6.fatal (the most serious)
                case LogLevel.Fatal:
                    logger.Fatal(m => m(strMessage));
                    break;
                // 5.error
                case LogLevel.Error:
                    logger.Error(m => m(strMessage));
                    break;
                // 4.warn
                case LogLevel.Warn:
                    logger.Warn(m => m(strMessage));
                    break;
                // 3.info
                case LogLevel.Info:
                    logger.Info(m => m(strMessage));
                    break;
                // 2.debug
                case LogLevel.Debug:
                    logger.Debug(m => m(strMessage));
                    break;
                // 1.trace (the least serious)
                case LogLevel.Trace:
                    logger.Trace(m => m(strMessage));
                    break;
                // No Level
                case LogLevel.Off:
                    break;
                // default
                default:
                    break;
            }
        }

        /// <summary>
        /// Logs an application startup message in a "standard" way to console and Logger.
        /// </summary>
        /// <param name="strStartMessage"></param>
        public static void LogAppStart(string strStartMessage)
        {
            Log(LogLevel.All, String.Format("**** {0} started. *******", strStartMessage));
            Log(LogLevel.Info, String.Format(">>> Starting {0}  --- Assembly Version={1} / Deployment Version={2} / Product Version={3} (using .NET 4.0) ... ",
                strStartMessage, "n/a", "n/a", Application.ProductVersion));
            //Console.WriteLine(">>> Starting Server Console  --- Assembly Version={0} / Deployment Version={1} / Product Version={2} (using .NET 4.0) ... ",
            //    AppInfoHelper.getAssemblyVersion(), AppInfoHelper.getDeploymentVersion(), Application.ProductVersion);
            Log(LogLevel.Info, String.Format("    Linux={0} / Detected environment: {1}", EnvironmentHelper.isRunningOnLinux(), EnvironmentHelper.getOperatingSystem()));
        }

        /// <summary>
        /// Logs an exception in a "standard" way to console and Logger.
        /// </summary>
        /// <param name="strMessage">Message to log.</param>
        /// <param name="exc">Exception to log.</param>
        public static void LogException(string strMessage, Exception exc)
        {
            Log(LogLevel.Fatal, String.Format("----------------\nException! {0} [{1}]\n----------------\n", strMessage, exc.ToString()));
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
            Log(LogLevel.Info, String.Format("    Command line arguments: {0}\n", strargs));
        }

/*
        /// <summary>
        /// Static method to print the endpoint collection to the logger.
        /// </summary>
        /// <param name="logger">Logger object.</param>
        /// <param name="endpointCollection">Endpoint collection to print.</param>
        public static void LogEndPoint(ILog logger, Collection<EndpointDiscoveryMetadata> endpointCollection)
        {
            foreach (EndpointDiscoveryMetadata ep in endpointCollection)
            {
                Log(LogLevel.Info, String.Format("Address={0}", ep.Address.ToString()), logger);
                foreach (Uri uri in ep.ListenUris)
                {
                    Log(LogLevel.Info, String.Format("  Uri.AbsolutePath={0}", uri.AbsolutePath), logger);
                    Log(LogLevel.Info, String.Format("  Uri.AbsoluteUri={0}", uri.AbsoluteUri), logger);
                    Log(LogLevel.Info, String.Format("  Uri.Host={0}", uri.Host));
                }
                Log(LogLevel.Info, String.Format("Version={0}", ep.Version), logger);
            }
        }
*/

/*
        /// <summary>
        /// Static method to print the endpoint collection to the console.
        /// </summary>
        /// <param name="endpointCollection">Endpoint collection to print.</param>
        public static void PrintEndPoints(Collection<EndpointDiscoveryMetadata> endpointCollection)
        {
            foreach (EndpointDiscoveryMetadata ep in endpointCollection)
            {
                Console.WriteLine("Address={0}", ep.Address.ToString());
                foreach (Uri uri in ep.ListenUris)
                {
                    Console.WriteLine("  Uri.AbsolutePath={0}", uri.AbsolutePath);
                    Console.WriteLine("  Uri.AbsoluteUri={0}", uri.AbsoluteUri);
                    Console.WriteLine("  Uri.Host={0}", uri.Host);
                }
                Console.WriteLine("Version={0}", ep.Version);
            }
        }
*/

    }
}
