using System;
using LastScope.Logic.GameField;
using UnityEngine;
using Zenject;

namespace LastScope.Characters
{
    public class DestoryOutOfMap : MonoBehaviour
    {
        private IGameFieldFacade _gameFieldFacade;
        private IDisposable _disposable;

        private void Start()
        {
            _disposable = GetComponent<IDisposable>();
        }

        [Inject]
        private void Construct(IGameFieldFacade gameFieldFacade)
        {
            _gameFieldFacade = gameFieldFacade;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_gameFieldFacade.IsOutOfMap(transform.position))
            {
                if (!gameObject.activeSelf)
                    return;

                if (_disposable != null)
                {
                    _disposable.Dispose();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}