using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    [CreateAssetMenu(fileName = "StringIdScriptable", menuName = "Eloi/Toolbox/Scriptable String Id", order = 1)]
    public class StringIdScriptable : ScriptableObject
    {
        public string m_value;

        public string GetValue()
        {
            return m_value;
        }
        public void GetValue(out string value)
        {
            value = m_value;
        }
        public void GetValueAsLower(out string value)
        {
            value = m_value.ToLower();
        }
    }

    [System.Serializable]
    public class UnityStringIdScriptableEvent : UnityEvent<StringIdScriptable>{ 
    
    }
}
