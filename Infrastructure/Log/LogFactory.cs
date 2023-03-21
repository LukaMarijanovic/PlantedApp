namespace Infrastructure.Log
{
    public class LogFactory
    {
        private static ILogger _logger;
        public static ILogger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }

            return _logger;
        }
    }
}
