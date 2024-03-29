using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateReadMeIfNotExisting : MonoBehaviour
{

    public Eloi.AbstractMetaAbsolutePathDirectoryMono m_whereToCreate;
    public ReadMeToCreate[] m_readsMe;
    public ReadMeStringToCreate[] m_readsMeString;
    public bool m_createAtStart=true;
    [System.Serializable]
    public class ReadMeStringToCreate
    {
        [TextArea(0,5)]
        public string m_readMe;
        public Eloi.MetaRelativePathFile m_subfolderFilePath;
    }

    [System.Serializable]
    public class ReadMeToCreate
    {
        public TextAsset m_readMe;
        public Eloi.MetaRelativePathFile m_subfolderFilePath;
    }

    void Start()
    {
        if (m_createAtStart) {

            CreateReadMe();
        }
        
    }

    [ContextMenu("Create Read Me")]
    public void CreateReadMe()
    {
        if (m_whereToCreate == null)
            return;

        string dir = m_whereToCreate.GetPath();
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        if (Directory.Exists(dir))
        {
            for (int i = 0; i < m_readsMe.Length; i++)
            {
                Eloi.E_FilePathUnityUtility.MeltPathTogether(out string path, in dir, m_readsMe[i].m_subfolderFilePath.GetPath());
                string d = Path.GetDirectoryName(path);
                if (!Directory.Exists(d))
                    Directory.CreateDirectory(d);
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, m_readsMe[i].m_readMe.text);
                }
            }
            for (int i = 0; i < m_readsMeString.Length; i++)
            {
                Eloi.E_FilePathUnityUtility.MeltPathTogether(out string path, in dir, m_readsMeString[i].m_subfolderFilePath.GetPath());
                string d = Path.GetDirectoryName(path);
                if (!Directory.Exists(d))
                    Directory.CreateDirectory(d);
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, m_readsMeString[i].m_readMe);
                }
            }
        }
    }
}
