using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISet_TextAppendMaxLine : MonoBehaviour
{
   
        public Text m_affected;
        public int m_maxLine = 10;
        public void AppendStart(string text)
        {

        m_affected.text = text + m_affected.text  ;
    }
        public void AppendEnd(string text)
        {
            m_affected.text = m_affected.text + text;

        }
        public void AppendStartWithLineReturn(string text)
    {
        List<string> lines = m_affected.text.Split('\n').ToList();
        lines.Insert(0, text);
        if (lines.Count > m_maxLine)
            lines.RemoveAt(lines.Count - 1);
        m_affected.text = string.Join("\n", lines);
    }
        public void AppendEndWithLineReturn(string text)
        {
        List<string> lines = m_affected.text.Split('\n').ToList();
        lines.Add( text);
        if (lines.Count > m_maxLine)
            lines.RemoveAt(0);
        m_affected.text = string.Join("\n", lines);

    }

        private void Reset()
        {
            m_affected = GetComponent<Text>();
        }
    
}
