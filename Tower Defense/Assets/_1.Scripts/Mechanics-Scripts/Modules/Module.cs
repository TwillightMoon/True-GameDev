using ConfigClasses;
using System;
using UnityEngine;

namespace ModuleClass
{
    public abstract class Module : MonoBehaviour
    {
        protected IModuleHub m_moduleParent;

        protected void Init()
        {
            m_moduleParent = FindParentHub();
        }

        public virtual void RunUpdate() { return; }
        public virtual void RunFixedUpdate() { return; }
        public virtual void RunLateUpdate() { return; }

        public virtual void UpdateData(EntityConfig data) {return;}

        private IModuleHub FindParentHub() => transform.GetComponentInParent<IModuleHub>();
    }
}

