using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera camera;
    public GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        camera = Camera.main;
        offset = camera.transform.position - player.transform.position;
    }

    // Update is called once per frame
    

    void LateUpdate()
    {
            Vector3 newPosition = player.transform.position;
            newPosition.y = transform.position.y;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
    }
}
