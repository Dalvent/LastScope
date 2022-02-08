using UnityEngine;

namespace LastScope.Services
{
    public interface ICameraService
    {
        void Init(Camera mainCamera);
        Camera GameCamera { get; }
        Camera MainCamera { get; }
    }
}