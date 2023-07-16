using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Material _mat;
    private void Awake()
    {
        _mat = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        _mat.SetColor("_Color",Color.red);
    }
    
    private void OnTriggerExit(Collider other)
    {
        _mat.SetColor("_Color",Color.white);
    }
}
