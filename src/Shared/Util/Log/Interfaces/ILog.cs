﻿using System;

namespace Shared.Util.Log.Interfaces {
    public interface ILog {
        string Name { get; }

        void LogInfo(string Message, params object[] Args);
        void LogSuccess(string Message, params object[] Args);
        void LogWarning(string Message, params object[] Args);
        void LogError(string Message, params object[] Args);
        void LogFatal(Exception e);
    }
}