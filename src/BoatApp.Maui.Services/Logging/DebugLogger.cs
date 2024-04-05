using System.Diagnostics.CodeAnalysis;
using BoatApp.Domain.Logging;

namespace BoatApp.Maui.Services.Logging;

[ExcludeFromCodeCoverage]
public class DebugLogger : IDebugLogger
{
    public void Debug(string message) => System.Diagnostics.Debug.Print(GetFormattedMessage("DEBUG", message));

    public void Error(string message) => System.Diagnostics.Debug.Print(GetFormattedMessage("ERROR", message));

    public void Error(Exception ex) => Debug(ex.ToString());

    public void Info(string message) => System.Diagnostics.Debug.Print(GetFormattedMessage("INFO", message));

    public void Write(string tag, string message) => System.Diagnostics.Debug.Print(GetFormattedMessage(tag, message));

    private static string GetFormattedMessage(string tag, string message)
    {
        var prefix = DateTime.Now.ToString($"MM-dd-yyyy HH:mm:ss.fff");
        message = message.Trim();

        return prefix + $" ({tag}): {message}";
    }

}
