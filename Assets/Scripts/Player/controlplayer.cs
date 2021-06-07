using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlplayer : MonoBehaviour
{

    float speed = 4f;
    public Animator Animator;
    private Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove = 0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // What is the player doing with the controls?
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0, 0);
        //rb.velocity = new Vector2(move, 0);
        rb.AddForce(move);

        // Update the players position each frame
        transform.position += move
            * speed * Time.deltaTime;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (horizontalMove > 0f)
        {
            rb.velocity = new Vector2 (horizontalMove * speed, rb.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (horizontalMove < 0f)
        {
            rb.velocity = new Vector2 (horizontalMove * speed, rb.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
}
