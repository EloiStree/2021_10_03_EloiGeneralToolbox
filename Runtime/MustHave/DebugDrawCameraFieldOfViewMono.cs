using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugDrawCameraFieldOfViewMono : MonoBehaviour
{


    public Camera m_target;
    public Color m_lineColor = Color.green;

    private void Update()
    {
        if (m_target != null)
        {
            DrawLine(new Vector2(0, 0));
            DrawLine(new Vector2(0, 1));
            DrawLine(new Vector2(1, 0));
            DrawLine(new Vector2(1, 1));
        }
    }

    private void DrawLine(Vector2 pt)
    {
        Vector3 start = m_target.ViewportToWorldPoint(new Vector3(pt.x, pt.y, m_target.nearClipPlane));
        Vector3 end = m_target.ViewportToWorldPoint(new Vector3(pt.x, pt.y, m_target.farClipPlane));
        Debug.DrawLine(start, end, m_lineColor, Time.deltaTime);
    }
}
