using UnityEngine;
using TowerStats;


public class CombatTower : Buildings
{
    private void Start()
    {
        if (_enemyDetector)
            _enemyDetector.Init(this);

        Init();

        if (towerStates.Length != 0)
        {
            for (int i = 0; i < towerStates.Length; i++)
                towerStates[i].Init(this);
        }
        
        ChangeState<TowerChill>();
    }

    private void Update()
    {
        currentState.UpdateRun();
    }
}
