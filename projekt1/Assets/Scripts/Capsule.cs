using UnityEngine;

public class Capsule : MonoBehaviour
{
    public Vector3 startPos; // położenie początkowe obiektu
    public Vector3 endPos; // położenie końcowe obiektu
    public float duration = 3; // czas trwania ruchu
    private float time = 0; // czas początkowy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        float t = Mathf.PingPong(time/duration, 1);
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
}
