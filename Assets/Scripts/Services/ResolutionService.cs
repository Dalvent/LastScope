using System;
using UnityEngine;
using Zenject;

namespace LastScope.Services
{
    public class ResolutionService : IResolutionService, IInitializable, ITickable
    {
        public event Action OnRescaled;

        private Resolution resolution;

        public void Initialize()
        {
            resolution = Screen.currentResolution;
        }

        public void Tick()
        {
            Resolution newResolution = Screen.currentResolution;
            if (resolution.width != newResolution.width || resolution.height != newResolution.height)
            {
                OnRescaled?.Invoke();
                
                resolution = newResolution;
            }
        }
    }
}