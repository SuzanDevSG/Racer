using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float force;
    public Vector3 direction;
    private int matItertor = 0;
    // public GameObject gameManager;

    public ForceMode mode;
    public void Jumper(Rigidbody rb)
    {
        rb.AddForce(direction*force,mode);
    }
    public void ChangeMat(MeshRenderer meshRenderer, Material[] mat){
        meshRenderer.material = mat[matItertor];
        matItertor ++;
        matItertor %= mat.Length;

    }
}
