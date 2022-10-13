using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperNote_Links : DeveloperNoteMono
{
    public string[] m_Urls;

    [ContextMenu("Open Links")]
    public void OpenLinks()
    {
        for (int i = 0; i < m_Urls.Length; i++)
        {
            if (!string.IsNullOrEmpty(m_Urls[i]))
                Application.OpenURL(m_Urls[i]);
        }
    }
}
