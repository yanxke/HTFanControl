﻿using System;
using System.Collections.Generic;
using System.IO;

namespace HTFanControl.Util
{
    public class Log
    {
        private readonly string _logPath = Path.Combine(ConfigHelper._rootPath, "EventLog.txt");

        public LinkedList<string> RealtimeLog { get; } = new LinkedList<string>();

        public Log()
        {
            try
            {
                File.Delete(_logPath);
            }
            catch { }
        }

        public void LogMsg(string line)
        {
            string timestamp = $"[{DateTime.Now:hh:mm:ss.fff}]: ";

            Console.WriteLine($"{timestamp}{line}");

            try
            {
                File.AppendAllText(_logPath, $"{timestamp}{line}{Environment.NewLine}");
            }
            catch { }

            RealtimeLog.AddFirst($"{timestamp}{line}");
            if(RealtimeLog.Count > 50)
            {
                RealtimeLog.RemoveLast();
            }
        }
    }
}