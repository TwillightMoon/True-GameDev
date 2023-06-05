using UnityEngine;

namespace Units
{
    /** Пространство имён, содержащее классы реализации функционала вражеских Юнитов */
    namespace EnemyScrips
    {
        public class Enemy : Unit
        {



            private void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.CompareTag("Base")) 
                {
                    GlobalEvents.SendEnemyOnBase(unitCharacteristics.damageToBase);
                }
            }
        }
    }
}
