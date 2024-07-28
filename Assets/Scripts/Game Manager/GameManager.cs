using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float idleTime = 20f;
    private float timer;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            ResetTimer();
        }        
        
        timer += Time.deltaTime;

        if (timer >= idleTime)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void ResetTimer()
    {
        timer = 0f;
    }    
}
