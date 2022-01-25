
using DefaultNamespace.Logic;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IGameFieldService
    {
        ISquare Bounder { get; }
        ISquare DespawnArea { get; }
    }
}