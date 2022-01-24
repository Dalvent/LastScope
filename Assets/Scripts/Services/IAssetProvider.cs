using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IAssetProvider
    {
        GameObject Load(string path);
    }
}