using UnityEngine;
using TowerStats;


public class CombatTower : Buildings
{
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _combarRadiusCollider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _combarRadiusCollider.isTrigger = true;

        ChangeLevel(Levels.First);

        if (towerStates.Length != 0)
        {
            for (int i = 0; i < towerStates.Length; i++)
                towerStates[i].Init(this);
        }

        ChangeState<TowerChill>();
    }
}
