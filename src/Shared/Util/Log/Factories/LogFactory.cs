using System;
using System.Collections.Generic;
using Shared.Util.Log.Abstracts;
using Shared.Util.Log.Enums;
using Shared.Util.Log.EventArgs;
using Shared.Util.Log.Interfaces;

namespace Shared.Util.Log.Factories {
    public class LogFactory {
        private static Dictionary<string, ILog> _logs ;
        public static event EventHandler<LogWriteEventArgs> OnWrite;

        public static void Initalize() {
            _logs = new Dictionary<string, ILog>();
            /*var width = Console.LargestWindowWidth * 50 / 100;
            var height = Console.LargestWindowHeight * 50 / 100;

            if (width > 0 && height > 0)
                Console.SetWindowSize(width, height);*/
        }

        public static void Destroy() {

        }

        public static ILog GetLog(string name) {
            /*if (!_logs.ContainsKey(name)) {
                ILog log = new Log(name);
                _logs.Add(name, log);
            }*/
            //return _logs[name];
            return new Log(name);
        }

        /*public static ILog GetLog(Type logType) {
            return GetLog(logType.Name);
        }*/

        /*public static ILog GetLog(object instance) {
            return GetLog(instance.GetType());
        }

        public static ILog GetLog<T>() {
            return GetLog(typeof(T));
        }*/

        private static void CallOnWrite(ILog log, string message, LogType type) {
            if (OnWrite != null) {
                var args = new LogWriteEventArgs(log, message, type);
                OnWrite(log, args);
            }
        }

        private class Log : ILog {
            public Log(string name) {
                Name = name;
            }

            public string Name { get; }

            public void LogInfo(string message, params object[] args) {
                if(args.Length > 0) message = string.Format(message, args);
                CallOnWrite(this, message, LogType.Information);
            }

            public void LogSuccess(string message, params object[] args) {
                if(args.Length > 0) message = string.Format(message, args);
                CallOnWrite(this, message, LogType.Success);
            }

            public void LogWarning(string message, params object[] args) {
                if(args.Length > 0) message = string.Format(message, args);
                CallOnWrite(this, message, LogType.Warning);
            }

            public void LogError(string message, params object[] args) {
                if(args.Length > 0) message = string.Format(message, args);
                CallOnWrite(this, message, LogType.Error);
            }

            public void LogFatal(Exception e) {
                var message = string.Format("Name: {1}{0}Message: {2}{0}Stack trace:{3}", Environment.NewLine,
                    e.GetType().Name, e.Message, e.StackTrace);
                CallOnWrite(this, message, LogType.Fatal);
            }
        }
    }
}