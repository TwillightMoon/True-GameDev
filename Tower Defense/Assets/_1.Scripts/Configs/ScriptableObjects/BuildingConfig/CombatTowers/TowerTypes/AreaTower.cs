using UnityEngine;
using DamageTypes;

namespace ConfigClasses
{
    namespace TowerConfig
    {
        [CreateAssetMenu(fileName = "AreaTower", order = 2, menuName = "Gameplay/Towers/New AreaTower")]
        public class AreaTower : TowerConfig
        {
            [SerializeField] private float _splashRadius;

            public float splashRadius => _splashRadius;
            public override DamageType GetDamageType() => DamageType.Area;
        }
    }
}

