using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Eloi;
    using System.IO;

    public class DefaultDirectoryInNearExeDataPathStorageMono : Eloi.AbstractMetaAbsolutePathDirectoryMono
    {
        public Eloi.MetaRelativePathDirectory m_subfolders;

        public string m_debugPath;

        [ContextMenu("Verify Path builded in Editor")]
        public void GetEditorDebugPath()
        {
            GetPath(out string p);
        }
        [ContextMenu("Verify Path builded in Editor")]
        public void TryToOpenEditorDebugPath()
        {

            Application.OpenURL(m_debugPath);
        }
        [ContextMenu("Try to open Path builded in Editor")]
        public void TryToOpenEditorDebugPathFolder()
        {

            Application.OpenURL(Path.GetDirectoryName(m_debugPath));
        }

        public override void GetPath(out string path)
        {
            IMetaAbsolutePathDirectoryGet dir = new MetaAbsolutePathDirectory(Application.dataPath);
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            dir = E_FileAndFolderUtility.GetParent(in dir);
#else
        dir = new MetaAbsolutePathDirectory(Application.persistentDataPath);
#endif
            IMetaAbsolutePathDirectoryGet pathResult = Eloi.E_FileAndFolderUtility.Combine(dir, m_subfolders);
            pathResult.GetPath(out path);
            m_debugPath = path;
        }

        public override string GetPath()
        {
            GetPath(out string p);
            return p;
        }
        [ContextMenu("Create directory")]
        public void CreateDirectoryIfNotExisting() {
            Directory.CreateDirectory(GetPath());
        }

        


    }

}
