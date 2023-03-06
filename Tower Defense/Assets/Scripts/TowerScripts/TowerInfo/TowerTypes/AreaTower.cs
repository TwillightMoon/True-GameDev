using UnityEngine;

[CreateAssetMenu(fileName = "AreaTower", order = 2, menuName = "Gameplay/Towers/New AreaTower")]
public class AreaTower : TowerStatsInfo
{
    public override DamageType GetDamageType() => DamageType.Area;
}
