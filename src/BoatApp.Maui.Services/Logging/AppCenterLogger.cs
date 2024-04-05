using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using BoatApp.Common.Constants;
using BoatApp.Domain.Logging;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace BoatApp.Maui.Services.Logging;

[ExcludeFromCodeCoverage]
public class AppCenterLogger : IAppCenterLogger
{
    public async Task Init()
    {
#if ANDROID || IOS
        AppCenter.Start($"android={AppConstants.AppCenterAndroidKey};ios={AppConstants.AppCenteriOsKey}", typeof(Analytics), typeof(Crashes));
        await InitializeAnalyticsReport();
        await InitializeCrashReport();
#endif
    }

    public void LogError<T>(Exception exception, string payloadName, T payload) where T : class
    {
#if ANDROID || IOS
        var payloadString = JsonSerializer.Serialize(payload);
        Crashes.TrackError(exception, null, ErrorAttachmentLog.AttachmentWithText(payloadString, $"{payloadName}.json"));
#endif
    }

    public void LogError(Exception exception, IDictionary<string, string> properties = null)
    {
#if ANDROID || IOS
        Crashes.TrackError(exception, properties);
#endif
    }

    public void LogEvent(string name, IDictionary<string, string> properties = null)
    {
#if ANDROID || IOS
        Analytics.TrackEvent($"{AppConstants.AppCenterEventPrefix} {name}", properties);
#endif
    }

    private static Task InitializeAnalyticsReport() => Analytics.SetEnabledAsync(true);

    private static async Task InitializeCrashReport()
    {
        Crashes.SendingErrorReport += (sender, e) =>
        {
            AppCenterLog.Info(AppConstants.AppCenterLogTag, "Sending error report");

            var args = e;
            var report = args.Report;
            LogReport(report, null);
        };

        Crashes.SentErrorReport += (sender, e) =>
        {
            AppCenterLog.Info(AppConstants.AppCenterLogTag, "Sent error report");

            var args = e;
            var report = args.Report;
            LogReport(report, null);
        };

        Crashes.FailedToSendErrorReport += (sender, e) =>
        {
            AppCenterLog.Info(AppConstants.AppCenterLogTag, "Failed to send error report");

            var args = e;
            var report = args.Report;
            LogReport(report, e.Exception);
        };

        Crashes.ShouldAwaitUserConfirmation = AskForCrashSendingPermission;

        await Crashes.SetEnabledAsync(true);
    }

    private static bool AskForCrashSendingPermission()
    {
        Analytics.TrackEvent("CrashReportPermission");
        //  TODO: Crash Reporting Confirmation Dialog
        //  Build your own UI to ask for user consent here. SDK doesn't provide one by default.
        //  Return true if you built a UI for user consent and are waiting for user input on that custom UI, otherwise false.
        return false;
    }


    private static void LogReport(ErrorReport report, object exception)
    {
        if (!string.IsNullOrEmpty(report.StackTrace))
        {
            AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.StackTrace);
        }
        else
        {
            AppCenterLog.Verbose(AppConstants.AppCenterLogTag, "No system exception was found");
        }

        if (report.AndroidDetails != null)
        {
            AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.AndroidDetails.ThreadName);
        }
        else if (report.AppleDetails != null)
        {
            AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.AppleDetails.ExceptionName);
        }

        if (exception != null)
        {
            AppCenterLog.Verbose(AppConstants.AppCenterLogTag, "There is an exception associated with the failure");
        }
    }
}
