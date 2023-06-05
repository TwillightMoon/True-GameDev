using UnityEngine;
using StatsEnums.DamageTypes;

namespace ConfigClasses
{
    namespace ConfigBuildings
    {
        [CreateAssetMenu(fileName = "AreaTower", order = 2, menuName = "Gameplay/Towers/New AreaTower")]
        public class AreaTower : TowerConfig
        {
            [SerializeField] private float _splashRadius;

            public float splashRadius => _splashRadius;
            public override DamageType GetDamageType() => DamageType.Explosive;
        }
    }
}

