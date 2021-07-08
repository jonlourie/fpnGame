using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    // we will only use public variables when we want other classes to communicate this is to practice encapsaulation as opposed to coupling

    [SerializeField]
    private GameObject objectToActivate;

    [SerializeField]
    private bool isReUsable = true;

    [SerializeField]
    private bool shouldDeactivateObjectStart = true;

    private bool hasBeenUsed = false;

    private void Start()
    {
        if(objectToActivate != null && shouldDeactivateObjectStart) //compound
        objectToActivate.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        //nested if statement 
        if (other.tag == "Player" && objectToActivate != null)
        {
            //|| conditional "or" operator now the and operator is potrayed as && 
            if (!hasBeenUsed || isReUsable) // equivalent of saying if == hasBeenUsed
            {
                objectToActivate.SetActive(!objectToActivate.activeSelf);
                hasBeenUsed = true;
               
            }

        }
    }
}


//STRT CODING WITH ERRORS IN MIND AND ENCAPSULATION OPTIMIZIG IT FOR NO BUGS 