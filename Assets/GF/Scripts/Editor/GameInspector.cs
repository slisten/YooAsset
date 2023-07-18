using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GF
{
    [CustomEditor(typeof(Game))]
    public class GameInspector: Editor
    {
        private bool m_IsCompiling = false;
        
        private SerializedProperty logger = null;
        private ILogger[] loggerTypeNames = null;
        private List<string> currentLoggerTypeNames = null;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (m_IsCompiling && !EditorApplication.isCompiling)
            {
                m_IsCompiling = false;
                OnCompileComplete();
            }
            else if (!m_IsCompiling && EditorApplication.isCompiling)
            {
                m_IsCompiling = true;
                OnCompileStart();
            }
            
            
        }

        private void OnEnable()
        {
            _loggers = new List<ILogger>();
            logger = serializedObject.FindProperty("Logger");

             RefreshTypeNames();
        }

        private List<ILogger> _loggers;
        private void RefreshTypeNames()
         {
             loggerTypeNames = TypeCus.GetRuntimeTypeIns<ILogger>();
         }

        private void OnCompileStart()
        {
            
        }
        
        private void OnCompileComplete()
        {
            
        }
    }
}