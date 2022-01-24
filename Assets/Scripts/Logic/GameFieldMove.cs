using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

public class GameFieldMove : MonoBehaviour
{
    [Min(0)] public float Speed;
    void Update()
    {
        transform.position = transform.position.AddY(Speed * Time.deltaTime);
    }
}
