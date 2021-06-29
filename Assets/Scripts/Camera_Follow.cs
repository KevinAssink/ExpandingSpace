using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform GameObject;

    void FixedUpdate()
    {
        transform.position = new Vector2(GameObject.position.x, transform.position.z); //the camera will follow the player around :D
    }
}
