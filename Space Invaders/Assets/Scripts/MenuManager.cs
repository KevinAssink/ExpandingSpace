using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public GameObject inGameMenu;
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject optionMenu;

    private static AudioSource gameoverAudio;

    public static MenuManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ReturnToMainMenu();

        gameoverAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPause();
        }
    }

    public static void OpenGameOver()
    {
        Time.timeScale = 0f;
        instance.gameOverMenu.SetActive(true);
        instance.inGameMenu.SetActive(false);

        gameoverAudio.Play();
        PlayerInput.AudioShoot = false;
    }

    public void OnInGame()
    {
        Time.timeScale = 1f;
        instance.mainMenu.SetActive(false);
        instance.pauseMenu.SetActive(false);
        instance.gameOverMenu.SetActive(false);
        instance.inGameMenu.SetActive(true);

        PlayerInput.shooting = true;
        PlayerInput.AudioShoot = true;
        WaveManager.SpawnNewWave();

    }

    public void ControlsMenu()
    {
        instance.mainMenu.SetActive(false);
        instance.controlsMenu.SetActive(true);
    }

    public void OptionMenu()
    {
        instance.mainMenu.SetActive(false);
        instance.optionMenu.SetActive(true);
    }

    public void OpenPause()
    {
        Time.timeScale = 0f;
        instance.inGameMenu.SetActive(false);
        instance.pauseMenu.SetActive(true);

        PlayerInput.shooting = false;
        PlayerInput.AudioShoot = false;
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        instance.inGameMenu.SetActive(true);
        instance.pauseMenu.SetActive(false);

        PlayerInput.shooting = true;
        PlayerInput.AudioShoot = true;

    }

    public static void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        instance.gameOverMenu.SetActive(false);
        instance.pauseMenu.SetActive(false);
        instance.inGameMenu.SetActive(false);
        instance.controlsMenu.SetActive(false);
        instance.optionMenu.SetActive(false);

        PlayerInput.shooting = false;
        PlayerInput.AudioShoot = false;
        instance.mainMenu.SetActive(true);
        WaveManager.CancelGame();
        EnemyInput.shootTimer = 3f;
        EnemyInput.shootTime = 3f;

    }
}
