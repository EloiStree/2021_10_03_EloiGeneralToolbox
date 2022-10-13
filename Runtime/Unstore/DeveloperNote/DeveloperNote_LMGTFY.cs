using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class DeveloperNote_LMGTFY : DeveloperNoteMono
    {
        public string[] m_LMGTFYsUrl;

        [ContextMenu("Let's me google that for you")]
        public void OpenLMGTFY()
        {
            for (int i = 0; i < m_LMGTFYsUrl.Length; i++)
            {
                if (!string.IsNullOrEmpty(m_LMGTFYsUrl[i]))
                    Application.OpenURL(m_LMGTFYsUrl[i]);
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();
        }
    }
}
