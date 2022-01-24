using UnityEngine;

namespace Services.Input
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
            =>_camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
    }
}