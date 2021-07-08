using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{

    [SerializeField]
    private string objectName = "interactive Object";

    public string ObjectName => objectName; //the property just points stright to the varioable opbjectName

    //TODO: Create inventory object icons 
    //TODO: Create inventory object description text 

    private new Collider collider;
    private MeshRenderer meshRenderer;

    protected override void Start()
    {
        base.Start();
        collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        
    }

    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this); //a reference back to the inventory object itself "this"

        collider.enabled = false;
        meshRenderer.enabled = false;
        
    }
}
