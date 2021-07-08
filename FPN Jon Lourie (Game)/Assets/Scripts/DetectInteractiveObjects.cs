using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //tm pro was originally a paid assett its not part of the core uinity library or c# library we have to add it in there sstands for texty mesh pro

public class DetectInteractiveObjects : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float detectionRange;//rayMagnitude

    [SerializeField]
    private LayerMask layersToDetect;

    [SerializeField]
    private TextMeshProUGUI displayText;

    private InteractiveObject lookedAtObject;

    private void Start()
    {
        displayText.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtObject != null) //we could put this into a method but right now lets not
        {
            lookedAtObject.InteractWith();
        }

    }


    // Update is called once per frame
    void FixedUpdate() //raycast has to be set to every single frame - but remember fixed update is for physics like raycasts 
    {
        UpdateLookedAtObjects();

        UpdateDisplayText();
    }
     
    private void UpdateDisplayText()
    {
        if (lookedAtObject != null)
            displayText.text = lookedAtObject.DisplayText;
        else
        {
            displayText.text = string.Empty;
        }
    }

    private void UpdateLookedAtObjects ()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * detectionRange, Color.green); //based of whatever direction your camera is looking, camera transform.forward is an easy way to get the direction your camera is looking in the positive direction

        RaycastHit raycastHit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out raycastHit, detectionRange, layersToDetect))
        {
            //the code within this if statement only exxecutes if our raycast hits something 

            Debug.Log("raycast hit " + raycastHit.collider.gameObject.name); //working our through references we start with collider and from collider work our way down to game object name just through . and class instances

            lookedAtObject = raycastHit.collider.gameObject.GetComponent<InteractiveObject>(); // if we hit something lookedAtObject will grab the interactive object componant - else it is set to null 


            //>im not sure why i haver this second line of code down below review it when you goi over it tommorrow 

            //if (Input.GetButtonDown("Interact") && lookedAtObject != null)
            //{
                //lookedAtObject.InteractWith();
            //}

        }
        else
        {
            lookedAtObject = null;
        }
    }

}
