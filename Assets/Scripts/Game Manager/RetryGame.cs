using UnityEngine;
using System.Collections.Generic;

public class RetryGame : MonoBehaviour
{
    private GamesScore gameScore;
    private GroundSpawner groundSpawner;

    public GameObject groundSpawnerObject;
    public GameObject playerSet;
    public GameObject scriptSet;

    // Nilai yang ingin ditambahkan pada koordinat Y
    public float yOffset;

    public string tagToDestroy;

    void Start()
    {
        gameScore = GetComponent<GamesScore>();
        groundSpawner = groundSpawnerObject.GetComponent<GroundSpawner>();
    }

    public void RetryGameButton()
    {
        Time.timeScale = 1f;

        gameScore.score = 0;
        gameScore.scoreResult = 0;      
        groundSpawner.ResetPlatformPosition();

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
        if (playerSet != null)
        {
            // Mengambil posisi saat ini dari targetObject
            Vector3 currentPosition = playerSet.transform.position;
            
            // Menambahkan nilai yOffset pada koordinat Y
            currentPosition.y += yOffset;
            
            // Mengatur posisi baru
            playerSet.transform.position = currentPosition;
        }
    }  
    
}
