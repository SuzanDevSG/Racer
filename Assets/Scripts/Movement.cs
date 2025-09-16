using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float jumpForce;
    void FixedUpdate()
    {
        while(rb.velocity.y < 0.5f)
        {
            rb.AddForce(Vector3.forward * forwardForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.name);
        
        if(Other.CompareTag("Obstackle") )
            rb.AddForce(new Vector3(0,1,1) * jumpForce * Time.deltaTime, ForceMode.Impulse);
    }
    }

