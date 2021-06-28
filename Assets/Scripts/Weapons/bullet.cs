using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb;
    public int destroyTime = 2;
    public AudioSource shootingSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velX, velY);
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
    public void playSoundEffect()
	{
        shootingSound.Play();
	}
}
