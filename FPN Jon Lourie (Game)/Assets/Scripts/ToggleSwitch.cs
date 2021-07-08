using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : InteractiveObject //interactive object inherits from monobehvior 
{
    [SerializeField]
    private GameObject objectToToggle;



    public override void InteractWith() // we overide and have a special interact metrhod for this class 
    {
        base.InteractWith(); //basically how we call this method with this public overide class we have to mark it as a base class 
        
        objectToToggle.SetActive(!objectToToggle.activeSelf); //whatever the value ofg isopen is is changed 


    }


}
