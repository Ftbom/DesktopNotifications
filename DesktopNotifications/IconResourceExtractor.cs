using System.IO;

namespace DesktopNotifications
{
    public static class IconResourceExtractor
    {
        private static readonly string TempDir = Path.Combine(Path.GetTempPath(), "DesktopNotificationsLib", "Icons");
        public static string? GetExtractedIconPath(string? fileName)
        {
            if (fileName == null)
            {
                return null;
            }

            string targetPath = Path.Combine(TempDir, fileName);

            if (File.Exists(targetPath))
            {
                return targetPath;
            }

            Directory.CreateDirectory(TempDir);

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            string resourceName = $"DesktopNotifications.Assets.{fileName}";

            using Stream? resourceStream = assembly.GetManifestResourceStream(resourceName);
            if (resourceStream == null)
            {
                return null;
            }

            using FileStream fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write);
            resourceStream.CopyTo(fileStream);

            return targetPath;
        }
        public static string? GetExtractedIconPath(NotificationLevel? level)
        {
            return GetExtractedIconPath(GetNotificationIconName(level));
        }
        public static string? GetNotificationIconName(NotificationLevel? level)
        {
            return level switch
            {
                NotificationLevel.Error => "icon-error.png",
                NotificationLevel.Warning => "icon-warning.png",
                NotificationLevel.Success => "icon-success.png",
                NotificationLevel.Info => "icon-info.png",
                _ => null
            };
        }
    }
}
