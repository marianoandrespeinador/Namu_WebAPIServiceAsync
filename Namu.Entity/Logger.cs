using System;
using System.Diagnostics;

namespace Namu.Entity
{
    /// <summary>
    /// Logger es una pequeña utilidad para Loggear
    /// lo que uno quiera con -System.Diagnostics- de manera asíncrona.
    /// Output Configurado en la sección -System.Diagnostics- del archivo .config del app
    /// </summary>
    public static class Logger
    {
        public static void Error(string message, string module)
        {
            WriteEntry(message, "error", module);
        }

        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.Message, "error", module);
        }

        public static void Warning(string message, string module)
        {
            WriteEntry(message, "warning", module);
        }

        public static void Info(string message, string module)
        {
            WriteEntry(message, "info", module);
        }

        private static void WriteEntry(string message, string type, string module)
        {
            Trace.WriteLine(
                string.Format("{0},{1},{2},{3}",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    type,
                    module,
                    message));
        }
    }
}