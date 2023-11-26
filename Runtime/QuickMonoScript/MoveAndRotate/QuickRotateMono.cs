using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace be.eloistree.generaltoolbox
{
    public class QuickRotateMono : MonoBehaviour
    {
        public Transform m_toAffect;
        public Vector3 m_rotation;
        public Space m_rotationType;
        public float m_multiplicator=1;
       
        void Update()
        {
            m_toAffect.Rotate(m_rotation * m_multiplicator * Time.deltaTime , m_rotationType) ;

        }

        [ContextMenu("FetchCurrentTransform")]
        void FetchCurrentTransform() { m_toAffect = this.transform; }
    }
}
