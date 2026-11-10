using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Statystyki Gry")]
    public int score = 0;
    public int lives = 3;
    public bool isGameActive;

    [Header("Elementy UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;

    [Header("Ustawienia Spawnera")]
    public GameObject cakePrefab;
    public float spawnRate = 1.5f;
    private float initialSpawnRate = 1.5f;
    private float minX = -7f;
    private float maxX = 7f;
    private float spawnY = 7f;

    [Header("Poziom Trudności")]
    public float gravityMultiplier = 1f;

    public void Awake()
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

    void Start()
    {
        isGameActive = false; 
        
        titleScreen.SetActive(true);
        gameOverScreen.SetActive(false);

        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (livesText != null) livesText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        StopAllCoroutines();

        Target[] existingCakes = FindObjectsByType<Target>();
        foreach (Target cake in existingCakes)
        {
            Destroy(cake.gameObject);
        }

        isGameActive = true;
        score = 0;
        lives = 3;
        
        spawnRate = initialSpawnRate;
        gravityMultiplier = 1f; 
        
        UpdateScore(0);
        UpdateLives();

        if (scoreText != null) scoreText.gameObject.SetActive(true);
        if (livesText != null) livesText.gameObject.SetActive(true);
        
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        
        StartCoroutine(SpawnCakes());
    }

    IEnumerator SpawnCakes()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0);

            GameObject newCake = Instantiate(cakePrefab, spawnPos, cakePrefab.transform.rotation);
            
            Rigidbody2D cakeRb = newCake.GetComponent<Rigidbody2D>();
            if (cakeRb != null)
            {
                cakeRb.gravityScale = gravityMultiplier;
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (scoreText != null) scoreText.text = "Wynik: " + score;

        if (score > 0 && score % 10 == 0) 
        {
            if (spawnRate > 0.4f) 
            {
                spawnRate -= 0.10f; 
            }

            gravityMultiplier += 0.1f; 
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateLives();
        
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void UpdateLives()
    {
        if (livesText != null) livesText.text = "Życia: " + lives;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);

        if (livesText != null) livesText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        StartGame();
    }
}