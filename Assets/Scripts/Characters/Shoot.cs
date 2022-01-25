﻿using System.Collections;
using System.Collections.Generic;
using CodeBase.Services;
using DefaultNamespace.Factories;
using DefaultNamespace.StaticData;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public abstract class Shoot : MonoBehaviour
    {
        public List<Transform> ShootingFrom;
        public float ReloadTime;
        public float BulletSpeed = 5;
        public float Damage = 5;
        private IProjectileFactory _projectileFactory;

        [Inject]
        public void Construct(IProjectileFactory projectileFactory, IGameFieldService gameFieldService)
        {
            _projectileFactory = projectileFactory;
        }

        public abstract CharacterType GetCharacterType();
        public abstract ProjectileCustomisationStaticData GetCustomisation();

        
        private void Start()
        {
            StartCoroutine(Shooting());
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                yield return new WaitForSeconds(ReloadTime);

                foreach (var shootingFrom in ShootingFrom)
                {
                    _projectileFactory.CreateBullet(GetCharacterType(),
                        Damage,
                        BulletSpeed,
                        GetCustomisation(),
                        shootingFrom.position,
                        shootingFrom.rotation);
                }
            }
        }
    }
}