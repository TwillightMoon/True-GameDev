using UnityEngine;
using DamageTypes;

namespace ConfigClasses
{
    namespace BuildingConfig
    {
        [CreateAssetMenu(fileName = "PhysicalTower", order = 0, menuName = "Gameplay/Towers/New PhysicalTower")]
        public class PhysicalTower : BuildingsConfig
        {
            public override DamageType GetDamageType() => DamageType.Physical;
        }
    }
}

