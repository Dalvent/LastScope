using System;
using System.ComponentModel;

namespace CodeBase.Services
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
    }
}