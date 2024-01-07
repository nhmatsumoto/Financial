using Microsoft.Extensions.Logging;

namespace NHMatsumoto.Financial.Infrastructure.CrossCutting.IoC
{
    public class LoggerService<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogCritical(string message, object obj)
        {
            _logger.LogCritical(message, obj);
        }
    }
}
