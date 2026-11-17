using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Wartość Punktowa")]
    public int pointValue = 1;

    void Update()
    {
        if (transform.position.y < -6.25f)
        {
            if (GameManager.instance != null && GameManager.instance.isGameActive)
            {
                GameManager.instance.LoseLife();
            }
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance != null && GameManager.instance.isGameActive)
        {
            GameManager.instance.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }
}