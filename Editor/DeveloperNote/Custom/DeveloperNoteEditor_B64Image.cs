using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Eloi
{
    [CustomEditor(typeof(DeveloperNote_B64Image))]
    public class DeveloperNoteEditor_B64Image : Editor
    {

        
        public override void OnInspectorGUI()
        {
            DeveloperNote_B64Image myScript = (DeveloperNote_B64Image)target;
            DeveloperNoteEditor_B64Image.DrawImage(myScript.m_image, Open);
            DeveloperNoteEditor_B64Image.WarningAboutSizeB64();
            base.DrawDefaultInspector();
            if ((DateTime.Now - m_lastSizeUpdate).Milliseconds > 400)
            {
                GetViewWidth();
                m_lastSizeUpdate = DateTime.Now;
            }
        }

        private void Open()
        {
            DeveloperNote_B64Image myScript = (DeveloperNote_B64Image)target;
            E_Base64ToImage.OpenB64InBrowser(myScript.m_b64Text.m_b64Text);
        }

        public static void DrawImage(Texture2D texture, in Action toDoOnClick) {

            if ((DateTime.Now - m_lastSizeUpdate).Milliseconds > 400) { 
                GetViewWidth();
                m_lastSizeUpdate = DateTime.Now;
            }
            if (texture == null)
                return;
            GUILayout.BeginHorizontal(); 
            GUIStyle style = new GUIStyle();
            style.normal.background = texture;
            style.margin = new RectOffset(0, 0, 0, 0);
            style.alignment = TextAnchor.MiddleCenter;
            float ratio = texture.height / (float)texture.width;
            if (GUILayout.Button("", style, GUILayout.Width(m_width), GUILayout.Height(m_width * ratio)))
            {
                toDoOnClick.Invoke();
            }
            GUILayout.EndHorizontal();

        }


        static float m_width;
        static private Rect _rect;
        static DateTime m_lastSizeUpdate;
        private static float GetViewWidth()
        {
            m_width = EditorGUIUtility.currentViewWidth;
            return m_width;
        }

        public static void WarningAboutSizeB64()
        {

            GUILayout.Label("Git: Note that image take place in scene size if not in a prefab.");
        }
    }
   
}
