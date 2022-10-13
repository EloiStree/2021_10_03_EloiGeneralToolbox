using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_ImageInProject))]
    public class DeveloperNoteEditor_ImageInProject : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_ImageInProject myScript = (DeveloperNote_ImageInProject)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open / Watch"))
            {
                Application.OpenURL(AssetDatabase.GetAssetPath(myScript.m_image));
            }
            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
    }
}
