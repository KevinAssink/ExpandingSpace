using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlplayer : MonoBehaviour
{

    float speed = 4f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // What is the player doing with the controls?
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);
        //rb.velocity = new Vector2(move, 0);
        rb.AddForce(move);

        // Update the ships position each frame
        transform.position += move
            * speed * Time.deltaTime;


    }
}
