using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public static void MeltPathTogether(out string metlPath, in string rootFolderPath, params string[] subFolders)
        {
            List<string> cleanPart = new List<string>();
            TrimAtEndSlashAndBackSlashIfThereAre(in rootFolderPath, out string rootPathTrimmed);
            cleanPart.Add(rootPathTrimmed);
            for (int i = 0; i < subFolders.Length; i++)
            {
                TrimSlashAndBackSlashIfThereAre(in subFolders[i], out string trimmed);
                cleanPart.Add(trimmed);

            }
            metlPath = string.Join("/", cleanPart);
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

            char c = rootPath[rootPath.Length - 1];
            if (c == '/' || c == '\\')
            {
                trimRootPath = rootPath.Substring(0, rootPath.Length - 1);
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
            result = source.Replace("\\", "/");

        }
    }

    [System.Serializable]
    public class MetaFileExtension
    {
        [SerializeField] string m_extensionNameWithoutDot = "";

        public MetaFileExtension(string extensionNameWithoutDot)
        {
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }

        public void SetExtension(in string fileExtensionWithoutDot)
        {
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
    }

    [System.Serializable]
    public class MetaPath
    {
        [SerializeField] string m_path = "";
        public void GetPath(out string path) => path = m_path;
        public void SetPath(string path) => m_path = path;
        public string GetPathRef()
        {
            return m_path;
        }
        public MetaPath()
        {
        }

        public MetaPath(string path)
        {
            this.m_path = path;
        }
    }
    [System.Serializable]
    public class MetaFileNameWithoutExtension
    {
        [SerializeField] string m_fileName="";

        public MetaFileNameWithoutExtension()
        {
        }

        public MetaFileNameWithoutExtension(string fileName)
        {
            this.m_fileName = fileName;
        }

        public void GetName(out string fileName) => fileName = m_fileName;
        public void SetPath(string fileName) => m_fileName = fileName;
    }
    [System.Serializable]
    public class MetaFileNameWithExtension
    {
        [SerializeField] string m_fileName = "";
        [SerializeField] string m_extensionNameWithoutDot = "";

        public MetaFileNameWithExtension(string fileName, string extensionNameWithoutDot)
        {
            this.m_fileName = fileName;
            this.m_extensionNameWithoutDot = extensionNameWithoutDot;
        }

        public void SetFileName(in string fileName, in string fileExtensionWithoutDot) {
            m_fileName = fileName;
            m_extensionNameWithoutDot = fileExtensionWithoutDot;
        }
        public void GetExtensionWithoutDot(out string extension) => extension = m_extensionNameWithoutDot;
        public void GetExtensionWithDot(out string extension) => extension = "."+m_extensionNameWithoutDot;
        public void GetFileNameWithoutExtension(out string fileName) { fileName = m_fileName; }
        public void GetFileNameWithExtension(out string fileName) { fileName = m_fileName+"."+m_extensionNameWithoutDot; }
    }
    [System.Serializable]
    public class MetaAbsolutePathFile : MetaPath
    {
        public MetaAbsolutePathFile(string path) : base(path)
        {
        }
    }
    [System.Serializable]
    public class MetaRelativePathFile : MetaPath
    {
        public MetaRelativePathFile(string path) : base(path)
        {
        }
    }
    [System.Serializable]
    public class MetaAbsolutePathDirectory : MetaPath
    {
        public MetaAbsolutePathDirectory(string path) : base(path)
        {
        }

        
    }
    [System.Serializable]
    public class MetaRelativePathDirectory : MetaPath
    {
        public MetaRelativePathDirectory(string path) : base(path)
        {
        }
    }


    public class E_FileAndFolderUtility
    {
        public static void CreateFolderIfNotThere(in string path)
        {
            if (E_StringUtility.IsFilled(in path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public static void CreateTextFileIfNotThere(in string path, in string text)
        {
            if (!File.Exists(path)) {
                string dirPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                File.WriteAllText(path, text);
            }
        }

        public static void LoadTexture2DFromFile(in string path, out Texture2D texture) {

            if (Exists(in path))
            {
                byte[] buffer = File.ReadAllBytes(path);
                texture = new Texture2D(1, 1);
                texture.LoadImage(buffer);
            }
            else texture = null;

        }

        public static bool Exists(in string path)
        {
            return File.Exists(path);
        }
        public static bool DontExists(in string path)
        {
            return !File.Exists(path);
        }

        public static void OverrideFilePNG(in string path, in Texture2D texture, out bool succced)
        {
            succced = false;
            try
            {
                File.WriteAllBytes(path, texture.EncodeToPNG());
                succced = true;
            }
            catch {      }
        }
        public static void OverrideFileJPEG(in string path, in Texture2D texture, out bool succced)
        {
            succced = false;
            try
            {
                File.WriteAllBytes(path, texture.EncodeToJPG());
                succced = true;
            }
            catch { }
        }

        public static MetaAbsolutePathDirectory Combine(in MetaAbsolutePathDirectory root, params MetaRelativePathDirectory[] subfolders)
        {
            string[] paths = subfolders.Select(k => k.GetPathRef()).ToArray();
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPathRef(), paths);
            return new MetaAbsolutePathDirectory(path);
        }
        public static MetaAbsolutePathFile Combine(in MetaAbsolutePathDirectory root, in MetaFileNameWithExtension fileName)
        {
            fileName.GetFileNameWithExtension(out string fileExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPathRef() , fileExt ) ;
            return new MetaAbsolutePathFile(path);
        }

        public static void MoveOverride(in MetaAbsolutePathFile from, in MetaAbsolutePathFile to, out bool succedTransfert)
        {
            succedTransfert = false;
            string sfrom = from.GetPathRef(), sto = to.GetPathRef();

            if (Exists(in sto))
            {
                try
                {
                    File.Delete(sto);
                }
                catch { }
            }

            if (Exists(in sfrom) && Eloi.E_StringUtility.IsFilled(sto)) {
                try
                {
                    File.Move(sfrom, sto);
                    succedTransfert = true;
                }
                catch { }
            }

        }

        public static void GetFilesPathsIn(out string[] paths, MetaFileExtension fileOverwatch, MetaAbsolutePathDirectory directory, bool lookInChildren=true)
        {
            string dPath = directory.GetPathRef();
            if (E_StringUtility.IsFilled(in dPath) && Directory.Exists(dPath))
            {
                fileOverwatch.GetExtensionWithDot(out string fileExt);
                paths = Directory.GetFiles(dPath, "*" + fileExt, lookInChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            else {
                paths = new string[0];
            }
        }

        public static void MoveOverride(in MetaAbsolutePathFile filePath, in MetaAbsolutePathDirectory receivedDirectory, out bool succedToMove)
        {
            ExtractFileWithExtension(filePath, out MetaFileNameWithExtension fileName);
            MetaAbsolutePathFile destination= Combine( in receivedDirectory, in fileName);
            MoveOverride(filePath, destination, out succedToMove);

        }

        public static void ExtractFileWithExtension(in MetaAbsolutePathFile filePath, out MetaFileNameWithExtension fileName)
        {
            string path = filePath.GetPathRef();
            string name=Path.GetFileNameWithoutExtension(path),
                extension = Path.GetExtension(path);
            if (E_StringUtility.IsFilled(extension) && extension[0] == '.')
                extension = extension.Substring(1);
            fileName = new MetaFileNameWithExtension(name, extension);
        }
    }
}