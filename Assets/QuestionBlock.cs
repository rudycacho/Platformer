using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public AudioClip coinSound;
    private AudioSource audio;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnIntereact()
    {
        audio.PlayOneShot(coinSound);
        GameObject manager = GameObject.Find("Game Manager");
        manager.GetComponent<GameManager>().CoinCollected();
    }
}
