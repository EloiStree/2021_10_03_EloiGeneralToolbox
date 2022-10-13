using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_B64ImageFromURL))]
    public class DeveloperNoteEditor_B64ImageFromURL : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_B64ImageFromURL myScript = (DeveloperNote_B64ImageFromURL)target;
            GUILayout.BeginHorizontal();
            GUILayout.Label("Open:");
            if (GUILayout.Button("From Url"))
            {
                Application.OpenURL(myScript.m_imageUrl);
            }
            if (GUILayout.Button("Local"))
            {
                Application.OpenURL(myScript.m_b64Text.m_b64Text);
            }
            GUILayout.EndHorizontal();
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            base.DrawDefaultInspector();
        }
    }
}
