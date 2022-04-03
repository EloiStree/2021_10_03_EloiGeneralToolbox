using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringRelayMono : MonoBehaviour
{
    public bool dontPushEmpty=true;
    public Eloi.PrimitiveUnityEvent_String m_textToRelay;
    public void PushInTextToRelay(string text) {
        if (dontPushEmpty && Eloi.E_StringUtility.IsNullOrEmpty(in text))
            return;
            
        m_textToRelay.Invoke(text);
    }
}
