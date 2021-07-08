using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProBuildTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Entered The Trigger");
        }
        

    }
}

