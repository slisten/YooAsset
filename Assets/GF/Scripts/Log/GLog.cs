using UnityEngine;

namespace GF
{
    public static class GLog
    {
        private static ILogger logger;

        public static void Init(ILogger loggerIns = null)
        {
            if (loggerIns == null)
            {
                logger = new DefaultLogger();
                return;
            }
            logger = loggerIns;
        }

        public static void I(string msg, params object[] args)
        {
            logger.I(msg, args);
        }
        
        public static void W(string msg, params object[] args)
        {
            logger.W(msg, args);
        }
        
        public static void E(string msg, params object[] args)
        {
            logger.E(msg, args);
        }
    }
}