using System;
using Microsoft.Xrm.Sdk;

namespace PZone.Xrm.Plugins
{
    /// <summary>
    /// Плагин завершен с ошибкой.
    /// </summary>
    public class ErrorPluginResult : IPluginResult
    {
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string Message { get; }


        /// <summary>
        /// Содержимое исключения.
        /// </summary>
        public Exception Exception { get; }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public ErrorPluginResult(string message)
        {
            Message = string.IsNullOrWhiteSpace(message) ? "Ошибка выполнения плагина." : message;
        }


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <param name="exception">Содержимое исключения.</param>
        public ErrorPluginResult(string message, Exception exception)
        {
            Exception = exception;
            Message = string.IsNullOrWhiteSpace(message) 
                ? exception == null ? "Ошибка выполнения плагина." : exception.Message 
                : message;
        }


        /// <inheritdoc />
        public void Result()
        {
            throw new InvalidPluginExecutionException(Message, Exception);
        }
    }
}