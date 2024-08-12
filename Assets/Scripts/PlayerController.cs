using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Variable Gameobject
    public GameObject inputObjectUI; 
    public GameObject scoreTextBool;

    // Variable transform
    public float jumpForce = 5f;

    // Variable time
    public float jumpDelay = 0f;

    // Variable physics
    private Rigidbody2D rb;

    // Variable boolean
    private bool canJump = true;
    bool isGrounded= false;
    //private bool groundSpawned = false;

    // Variable audio
    private AudioSource audioSource;  
    public AudioClip jumpSound; 
    public AudioClip landSound;    

    // Variable Animation
    public Animator animator; 

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
        if (Input.GetKeyDown(KeyCode.Return) && canJump)
        {
            Jump();
        }
        animator.SetBool("isJumping", !isGrounded);        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetFloat("yVelocity", rb.velocity.y);
        // Set status menjadi tidak bisa melompat
        canJump = false; 
        isGrounded = false;        
        StartCoroutine(JumpDelay());
        // Mainkan suara melompat
        PlaySound(jumpSound);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //&& !groundSpawned)
        {
            //groundSpawned = true;
            // Panggil metode untuk meng-spawn platform baru
            FindObjectOfType<GroundSpawner>().SpawnPlatform();  
            // Tambahkan score
            gameScore.score++;
            gameScore.UpdateScoreUI();                   
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Pause the game
            Time.timeScale = 0f; 
            inputObjectUI.SetActive(true);
            gameScore.scoreResult = gameScore.score;
            gameScore.UpdateScoreResultUI();
            // Hide text
            scoreTextBool.SetActive(false);
        }
    }   

    //public void GroundSpawned()
    //{
    //    // Reset flag ketika ground baru di-spawn
    //    groundSpawned = false;
    //    Debug.Log("Masuk Function");
    //}    

    private IEnumerator JumpDelay()
    {
        // Tunggu selama jumpDelay detik
        yield return new WaitForSeconds(jumpDelay); 
        // Izinkan melompat lagi setelah delay
        canJump = true; 
        // Mainkan suara mendarat
        PlaySound(landSound);   
        isGrounded = true;   
        animator.SetBool("isJumping", isGrounded);     
    }    

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }    
}