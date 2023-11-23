using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Eloi
{
    public class OnMouseClick2DMono : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler,
        IPointerMoveHandler, IPointerExitHandler
    {
        public UnityEvent m_onMouseEnter;
        public UnityEvent m_onMouseDown;
        public UnityEvent m_onMouseUp;
        public UnityEvent m_onMouseExit;
        public UnityEvent m_onMouseMove;

     

        public void OnPointerDown(PointerEventData eventData)
        {
            m_onMouseDown.Invoke();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            m_onMouseUp.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_onMouseEnter.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_onMouseExit.Invoke();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            m_onMouseMove.Invoke();
        }

       

       
    }
}

