using System;
using UnityEngine;

namespace LastScope.Extensions
{
    public static class CameraAccessingExtensions
    {
        private const string MainCameraTag = "MainCamera";
        private const string GameplayCameraTag = "GameplayCamera";
        private const string BackgroundCameraTag = "BackgroundCamera";
        
        public static Camera GetGameplayCamera(this Camera mainCamera)
        {
            if (!mainCamera.CompareTag(MainCameraTag))
            {
                throw new ArgumentException($"Camera must have tag {MainCameraTag}, but it have {mainCamera.tag}");
            }

            Camera gameplayCamera = mainCamera.gameObject
                .FindInChildWithTag(GameplayCameraTag)
                .GetComponent<Camera>();

            if (gameplayCamera == null)
            {
                throw new AggregateException($"Camera don't have {GameplayCameraTag}!");
            }
            
            return gameplayCamera;
        }
        
        public static Camera GetBackgroundCamera(this Camera mainCamera)
        {
            if (!mainCamera.CompareTag(MainCameraTag))
            {
                throw new ArgumentException($"Camera must have tag {MainCameraTag}, but it have {mainCamera.tag}");
            }
            
            Camera backgroundCamera = mainCamera.gameObject
                .FindInChildWithTag(BackgroundCameraTag)
                .GetComponent<Camera>();

            if (backgroundCamera == null)
            {
                throw new AggregateException($"Camera don't have {BackgroundCameraTag}!");
            }
            
            return backgroundCamera;
        }
    }
}