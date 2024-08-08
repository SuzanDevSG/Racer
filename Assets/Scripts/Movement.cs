using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float jumpForce;
    void Start()
    {
        rb.AddForce(Vector3.forward * forwardForce * Time.deltaTime, ForceMode.Impulse);
        
        
    }
    void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.name);
        
        if(Other.CompareTag("Obstackle") )
            //rb.AddForce(Vector3.forward * forwardForce,ForceMode.Force);
            Other.GetComponent<Obstacle>().Jumper(rb);
        }
    }

// public class Obstacle : MonoBehaviour{
//     
// }
