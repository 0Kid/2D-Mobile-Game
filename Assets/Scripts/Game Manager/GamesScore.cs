using UnityEngine;
using UnityEngine.UI;

public class GamesScore : MonoBehaviour
{
    public Text scoreText;
    // Variabel untuk menyimpan score
    private int score = 0; 

    void Start() 
    {
        // Set score awal di UI
        UpdateScoreUI();        
    }

    
}
