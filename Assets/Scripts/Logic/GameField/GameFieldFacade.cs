using LastScope.Characters;
using LastScope.Extensions;
using LastScope.Services;
using UnityEngine;
using Zenject;

namespace LastScope.Logic.GameField
{
    public class GameFieldFacade : MonoBehaviour, IGameFieldFacade
    {
        public GameFieldMove Move;
        public DespawnArea DespawnArea;

        private ICameraService _cameraService;

        [Inject]
        public void Constructor(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        public float GetTop()
        {
            return _cameraService.GameCamera.PerspectiveLocalTop(DistanceToCamera());
        }

        public float GetBottom()
        {
            return _cameraService.GameCamera.PerspectiveLocalTop(DistanceToCamera());
        }

        public bool IsOutOfMap(Vector2 point)
        {
            return DespawnArea.IsOutOfMap(point);
        }

        private float DistanceToCamera()
        {
            return _cameraService.GameCamera.transform.position.z - transform.position.z;
        }
    }
}