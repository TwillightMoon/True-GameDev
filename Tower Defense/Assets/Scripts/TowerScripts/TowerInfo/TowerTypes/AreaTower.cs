using UnityEngine;
using TowerStats;

[CreateAssetMenu(fileName = "AreaTower", order = 2, menuName = "Gameplay/Towers/New AreaTower")]
public class AreaTower : BuildingsConfig
{
    public override DamageType GetDamageType() => DamageType.Area;
}
