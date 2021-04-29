using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI waveText;
    private int wave;

    public TextMeshProUGUI lifeText;
    private int life = 3;

    private static UIManager instance;

    public static AudioSource hitSound;

    public void Start()
    {
        hitSound = GetComponent<AudioSource>();

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("000");

    }

    public static void UpdateWave()
    {
        instance.wave++;

        if(PlayerInput.bulletSpeedOnWave = true)
        {
            EnemyInput.shootTimer--;
        }

        instance.waveText.text = instance.wave.ToString();
    }

    public static void UpdateLife()
    {
        hitSound.Play();
        instance.life -= 1;
        instance.lifeText.text = instance.life.ToString();

        if (instance.life == 0)
        {
            MenuManager.OpenGameOver();
        }
    }

    public static void ResetUI()
    {
        instance.life = 3;
        instance.score = 0;
        instance.wave = 0;
        instance.lifeText.text = instance.life.ToString("3");
        instance.scoreText.text = instance.score.ToString("000");
        instance.waveText.text = instance.wave.ToString();
    }
}