using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PageMono : MonoBehaviour
{
    public string m_callId;
    public string m_displayInButton;
    public string m_displayInScroll;
    public string m_displayInTitle;

    public UnityEvent m_onDisplayRequest;
    public UnityEvent m_onHideRequest;


    [ContextMenu("Display")]
    public void RequestToDisplay() {
        m_onDisplayRequest.Invoke();
    }

    [ContextMenu("Hide")]
    public void RequestToHide()    {
        m_onHideRequest.Invoke();
    }

}
