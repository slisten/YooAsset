namespace GF
{
    public interface ILogger
    {
        void I(string msg, params object[] args);
        void W(string msg, params object[] args);
        void E(string msg, params object[] args);
    }
}