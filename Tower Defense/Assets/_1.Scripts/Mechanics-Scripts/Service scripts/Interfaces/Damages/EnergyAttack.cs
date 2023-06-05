public class EnergyAttack : IAttacker
{
    public void SetEnergyDamage(IDamageable damageable, float damage)
    {
        damageable.GetEnergyDamage(damage);
    }

    public void SetExplosiveDamage(IDamageable damageable, float damage)
    {
    }

    public void SetPysicalDamage(IDamageable damageable, float damage)
    {
    }
}
