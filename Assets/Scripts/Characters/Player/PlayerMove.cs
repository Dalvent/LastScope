using LastScope.Extensions;
using LastScope.Services.Input;
using UnityEngine;
using Zenject;

namespace LastScope.Characters.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float Speed;
        public float Width;
        public float Height;

        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.UseMove)
            {
                Vector3 cursorPosition = _inputService.FingerPosition;
                cursorPosition.z = transform.position.z;

                Vector3 nextPosition = NextPosition(cursorPosition);
                transform.position = nextPosition;
            }
        }

        private Vector3 NextPosition(Vector3 cursorPosition)
        {
            return Vector3.MoveTowards(transform.position, cursorPosition, Speed * Time.deltaTime);
        }
    }
}