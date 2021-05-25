using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignore_box_collider_enemy : MonoBehaviour
{
    public Transform enemyPrefab;

    private void Start()
    {
        //Transform enemy = Instantiate(enemyPrefab) as Transform;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        
    }

    //  private void OnCollisionEnter(Collision2D  : Collision)
    //{

    //if (Collision.gameObject.Tag("enemy"))
    // {
    //  Physics.IgnoreCollision(Collision.collider, Collider);

    // }

    // }
}
