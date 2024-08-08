using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    [Range(0,1)]
    public float value = 0f;
    public float force = 0f;
    public Rigidbody rb;
    void Awake()
    {
        source.clip = clip;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("Played");
            source.PlayOneShot(source.clip);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            source.loop = !source.loop;    
       }
        if(Input.GetKeyDown(KeyCode.D)){
            rb.MovePosition(Vector3.forward*force);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Triggers")
        {
            source.pitch = value;
            source.Play();
        }

    }

}
