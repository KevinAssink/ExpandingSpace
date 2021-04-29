using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreValue;

    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);

        EnemyInput.allAliens.Remove(gameObject);

        if(EnemyInput.allAliens.Count == 0)
        {
            WaveManager.SpawnNewWave();
        }

        Destroy(gameObject);
    }
}
