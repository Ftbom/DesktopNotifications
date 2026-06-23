using System;
using System.Collections.Generic;

namespace DesktopNotifications
{
    public enum NotificationLevel
    {
        Info,
        Success,
        Warning,
        Error
    }
    /// <summary>
    /// </summary>
    public class Notification
    {
        public Notification()
        {
            Buttons = new List<(string Title, string ActionId)>();
        }
        public NotificationLevel? Level { get; set; }
        public string? Title { get; set; }

        public string? Body { get; set; }

        public string? BodyImagePath { get; set; }

        public string BodyImageAltText { get; set; } = "Image";

        public List<(string Title, string ActionId)> Buttons { get; }
    }
}