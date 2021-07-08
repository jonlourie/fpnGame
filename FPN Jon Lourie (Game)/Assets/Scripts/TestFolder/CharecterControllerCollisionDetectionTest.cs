using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterControllerCollisionDetectionTest : MonoBehaviour
{
  
    private void OnControllerColliderHit(ControllerColliderHit hit) //oncontroller collider is specifically for charecter like things on collison entry is used for basic objecvts non chjarecter conmtroller 
    {
        if (hit.gameObject.name == "PushCube")
        {
            Debug.Log("Player Collison Made");
        }
        
        //how to make not eqaul too

        //if(hit.gameObject.tag != "Floor")
        //{
        //    Debug.Log("We hhit anything but the floor here");
        //}

    }
}


