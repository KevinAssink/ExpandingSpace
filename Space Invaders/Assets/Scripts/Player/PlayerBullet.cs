using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public int scoreValue;

    private float speed = 25; 

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            other.gameObject.GetComponent<Enemy>().Kill();
            Destroy(gameObject);
            UIManager.UpdateScore(scoreValue);
            Debug.Log("Alien Hit!");
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Enemy Bullet Hit!");
        }
    }
}
