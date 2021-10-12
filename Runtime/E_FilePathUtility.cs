using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_FilePathUnityUtility : MonoBehaviour
    {

        public static void MeltPathTogether(string rootPath, params string[] subFolders) {

            List<string> clean = new List<string>();
            E_CodeTag.NotTimeNowButUrgent.Info("I use so many time this code of fusionning path and remove the /\\. That i need to code this here.ASAP");
            E_CodeTag.SleepyCode.Info("I am bit dizzy and I need full focus for this one");
        }


        public static void GetEditorWindowAssetsFolderPath(out string path)
        {
            throw new System.NotImplementedException("Yo");
        }
        public static void GetEditorWindowRootFolderPath(out string path)
        {
            throw new System.NotImplementedException("Yo");
        }

        public static void GetRuntimeWindowExeFolderPath(out string path)
        {
            throw new System.NotImplementedException("Yo");
        }
        public static void GetEditorWindowDataFolderPath(out string path)
        {
            throw new System.NotImplementedException("Yo");
        }
        public static void GetRuntimeWindowDataFolderPath(out string path)
        {
            throw new System.NotImplementedException("Yo");
        }
    }
}
