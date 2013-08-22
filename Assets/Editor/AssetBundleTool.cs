using UnityEngine;
using UnityEditor;
using System.Collections;

public static class AssetBundleTool {
    [MenuItem("Asset Bundle/Build asset bundles")]
    static void BuildAssetBundles() {
        var options = BuildAssetBundleOptions.CompleteAssets;
        for (var i = 0; i < 1024; i++) {
            var path = "Assets/Dataset/file" + i.ToString("0000") + ".bytes";
            var asset = AssetDatabase.LoadMainAssetAtPath(path) as TextAsset;
            Object[] assets = { asset };
            var destPath = "Bundles/bundle" + i.ToString("0000") + ".unity3d";
            BuildPipeline.BuildAssetBundle(asset, assets, destPath, options, BuildTarget.iPhone);
        }
    }
}