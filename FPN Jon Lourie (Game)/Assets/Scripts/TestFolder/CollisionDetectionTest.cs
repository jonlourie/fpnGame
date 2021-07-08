using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collison  Has Occured");
    }
}
