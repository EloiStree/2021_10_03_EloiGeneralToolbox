using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Eloi
{
    public class GitIgnoreSwitchMono : MonoBehaviour
    {
        public string m_targetFolder;

        public string[] m_folderGitIgnore;
        public string[] m_folderGit;



              [ContextMenu("Refresh Path")]
        public void RefreshPath()
        {
            m_targetFolder = Application.dataPath;
        }

    
        private void RefreshtDirectoryList()
        {
            m_folderGit = Directory.GetDirectories(m_targetFolder, "*", SearchOption.AllDirectories).Where(k=>EndWith(k, ".git")).ToArray();
            m_folderGitIgnore = Directory.GetDirectories(m_targetFolder, "*", SearchOption.AllDirectories).Where(k => EndWith(k, ".giti")).ToArray();
        }

        private bool EndWith(string path, string endtext)
        {
            return path.EndsWith(endtext);
        }

        [ContextMenu("Turn Git Ignore to Git")]
        public void TurnGitIgnoreToGit()
        {
            RefreshtDirectoryList();
            foreach (var path in m_folderGitIgnore)
            {
                try
                {
                    Directory.Move(path, path.Replace(".giti", ".git"));
                }
                catch ( Exception e){
                    Debug.Log("Did not rename Git Ignore:" + e.StackTrace);
                }
            }
            RefreshtDirectoryList();

        }
        [ContextMenu("Turn Git to Git Ignore")]
        public void TurnGitToGitIgnore()
        {
            RefreshtDirectoryList(); 
            foreach (var path in m_folderGit)
            {
                try
                {
                    Directory.Move(path, path.Replace(".git", ".giti"));
                }
                catch (Exception e)
                {
                    Debug.Log("Did not rename Git:" + e.StackTrace);
                }
            }
            RefreshtDirectoryList();
        }

    }
}
