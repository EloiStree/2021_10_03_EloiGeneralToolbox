using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PagesManagerMono : MonoBehaviour
{
    public List<PageMono> m_pages;
    public UnityEvent m_onPagesReload;
   

    [ContextMenu("ReloadThePagesInChildren")]
    public void ReloadThePagesInChildren() {
        m_pages.Clear();
        m_pages.AddRange( GetComponentsInChildren<PageMono>() );
        m_pages = m_pages.Where(k => k != null).ToList();
        m_onPagesReload.Invoke();
    }
    [ContextMenu("Hide all")]
    public void HideAll() {
        foreach (var item in m_pages)
        {
            item.RequestToHide();
        }
    }

    [ContextMenu("Display All")]
    public void DisplayAll()
    {
        foreach (var item in m_pages)
        {
            item.RequestToDisplay();
        }
    }
    [ContextMenu("Debug Page All")]
    public void DebugModeAll()
    {
        for (int i = 0; i < m_pages.Count; i++)
        {
            PageResetFitInMono fit = m_pages[i].GetComponentInChildren<PageResetFitInMono>();
            if (fit)
            {
                fit.GetRectTransformLinked(out RectTransform targetRect);
                Vector2 minA = targetRect.anchorMin;
                Vector2 maxA = targetRect.anchorMax;
                minA.y = i + 1;
                maxA.y = i + 2;
                targetRect.anchorMin = minA;
                targetRect.anchorMax = maxA;
            }
        }
        foreach (var item in m_pages)
        {
            item.RequestToDisplay();
        }
    }
    [ContextMenu("Re fit all page")]
    public void RefitAllPages()
    {
        for (int i = 0; i < m_pages.Count; i++)
        {
            
            PageResetFitInMono fit = m_pages[i].GetComponentInChildren<PageResetFitInMono>();
            if (fit)
            {
                fit.ResetToFitPosition();
            
            }
        }
      
    }

    public void DisplayOnlyAtIndex(int index)
    {
        int i = 0;
        foreach (var item in m_pages)
        {
            if (i == index)
                item.RequestToDisplay();
            else
                item.RequestToHide();
            i++;
        }
    }
  
}
