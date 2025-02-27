using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float acceleration = 3f;
    public float maxSpeed = 10f;
    public float jumpImpulse = 1f;
    public float jumpBoostForce;
    
    public bool isGrounded;
    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAmount = Input.GetAxis("Horizontal");
        rb.linearVelocity += Vector3.right * (horizontalAmount * Time.deltaTime * acceleration);
        
        float horizontalSpeed = rb.linearVelocity.x;
        horizontalSpeed = Mathf.Clamp(horizontalSpeed, -maxSpeed, maxSpeed);
        
        Vector3 newVelocity = rb.linearVelocity;
        newVelocity.x = horizontalSpeed;
        rb.linearVelocity = newVelocity;
        
        // Test if charater on ground surface
        Collider c = GetComponent<Collider>();
        Vector3 startPoint = transform.position;
        float castDistance = c.bounds.extents.y + 0.01f;
        
        isGrounded = Physics.Raycast(startPoint, Vector3.down, castDistance);
        
        Color color = isGrounded ? Color.green : Color.red;
        Debug.DrawLine(startPoint, startPoint + castDistance * Vector3.down, color, 0f, false);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpImpulse, ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            if (rb.linearVelocity.y > 0)
                rb.AddForce(Vector3.up * jumpBoostForce, ForceMode.Acceleration);
        }

        if (horizontalAmount == 0f)
        {
            Vector3 decayedVelocity = rb.linearVelocity;
            decayedVelocity.x *= 1f - Time.deltaTime * 4f;
            rb.linearVelocity = decayedVelocity;
        }
        else
        {
            float yawRotation = (horizontalAmount > 0f) ? 0f : -180f;
            Quaternion rotation = Quaternion.Euler(0f, yawRotation, 0f);
            transform.rotation = rotation;
        }
        
    }

    void FixedUpdate()
    {
        Collider c = GetComponent<Collider>();
        float breakCastDistance = c.bounds.extents.y + 0.01f;
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, breakCastDistance))
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
