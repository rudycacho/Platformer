using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Draw Ray
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 100f;
        mousePosition = camera.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(camera.transform.position, mousePosition, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.CompareTag("Brick"))
                {
                    hit.transform.GetComponent<BrickLogic>().OnIntereact();
                }

                if (hit.transform.CompareTag("Question"))
                {
                    hit.transform.GetComponent<QuestionBlock>().OnIntereact();
                }
            }
        }
    }
}
