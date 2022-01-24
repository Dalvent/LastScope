using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Services;
using DefaultNamespace;
using Services.Input;
using UnityEngine;
using Zenject;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public float Width;
    public float Height;

    private IInputService _inputService;
    private IGameFieldService _gameFieldService;

    [Inject]
    public void Construct(IInputService inputService, IGameFieldService gameFieldService)
    {
        _inputService = inputService;
        _gameFieldService = gameFieldService;
    }

    private void Update()
    {
        if (_inputService.UseMove)
        {
            Vector3 cursorPosition = _inputService.MovePosition;
            cursorPosition.z = transform.position.z;

            Vector3 nextPosition = _gameFieldService.InFieldRange(NextPosition(cursorPosition), Width, Height);
            transform.position = nextPosition;
        }
    }

    private Vector3 NextPosition(Vector3 cursorPosition)
    {
        return Vector3.MoveTowards(transform.position, cursorPosition, Speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.12f, 0.64f, 0.12f, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(Width, Height, 0.4f));
    }
}