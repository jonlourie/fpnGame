using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] //every interactive object needs an componant 

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected private string displayText = "Interactive Object"; //chiold classes can know about it 

    protected private AudioSource audioSource;  //you have to initailize it since your not dragging it onto on objhect your not initializing it thats why you need start 

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    public virtual string DisplayText //this property acts as a public facing point of acces for displayText an otherwise private variable  - we set the variable and get the variable - set it to its string value whatever that is now 
    {

        //virtual is essentaill for child classes
        get
        {
            return displayText;
        }

        set
        {
            displayText = value; //we dont actually need this setter 
        }

    }

    public virtual void InteractWith()
    {

        //Debug.Log("The player interacted with an object " + name + ".");
        Debug.Log($"the player interacted with {name} it was fun."); //easier way called string interperaltion// 
        if(audioSource != null)
        audioSource.Play(); //this was in toggle class before interactive objectsnow we play arte audio in addition to identiyfying the object easy way to make parent class work for the children 

    }
}
