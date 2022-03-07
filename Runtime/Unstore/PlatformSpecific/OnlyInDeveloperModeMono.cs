using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace be.eloistree.generaltoolbox
{
    
    public class OnlyInDeveloperModeMono : MonoBehaviour
    {
        public UnityEvent m_inDevMode;
        public UnityEvent m_inClientMode;
        public bool m_useDefaultDeactivate = true;
        public bool m_useDefaultDestroy = false;
        void Awake()
        {
            Refresh();

        }
        void OnEnable()
        {
            Refresh();

        }

        [ContextMenu("Refresh")]
        private void Refresh()
        {
            bool isDevMode = DeveloperMode.IsInDeveloperMode();

            if (isDevMode)
            {
                m_inDevMode.Invoke();
            }
            else
            {

                m_inClientMode.Invoke();
                if (m_useDefaultDeactivate)
                    this.gameObject.SetActive(false);
                if (m_useDefaultDestroy)
                    Destroy(this.gameObject);
            }
        }
    }
}
