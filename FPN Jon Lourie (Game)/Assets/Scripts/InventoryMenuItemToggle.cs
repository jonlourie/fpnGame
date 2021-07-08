using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{

    [SerializeField]
    private Image iconImage; // we set this in unity 


    private InventoryObject associatedInventoryObject;
    private ToggleGroup toggleGroup;
    private Toggle toggle;
    private InventoryMenu inventoryMenu;

    private AudioSource audioSource;

    private void Start()
    {


        audioSource = GetComponent<AudioSource>();

        inventoryMenu = FindObjectOfType<InventoryMenu>();

        toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle = GetComponent<Toggle>();

        toggle.group = toggleGroup;
        
    }

    public InventoryObject AssociatedInventoryObject // we used the setter to first recognize the inventory object and then set the sprite image
    {
        get
        {
            return associatedInventoryObject;
        }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;

        }


    }


    public void OnValueChange (bool isOn)
    {
        if(isOn)
        {
            inventoryMenu.SelectedToggle = this;
            audioSource.Play();
        }
    }

    

    //in this script we are going to associate the toggle with the inventoryobject



}

