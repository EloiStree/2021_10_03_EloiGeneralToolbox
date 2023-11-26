using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ColorToRendererMono : MonoBehaviour
{
    public Renderer[] m_targets;
    public Color m_colorReceived;

    public void PushColor(Color color)
    {
        m_colorReceived = color;
        for (int i = 0; i < m_targets.Length; i++)
        {
            if (m_targets[i] != null)
                m_targets[i].material.color = m_colorReceived;
        }
    }

    [ContextMenu("SetWithChildrenRenderer")]
    public void SetWithChildrenRenderer()
    {
        m_targets = GetComponentsInChildren<Renderer>();
    }
    [ContextMenu("SetWithOnlyParentRenderer")]
    public void SetWithOnlyParentRenderer()
    {
        m_targets = GetComponents<Renderer>();
    }

    public void Reset()
    {
        SetWithChildrenRenderer();
    }
}
