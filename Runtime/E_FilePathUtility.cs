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

        //public static void GetEditorWindowAssetsFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetEditorWindowRootFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}

        //public static void GetRuntimeWindowExeFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetEditorWindowDataFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}
        //public static void GetRuntimeWindowDataFolderPath(out string path)
        //{
        //    throw new System.NotImplementedException("Yo");
        //}

        public static void AllBackslash(in string source, out string result)
        {
            result = source.Replace("/", "\\");

        }
        public static void AllSlash(in string source, out string result)
        {
            result = source.Replace("\\", "/");
        }

        public static void GetJustDirectoryName(in string directoryPath, out string name)
        {
            string under = Directory.GetParent(directoryPath).FullName;

            name = directoryPath.Replace(under, "");
            name = name.Replace("/", "");
            name = name.Replace("\\", "");

        }
        public static void GetDirectoryPathOf(in string directoryPath, out string path)
        {
            path = System.IO.Path.GetDirectoryName(directoryPath);
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

    public interface IMetaPathSet
    {
        void GetPath(out string path);
        void SetPath(string path);
        string GetPath();
    }
    public interface IMetaPathGet
    {
        void GetPath(out string path);
        string GetPath();
    }

    [System.Serializable]
    public class MetaPath : IMetaPathSet, IMetaPathGet
    {
        [SerializeField] string m_path = "";
        public void GetPath(out string path) => path = m_path;
        public void SetPath(string path) => m_path = path;
        public string GetPath()
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

    public interface IMetaFileNameWithoutExtensionGet
    {
        void GetName(out string fileName);
    }
    [System.Serializable]
    public class MetaFileNameWithoutExtension : IMetaFileNameWithoutExtensionGet
    {
        [SerializeField] string m_fileName = "";

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


    public interface IMetaFileNameWithExtensionGet
    {
        void GetExtensionWithoutDot(out string extension);
        void GetExtensionWithDot(out string extension);
        void GetFileNameWithoutExtension(out string fileName);
        void GetFileNameWithExtension(out string fileName);

    }
    [System.Serializable]
    public class MetaFileNameWithExtension : IMetaFileNameWithExtensionGet
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
        public void GetExtensionWithDot(out string extension) => extension = "." + m_extensionNameWithoutDot;
        public void GetFileNameWithoutExtension(out string fileName) { fileName = m_fileName; }
        public void GetFileNameWithExtension(out string fileName) { fileName = m_fileName + "." + m_extensionNameWithoutDot; }
    }

    public interface IMetaAbsolutePathFileGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaAbsolutePathFile : MetaPath, IMetaAbsolutePathFileGet
    {
        public MetaAbsolutePathFile(string path) : base(path)
        {
        }
    }
    public abstract class AbstractMetaRelativePathFileMono : MonoBehaviour, IMetaRelativePathFileGet
    {
        public abstract void GetPath(out string path);
        public abstract string GetPath();
    }
    public abstract class AbstractMetaAbsolutePathFileMono : MonoBehaviour, IMetaAbsolutePathFileGet
    {
        public abstract void GetPath(out string path);
        public abstract string GetPath();
    }
    public abstract class AbstractMetaRelativePathDirectoryMono : MonoBehaviour, IMetaRelativePathDirectoryGet
    {
        public abstract void GetPath(out string path);
        public abstract string GetPath();
    }
    public abstract class AbstractMetaAbsolutePathDirectoryMono : MonoBehaviour, IMetaAbsolutePathDirectoryGet
    {
        public abstract void GetPath(out string path);
        public abstract string GetPath();
    }

    public interface IMetaRelativePathFileGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaRelativePathFile : MetaPath, IMetaRelativePathFileGet
    {
        public MetaRelativePathFile(string path) : base(path)
        {
        }
    }
    public interface IMetaAbsolutePathDirectoryGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaAbsolutePathDirectory : MetaPath, IMetaAbsolutePathDirectoryGet
    {
        public MetaAbsolutePathDirectory(string path) : base(path)
        {
        }


    }
    public interface IMetaRelativePathDirectoryGet : IMetaPathGet
    {
    }
    [System.Serializable]
    public class MetaRelativePathDirectory : MetaPath, IMetaRelativePathDirectoryGet
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
        public static void CreateFolderIfNotThere(in IMetaAbsolutePathFileGet filepath)
        {
            string path = Path.GetDirectoryName(filepath.GetPath());
            if (E_StringUtility.IsFilled(in path) && !Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        public static void CreateFolderIfNotThere(in IMetaAbsolutePathDirectoryGet directoryPath)
        {
            string path = (directoryPath.GetPath());
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
        public static bool Exists(in IMetaAbsolutePathFileGet path)
        {
            return File.Exists(path.GetPath());
        }
        public static bool DontExists(in IMetaAbsolutePathFileGet path)
        {
            return !File.Exists(path.GetPath());
        }
        public static void OverrideFilePNG(in IMetaAbsolutePathFileGet path, in Texture2D texture, out bool succced)
        {
            OverrideFilePNG(path.GetPath(), in texture, out succced);
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
        public static void OverrideFileJPEG(in IMetaAbsolutePathFileGet path, in Texture2D texture, out bool succced)
        {
            OverrideFileJPEG(path.GetPath(), in texture, out succced);
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

        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaRelativePathDirectoryGet subfolders, in IMetaFileNameWithExtensionGet file)
        {
            E_FilePathUnityUtility.MeltPathTogether(out string pathfolder, root.GetPath(), subfolders.GetPath());
            file.GetFileNameWithExtension(out string fileNameWExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new MetaAbsolutePathFile(path);
        }
        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaRelativePathDirectoryGet[] subfolders, in IMetaFileNameWithExtensionGet file)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            E_FilePathUnityUtility.MeltPathTogether(out string pathfolder, root.GetPath(), paths);
            file.GetFileNameWithExtension(out string fileNameWExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, pathfolder, fileNameWExt);
            return new MetaAbsolutePathFile(path);
        }
        public static IMetaAbsolutePathDirectoryGet Combine(in IMetaAbsolutePathDirectoryGet root, params IMetaRelativePathDirectoryGet[] subfolders)
        {
            string[] paths = subfolders.Select(k => k.GetPath()).ToArray();
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPath(), paths);
            return new MetaAbsolutePathDirectory(path);
        }
        public static IMetaAbsolutePathFileGet Combine(in IMetaAbsolutePathDirectoryGet root, in IMetaFileNameWithExtensionGet fileName)
        {
            fileName.GetFileNameWithExtension(out string fileExt);
            E_FilePathUnityUtility.MeltPathTogether(out string path, root.GetPath() , fileExt ) ;
            return new MetaAbsolutePathFile(path);
        }

        public static void MoveOverride(in IMetaAbsolutePathFileGet from, in IMetaAbsolutePathFileGet to, out bool succedTransfert)
        {
            succedTransfert = false;
            string sfrom = from.GetPath(), sto = to.GetPath();

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

        public static void GetFilesPathsIn(out string[] paths, IMetaFileNameWithExtensionGet fileOverwatch, IMetaAbsolutePathDirectoryGet directory, bool lookInChildren=true)
        {
            string dPath = directory.GetPath();
            if (E_StringUtility.IsFilled(in dPath) && Directory.Exists(dPath))
            {
                fileOverwatch.GetExtensionWithDot(out string fileExt);
                paths = Directory.GetFiles(dPath, "*" + fileExt, lookInChildren ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            else {
                paths = new string[0];
            }
        }

        public static void MoveOverride(in IMetaAbsolutePathFileGet filePath, in IMetaAbsolutePathDirectoryGet receivedDirectory, out bool succedToMove)
        {
            ExtractFileWithExtension(filePath, out IMetaFileNameWithExtensionGet fileName);
            IMetaAbsolutePathFileGet destination= Combine( in receivedDirectory, in fileName);
            MoveOverride(filePath, destination, out succedToMove);

        }

        public static void ExtractFileWithExtension(in IMetaAbsolutePathFileGet filePath, out IMetaFileNameWithExtensionGet fileName)
        {
            string path = filePath.GetPath();
            string name=Path.GetFileNameWithoutExtension(path),
                extension = Path.GetExtension(path);
            if (E_StringUtility.IsFilled(extension) && extension[0] == '.')
                extension = extension.Substring(1);
            fileName = new MetaFileNameWithExtension(name, extension);
        }

        public static IMetaAbsolutePathFileGet GetParent(in IMetaAbsolutePathFileGet path)
        {
            string p = System.IO.Directory.GetParent(path.GetPath()).FullName;
            return new MetaAbsolutePathFile(p);
        }
        public static IMetaAbsolutePathDirectoryGet GetParent(in IMetaAbsolutePathDirectoryGet path)
        {
            string p = System.IO.Directory.GetParent(path.GetPath()).FullName;
            return new MetaAbsolutePathDirectory(p);
        }


        public delegate void AccessTextDefaultIfNeeded(out string textToUse);
        public static void ImportOrCreateThenImport(out string imported, in IMetaAbsolutePathFileGet fileTarget, AccessTextDefaultIfNeeded defaultTextToStore)
        {
            string p = fileTarget.GetPath();
            if (File.Exists(p))
            {
                imported = File.ReadAllText(p);
            }
            else
            {
                E_FileAndFolderUtility.CreateFolderIfNotThere(fileTarget);
                defaultTextToStore(out string textToUse);
                imported = textToUse;
                File.WriteAllText(p,textToUse);
            }
        }
        public static void ImportOrCreateThenImportIn<T>(ref T jsonableTarget, in IMetaAbsolutePathFileGet fileTarget)
        {
            string p = fileTarget.GetPath();
            if (File.Exists(p))
            {
                string imported = File.ReadAllText(p);
                jsonableTarget = JsonUtility.FromJson<T>(imported);
            }
            else
            {
                string textToExport = JsonUtility.ToJson(jsonableTarget);
                E_FileAndFolderUtility.CreateFolderIfNotThere(fileTarget);
                File.WriteAllText(p, textToExport);
            }
        }

        public static void GetFileInfoFromPath(in IMetaAbsolutePathFileGet filePath, out IMetaFileNameWithExtensionGet fileInfo)
        {
             ExtractFileWithExtension(in filePath, out fileInfo);
        }

        public static void GetFileInfoFromPath(in IMetaAbsolutePathFileGet filePath, out bool exist, out IMetaFileNameWithExtensionGet fileInfo)
        {
            ExtractFileWithExtension(in filePath, out fileInfo);
            exist= File.Exists(filePath.GetPath());
        }

        public static void GetDirectoryFromPath(in IMetaAbsolutePathFileGet filePath, out IMetaAbsolutePathDirectoryGet directory)
        {
            directory = new MetaAbsolutePathDirectory(Path.GetDirectoryName(filePath.GetPath()));
        }
    }
}