using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<IHealth>().TakeDamage(Damage);
        Destroy(gameObject);
    }
}
