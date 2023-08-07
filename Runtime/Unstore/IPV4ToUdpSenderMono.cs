using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class IPV4ToUdpSenderMono : MonoBehaviour
{
    public IPV4AsStringTextInSceneMono m_target;
    public SendType m_typePerDefaut = SendType.UTF8;
    public enum SendType {  UTF8, Unicode}

    public void SendMessageToTargets(string message) {
        SendMessageToTargets(message, m_typePerDefaut);
    }
    public void SendMessageToTargets(string message, SendType sendType) {

        foreach (var item in m_target.m_ipv4)
        {
            UdpClient udpClient = new UdpClient(item.GetIpString(), item.GetPort()) ;
            try
            {
                byte[] data = sendType == SendType.UTF8? Encoding.UTF8.GetBytes(message): Encoding.Unicode.GetBytes(message);
                udpClient.Send(data, data.Length);
            }
            catch (Exception )
            {          }
            finally
            {
                udpClient.Close();
            }

        }
    }
}
