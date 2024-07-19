using UnityEngine;
using UnityEngine.UI;

public class GamesScore : MonoBehaviour
{
    public Text scoreText;
    // Variabel untuk menyimpan score
    public int score = 0; 

    void Start() 
    {
        // Set score awal di UI
        UpdateScoreUI();        
    }

    public void UpdateScoreUI()
    {
        // Update teks score di UI Text
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }    
}
