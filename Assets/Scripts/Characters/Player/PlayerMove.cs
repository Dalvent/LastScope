using System;
using LastScope.Extensions;
using LastScope.Logic;
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
        
        public Vector3 Velocity { get; private set; }

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
                Vector3 transformPosition = transform.position;
                
                Vector3 cursorPosition = _inputService.FingerPosition;
                cursorPosition.z = transformPosition.z;

                Vector3 nextPosition = NextPosition(cursorPosition);
                Velocity = nextPosition - transformPosition;
                transform.position = nextPosition;
            }
            else
            {
                Velocity = Vector3.zero;
            }
        }

        private Vector3 NextPosition(Vector3 cursorPosition)
        {
            return Vector3.MoveTowards(transform.position, cursorPosition, Speed * Time.deltaTime);
        }
    }
}