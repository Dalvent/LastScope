using Cinemachine;
using UnityEngine;

namespace CodeBase.Services
{
    public class CinemachineService : ICinemachineService
    {
        private readonly CinemachineVirtualCamera _cinemachineVirtualCamera;

        public CinemachineService(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _cinemachineVirtualCamera = cinemachineVirtualCamera;
        }
        
        public void Follow(Transform target)
        {
            _cinemachineVirtualCamera.Follow = target;
        }
    }
}