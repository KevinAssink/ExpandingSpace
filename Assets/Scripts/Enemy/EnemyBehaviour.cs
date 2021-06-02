using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float speed;
    private float distance; //set the distance of the enemy seeing the player
    public float agroRange;
    public Transform target;//set target from inspector instead of looking in Update
    public int health = 100; // amount of base health
    public GameObject deathEffect; // plays death effect 
    public Transform enemyGFX;
    Rigidbody2D rb;

    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < agroRange) //Agro range
        {  //rotate to look at the player
            //transform.LookAt(target.position);
            //transform.Rotate(new Vector2(0, -90), Space.Self);//correcting the original rotation
        }

        if (Vector2.Distance(transform.position, target.position) < agroRange) //Agro range
        {   //move towards the player
            if (Vector2.Distance(transform.position, target.position) > distance)
            {//move if distance from target is greater than distance
                if (transform.position.x < target.position.x)
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                else
                    transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

            }
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);

        }
            else if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}