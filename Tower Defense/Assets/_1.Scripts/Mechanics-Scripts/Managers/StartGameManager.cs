using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    /** Менеджер, содержащий и применяющий все настроки к уровню */
    public class StartGameManager : Singleton<StartGameManager>
    {
        public static UnityEvent<int> onHealthChange = new UnityEvent<int>();


        [Header("Свойства уровня")]
        [SerializeField] private int _startBalance; /**< Integer variable. Начальный баланс на уровне */
        [SerializeField] private int gameHealth;

        private void Start()
        {
            Time.timeScale = 1.0F;

            WalletScript.instance.SetCurrentBalace(_startBalance);

            Debug.Log("Test");
            WaveManager.instance.SpawnStart();

            onHealthChange.Invoke(gameHealth);

            GlobalEvents.onEnemyOnBase.AddListener(HealthDecrease);
        }



        private void HealthIncrease(int amount)
        {
            gameHealth += amount;
            onHealthChange.Invoke(gameHealth);
        }
        private void HealthDecrease(int amount) 
        {
            if (gameHealth <= amount) gameHealth = 0;
            else gameHealth -= amount;

            onHealthChange.Invoke(gameHealth);
        }
    }
}

