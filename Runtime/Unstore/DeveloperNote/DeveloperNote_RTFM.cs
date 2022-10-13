using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_RTFM : DeveloperNoteMono
    {
        public string[] m_RTFMsUrl;

        [ContextMenu("Open RTFM")]
        public void OpenRTFM() {
            for (int i = 0; i < m_RTFMsUrl.Length; i++)
            {
                if(!string.IsNullOrEmpty(m_RTFMsUrl[i]))
                    Application.OpenURL(m_RTFMsUrl[i]);
            }
        }
        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}
