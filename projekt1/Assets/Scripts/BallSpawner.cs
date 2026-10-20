using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject ball;
    public float spawnInterval = 1.0f;
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float spawnY = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (!GameManager.Instance.isGameOver)
        {
            SpawnSingleBall();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnSingleBall()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        Instantiate(ball, spawnPosition, Quaternion.identity);
    }
}
