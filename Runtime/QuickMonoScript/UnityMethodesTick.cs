using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi {
    public class UnityMethodesTick : MonoBehaviour
    {
        public UnityEvent m_onAwake;
        public UnityEvent m_onStart;
        public UnityEvent m_onEnable;
        public UnityEvent m_onDisable;
        public UnityEvent m_onDestroy;
        public UnityEvent m_onApplicationQuit;


        public void Awake() {
            if(gameObject.activeInHierarchy) m_onAwake.Invoke();
        } 
        public void Start()
        {
            if (gameObject.activeInHierarchy) m_onStart.Invoke();
        }
        public void OnEnable(){
                if (gameObject.activeInHierarchy) m_onEnable.Invoke();
        }
        public void OnDisable()
                {
                    if (gameObject.activeInHierarchy) m_onDisable.Invoke();
        }
        public void OnDestroy()
                    {
                        if (gameObject.activeInHierarchy) m_onDestroy.Invoke();
        }
        public void OnApplicationQuit()
                        {
                            if (gameObject.activeInHierarchy) m_onApplicationQuit.Invoke();
        }

    }
}
