using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_Links))]
    public class DeveloperNoteEditor_Links : Editor
    {
        public override void OnInspectorGUI()
        {
            DeveloperNote_Links myScript = (DeveloperNote_Links)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Go to Link(s)"))
            {
                myScript.OpenLinks();
            }
            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
    }
}
