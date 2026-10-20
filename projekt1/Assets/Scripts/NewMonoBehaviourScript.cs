using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameOver) return;
        
        GameManager.Instance.AddScore(1);
        
        Destroy(gameObject);
    }
}
