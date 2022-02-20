using LastScope.Characters.Shoot;
using UnityEngine;

namespace LastScope.Characters.Loot
{
    public class UpgradeGunsCount : MonoBehaviour
    {
        public int Power = 1;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<IShoot>().Upgrade(Power);
            Destroy(gameObject);
        }
    }
}
