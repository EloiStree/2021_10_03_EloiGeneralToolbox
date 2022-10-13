using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_VideoOdyseeWithThumbnail))]
    public class DeveloperNoteEditor_VideoOdyseeWithThumbnail : Editor
    {


        public override void OnInspectorGUI()
        {
            DeveloperNote_VideoOdyseeWithThumbnail myScript = (DeveloperNote_VideoOdyseeWithThumbnail)target;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Open on Odysee"))
            {
                Application.OpenURL(myScript.m_odyseeUrl);
            }
            GUILayout.EndHorizontal();
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            base.DrawDefaultInspector();
        }
    }
}
