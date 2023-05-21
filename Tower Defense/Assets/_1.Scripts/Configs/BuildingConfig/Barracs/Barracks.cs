using UnityEngine;

namespace ConfigClasses
{
    namespace ConfigBuildings
    {
        [CreateAssetMenu(fileName = "Barracs", order = 4, menuName = "Gameplay/Towers/New Barracks")]
        public class Barracks : BuildingConfig
        {
            [Header("Характеристики юнитов")]
            [SerializeField] [Tooltip("Количество юнитов одновременно")] private byte _unitCount;
            [SerializeField] [Tooltip("Время на восстановление одного юнита в секундах")] private uint _respawnTime;
        }
    }
}

