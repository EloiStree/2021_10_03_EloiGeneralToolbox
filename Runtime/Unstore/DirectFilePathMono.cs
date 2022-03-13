using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectFilePathMono : Eloi.AbstractMetaAbsolutePathFileMono
{

    public Eloi.MetaAbsolutePathDirectory m_folderPath;
    public Eloi.MetaFileNameWithExtension m_fileName;

public override void GetPath(out string path)
{
        IMetaAbsolutePathDirectoryGet d = m_folderPath;
               IMetaFileNameWithExtensionGet f = m_fileName;
         path =E_FileAndFolderUtility.Combine(in d, in  f).GetPath();
}

public override string GetPath()
{
        GetPath(out string path);
        return path;
}

}
