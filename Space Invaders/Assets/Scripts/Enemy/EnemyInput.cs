using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    private static EnemyInput instance;

    public GameObject bulletPrefab;
    public GameObject ufoPrefab;

    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);
    private Vector3 ufoSpawnPos = new Vector3(14.5f, 5, 0);

    private const float max_left = -12.5f;
    private const float start_y = 4f; 
    private const float max_right = 12.5f;
    private const float max_move_speed = 0.02f; 

    public static float moveTimer = 0.01f;
    public static float moveTime = 0.005f;

    public static float shootTimer = 3.0f;
    public static float shootTime = 3.0f;

    private float ufoTimer = 10f;
    private const float ufo_min = 1f;
    private const float ufo_max = 20f; 

    private bool movingRight;
    private bool entering = true;

    public static List<GameObject> allAliens = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(go); 
        }
    }

    void Update()
    {

        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);

            if (transform.position.y <= start_y)
            {
                entering = false; 
            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }

            if (shootTimer <= 0)
            {
                Shoot();
            }

            if (ufoTimer <= 0)
            {
                SpawnUfo();
            }

            moveTimer -= Time.deltaTime;
            shootTimer -= Time.deltaTime;
            ufoTimer -= Time.deltaTime;
        }
    }

    public void MoveEnemies()
    {
        if(allAliens.Count > 0)
        {
            int hitMax = 0; 

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }
                else allAliens[i].transform.position -= hMoveDistance;

                if(allAliens[i].transform.position.x > max_right || allAliens[i].transform.position.x < max_left)
                {
                    hitMax++;
                }
            }

            if(hitMax > 0)
            {
                for (int i = 0; i< allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= vMoveDistance;
                }

                movingRight = !movingRight;
            }

            moveTimer = GetMoveSpeed();
        }
    }

    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(bulletPrefab, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    private void SpawnUfo()
    {
        Instantiate(ufoPrefab, ufoSpawnPos, Quaternion.identity);
        ufoTimer = Random.Range(ufo_min, ufo_max);
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;

        if (f < max_move_speed)
        {
            return max_move_speed;
        }
        else
        {
            return f;
        }
    }
}