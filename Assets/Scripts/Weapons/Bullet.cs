using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float velX = 5f;
    float velY = 1f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }
}
