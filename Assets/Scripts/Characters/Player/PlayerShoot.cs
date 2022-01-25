using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Services;
using DefaultNamespace;
using DefaultNamespace.StaticData;
using UnityEngine;
using Zenject;

public class PlayerShoot : Shoot
{
    private IStaticDataService _staticDataService;

    public override CharacterType GetCharacterType()
        => CharacterType.Player;

    [Inject]
    public void Construct(IStaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }
    
    public override ProjectileCustomisationStaticData GetCustomisation()
    {
        return _staticDataService.Player.Customisation;
    }
}