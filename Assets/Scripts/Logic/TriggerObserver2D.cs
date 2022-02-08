using System;
using UnityEngine;

namespace LastScope.Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver2D : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEnter;
        public event Action<Collider2D> TriggerExit;

        public void OnTriggerEnter2D(Collider2D other) =>
            TriggerEnter?.Invoke(other);

        public void OnTriggerExit2D(Collider2D other) =>
            TriggerExit?.Invoke(other);
    }
}