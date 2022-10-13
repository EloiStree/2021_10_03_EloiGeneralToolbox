using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_MarkDown))]
    public class DeveloperNoteEditor_MarkDown : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_MarkDown myScript = (DeveloperNote_MarkDown)target;
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("View as file"))
            {
                myScript.OpenMarkDownAsMarkdownFile();
            }
            if (GUILayout.Button("View on Browser"))
            {
                myScript.OpenInBrowser();
            }

            GUILayout.EndHorizontal();
            base.DrawDefaultInspector();
        }
       


    }

}
