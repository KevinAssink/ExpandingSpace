using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private float speed = 9f; 

    private AudioSource shootAudio;

    public GameObject bulletPrefab;

    private const float max_left = -12.7f;
    private const float max_right = 12.7f;

    public static bool shooting = false;
    private bool isShooting;
    public static bool AudioShoot = false;

    public static bool bulletSpeedOnWave = true;

    void Start()
    {
        shootAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (EnemyInput.shootTimer == 0.4f)
        {
            bulletSpeedOnWave = false;
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > max_left)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < max_right)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if(shooting == true)
        {
            if (Input.GetKey(KeyCode.Space) && !isShooting)
            {
                if (AudioShoot == true)
                {
                    shootAudio.Play();
                }
                StartCoroutine(Shoot());

            }
        }
    }


    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit");
            Destroy(collision.gameObject);

            UIManager.UpdateLife();
        }
    }
}