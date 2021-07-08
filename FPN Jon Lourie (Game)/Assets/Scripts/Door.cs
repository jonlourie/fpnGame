using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBaseAttribute]

public class Door : InteractiveObject
{

    [SerializeField]
    private InventoryObject key;

    //[SerializeField]
    private bool isLocked = false;

    private Animator animator;
    private bool isOpen = false;
    //we can overide properites 

    [SerializeField]
    private string lockedText;

    [SerializeField]
    private AudioClip openClip, lockedClip, closedClip;

    public override string DisplayText
    {
        get
        {
            if(isLocked)
            {


                if(!HasKey)
                return $"{lockedText} {displayText}"; // return will exit out of the getter property as soon as it return

                else
                {
                    return $"use the {key.ObjectName}";
                }

            }
            if(isOpen)
            {
                return $"Close {displayText}";
            }
            else
            {
                return $"Open {displayText}";
            }
            
        }

    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key); //has key property is a fancy bool variable that checks if the playerinventory has has key 

    protected override void Start()
    {


        base.Start();
        animator = GetComponent<Animator>();

        InitializeIsLocked();


    }


    private void InitializeIsLocked() //if there is a key attached to this door object we will start the door off as being locked 
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
       

        if (isLocked && !HasKey)
        {
            animator.SetTrigger("playShake");
            audioSource.clip = lockedClip;
        }
        else
        {
            if (isLocked && HasKey)
            isLocked = false;

        

            isOpen = !isOpen;  // whenever is interact with this it eqauls the opposite of its last state similiar to the text trigger this is short hand way of not writing out a long if else statement opposite day
            animator.SetBool("isOpen", isOpen);

            if(isOpen)
            {
                audioSource.clip = openClip;
            }
            else
            {
                audioSource.clip = closedClip;
            }
        }


         base.InteractWith();

    }
}
