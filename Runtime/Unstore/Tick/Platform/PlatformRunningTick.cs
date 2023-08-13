using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class PlatformRunningTick : MonoBehaviour
    {

        public RuntimePlatform m_targetPlatform;
        public UnityEvent m_onTargetPlatform;
        void Awake()
        {
            if(Application.platform == m_targetPlatform)
            {
                m_onTargetPlatform.Invoke();
            }
            Destroy(this);
        }
    }
}
