namespace BoatApp.Domain.Logging;

public interface IAppCenterLogger
{
    Task Init();
    void LogEvent(string name, IDictionary<string, string> properties = null);
    void LogError(Exception exception, IDictionary<string, string> properties = null);
    void LogError<T>(Exception exception, string payloadName, T payload) where T : class;
}