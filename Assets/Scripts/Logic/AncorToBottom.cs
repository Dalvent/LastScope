using LastScope.Logic.GameField;
using LastScope.Services;
using UnityEngine;
using Zenject;

namespace LastScope.Logic
{
    public class AncorToBottom : MonoBehaviour
    {
        private IGameFieldFacade _gameFieldFacade;
        private IResolutionService _resolutionService;

        public BoxCollider2D BoxCollider2D;

        [Inject]
        private void Construct(IGameFieldFacade gameFieldFacade, IResolutionService resolutionService)
        {
            _gameFieldFacade = gameFieldFacade;
            _resolutionService = resolutionService;
        }

        private void Start()
        {
            Rescaled();
        }

        private void OnEnable()
        {
            _resolutionService.OnRescaled += Rescaled;
        }

        private void OnDisable()
        {
            _resolutionService.OnRescaled -= Rescaled;
        }

        private void Rescaled()
        {
            transform.localPosition = new Vector3(0, _gameFieldFacade.GetTop() - BoxCollider2D.size.y * 0.5f, 0);
        }
    }
}
