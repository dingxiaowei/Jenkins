using UnityEditor;
using System.IO;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

class PerformBuild
{
    static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();

        foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if (e == null)
                continue;

            if (e.enabled)
                names.Add(e.path);
        }
        return names.ToArray();
    }

    static string GetBuildPath()
    {
        string dirPath = Application.dataPath + "/../build/iPhone";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        return dirPath;
    }

    [UnityEditor.MenuItem("Tools/PerformBuild/Test Command Line Build iPhone Step")]
    static void CommandLineBuild()
    {
        Debug.Log("Command line build\n------------------\n------------------");

        string[] scenes = GetBuildScenes();
        string path = GetBuildPath();
        if (scenes == null || scenes.Length == 0 || path == null)
            return;

        Debug.Log(string.Format("Path: \"{0}\"", path));
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }

        Debug.Log("Starting Build!");
        BuildPipeline.BuildPlayer(scenes, path, BuildTarget.iOS, BuildOptions.None);
    }

    static string GetBuildPathAndroid()
    {
        string dirPath = Application.dataPath.Replace("/Assets", "") + "/../build/android/"+Application.productName+".apk";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        return dirPath;
    }

    [UnityEditor.MenuItem("Tools/PerformBuild/Test Command Line Build Step Android")]
    static void CommandLineBuildAndroid()
    {
        Debug.Log("Command line build android version\n------------------\n------------------");

        string[] scenes = GetBuildScenes();
        string path = GetBuildPathAndroid();
        if (scenes == null || scenes.Length == 0 || path == null)
        {
            Debug.LogError("Please add scene to buildsetting...");
            return;
        }

        Debug.Log(string.Format("Path: \"{0}\"", path));
        for (int i = 0; i < scenes.Length; ++i)
        {
            Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
        }

        Debug.Log("Starting Android Build!");
        BuildPipeline.BuildPlayer(scenes, path, BuildTarget.Android, BuildOptions.None);
    }
}