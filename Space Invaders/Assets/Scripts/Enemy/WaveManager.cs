using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] allAliensSets;

    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0, 10);

    private static WaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    public static void CancelGame()
    {
        instance.StopAllCoroutines();

        EnemyInput.allAliens.Clear();

        if(instance.currentSet != null)
        {
            Destroy(instance.currentSet);
        }

        UIManager.ResetUI();
    }

    private IEnumerator SpawnWave()
    {
        EnemyInput.allAliens.Clear();

        if (currentSet != null)
        {
            Destroy(currentSet);
        }

        yield return new WaitForSeconds(2);

        currentSet = Instantiate(allAliensSets[Random.Range(0, allAliensSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
        EnemyInput.shootTimer -= 0.1f;
        EnemyInput.shootTime -= 0.1f;
    }
}