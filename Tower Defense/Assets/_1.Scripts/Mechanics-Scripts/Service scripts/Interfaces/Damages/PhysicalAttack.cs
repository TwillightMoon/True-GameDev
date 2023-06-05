public class PhysicalAttack : IAttacker
{
    public void SetEnergyDamage(IDamageable damageable, float damage)
    {
    }

    public void SetExplosiveDamage(IDamageable damageable, float damage)
    {
    }

    public void SetPysicalDamage(IDamageable damageable, float damage)
    {
        damageable.GetPhysicalDamage(damage);
    }
}
