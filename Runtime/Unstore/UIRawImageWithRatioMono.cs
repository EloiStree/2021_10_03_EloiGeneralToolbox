using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRawImageWithRatioMono : MonoBehaviour
{
    public RawImage m_imageToAffect;
    public AspectRatioFitter m_ratioToAffect;

    public void ApplyTexture(Texture2D texture) {
        m_imageToAffect.texture = texture;
        m_ratioToAffect.aspectRatio = texture.width /(float) texture.height;
    }

    private void Reset()
    {
        m_imageToAffect = GetComponent<RawImage>();
        m_ratioToAffect = GetComponent<AspectRatioFitter>();

    }
}
