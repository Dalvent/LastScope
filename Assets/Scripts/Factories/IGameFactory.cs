using UnityEngine;

namespace LastScope.Factories
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Transform parent);
    }
}