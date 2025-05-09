﻿namespace BoatApp.Domain.Logging;

public interface IDebugLogger
{
    void Debug(string message);

    void Error(string message);

    void Error(Exception ex);

    void Info(string message);

    void Write(string tag, string message);
}