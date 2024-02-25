using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines locations where logs can be generated.
/// </summary>
public enum LogLocation
{
    GameManager,
    Controller,
    Snake,
    SnakeNode,
    EventBridge
}

/// <summary>
/// Provides a centralized logging system for the application.
/// </summary>
public static class Logger
{
    /// <summary>
    /// Enables or disables logging throughout the application.
    /// </summary>
    public static bool IsLoggingEnabled { get; set; } = true;

    /// <summary>
    /// Logs a message with specified color and location.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="location">The location from which the log is generated.</param>
    /// <param name="color">The color of the message. Default is white.</param>
    /// <remarks>
    /// If logging is disabled, this method returns without logging the message.
    /// </remarks>
    public static void Log(string message, LogLocation location, string color = "white")
    {
        if (!IsLoggingEnabled) return;

        string formattedMessage = $"[{location}] {message}";
        Debug.Log($"<color={color}>{formattedMessage}</color>");
    }

    /// <summary>
    /// Logs a warning message with an optional location.
    /// </summary>
    /// <param name="message">The warning message to log.</param>
    /// <param name="location">The location from which the log is generated. Default is unspecified.</param>
    /// <remarks>
    /// This method uses a yellow color for warning messages.
    /// </remarks>
    public static void Warning(string message, LogLocation location)
    {
        Log(message, location, "yellow");
    }

    /// <summary>
    /// Logs an error message with an optional location.
    /// </summary>
    /// <param name="message">The error message to log.</param>
    /// <param name="location">The location from which the log is generated. Default is unspecified.</param>
    /// <remarks>
    /// This method uses a red color for error messages.
    /// </remarks>
    public static void Error(string message, LogLocation location)
    {
        Log(message, location, "red");
    }
}

