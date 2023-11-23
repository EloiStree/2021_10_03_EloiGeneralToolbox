using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class Convert_PrimitiveToString : MonoBehaviour
    {

        public Eloi.PrimitiveUnityEvent_String m_relay;

        public void Convert(float value)
        {
            m_relay.Invoke(value.ToString());
        }
        public void Convert(int value)
        {
            m_relay.Invoke(value.ToString());
        }
        public void ConvertBoolAs01(bool value)
        {
            m_relay.Invoke(value?"1":"0");
        }
        public void ConvertBoolAsFalseTrue(bool value)
        {
            m_relay.Invoke(value.ToString());
        }
    }
}
