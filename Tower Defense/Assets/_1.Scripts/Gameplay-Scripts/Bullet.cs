using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private IAttacker attacker;
    private float damage;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetAttaker(IAttacker attacker, float damage)
    {
        this.attacker = attacker;
        this.damage = damage;
    }

    public Rigidbody2D rigbody => _rigidbody2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            attacker.SetPysicalDamage(damageable, damage);
            attacker.SetEnergyDamage(damageable, damage);
            attacker.SetExplosiveDamage(damageable, damage);

            Destroy(this.gameObject);
        }
    }
}
