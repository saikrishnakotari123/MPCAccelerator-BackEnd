#region Namespace
using MPCA.Contracts;
using NLog; 
#endregion

namespace MPCA.LoggerService
{
    /// <summary>
    /// Logger Manager (NLog)
    /// </summary>
    /// <seealso cref="MPCA.Contracts.ILoggerManager" />
    public class LoggerManager : ILoggerManager
    {
        #region Instance Variable
        /// <summary>
        /// The logger
        /// </summary>
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Methods
        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Logs the warn.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarn(string message)
        {
            logger.Warn(message);
        } 
        #endregion
    }
}
