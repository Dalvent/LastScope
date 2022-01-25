using CodeBase.Services;
using DefaultNamespace.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameRunner : IInitializable
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICinemachineService _cinemachineService;
        private readonly IGameFieldService _gameFieldService;

        public GameRunner(ICinemachineService cinemachineService, IGameFieldService gameFieldService, IGameFactory gameFactory)
        {
            _cinemachineService = cinemachineService;
            _gameFieldService = gameFieldService;
            _gameFactory = gameFactory;
        }

        public void Initialize()
        {
            GameObject hero = _gameFactory.CreatePlayer(_gameFieldService.Bounder.transform);
            _cinemachineService.Follow(hero.transform);
        }
    }
}