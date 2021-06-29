using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlplayer : MonoBehaviour
{

    float moveSpeed = 3f;
    float velX;
    float velY;
    Rigidbody2D rb;
    bool facingRight = true;
    public float jumpForce = 600f;
    public LayerMask theGround;
    public Transform groundCheck;
    bool onTheGround = false;


    public GameObject bulletRight, bulletLeft, gameOverText, restartButton;

    public GameObject heart1, heart2, heart3;
    public int playerhealth = 3;
    int playerLayer, enemyLayer;
    bool coroutineAllowed = true;
    Color color;
    Renderer rend;

    Vector2 bulletPos;
    public float fireRate = 0.5f;
    float nextFire = 0f;

    // Use this for initialization
    void Start()
    {
        playerLayer = this.gameObject.layer;
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        heart1 = GameObject.Find("heart1");
        heart2 = GameObject.Find("heart2");
        heart3 = GameObject.Find("heart3");
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        rend = GetComponent<Renderer>();
        color = rend.material.color;

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * moveSpeed, velY);

        onTheGround = Physics2D.Linecast(transform.position, groundCheck.position, theGround);
        if (onTheGround && Input.GetButtonDown(" Jump"))
        {
            velY = 0f;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        } else if (velX < 0) {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && localScale.x >0 )) 
        {
           localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
    void fire()
    {
        bulletPos = transform.position;

        if (facingRight)
        {
            bulletPos += new Vector2(+1f, 0.01f);
            Instantiate(bulletRight, bulletPos, Quaternion.identity);
        }
        else
        {
            bulletPos += new Vector2(-1f, 0.01f);
            Instantiate(bulletLeft, bulletPos, Quaternion.identity);
        }
    }

     void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.tag.Equals("Enemy"))
        {
            playerhealth -= 1;
            switch (playerhealth)
            {
                case 2:
                    heart3.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
                case 1:
                    heart2.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
                case 0:
                    heart1.gameObject.SetActive(false);
                    if (coroutineAllowed)
                        StartCoroutine("Immortal");
                    break;
            }

           if (playerhealth < 1)
           {
               gameOverText.SetActive(true);
               restartButton.SetActive(true);
               gameObject.SetActive(false);
           }
            
        }
    }

    IEnumerator Immortal()
    {
        coroutineAllowed = false;
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        color.a = 0.5f;
        rend.material.color = color;
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        color.a = 1f;
        rend.material.color = color;
        coroutineAllowed = true;
    }
    




}