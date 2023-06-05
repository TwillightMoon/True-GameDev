
public interface IAttacker
{
    void SetPysicalDamage(IDamageable damageable, float damage);
    void SetEnergyDamage(IDamageable damageable, float damage);
    void SetExplosiveDamage(IDamageable damageable, float damage);
}
