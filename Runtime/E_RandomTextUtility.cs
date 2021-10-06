using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi {
public class E_RandomTextUtility : MonoBehaviour
{
    public string[] m_names = new string[] { "Eloi" , "Mathieu", "Quentin"};

    public static void GetRandomName_DisnayCharacter(int count, out string[] names)
    {
        throw new System.NotImplementedException();
    }
    public static void GetRandomName_DisnayCharacter(out string name)
    {
            E_UnityRandomUtility.GetRandomOf(out name, E_InCodeNameCollection.m_disneyCharacter);
           
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
}
}
    }
