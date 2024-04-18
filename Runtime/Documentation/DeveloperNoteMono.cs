using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperNoteMono : MonoBehaviour
{
    [Tooltip("Just a note of the developer")]
    [TextArea(4,10)]
    public string m_note;
    [Tooltip("Who wrote the developer note")]
    public string m_author;
    protected virtual void OnValidate()
    {
#if UNITY_EDITOR
        UnityEditor.EditorPrefs.SetString("CurrentDev", m_author);
#endif
    }

    private void Reset()
    {
#if UNITY_EDITOR
        m_author= UnityEditor.EditorPrefs.GetString("CurrentDev","");
#endif
    }
}
