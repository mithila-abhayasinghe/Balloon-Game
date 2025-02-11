using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public Image[] hearts;
    public AudioClip popSound;
    public AudioClip wrongSound;
    private AudioSource audioSource;
    private int missedBalloons = 0;
    private int obstacleHits = 0;
    private bool isPaused = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // Pause functionality
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePanel.SetActive(isPaused);
    }

    public void MissBalloon()
    {
        missedBalloons++;
        UpdateHearts(3 - missedBalloons);

        if (missedBalloons >= 3)
        {
            GameOver();
        }
    }

    public void HitObstacle()
    {
        obstacleHits++;
        PlayWrongSound();

        if (obstacleHits >= 3)
        {
            GameOver();
        }
    }

    public void PopBalloon()
    {
        PlayPopSound();
    }

    private void UpdateHearts(int remainingHearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < remainingHearts;
        }
    }

    private void PlayPopSound()
    {
        audioSource.PlayOneShot(popSound);
    }

    private void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrongSound);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

