using UnityEngine;
using System.Collections;

public class AssetBundleLoader : MonoBehaviour
{
    public string baseUrl = "https://github.com/keijiro/unity-manybundles-test/raw/master/Bundles/";
    public int numberOfFiles = 1024;
    string lastLoaded = "";

    IEnumerator Start ()
    {
        for (var i = 0; i < numberOfFiles; i++) {
            var url = baseUrl + "bundle" + i.ToString ("0000") + ".unity3d";
            var www = WWW.LoadFromCacheOrDownload (url, 0);
            yield return www;
            if (www.error != null) {
                lastLoaded = www.error.ToString();
                break;
            }
            lastLoaded = www.assetBundle.mainAsset.name;
        }
    }

    void OnGUI ()
    {
        GUI.Label (new Rect (32, 32, 200, 200), lastLoaded); 
    }
}
