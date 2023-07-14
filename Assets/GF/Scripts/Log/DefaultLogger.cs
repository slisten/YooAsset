using UnityEngine;

namespace GF
{
    public class DefaultLogger: ILogger
    {
        public void I(string msg, params object[] args)
        {
            Debug.Log(FormatMsg(msg, args));
        }

        public void W(string msg, params object[] args)
        {
            Debug.LogWarning(FormatMsg(msg, args));
        }

        public void E(string msg, params object[] args)
        {
            Debug.LogError(FormatMsg(msg, args));
        }

        private string FormatMsg(string msg, params object[] args)
        {
            if (args == null || args.Length <= 0)
            {
                return msg;
            }
            
            return string.Format(msg, args);
        }
    }
}