using UnityEngine;

namespace LastScope.Services
{
    public interface IPlayerService
    {
        public void Init(GameObject player);
        public bool IsDead { get; }
        Transform Transform { get; }
    }

    public class PlayerService : IPlayerService
    {
        private GameObject _player;

        public void Init(GameObject player)
        {
            _player = player;
        }

        public bool IsDead => _player == null;
        public Transform Transform => _player.transform;
    }
}