using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float moveSpeed = 0f;
    public float yOffset;
    
    void Update() 
    {
        ObstacleSpawn();
    }

    void ObstacleSpawn()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yOffset += 0.42f;
        }
    }
}
