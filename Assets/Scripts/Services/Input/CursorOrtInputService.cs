using LastScope.Characters.Player;
using UnityEngine;

namespace LastScope.Services.Input
{
    public class CursorOrtInputService : IInputService
    {
        private readonly ICameraService _cameraService;

        public CursorOrtInputService(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public bool UseMove
            => UnityEngine.Input.GetButton("Fire1");

        public Vector2 FingerPosition
            =>_cameraService.GameCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
    }
}