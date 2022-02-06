using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Additional
{
    public static class AdditionalGizmos
    {
        public static void DrawWireBorderCube(Vector3 position, float width, float height)
        {
            Gizmos.DrawWireCube(position, new Vector3(width, height, 1));
            Gizmos.DrawCube(position.AddX(width * -0.5f), new Vector3(0, height, 1));
            Gizmos.DrawCube(position.AddX(width * 0.5f), new Vector3(0, height, 1));
            Gizmos.DrawCube(position.AddY(height * -0.5f), new Vector3(width, 0, 1));
            Gizmos.DrawCube(position.AddY(height * 0.5f), new Vector3(width, 0, 1));
        }
        
        public static void DrawWireBorderIsoscelesTrapezoid(Vector3 position, float topWidth, float bottomWidth, float height)
        {
            Vector3 topLeft = position.AddX(-topWidth * 0.5f).AddY(height * 0.5f);
            Vector3 topRight = position.AddX(topWidth * 0.5f).AddY(height * 0.5f);
            Vector3 bottomRight = position.AddX(bottomWidth * 0.5f).AddY(-height * 0.5f);
            Vector3 bottomLeft = position.AddX(-bottomWidth * 0.5f).AddY(-height * 0.5f);

            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(bottomLeft, bottomRight);
            Gizmos.DrawLine(topLeft, bottomLeft);
            Gizmos.DrawLine(topRight, bottomRight);
        }

        public static void DrawCube(Vector3 position, Quaternion rotation, Vector3 center, Vector3 size)
        {
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(position, rotation, Vector3.one);
            Matrix4x4 defaultMatrix = Gizmos.matrix;
            Gizmos.matrix = rotationMatrix;
            Gizmos.DrawCube(center, size);
            Gizmos.matrix = defaultMatrix;
        }
    }
}