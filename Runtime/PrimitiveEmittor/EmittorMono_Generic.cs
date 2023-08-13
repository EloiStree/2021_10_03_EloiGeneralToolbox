using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class EmittorMono_Generic<T> : MonoBehaviour
    {
        public T m_valueToPush;
        public GenericEvent m_onPush;

        [System.Serializable]
        public class GenericEvent : UnityEvent<T> { }

        protected void PushValue() {
            m_onPush.Invoke(m_valueToPush);
        }

        public void SetValue(T value) {
            m_valueToPush = value;
        }
    }
}
