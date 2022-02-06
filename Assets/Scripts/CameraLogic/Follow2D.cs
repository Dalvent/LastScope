using System;
using UnityEngine;

namespace LastScope.CameraLogic
{
    public class Follow2D : MonoBehaviour
    {
        public Transform Target;

        public void LateUpdate()
        {
            transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
        }
    }
}