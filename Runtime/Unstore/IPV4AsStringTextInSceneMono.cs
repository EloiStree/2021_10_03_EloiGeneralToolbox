using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IPV4AsStringTextInSceneMono : MonoBehaviour


{

    public Eloi.IPv4AsStringTextMono[] m_ipv4InScene;

    public List<Eloi.IPV4AsUShort> m_ipv4 = new List<Eloi.IPV4AsUShort>();


    void Awake()
    {
       // FetchAllInScene();    
    }


    [ContextMenu("FetchAllInScene")]
    public void FetchAllInScene() {

        Eloi.E_SearchInSceneUtility.TryToFetchWithInScene(ref m_ipv4InScene);
    }

    [ContextMenu("Fetch List")]
    public void RefreshList() {
        m_ipv4.Clear();
        foreach (var item in m_ipv4InScene)
        {
            m_ipv4.AddRange(item.m_ipfound);
        }
        m_ipv4 = m_ipv4.Distinct().ToList();
    }

}
