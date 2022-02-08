using System;
using System.Collections;
using System.Collections.Generic;
using LastScope.Characters;
using UnityEngine;

namespace LastScope
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
