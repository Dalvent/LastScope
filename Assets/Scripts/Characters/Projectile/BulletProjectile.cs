using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Factories.Pools.Projectile;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public BulletProjectileFacade bulletProjectileFacade;
    public float Damage { get; set; }
    public float Speed { get; set; }

    private void Update()
    {
        transform.position += transform.rotation * Vector3.up * Speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!gameObject.activeSelf)
            return;
        
        other.gameObject.GetComponent<IHealth>().TakeDamage(Damage);
        bulletProjectileFacade.Dispose();
    }
}
