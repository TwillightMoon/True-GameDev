using DebugScripts.GizmosDebug;

using UnityEngine;

namespace Units
{
    namespace UnitStates
    {
        public class UnitWalk : UnitState
        {
            private Transform currentTargetPoint;

            public override void StateStart()
            {
                if (!parentUnit.pathPoints.TryPeek(out currentTargetPoint))
                    ChangeState<UnitChill>();
            }

            public override void FixedRun()
            {
                if (Vector2.Distance(transform.position, currentTargetPoint.position) > 0.001F)
                {
                    float step = parentUnit.unitCharacteristics.velocity * Time.deltaTime;
                    parentUnit.Rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, currentTargetPoint.position, step));
                }
                else
                {
                    parentUnit.pathPoints.Dequeue();
                    if (!parentUnit.pathPoints.TryPeek(out currentTargetPoint))
                        ChangeState<UnitChill>();
                }

            }

            public override void StateStop()
            {
                return;
            }

            public override void ChangeState<T>()
            {
                parentUnit.ChangeState<T>();
            }

            private void OnDrawGizmosSelected()
            {
                if (!currentTargetPoint) return;
                    GizmosOnPlaying.DrawLine(transform.position, currentTargetPoint.position, Color.green);
            }
        }
    }
}

