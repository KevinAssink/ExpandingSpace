using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_box_collider_enemy : MonoBehaviour
{
    public Transform enemyPrefab;

    private void Start()
    {
        
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }

    
}
