using LastScope.Extensions;
using UnityEngine;

namespace LastScope.Logic
{
    public class GameFieldMove : MonoBehaviour
    {
        [Min(0)] public float Speed;
        void Update()
        {
            transform.position = transform.position.AddY(Speed * Time.deltaTime);
        }
    }
}
