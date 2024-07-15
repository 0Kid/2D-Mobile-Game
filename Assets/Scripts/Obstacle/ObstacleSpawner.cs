using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float moveSpeed = 0f;
    
    void Update() 
    {
        ObstacleSpawn();
    }

    void ObstacleSpawn()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
}
