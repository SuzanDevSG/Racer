using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Animator anim;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            anim.SetBool("move",true);
        }
        else{
            anim.SetBool("move",false);
        }
    }
}
