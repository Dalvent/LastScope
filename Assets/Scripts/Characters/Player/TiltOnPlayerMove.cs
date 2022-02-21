using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using LastScope.Logic;
using Unity.Mathematics;
using UnityEngine;

namespace LastScope.Characters.Player
{
    public class TiltOnPlayerMove : MonoBehaviour
    {
        public PlayerMove PlayerMove;

        public float MaxRotationAngle = 45f;

        private void Update()
        {
            float maxHorizontalSpeedPerFrame = PlayerMove.Speed * Time.deltaTime;
            float currentHorizontalSpeed = Mathf.Abs(PlayerMove.Velocity.normalized.x) * PlayerMove.Velocity.x;
            float speedCoefficient = currentHorizontalSpeed / maxHorizontalSpeedPerFrame;
            float targetRotation = speedCoefficient * MaxRotationAngle;

            float currentRotation = transform.rotation.eulerAngles.y;
            if (currentRotation > 180)
            {
                currentRotation -= 360;
            }
            
            float rotationSpeedCoef = Mathf.Abs(currentRotation - targetRotation) 
                                      / (MaxRotationAngle * 2f);
            
            transform.DORotate(new Vector3(0, targetRotation, 0), rotationSpeedCoef);
        }

        private void SetRotationAngleY(float yAngle)
        {
            transform.rotation = Quaternion.Euler(0.0f, yAngle, 0.0f);
        }
    }
}