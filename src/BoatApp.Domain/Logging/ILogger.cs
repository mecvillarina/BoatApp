namespace BoatApp.Domain.Logging;

public interface ILogger
{
    void AppCenterLogEvent(string name, IDictionary<string, string> properties = null);
    void AppCenterLogEvent(string name, string key, string value);
    void AppCenterLogError(Exception exception);
    void AppCenterLogError(Exception exception, IDictionary<string, string> properties);
    void AppCenterLogError<T>(Exception exception, string payloadName, T payload) where T : class;

    void Debug(string message);
    void Error(string message);
    void Error(Exception ex);
    void Info(string message);
    void Write(string tag, string message);
}