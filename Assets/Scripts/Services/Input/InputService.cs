using LastScope.CameraLogic;
using LastScope.Characters.Player;
using UnityEngine;

namespace LastScope.Services.Input
{
    public class InputService : IInputService
    {
        private readonly IPlayerService _playerService;
        private readonly ICameraService _cameraService;

        public InputService(ICameraService cameraService, IPlayerService playerService)
        {
            _playerService = playerService;
            _cameraService = cameraService;
        }

        public bool UseMove
            => UnityEngine.Input.GetButton("Fire1");

        public Vector3 GetWorldPositionOnPlane()
        {
            var ray = _cameraService.GameCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 25f))
            {
                return hit.point;
            }

            return _playerService.Transform.position;
        }

        public Vector2 FingerPosition
            => GetWorldPositionOnPlane();
    }
}