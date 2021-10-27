using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ApplicationBasicActionsMono : MonoBehaviour
{

    public void OpenProjectRoot()
    {
        Application.OpenURL(Directory.GetCurrentDirectory());
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void OpenRootRelativeFolder(string relativePath)
    {
        Eloi.E_FilePathUnityUtility.MeltPathTogether(out string path, Directory.GetCurrentDirectory(), relativePath);
        Application.OpenURL(path);
    }

    public void QuitTheApplication() {
        Application.Quit();
    }
}
