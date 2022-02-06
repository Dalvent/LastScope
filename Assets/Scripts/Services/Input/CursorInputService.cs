using UnityEngine;

namespace LastScope.Services.Input
{
    public class CursorInputService : IInputService
    {
        private readonly Camera _camera;

        public CursorInputService()
        {
            _camera = Camera.main;
        }

        public bool UseMove
            => UnityEngine.Input.GetButton("Fire1");

        public Vector2 MovePosition
            =>GetWorldPositionOnPlane(UnityEngine.Input.mousePosition, 6);
        
        public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
            float distance;
            xy.Raycast(ray, out distance);
            return ray.GetPoint(distance);
        }
    }
}