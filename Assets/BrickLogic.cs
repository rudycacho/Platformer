using UnityEngine;
using UnityEngine.Rendering;

public class BrickLogic : MonoBehaviour
{
    ParticleSystem ps = null;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }
    void Update()
    {
        
    }

    public void OnIntereact()
    {
        ps.Play();
        Destroy(this.gameObject);
    }
}
