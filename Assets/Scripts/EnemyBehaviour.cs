using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public float speed;
    private float distance; //set the distance of the enemy seeing the player
    public float agroRange;
    public Transform target;//set target from inspector instead of looking in Update

    void Update()
    {
        if(target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < agroRange) //Agro range
        {  //rotate to look at the player
            transform.LookAt(target.position);
            transform.Rotate(new Vector2(0, -90), Space.Self);//correcting the original rotation
        }

        if (Vector2.Distance(transform.position, target.position) < agroRange) //Agro range
        {   //move towards the player
            if (Vector2.Distance(transform.position, target.position) > distance)
            {//move if distance from target is greater than distance
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
               
            }
        }
       
    }
}
