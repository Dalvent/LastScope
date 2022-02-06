using UnityEngine;

namespace LastScope.Services
{
    public interface IAssetProvider
    {
        GameObject Load(string path);
    }
}