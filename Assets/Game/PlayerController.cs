using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.02f;

    private void Awake()
    {
        Speed = 0.01f;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Vector3.up * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.down * Speed;
        }
    }
}
