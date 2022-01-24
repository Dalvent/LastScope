using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class GameFieldBounder : MonoBehaviour
{
    [SerializeField] private float _fieldWidth = 1;
    private Camera _camera;

    public float HalfFieldWidth { get; private set; }
    public float HalfFieldHeight { get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
        HalfFieldWidth = _fieldWidth / 2;
        HalfFieldHeight = _camera.orthographicSize;
    }

    public Vector3 InFieldRange(Vector3 position, float width, float height)
    {
        float halfWidth = width * 0.5f;
        float halfHeight = height * 0.5f;

        return new Vector3(
            Math.Min(Math.Max(position.x, transform.position.x - HalfFieldWidth + halfWidth), transform.position.x + HalfFieldWidth - halfWidth),
            Math.Min(Math.Max(position.y, transform.position.y - HalfFieldHeight + halfHeight), transform.position.y + HalfFieldHeight - halfHeight), 
            position.z);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.12f, 0.12f, 0.64f, 0.1f);
        Gizmos.DrawCube(transform.position, new Vector3(_fieldWidth, Camera.main.orthographicSize * 2, 1));
    }
}