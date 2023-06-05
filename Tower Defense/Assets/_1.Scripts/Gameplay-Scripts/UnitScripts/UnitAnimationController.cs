using UnityEngine;
using StatsEnums.Orientation;

public class UnitAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _currentAnimationHash;

    private int _walkDownHash = Animator.StringToHash("WalkDown");
    private int _walkUpHash = Animator.StringToHash("WalkUp");
    private int _walkRightHash = Animator.StringToHash("WalkRight");
    private int _walkLeftHash = Animator.StringToHash("WalkLeft");


    public void ChangeAnimationOrientation(OrientationEnum orientation)
    {
        int animHash = GetAnimationOrientationHash(orientation);

        if (_currentAnimationHash == animHash)
        {
            Debug.Log("sss");
            return;
        }

        _animator.Play(animHash);
        _currentAnimationHash = animHash;
    }

    public int GetAnimationOrientationHash(OrientationEnum orientation)
    {
        switch (orientation) 
        {
            case OrientationEnum.Down:
                return _walkDownHash;
            case OrientationEnum.Up:
                return _walkUpHash;
            case OrientationEnum.Right: 
                return _walkRightHash;
            case OrientationEnum.Left:
                return _walkLeftHash;
            default:
                return _walkDownHash;
        }
    }
}
