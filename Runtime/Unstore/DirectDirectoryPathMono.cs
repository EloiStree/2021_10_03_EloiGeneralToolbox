using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDirectoryPathMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
{

    public Eloi.MetaAbsolutePathDirectory m_directoryPath;

    public override void GetPath(out string path)
    {
        path= m_directoryPath.GetPath();
    }

    public override string GetPath()
    {
        return m_directoryPath.GetPath(); 
    }
    [ContextMenu("Open Target")]
    public void OpenTargetWithUnity() { Application.OpenURL(GetPath()); }
    [ContextMenu("Open Directory")]
    public void OpenTargetDirectoryWithUnity()
    {
        Eloi.E_FilePathUnityUtility.GetDirectoryPathOf(GetPath(), out string dirPath);
        Application.OpenURL(dirPath);
    }
}
