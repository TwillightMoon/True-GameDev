using UnityEngine;

namespace Units
{
    namespace UnitStates
    {
        public class UnitWalk : UnitState
        {
            private Vector2 currentTargetPoint;

            public override void StateStart()
            {
                if (!parentUnit.pathPoints.TryDequeue(out currentTargetPoint))
                    ChangeState<UnitChill>();
            }

            public override void FixedRun()
            {
                if (Vector2.Distance(transform.position, currentTargetPoint) > 0.001F)
                {
                    float step = parentUnit.unitCharacteristics.velocity * Time.deltaTime;
                    parentUnit.Rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, currentTargetPoint, step));
                }
                else if (!parentUnit.pathPoints.TryDequeue(out currentTargetPoint))
                    ChangeState<UnitChill>();

            }

            public override void StateStop()
            {
                return;
            }

            public override void ChangeState<T>()
            {
                parentUnit.ChangeState<T>();
            }
        }
    }
}

