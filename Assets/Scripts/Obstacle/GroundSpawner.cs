using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject leftSpawnPoint; // GameObject yang ditempatkan di posisi spawn kiri
    public GameObject rightSpawnPoint; // GameObject yang ditempatkan di posisi spawn kanan
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
        lastSpawnedPlatform = Instantiate(platformPrefab, initialPosition, Quaternion.identity);
        direction = 1f; // Tentukan arah awal (kanan)
    }

    public void SpawnPlatform()
    {
        Vector2 spawnPosition;
        float randomValue = Random.value;

        if (randomValue > 0.5f)
        {
            // Spawn dari kiri
            spawnPosition = leftSpawnPoint.transform.position;
            direction = 1f; // Gerak ke kanan
        }
        else
        {
            // Spawn dari kanan
            spawnPosition = rightSpawnPoint.transform.position;
            direction = -1f; // Gerak ke kiri
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
