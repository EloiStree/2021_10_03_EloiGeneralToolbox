using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace be.eloistree.generaltoolbox
{
    public class UIInputFieldPlayerPrefs : MonoBehaviour
    {
        public InputField m_inputfield;
        public string m_id;
        public Eloi.PrimitiveUnityEvent_String m_onLoad;
        // Start is called before the first frame update
        void Awake()
        {
            string t = PlayerPrefs.GetString(m_id);
            m_inputfield.text = t;
            m_onLoad.Invoke(t);
        }

        private void OnDestroy()
        {
            SaveInputField();
        }

        private void SaveInputField()
        {
            PlayerPrefs.SetString(m_id, m_inputfield.text);
        }

        private void OnApplicationPause(bool pause)
        {
            SaveInputField();

        }
        private void OnApplicationQuit()
        {

            SaveInputField();
        }


        private void Reset()
        {
            GenerateId();
            m_inputfield = GetComponent<InputField>();
        }

        [ContextMenu("Generate New ID")]
        private void GenerateId()
        {
            m_id = "" + Guid.NewGuid();
        }
    }
}
