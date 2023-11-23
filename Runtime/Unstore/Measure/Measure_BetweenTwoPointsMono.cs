using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Eloi
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class Measure_BetweenTwoPointsMono : MonoBehaviour
    {
        public Transform m_startPoint;
        public Transform m_endPoint;

        public float m_distanceBetween;
        void Update()
        {
            RefreshInfo();
        }

        [ContextMenu("Refresh")]
        private void RefreshInfo()
        {
            m_distanceBetween = Vector3.Distance(m_startPoint.position, m_endPoint.position);
        }
    }
}
