using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_OnPanelPressReleaseMono : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent m_onPressed;
    public UnityEvent m_onRelease;
    public UnityEvent<bool> m_onPressedAsBool;
    public bool m_isPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        m_isPressed = true;
        m_onPressed.Invoke();
        m_onPressedAsBool.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_isPressed = false;
        m_onRelease.Invoke();
        m_onPressedAsBool.Invoke(false);
    }
}