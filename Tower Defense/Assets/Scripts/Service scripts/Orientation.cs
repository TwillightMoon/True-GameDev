using UnityEngine;

public enum OrientationEnum
{
    Left,
    Right,
    Up,
    Down
}

public class Orientation
{
    public static Vector2 GetVectorRotation(OrientationEnum orientation)
    {
        switch (orientation)
        {
            case OrientationEnum.Left:
                return Vector3.forward * 90;
            case OrientationEnum.Right:
                return Vector3.forward * -90;
            case OrientationEnum.Up:
                return Vector3.zero;
            case OrientationEnum.Down:
                return Vector3.forward * -180;
            default:
                return Vector3.zero;
        }
    }
    public static Vector2 GetVectorDirection(OrientationEnum orientation)
    {
        switch (orientation)
        {
            case OrientationEnum.Left:
                return Vector2.left;
            case OrientationEnum.Right:
                return Vector2.right;
            case OrientationEnum.Up:
                return Vector2.up;
            case OrientationEnum.Down:
                return Vector2.down;
            default:
                return Vector2.up;
        }
    }
}
