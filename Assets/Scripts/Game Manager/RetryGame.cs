using UnityEngine;

public class RetryGame : MonoBehaviour
{
    private GamesScore gameScore;

    private GroundSpawner groundSpawner;

    public GameObject gameObject;

    // Nilai yang ingin ditambahkan pada koordinat Y
    public float yOffset;    

    public string tagToDestroy;

    void Start()
    {
        gameScore = GetComponent<GamesScore>();
        groundSpawner = GetComponent<GroundSpawner>();
    }

    public void RetryGameButton()
    {
        Time.timeScale = 1f;

        gameScore.score = 0;
        gameScore.scoreResult = 0;
        groundSpawner.SpawnInitialPlatform();        
    }

    public void RemoveGround()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tagToDestroy);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }  

    public void RestartPosition()
    {
        if (gameObject != null)
        {
            // Mengambil posisi saat ini dari targetObject
            Vector3 currentPosition = gameObject.transform.position;
            
            // Menambahkan nilai yOffset pada koordinat Y
            currentPosition.y += yOffset;
            
            // Mengatur posisi baru
            gameObject.transform.position = currentPosition;
        }
    }  
}
