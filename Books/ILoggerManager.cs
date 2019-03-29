using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public interface ILoggerManager
    {
        //Criando mensagens de log
        void LogInfo(string mensagem);
        void LogWarn(string mensagem);
        void LogDebug(string mensagem);
        void LogError(string mensagem);
    }
}
