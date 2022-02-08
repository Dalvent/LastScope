using UnityEngine;

namespace LastScope.Services
{
    public interface IPlayerService
    {
        public void Init(GameObject player);
        Transform Transform { get; }
    }

    public class PlayerService : IPlayerService
    {
        private GameObject _player;

        public void Init(GameObject player)
        {
            _player = player;
        }

        public Transform Transform => _player.transform;
    }
}