using UnityEngine;
using DamageTypes;

namespace ConfigClasses
{
    namespace TowerConfig
    {
        [CreateAssetMenu(fileName = "PhysicalTower", order = 0, menuName = "Gameplay/Towers/New PhysicalTower")]
        public class PhysicalTower : TowerConfig
        {
            public override DamageType GetDamageType() => DamageType.Physical;
        }
    }
}

