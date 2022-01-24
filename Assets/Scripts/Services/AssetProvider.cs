using UnityEngine;

namespace CodeBase.Services
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Load(string path)
        {
            return (GameObject)Resources.Load(path);
        }
    }
}