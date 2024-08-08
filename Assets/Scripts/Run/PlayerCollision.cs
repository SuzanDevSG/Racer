using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public HUDManager hudManager;

    private Rigidbody rb;
    private int roundNumber = 0;
    void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstackle"))
        {
            //Time.timeScale = 0;
            hudManager.InGameTriggeredPanel[0].SetActive(true);
            playerMovement.enabled = false;
        }
        if (collisionInfo.collider.CompareTag("Booster"))
            collisionInfo.collider.GetComponent<Obstacle>().Jumper(rb);
        if (collisionInfo.collider.CompareTag("Triggers"))
        {
            collisionInfo.collider.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider Other){
        if(Other.CompareTag("CheckPoint")){
            ++roundNumber;
            Debug.Log("Round" + roundNumber +"Completed");
            if(roundNumber >= 2){
                //hudManager.HUD[1].SetActive(true);
                hudManager.InGameTriggeredPanel[1].SetActive(true);
            //playerMovement.enabled = false;
            //hudManager.LoadNextLevelScene();
            }
        }
        if(Other.CompareTag("Ground"))
        {
            hudManager.InGameTriggeredPanel[0].SetActive(true);

            Time.timeScale = 0;
            playerMovement.enabled = false;
        }
    }
}
