using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildTest : Editor
{
    [MenuItem("Test/Build", false, 2)]
    public static void Build()
    {
        string path = Application.dataPath + "/../Bundles";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
}
