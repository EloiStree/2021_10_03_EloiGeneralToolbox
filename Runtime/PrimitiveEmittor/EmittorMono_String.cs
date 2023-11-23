using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class EmittorMono_String : EmittorMono_Generic<string>
    {
        [ContextMenu("Push ")]
        public void Push()
        {
            m_onPush.Invoke(m_valueToPush);
        }
    }
}
