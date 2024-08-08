using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TesterEditor : MonoBehaviour
{
    public Tester edit;
    public TesterProfile newtp;
    public void Start()
    {
        // edit.tp.name ="";
        edit.tp = newtp;
        // newtp = edit.tp;
     
    }
}
