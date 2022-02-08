using System;
using System.Collections;
using System.Collections.Generic;
using LastScope.Characters.GameField;
using LastScope.Extensions;
using LastScope.Services;
using UnityEngine;
using Zenject;

namespace LastScope
{
    public class AncorToBottom : MonoBehaviour
    {
        private IGameFieldFacade _gameFieldFacade;
        private ICameraService _cameraService;
        private IResolutionService _resolutionService;

        public BoxCollider2D BoxCollider2D;

        [Inject]
        private void Construct(ICameraService cameraService, IGameFieldFacade gameFieldFacade, IResolutionService resolutionService)
        {
            _gameFieldFacade = gameFieldFacade;
            _cameraService = cameraService;
            _resolutionService = resolutionService;
        }

        private void Start()
        {
            Rescaled();
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
            float distance = _cameraService.GameCamera.transform.position.z - _gameFieldFacade.transform.position.z;
            float topHeightPart = Math.Abs(distance * Mathf.Tan(_cameraService.GameCamera.fieldOfView * 0.5f * Mathf.Deg2Rad - _cameraService.GameCamera.transform.rotation.x * 2));
            transform.localPosition = new Vector3(0, topHeightPart - BoxCollider2D.size.y * 0.5f, 0);
        }
    }
}
