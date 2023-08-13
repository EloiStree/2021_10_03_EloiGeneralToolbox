using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageResetFitInMono : MonoBehaviour
{
    public RectTransform m_targetToReset;


    [ContextMenu("Reset to Fit")]
    public void ResetToFitPosition()
    {
        m_targetToReset.anchorMin = Vector3.zero;
        m_targetToReset.anchorMax = Vector3.one;
        m_targetToReset.offsetMin = Vector3.zero;
        m_targetToReset.offsetMax = Vector3.zero;


    }
    public void GetRectTransformLinked(out RectTransform targetRect)
    {
        targetRect = m_targetToReset;
    }

    void Reset()
    {
        m_targetToReset = this.GetComponent<RectTransform>(); 
        
    }
}
