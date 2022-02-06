using System;
using LastScope.Additional;
using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Logic
{
    public class GameFieldBounder : MonoBehaviour, ISquare
    {
        public BoxCollider2D Collider2D;
        public Camera Camera;

        public float Width => Collider2D.size.x;
        public float Height => Collider2D.size.y;

        public Vector2 Size
        {
            get => Collider2D.size;
            set => Collider2D.size = value;
        }

        public float ultraConst = 0.0f;
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.12f, 0.72f, 0.12f, 1f);
            Camera camera = Camera;
            float distance = camera.transform.position.z - transform.position.z;

            float topHeightPart = Math.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad - camera.transform.rotation.x * 2));
            float bottomHeightPart = Math.Abs(distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad + camera.transform.rotation.x * 2));
            float fullHeight = topHeightPart + bottomHeightPart;
            float trapezoidOffset = fullHeight * 0.5f - bottomHeightPart;

            float angle = camera.transform.rotation.x * camera.aspect;

            float widthDifOfTrapezoid = Mathf.Atan(angle) * fullHeight;
            float topWidth = fullHeight * camera.aspect - widthDifOfTrapezoid;
            float bottomWidth = fullHeight * camera.aspect + widthDifOfTrapezoid;

            Gizmos.color = Color.magenta;
            AdditionalGizmos.DrawWireBorderIsoscelesTrapezoid(transform.position.AddY(trapezoidOffset), topWidth, bottomWidth, fullHeight);

            Gizmos.color = new Color(0.12f, 0.72f, 0.72f, 1f);
            Gizmos.DrawLine(transform.position, transform.position.AddY(topHeightPart));
            Gizmos.color = new Color(0.82f, 0.72f, 0.12f, 1f);
            Gizmos.DrawLine(transform.position, transform.position.AddY(-bottomHeightPart));
        }
    }
}