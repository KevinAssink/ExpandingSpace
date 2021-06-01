/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public float playerDistance;
    public float rotationSpeed;
    public float moveSpeed;


    // Update is called once per frame
    void Update()
    {

        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < 15f)
        {
            LookAtPlayer();
        }
        if (playerDistance < 12f)
        {
            chase();
        }

    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

    }


    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
*/
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

    }
   

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}