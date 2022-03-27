using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public class FilesSizeRangeSearchMono : MonoBehaviour
    {
        public AbstractMetaAbsolutePathDirectoryMono m_targetDirectory;

        public long m_minimumFileSize= 20000000;
        public long m_maxFileSize = 20000000000;
        public string[] m_filesInDirectory;
        public List<MetaAbsolutePathFile> m_filesFound;
        public string m_debug;
        [ContextMenu("Search For Files")]
        public void SearchForFiles() {
            string[] files = new string[0];
            E_FileAndFolderUtility.GetAllfilesInAndInChildren(m_targetDirectory, out files);
           // E_FileAndFolderUtility.GetAllfilesInAndOnlyInFolder(m_targetDirectory, out files);
            E_FileAndFolderUtility.FilterWithSize(in files, out m_filesFound, in m_minimumFileSize, in m_maxFileSize);
            m_filesInDirectory = files;
        }

        public void OnValidate()
        {

            m_debug = "Min:" + (m_minimumFileSize / 1000000f) + " Mo    Max:" + (m_maxFileSize / 1000000f)+" Mo";
        }
    }
}
