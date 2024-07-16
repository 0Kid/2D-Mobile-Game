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
            Vector3 spawnPosition;

            if (lastSpawnedObject != null)
            {
                // Mengambil posisi objek terakhir yang di-instantiate
                spawnPosition = lastSpawnedObject.transform.position;
                // Menambahkan offset pada sumbu Y
                spawnPosition.y += 0.1f; 
            }
            else
            {
                // Jika belum ada objek yang di-instantiate, gunakan posisi default
                spawnPosition = new Vector3(0, 0, 0);
            }            
            
            // Instantiate objek baru di posisi yang diambil
            lastSpawnedObject = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
