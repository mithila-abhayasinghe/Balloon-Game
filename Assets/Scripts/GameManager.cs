using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    public Image[] hearts;
    private int lives = 3;

    public AudioClip popSound;
    public AudioClip wrongSound;
    private AudioSource audioSource;
    private bool isPaused = false;

    // New game mechanics 
    private int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = score.ToString();

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

    public void MissBlueBalloon()
    {

        lives--;
        UpdateHearts(lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // new
    public void HitRedBalloon()
    {
        lives--;
        PlayWrongSound();
        // new ignored combo 
        UpdateHearts(lives);
        if (lives <= 0)
        {
            GameOver();
        }
    }


    // new
    public void PopBlueBalloon()
    {
        // ignored combo but adding score
        score++;
        scoreText.text = score.ToString();
        PlayPopSound();
    }

    private void UpdateHearts(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
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

