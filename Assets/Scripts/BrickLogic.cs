using UnityEngine;
using UnityEngine.Rendering;

public class BrickLogic : MonoBehaviour
{
    public AudioClip brickSound;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void OnIntereact()
    {
        audio.PlayOneShot(brickSound);
        GameObject manager = GameObject.Find("Game Manager");
        manager.GetComponent<GameManager>().BrickCollected();
        Destroy(this.gameObject);
    }
}
