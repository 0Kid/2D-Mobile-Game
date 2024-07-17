using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private GameObject lastSpawnedObject;
    public float moveSpeed = 0f;
    public float yOffset = 0.42f;
    
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
            Vector2 spawnPosition;

            if (lastSpawnedObject != null)
            {
                 Debug.Log("Masuk If");
                // Mengambil posisi objek terakhir yang di-instantiate
                spawnPosition = lastSpawnedObject.transform.position; 
                // Menambahkan offset pada sumbu Y 
                spawnPosition.y += yOffset; 
            }
            else
            {
                Debug.Log("Masuk Else");
                // Jika belum ada objek yang di-instantiate, gunakan posisi default
                spawnPosition = new Vector2(0, 0);
            }            
            
            // Instantiate objek baru di posisi yang diambil
            lastSpawnedObject = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Obstacle di-spawn pada posisi: " + spawnPosition);
        }
    }
}
