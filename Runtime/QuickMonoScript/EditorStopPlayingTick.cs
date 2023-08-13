using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    [ExecuteInEditMode]
    public class EditorStopPlayingTick : MonoBehaviour
    {

        public bool m_isPlaying;
        public UnityEvent m_onEditorPlay;
        public UnityEvent m_onEditorStop;
        public void Update()
        {
            bool isPlaying = Application.isPlaying;
            if (isPlaying != m_isPlaying) {
                m_isPlaying = isPlaying;
                if (isPlaying)
                    m_onEditorPlay.Invoke();
                else m_onEditorStop.Invoke();
            }
        }
    }
}
