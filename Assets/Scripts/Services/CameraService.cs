using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Services
{
    public class CameraService : ICameraService
    {
        public Camera GameCamera { get; private set; }
        public Camera MainCamera { get; private set; }
        public Camera BackgroundCamera { get; private set; }

        public void Init(Camera mainCamera)
        {
            MainCamera = mainCamera;
            GameCamera = MainCamera.GetGameplayCamera();
            BackgroundCamera = MainCamera.GetBackgroundCamera();
        }
    }
}