using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;
    private Rigidbody2D rb;
    private bool firstCollision = true;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (firstCollision)
            {
                // Hindari spawn platform pada collision pertama
                firstCollision = false;
                return;
            }            
            // Panggil metode untuk meng-spawn ground baru
            FindObjectOfType<GroundSpawner>().SpawnPlatform();
        }
    }    
}
