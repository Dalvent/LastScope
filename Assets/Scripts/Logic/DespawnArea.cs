using System;
using LastScope.Additional;
using UnityEngine;

namespace LastScope.Logic
{
    public class DespawnArea : MonoBehaviour, ISquare
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            var disposable = other.GetComponent<IDisposable>();
            if (disposable != null)
            {
                disposable.Dispose();
            }
            
            Destroy(other.gameObject);
        }
    }
}