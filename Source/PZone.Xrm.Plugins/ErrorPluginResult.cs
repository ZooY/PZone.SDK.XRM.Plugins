using Microsoft.Xrm.Sdk;

namespace PZone.Xrm.Plugins
{
    /// <summary>
    /// Плагин завершен с ошибкой.
    /// </summary>
    public class ErrorPluginResult : IPluginResult
    {
        private readonly string _message;


        /// <summary>
        /// Конструтор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public ErrorPluginResult(string message)
        {
            _message = message;
        }


        /// <inheritdoc />
        public void Result()
        {
            throw new InvalidPluginExecutionException(string.IsNullOrWhiteSpace(_message) ? "Ошибка выполнения плагина." : _message);
        }
    }
}