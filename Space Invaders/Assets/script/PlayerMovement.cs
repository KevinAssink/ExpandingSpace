using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{

    public float MoveSpeed = 3f;
    private Rigidbody2D rb;
    public float JumpPower = 8;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MoveSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MoveSpeed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -MoveSpeed) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector3(0, JumpPower, 0);
        }


    }
}
