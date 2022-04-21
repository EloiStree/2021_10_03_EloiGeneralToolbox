using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2DToRendererMono : MonoBehaviour
{
    public Renderer m_target;
    public string m_textureName = "_Base";

    public Texture2D m_texture;
    public void PushTexture2D(Texture2D texture)
    {
        m_texture = texture;
        m_target.material.SetTexture(m_textureName, m_texture);
    }
    public void Reset()
    {
        m_target = GetComponent<Renderer>();
    }
}
