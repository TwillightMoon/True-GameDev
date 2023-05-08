using UnityEngine;
using DamageTypes;

namespace ConfigClasses
{
    namespace TowerConfig
    {
        [CreateAssetMenu(fileName = "EnergyTower", order = 1, menuName = "Gameplay/Towers/New EnergyTower")]
        public class EnergyTower : TowerConfig
        {
            public override DamageType GetDamageType() => DamageType.Energy;
        }
    }
}

