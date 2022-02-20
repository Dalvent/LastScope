using LastScope.Characters.Player;
using LastScope.Factories;
using LastScope.Logic;
using LastScope.Logic.GameField;
using LastScope.Services;
using LastScope.Services.Input;
using UnityEngine;
using Zenject;

namespace LastScope.Infrastructure
{
    public class GameRunner : IInitializable
    {
        private readonly ICameraService _cameraService;
        private readonly IPlayerService _playerService;
        private readonly IGameFactory _gameFactory;
        private readonly IGameFieldFacade _gameFieldFacade;

        public GameRunner(ICameraService cameraService, IPlayerService playerService, IGameFactory gameFactory, IGameFieldFacade gameFieldFacade)
        {
            _cameraService = cameraService;
            _playerService = playerService;
            _gameFactory = gameFactory;
            _gameFieldFacade = gameFieldFacade;
        }

        public void Initialize()
        {
            _playerService.Init(_gameFactory.CreatePlayer(_gameFieldFacade.transform));
            _cameraService.Init(Camera.main);
        }
    }
}