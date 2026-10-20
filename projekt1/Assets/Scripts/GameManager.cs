using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public float timeRemaining = 60f;
    public bool isGameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScoreText;
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        } else
        {
            GameOver();
        }
    }

    public void AddScore(int pointsToAdd)
    {
        if (isGameOver) return;

        score += pointsToAdd;
        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = "Czas: " + Mathf.Ceil(timeRemaining).ToString();
        scoreText.text = "Punkty: " + score.ToString();
    }

    void GameOver()
    {
        isGameOver = true;
        timeRemaining = 0;
        UpdateUI();

        if (finalScoreText != null)
        {
            finalScoreText.text = "Twój wynik to: " + score.ToString();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
