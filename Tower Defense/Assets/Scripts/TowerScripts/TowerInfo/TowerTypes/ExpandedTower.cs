using UnityEngine;

[CreateAssetMenu(fileName = "ExpandedTower", order = 3, menuName = "Gameplay/Towers/New ExpandedTower")]
public class ExpandedTower : TowerStatsInfo
{
    [Header("Тип башни")]
    [SerializeField] private DamageType _thisTowerDamageType;

    private void OnValidate() => m_damageType = _thisTowerDamageType;
}
