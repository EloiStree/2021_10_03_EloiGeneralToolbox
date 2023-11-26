using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class MoveObjectAtPositionDoubleAnchorMono : MonoBehaviour
    {

        public Transform m_whatToMove;
        public Transform m_defaultAnchorToUse;


        public void MoveAtWorldPosition(Vector3 positionWorld, Quaternion rotationWorld)
        {
            if (m_defaultAnchorToUse == null)
                MoveAtWorldPositionFromAnchorFocus(positionWorld, rotationWorld, m_whatToMove);
            else
                MoveAtWorldPositionFromAnchorFocus(positionWorld, rotationWorld, m_defaultAnchorToUse);
        }
        public void MoveAtWorldPositionFromAnchorFocus(Vector3 positionWorld, Quaternion rotationWorld, Transform anchorFocus)
        {
            m_whatToMove.position = positionWorld;
            m_whatToMove.rotation = rotationWorld;
            m_whatToMove.position += m_whatToMove.position- anchorFocus.position ;

            Quaternion rotationBetweenAnchors = Quaternion.FromToRotation( anchorFocus.rotation*Vector3.forward , rotationWorld * Vector3.forward);
            m_whatToMove.rotation = rotationBetweenAnchors *m_whatToMove.rotation  ;

            m_whatToMove.position += positionWorld - anchorFocus.position;


        }
    }
}
