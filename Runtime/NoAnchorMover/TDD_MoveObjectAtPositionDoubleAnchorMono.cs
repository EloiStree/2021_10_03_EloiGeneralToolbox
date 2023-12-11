using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class TDD_MoveObjectAtPositionDoubleAnchorMono : MonoBehaviour
    {
        public MoveObjectAtPositionDoubleAnchorMono m_toAffect;
        public Transform m_whereToMove;
    
        void Update()
        {
            m_toAffect.MoveAtWorldPosition(m_whereToMove.position, m_whereToMove.rotation);
        }
        private void Reset()
        {
            m_whereToMove = transform;
            m_toAffect = GetComponent<MoveObjectAtPositionDoubleAnchorMono>();
        }
    }
}
