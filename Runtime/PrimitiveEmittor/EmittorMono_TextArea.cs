using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class EmittorMono_TextArea : MonoBehaviour
    {
        [TextArea(0,10)]
        public string m_valueToPush;
        public GenericEvent m_onPush;

        [System.Serializable]
        public class GenericEvent : UnityEvent<string> { }

        [ContextMenu("Push")]
        public void Push() {
            m_onPush.Invoke(m_valueToPush);
        }
    }
}
