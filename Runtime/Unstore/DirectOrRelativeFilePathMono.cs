using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectOrRelativeFilePathMono : AbstractMetaAbsolutePathFileMono
{
    public Eloi.AbstractMetaAbsolutePathFileMono m_filePath;
    public Eloi.AbstractMetaAbsolutePathFileMono m_relativeToProjectFilePath;

    public override void GetPath(out string path)
    {
        if (m_filePath != null)
        {
            m_filePath.GetPath(out string directPath);
            if (directPath.Trim().Length > 0)
            {
                path = directPath;
                return;
            }
        }
        path = m_relativeToProjectFilePath.GetPath();
    }

    public override string GetPath()
    {
        GetPath(out string p);
        return p;
    }
}

