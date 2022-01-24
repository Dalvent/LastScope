using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerShoot : Shoot
{
    protected override int GetProjectileLayer()
    {
        return LayerMask.NameToLayer("PlayerProjectile");
    }
}