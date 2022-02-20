using System;
using LastScope.Extensions;
using LastScope.Services;
using UnityEngine;
using Zenject;

namespace LastScope.Logic
{
    public class RepeatBackgroundSprite : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public float Speed = 1.5f;
        
        private IResolutionService _resolutionService;
        private ICameraService _cameraService;

        [Inject]
        private void Construct(ICameraService cameraService, IResolutionService resolutionService)
        {
            _cameraService = cameraService;
            _resolutionService = resolutionService;
        }

        private void Start()
        {
            Rescaled();
        }

        public void Update()
        {
            float halfHeight = SpriteRenderer.size.y * 0.5f;

            float actualSpeed = (Speed * Time.deltaTime) % halfHeight;
            transform.position = transform.position.AddY(actualSpeed);
            
            float centerOfSprite = halfHeight * 0.5f;
            if (centerOfSprite < transform.localPosition.y)
            {
                transform.position = transform.position.AddY(-halfHeight);
            }
            else if(-centerOfSprite > transform.localPosition.y)
            {
                transform.position = transform.position.AddY(halfHeight);
            }
        }

        private void OnEnable()
        {
            _resolutionService.OnRescaled += Rescaled;
        }

        private void OnDisable()
        {
            _resolutionService.OnRescaled -= Rescaled;
        }

        private void Rescaled()
        {
            //float height = _cameraService.BackgroundCamera.OrthographicHeight();
            SpriteRenderer.size = SpriteRenderer.size.SetY(SpriteRenderer.size.y * 2);
        }
    }
}