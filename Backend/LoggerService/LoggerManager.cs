using System;
using System.Collections.Generic;
using System.Text;
using Books;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {

        }

        public void LogDebug(string mensagem)
        {
            logger.Debug(mensagem);
        }

        public void LogError(string mensagem)
        {
            logger.Error(mensagem);
        }

        public void LogInfo(string mensagem)
        {
            logger.Info(mensagem);
        }

        public void LogWarn(string mensagem)
        {
            logger.Warn(mensagem);
        }
    }
}
