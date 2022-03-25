using UnityEngine;
using UnityEditor;
using System;
using System.IO;

// KJ: You can statically use an elemnt so you don't need
// to put Path.Combine(...) and can just do Combine(...)
using static System.IO.Path;

public class ScreenshotTool
{
    #region Callable Methods
    [MenuItem("Window/Screenshot/Game Window Resolution")]
    private static void ScreenshotNormalSize() => Screenshot();

    [MenuItem("Window/Screenshot/Game Window Resolution x2")]
    private static void ScreenshotDoubleSize() => Screenshot(2);

    [MenuItem("Window/Screenshot/Game Window Resolution x3")]
    private static void ScreenshotTripleSize() => Screenshot(3);

    [MenuItem("Window/Screenshot/Game Window Resolution x4")]
    private static void ScreenshotQuadrupleSize() => Screenshot(4);
    #endregion

    // Standard Method
    private static void Screenshot(int scaleFactor = 1)
    {
        // Make sure no 0 or negative values are entered
        scaleFactor = Mathf.Max(scaleFactor, 1);

        // Minecraft datetime format.
        string dateFormat = "yyyy-MM-dd_HH.mm.ss";

        string filePath = "Screenshots";
        string fileName = DateTime.Now.ToString(dateFormat);
        string fileType = ".png";

        // Make sure we can store the image.
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        // Create full filepath and check it's we won't override anything.
        string fullPath = Combine(filePath, fileName + fileType);
        fullPath = IncrementFilenameIfExists(fullPath);

        // Capture the screen shot and tell the user about it!
        ScreenCapture.CaptureScreenshot(fullPath, scaleFactor);
        Debug.Log($"Screenshot saved to \"{fullPath}\"");
    }

    // Makes sure files won't override eachother when saving,
    // It does this by returning "path/filename (x).extension"
    private static string IncrementFilenameIfExists(string path)
    {
        // Store path and remove it for easy filename changes
        string extension = GetExtension(path);
        string editPath = ChangeExtension(path, null);

        // Make sure no null or empty file names are used.
        if (String.IsNullOrEmpty(GetFileName(editPath)))
        {
            throw new ArgumentException("Parameter for IO path cannot be null or empty", nameof(path));
        }
        
        // KJ: Time to go through all the paths now...
        int counter = 0;
        while (File.Exists(path))
        {
            counter++;
            // KJ: Don't know how other operating systems do it but it's gonna be the windows way!
            path = ChangeExtension(editPath + $" ({counter})", extension);
        }

        return path;
    }
}
