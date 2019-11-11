using System.IO;

namespace EloBoost.Shared.Extensions
{
    public static class FileExtensions
    {
        /// <summary>
        /// Checks file exists
        /// </summary>
        public static bool FileExists(this string filePathName) => File.Exists(filePathName);

        /// <summary>
        /// Get the file size of a given filename.
        /// </summary>
        public static long FileSize(this string filePath)
        {
            long bytes = 0;

            try
            {
                var oFileInfo = new FileInfo(filePath);
                bytes = oFileInfo.Length;
            }
            catch
            {
                //ignored
            }
            return bytes;
        }

        /// <summary>
        /// Nicely formatted file size. This method will return file size with bytes, KB, MB and GB in it. You can use this alongside the Extension method named FileSize.
        /// </summary>
        public static string FormatFileSize(this int fileSize)
        {
            //declarations
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            var j = 0;

            //loop and divide
            while (fileSize > 1024 && j < (suffix.Length - 1))
            {
                fileSize = fileSize / 1024;
                j++;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            return $"{fileSize:0} {suffix[j]}";
        }
    }
}