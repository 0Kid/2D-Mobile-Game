using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject inputObjectUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Unpause the game
        Time.timeScale = 0f; 
        gameObject.SetActive(true);
    }      
}
