using UnityEngine;

namespace Buildings
{
    namespace TowerStates
    {
        /** —осто€ние, определ€ющее поведение башни в состо€нии поко€. */
        public class TowerChill : TowerState
        {
            public override void StateStart()
            {
            }

            public override void StateStop()
            {
            }

            public override void ChangeState<T>()
            {
                parentTower.ChangeState<T>();
            }
        }
    }
}

