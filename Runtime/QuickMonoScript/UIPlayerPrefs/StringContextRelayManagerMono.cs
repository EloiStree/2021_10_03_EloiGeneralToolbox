using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringContextRelayManagerMono : MonoBehaviour
{

    public string m_lastContextReceived;
    public Eloi.PrimitiveUnityEvent_String m_onContextReceived;
    public StringContextListenerRelayMono [] m_listenerInEditor;
    public GameObject[] m_searchInChildrenForListener;

    [ContextMenu("RePush Last received")]
    public void PushContextFromLastReceived() {
        PushContext(m_lastContextReceived);
    }

    public void PushContext(string stringContextId)
    {
        m_onContextReceived.Invoke(stringContextId);
        foreach (var listener in m_listenerInEditor) {

            if (listener != null) { 
                    listener.PushContext(stringContextId);
            }
        }

        foreach (var gameObject in m_searchInChildrenForListener) {

            if (gameObject != null)
            { 
            
            StringContextListenerRelayMono[] listeners = gameObject.GetComponentsInChildren<StringContextListenerRelayMono>();
            foreach (var listener in listeners)
                if (listener != null)
                    listener.PushContext(stringContextId);
            }
        }
    }

}
