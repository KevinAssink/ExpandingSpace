using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
    public int scoreValue;

    public GameObject bulletPrefab;

    private const float max_left = -17.5f;
    private float speed = 15;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x <= max_left)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("UFO Hit!");
            Destroy(other.gameObject);
            Destroy(gameObject);
            UIManager.UpdateScore(scoreValue);
        }
    }
}