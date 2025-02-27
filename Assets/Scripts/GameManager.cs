using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    public GameObject levelScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;
    private AudioSource audioSource;
    private bool playerLost = false;
    private int score = 0;
    private int coins = 0;
    int scoreLength = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int timeLeft = 100 - (int)(Time.time);
        timeText.text = $"Time\n{timeLeft}";
        if (timeLeft == 0)
        {
            playerLost = true;
            levelScreen.SetActive(false);
            gameOverScreen.SetActive(true);
            
        }
    }
    
    // Update Coin Counter
    public void CoinCollected()
    {
        coins++;
        coinText.text = $"x{coins}";
        scoreUpdate(100);
    }

    public void BrickCollected()
    {
        scoreUpdate(100);
    }

    public void scoreUpdate(int addScore)
    {
        score += addScore;
        string scoreString = score.ToString();
        int numZeros = scoreLength - scoreString.Length;
        
        string newScoreString ="";
        
        for(int i = 0; i < numZeros; i++){
            newScoreString += "0";
        }
        newScoreString += scoreString;
        scoreText.text = "Mario\n" + newScoreString;
    }

    public void GameEnd()
    {
        
        audioSource.PlayOneShot(audioSource.clip);
        levelScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        if (!playerLost)
        {
            gameOverText.text = "You Win!";
        }
    }
}
