using UnityEngine;
using DamageTypes;

namespace ConfigClasses
{
    namespace BuildingConfig
    {
        [CreateAssetMenu(fileName = "EnergyTower", order = 1, menuName = "Gameplay/Towers/New EnergyTower")]
        public class EnergyTower : BuildingsConfig
        {
            public override DamageType GetDamageType() => DamageType.Energy;
        }
    }
}

