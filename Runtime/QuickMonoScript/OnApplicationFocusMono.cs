using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class OnApplicationFocusMono : MonoBehaviour
    {
        public UnityEvent m_onFocus;
        public UnityEvent m_onUnfocus;
        public UnityEvent m_onPause;
        public UnityEvent m_onUnpause;
        public UnityEvent m_onQuit;

        public void OnApplicationFocus(bool focus)
        {
            if (focus) m_onFocus.Invoke();
            else m_onUnfocus.Invoke();
        }
        private void OnApplicationPause(bool pause)
        {
            if (pause) m_onPause.Invoke();
            else m_onUnpause.Invoke();
        }
        private void OnApplicationQuit()
        {
            m_onQuit.Invoke();
        }
    }

