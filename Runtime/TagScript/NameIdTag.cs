using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class NameIdTag : MonoBehaviour
    {
        public string m_associatedIdName="";

        public void GetName(out string name) { name = m_associatedIdName; }
        public string GetName() { return  m_associatedIdName; }
        public void SetName(string name) { m_associatedIdName = name; }



        private void Reset()
        {
            m_associatedIdName = gameObject.name;
        }
    }
    
}
