using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class E_FilePathUnityUtility 
    {

        /// <summary>
        /// This methode will take the root path and the subfolder path. Remove the border / and \\ then join then with / together as a meltpath
        /// </summary>
        /// <param name="metlPath"></param>
        /// <param name="rootFolderPath"></param>
        /// <param name="subFolders"></param>
        public static void MeltPathTogether(out string metlPath , in string rootFolderPath, params string[] subFolders) {
            List<string> cleanPart = new List<string>();
            TrimAtEndSlashAndBackSlashIfThereAre(in rootFolderPath, out string rootPathTrimmed);
            cleanPart.Add(rootPathTrimmed);
            for (int i = 0; i < subFolders.Length; i++)
            {
                TrimSlashAndBackSlashIfThereAre(in subFolders[i], out string trimmed);
                cleanPart.Add(trimmed);

            }
            metlPath = string.Join("\\", cleanPart);
            Eloi.E_CodeTag.QualityAssurance.RequestTestingInTheFuture();
        }

        public static void TrimSlashAndBackSlashIfThereAre(in string rootPath, out string triRootPath)
        {
            TrimAtStartSlashAndBackSlashIfThereAre(in rootPath, out string trimmedAtStart);
            TrimAtEndSlashAndBackSlashIfThereAre(in trimmedAtStart, out triRootPath);
        }

        public static void TrimAtEndSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }
           
            char c = rootPath[rootPath.Length-1];
            if (c == '/' || c == '\\') {
                trimRootPath = rootPath.Substring(0, rootPath.Length-1);
            }
        }

        public static void TrimAtStartSlashAndBackSlashIfThereAre(in string rootPath, out string trimRootPath)
        {
            trimRootPath = rootPath;
            if (rootPath == null || rootPath.Length <= 0)
            {
                return;
            }
            if (rootPath[0] == '/' || rootPath[0] == '\\')
                trimRootPath = rootPath.Substring(1);
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

        public static void AllBackslash(in string source, out string result)
        {
            result = source.Replace("/", "\\");

        }
        public static void AllSlash(in string source, out string result)
        {
            result = source.Replace( "\\", "/");

        }
    }
}
