using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Material activeMaterial = null;
    void Awake()
    {
    if( instance == null)
        instance = this;

    else if ( instance != null && instance != this)
        Destroy(this);
    }








}
