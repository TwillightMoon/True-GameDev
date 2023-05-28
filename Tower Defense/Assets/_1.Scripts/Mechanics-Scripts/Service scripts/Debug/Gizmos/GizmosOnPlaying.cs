using UnityEngine;

namespace DebugScripts
{
    namespace GizmosDebug
    {
        public static class GizmosOnPlaying
        {
            public static void DrawLine(Vector2 start, Vector2 end, Color color)
            {
                if (!Application.isPlaying) return;

                Gizmos.color = color;
                Gizmos.DrawLine(start, end);
            }
        }
    }
}

