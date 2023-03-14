using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstrectUIPlayerPrefs : MonoBehaviour
    {
        public string m_id;
        public Eloi.PrimitiveUnityEvent_String m_onLoad;
        public StorageType m_storageType = StorageType.PersistentDataPath;
        public enum StorageType { 
            PlayerPrefs, DataPath, PersistentDataPath
        }


        public abstract void GetInfoToStoreAsString(out string infoToStore);
        public abstract void SetWithStoredInfoFromString(string recoveredInfo);
        void Awake()
        {
            ReloadInfoStoredAndPushItBack();
        }

        private void ReloadInfoStoredAndPushItBack()
        {
            if (m_storageType == StorageType.PlayerPrefs) { 
                string t = "";
                if (PlayerPrefs.HasKey(m_id))
                    t = PlayerPrefs.GetString(m_id);
                else GetInfoToStoreAsString(out t);

                SetWithStoredInfoFromString(t);
                m_onLoad.Invoke(t);
            }
            else
            {
                string folderPath = GetFilePathWhereToStore();
                MetaAbsolutePathFile p = new MetaAbsolutePathFile(folderPath);
                Eloi.E_FileAndFolderUtility.ImportFileAsText(p, out string text,"");
                SetWithStoredInfoFromString(text);
                m_onLoad.Invoke(text);
            }
        }

        private void SaveInputField()
        {
            if (m_storageType == StorageType.PlayerPrefs)
            {
                GetInfoToStoreAsString(out string infoToStore);
                PlayerPrefs.SetString(m_id, infoToStore);
            }
            else
            {
                GetInfoToStoreAsString(out string infoToStore);
                string folderPath = GetFilePathWhereToStore();
                MetaAbsolutePathFile p = new MetaAbsolutePathFile(folderPath);
                Eloi.E_FileAndFolderUtility.ExportByOverriding(p, infoToStore);
               //Debug.Log("PS|" + folderPath);
            }

        }

        private string GetFilePathWhereToStore()
        {
            string folderPath = Application.persistentDataPath;
            if (m_storageType == StorageType.PlayerPrefs)
            {
                folderPath = Application.dataPath;
            }
            Eloi.E_StringByte64Utility.Base64EncodeUsingUTF8FileSafe(m_id, out string idB64);
            Eloi.E_FilePathUnityUtility.MeltPathTogether(out folderPath, folderPath, idB64);
            return folderPath;
        }

        private void OnDestroy()
        {
            SaveInputField();
        }
        private void OnApplicationPause(bool pause)
        {
            SaveInputField();

        }
        private void OnApplicationQuit()
        {

            SaveInputField();
        }


        protected virtual void Reset()
        {
            GenerateId();
        }

        [ContextMenu("Generate New ID")]
        private void GenerateId()
        {
            Eloi.E_UnityRandomUtility.GetRandomGUID(out string id);
            m_id = "" + id;
        }
    }
}
