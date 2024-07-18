using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    // GameObject yang ditempatkan di posisi spawn kiri
    public GameObject leftSpawnPoint; 
    // GameObject yang ditempatkan di posisi spawn kanan
    public GameObject rightSpawnPoint;
    public float moveSpeed = 2f;
    public float yOffset = 0.42f;
    private GameObject lastSpawnedPlatform;
    private float direction;

    void Start()
    {
        // Inisialisasi platform pertama di posisi spawn kiri atau kanan
        SpawnInitialPlatform();
    }

    void Update()
    {
        MovePlatform();
    }

    void SpawnInitialPlatform()
    {
        Vector2 initialPosition = leftSpawnPoint.transform.position;
        // Tentukan arah awal (kanan)
        direction = 1f; 
    }

    public void SpawnPlatform()
    {
        Vector2 spawnPosition;
        float randomValue = Random.value;

        if (randomValue > 0.5f)
        {
            // Spawn dari kiri
            spawnPosition = leftSpawnPoint.transform.position;
            // Gerak ke kanan
            direction = 1f; 
        }
        else
        {
            // Spawn dari kanan
            spawnPosition = rightSpawnPoint.transform.position;
            // Gerak ke kiri
            direction = -1f; 
        }

        spawnPosition.y = lastSpawnedPlatform != null ? lastSpawnedPlatform.transform.position.y + yOffset : spawnPosition.y;

        lastSpawnedPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }

    void MovePlatform()
    {
        if (lastSpawnedPlatform != null)
        {
            lastSpawnedPlatform.transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);
        }
    }

}
