using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class OnMouseClick3DMono : MonoBehaviour
    {

        public UnityEvent m_onMouseEnter;
        public UnityEvent m_onMouseDown;
        public UnityEvent m_onMouseUp;
        public UnityEvent m_onMouseExit;
        public UnityEvent m_onMouseOver;
        public UnityEvent m_onMouseDrag;


        void OnMouseEnter()
        {
            m_onMouseEnter.Invoke();
           
        }

        void OnMouseDown()
        {
            m_onMouseDown.Invoke();
          
        }



        void OnMouseUp()
        {
            m_onMouseUp.Invoke();
          
        }
     
        void OnMouseExit()
        {
            m_onMouseExit.Invoke();

        }
        void OnMouseOver()
        {
            m_onMouseOver.Invoke();

        }
        void OnMouseDrag()
        {
            m_onMouseDrag.Invoke();

        }



    }
}
