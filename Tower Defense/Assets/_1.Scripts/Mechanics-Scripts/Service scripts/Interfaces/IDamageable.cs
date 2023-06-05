using UnityEngine;

public interface IDamageable
{
    void GetPhysicalDamage(float damage);
    void GetExplosiveDamage(float damage);
    void GetEnergyDamage(float damage);
}
