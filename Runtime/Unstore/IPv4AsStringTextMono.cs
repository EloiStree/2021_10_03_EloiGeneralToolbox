using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class IPv4AsStringTextMono : MonoBehaviour
    {

        [TextArea(0,10)]
        public string m_textAsIP;

        public string [] m_lines;
        public List<IPV4AsUShort> m_ipfound = new List<IPV4AsUShort>();
        //public StringEvent m_onTextChanged;
        //[System.Serializable]
        //public class StringEvent : UnityEvent<string> { }

        public void SetText(string text) {
            m_textAsIP = text;
            Refresh();
        }

        [ContextMenu("Refresh")]
        private void Refresh()
        {
            m_lines = m_textAsIP.Split("\n");
            m_ipfound.Clear();
            foreach (var item in m_lines)
            {

                string[] leftAndRight = item.Split(':');
                if (leftAndRight.Length == 2) {
                    string[] leftToken = leftAndRight[0].Split('.');
                    if (leftToken.Length == 4) { 
                        if(ushort.TryParse(leftToken[0], out ushort ipv4_0) &&
                            ushort.TryParse(leftToken[1], out ushort ipv4_1) &&
                            ushort.TryParse(leftToken[2], out ushort ipv4_2) &&
                            ushort.TryParse(leftToken[3], out ushort ipv4_3) &&
                            uint.TryParse(leftAndRight[1], out uint port))
                            m_ipfound.Add(new IPV4AsUShort(ipv4_0, ipv4_1, ipv4_2, ipv4_3, port) );

                    }

                }
            }
        }
    }
    [System.Serializable]
    public class IPV4AsUShort : IEqualityComparer<IPV4AsUShort>
    
    {
        public ushort m_ip0;
        public ushort m_ip1;
        public ushort m_ip2;
        public ushort m_ip3;
        public uint m_port;

        public IPV4AsUShort(ushort ip0, ushort ip1, ushort ip2, ushort ip3, uint port)
        {
            m_ip0 = ip0;
            m_ip1 = ip1;
            m_ip2 = ip2;
            m_ip3 = ip3;
            m_port = port;
        }


        public override bool Equals(object obj)
        {
            if (! (obj is IPV4AsUShort)) return false;
            IPV4AsUShort o = (IPV4AsUShort)obj;
            return  
                   m_ip0 ==  o.m_ip0 &&
                   m_ip1 ==  o.m_ip1 &&
                   m_ip2 ==  o.m_ip2 &&
                   m_ip3 ==  o.m_ip3 &&
                   m_port == o.m_port;
        }

        public bool Equals(IPV4AsUShort x, IPV4AsUShort y)
        {
            return
                  x.m_ip0 ==  y.m_ip0 &&
                  x.m_ip1 ==  y.m_ip1 &&
                  x.m_ip2 ==  y.m_ip2 &&
                  x.m_ip3 ==  y.m_ip3 &&
                  x.m_port == y.m_port;
        }

        public int GetHashCode(IPV4AsUShort obj)
        {
            return HashCode.Combine(obj.m_ip0, obj.m_ip1, obj.m_ip2, obj.m_ip3, obj.m_port);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(m_ip0, m_ip1, m_ip2, m_ip3, m_port);
        }

        public string GetIpString()
        {
            return string.Join(".", m_ip0, m_ip1, m_ip2, m_ip3);
        }

        public int GetPort()
        {
            return (int) m_port;
        }
    }
}
