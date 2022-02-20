using UnityEngine;
using Random = UnityEngine.Random;

namespace LastScope.Characters.Loot
{
    public class DropLootOnDied : MonoBehaviour
    {
        public Health Health;
        [Range(0, 1f)] public float DropChance;
        public GameObject Loot;

        private void OnEnable()
        {
            Health.Died += OnDied;
        }

        private void OnDisable()
        {
            Health.Died -= OnDied;
        }

        private void OnDied()
        {
            if (DropChance >= Random.Range(0f, 1f))
            {
                Instantiate(Loot, transform.position, Quaternion.identity);
            }
        }
    }
}