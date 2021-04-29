using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public float seconds;

    void Start()
    {
        Destroy(gameObject, seconds); 
    }
}