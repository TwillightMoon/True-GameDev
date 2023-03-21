using UnityEngine;

[CreateAssetMenu(fileName = "AreaTower", order = 4, menuName = "Gameplay/Towers/New Barracks")]
public class Barracks : BuildingsConfig
{
    [Header("Характеристики юнитов")]
    [SerializeField][Tooltip("Количество юнитов одновременно")] private byte _unitCount;
    [SerializeField][Tooltip("Время на восстановление одного юнита в секундах")] private uint _respawnTime;

}
