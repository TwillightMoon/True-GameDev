using UnityEngine;
using TowerStats;

[CreateAssetMenu(fileName = "PhysicalTower", order = 0, menuName = "Gameplay/Towers/New PhysicalTower")]
public class PhysicalTower : TowerStatsInfo
{
    public override DamageType GetDamageType() => DamageType.Physical;
}
