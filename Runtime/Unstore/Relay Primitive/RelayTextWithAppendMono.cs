using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class RelayTextWithAppendMono : MonoBehaviour
    {
        public string m_appendStart;
        public string m_appendEnd;
        public Eloi.PrimitiveUnityEvent_String m_onTextPush;
        public void PushText(string text) {

            m_onTextPush.Invoke(string.Join("", m_appendStart, text, m_appendEnd));
        }
 
    }
}
