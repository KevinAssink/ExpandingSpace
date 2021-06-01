using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_box_collider_enemy : MonoBehaviour
{
    public Transform enemyPrefab;

    private void Start()
    {
        
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }

    
}
