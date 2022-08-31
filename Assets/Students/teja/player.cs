using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    private GameObject triggeringnpc;
    private bool triggring;
   

    

    // Update is called once per frame
    void Update()


    {

        

        if (triggring)
        {
            print("player is triggered with " + triggeringnpc);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggring = true;
            triggeringnpc = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggring = false;
            triggeringnpc = null;
        }
    }

     

}


