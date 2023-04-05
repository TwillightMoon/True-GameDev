using UnityEngine;
using TowerStats;

[CreateAssetMenu(fileName = "EnergyTower", order = 1, menuName = "Gameplay/Towers/New EnergyTower")]
public class EnergyTower : BuildingsConfig
{
    public override DamageType GetDamageType() => DamageType.Energy;
}
