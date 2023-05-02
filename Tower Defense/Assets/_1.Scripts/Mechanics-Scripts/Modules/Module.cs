using UnityEngine;

namespace Module
{
    public abstract class Module : MonoBehaviour
    {
        protected IModuleHub moduleParent;

        virtual public void RunUpdate() {return;}
        virtual public void RunFixedUpdate() {return;}
        virtual public void RunLateUpdate() {return;}

        abstract public void UpdateData(ScriptableObject data);
    }
}

