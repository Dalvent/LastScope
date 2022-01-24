using UnityEngine;

namespace DefaultNamespace.Factories
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Transform parent);
    }
}