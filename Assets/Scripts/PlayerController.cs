using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variable transform
    public float jumpForce = 5f;

    // Variable time
    public float jumpDelay = 0f;

    // Variable physics
    private Rigidbody2D rb;

    // Variable boolean
    private bool canJump = true;

    // Variable audio
    private AudioSource audioSource;  
    public AudioClip jumpSound; 
    public AudioClip landSound;      

    // Call function
    private GamesScore gameScore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        // Mendapatkan referensi ke skrip GameScoreFunction
        gameScore = FindObjectOfType<GamesScore>();        
    }

    void Update()
    {
        // Jika 
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // Set status menjadi tidak bisa melompat
        canJump = false;         
        StartCoroutine(JumpDelay());
        // Mainkan suara melompat
        PlaySound(jumpSound);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Panggil metode untuk meng-spawn platform baru
            FindObjectOfType<GroundSpawner>().SpawnPlatform();  
            // Tambahkan score
            gameScore.score++;
            gameScore.UpdateScoreUI();                     
        }
    }  

    private IEnumerator JumpDelay()
    {
        // Tunggu selama jumpDelay detik
        yield return new WaitForSeconds(jumpDelay); 
        // Izinkan melompat lagi setelah delay
        canJump = true; 
        // Mainkan suara mendarat
        PlaySound(landSound);         
    }    

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }    
}
