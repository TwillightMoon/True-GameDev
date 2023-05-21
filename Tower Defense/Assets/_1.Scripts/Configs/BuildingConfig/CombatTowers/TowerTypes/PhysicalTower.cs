using UnityEngine;
using StatsEnums.DamageTypes;

namespace ConfigClasses
{
    namespace ConfigBuildings
    {
        [CreateAssetMenu(fileName = "PhysicalTower", order = 0, menuName = "Gameplay/Towers/New PhysicalTower")]
        public class PhysicalTower : TowerConfig
        {
            public override DamageType GetDamageType() => DamageType.Physical;
        }
    }
}

