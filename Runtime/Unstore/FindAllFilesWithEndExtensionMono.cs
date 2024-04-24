using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class FindAllFilesWithEndExtensionMono : MonoBehaviour
    {


        public string m_fileExtension = ".demo.xml";
        public Eloi.AbstractMetaAbsolutePathDirectoryMono m_directoryToSearch;

        public UnityEvent<string[]> m_onSearchRequested;


        [ContextMenu("Search and Push")]
        public void SearchAndPush() {

            string path = m_directoryToSearch.GetPath();
            if (Directory.Exists(path)) {

                string search = m_fileExtension.ToLower();
               string [] files = Directory.GetFiles(path,"*", SearchOption.AllDirectories);
                m_onSearchRequested.Invoke(files.Where(k => k.Length >= search.Length && k.ToLower().EndsWith(search)).ToArray());
            }
            
        }
    }
}
