using UnityEngine;

public class Target : MonoBehaviour
{
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
            GameManager.instance.UpdateScore(1);
            Destroy(gameObject);
        }
    }
}