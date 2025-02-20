using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;
    private int score;
    private int coins = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int timeLeft = 300 - (int)(Time.time);
        timeText.text = $"Time\n{timeLeft}";
    }
    
    // Update Coin Counter
    public void CoinCollected()
    {
        coins++;
        coinText.text = $"x{coins}";
    }
}
