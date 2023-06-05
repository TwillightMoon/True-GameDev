using DebugScripts.GizmosDebug;

using StatsEnums.Orientation;

using UnityEngine;

namespace Units
{
    namespace UnitStates
    {
        public class UnitWalk : UnitState
        {
            [SerializeField] UnitAnimationController _unitAnimationController;
            private Transform currentTargetPoint;

            public override void StateStart()
            {
                if (!parentUnit.pathPoints.TryPeek(out currentTargetPoint))
                    ChangeState<UnitChill>();
                else
                    ChangeAnim();
            }

            public override void FixedRun()
            {
                if (Vector2.Distance(transform.position, currentTargetPoint.position) > 0.001F)
                {
                    float step = parentUnit.unitCharacteristics.velocity * Time.deltaTime;
                    parentUnit.Rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, currentTargetPoint.position, step));
                }
                else
                    GetNextPoint();

            }

            public override void StateStop()
            {
                return;
            }

            public override void ChangeState<T>()
            {
                parentUnit.ChangeState<T>();
            }

            private void GetNextPoint()
            {
                parentUnit.pathPoints.Dequeue();
                if (!parentUnit.pathPoints.TryPeek(out currentTargetPoint))
                    ChangeState<UnitChill>();
                else
                    ChangeAnim();

            }

            private void ChangeAnim()
            {
                Vector2 direction = (currentTargetPoint.position - transform.position).normalized;
                direction.x = (int)direction.x;
                direction.y = (int)direction.y;
                Debug.Log(direction);

                if (direction.y > 0)
                {
                    _unitAnimationController.ChangeAnimationOrientation(OrientationEnum.Up);
                    Debug.Log("Log: up");
                }
                else if (direction.y < 0)
                {
                    _unitAnimationController.ChangeAnimationOrientation(OrientationEnum.Down);
                    Debug.Log("Log: down");
                }
                else if (direction.x > 0)
                {
                    _unitAnimationController.ChangeAnimationOrientation(OrientationEnum.Right);
                    Debug.Log("Log: right");
                }
                else if (direction.x < 0)
                {
                    _unitAnimationController.ChangeAnimationOrientation(OrientationEnum.Left);
                    Debug.Log("Log: left");
                }
            }

            private void OnDrawGizmosSelected()
            {
                if (!currentTargetPoint) return;
                    GizmosOnPlaying.DrawLine(transform.position, currentTargetPoint.position, Color.green);
            }
        }
    }
}

