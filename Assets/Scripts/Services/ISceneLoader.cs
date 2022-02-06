using System;

namespace LastScope.Services
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
    }
}