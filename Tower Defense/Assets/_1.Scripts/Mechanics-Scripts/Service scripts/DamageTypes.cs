using UnityEngine;

namespace DamageTypes
{
    public enum DamageType : byte
    {
        Physical,
        Energy,
        Area,
        AMY
    }

    public class DamageTypes
    {
        public static void GetAttackType(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    return;
                case DamageType.Energy:
                    return;
                case DamageType.Area:
                    return;
                case DamageType.AMY:
                    return;
                default:
                    return;
            }
        }
    }
}


