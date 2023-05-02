using Buildings;
using System;
using UnityEngine;

namespace ModuleClass
{
    public abstract class Module : MonoBehaviour
    {
        protected IModuleHub m_moduleParent;

        protected void Awake()
        {
            Debug.Log("sd");
            m_moduleParent = FindParentHub();
        }

        public virtual void RunUpdate() { return; }
        public virtual void RunFixedUpdate() { return; }
        public virtual void RunLateUpdate() { return; }

        public virtual void UpdateData(ScriptableObject data) {return;}


        private void OnConnectedToServer()
        {
                try
                {
                    m_moduleParent = FindParentHub();
                }
                catch (InvalidCastException e)
                {
                    Debug.LogError("Произошла ошибка приведения типов: " + e.Message);
                }
        }
        private IModuleHub FindParentHub() => transform.GetComponentInParent<IModuleHub>();
    }
}

