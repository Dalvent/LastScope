using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Logic;
using Extensions;
using UnityEngine;

public class GameFieldBounder : MonoBehaviour, ISquare
{
    [SerializeField] private float _width = 1;
    private float _height = 1;
    private Camera _camera;

    public float Width => _width;
    public float Height => _height;

    private void Awake()
    {
        _camera = Camera.main;
        _height = _camera.orthographicSize * 2;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.12f, 0.12f, 0.64f, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(_width, Camera.main.orthographicSize * 2, 1));
    }
}