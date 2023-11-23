using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToMaterialMono : MonoBehaviour
{
    public Material m_target;
    public Color m_colorReceived = Color.white;
    public void PushColor(Color color)
    {
        m_colorReceived = color;
        if (m_target != null)
            m_target.color = m_colorReceived;
    }

}
