using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay; // this is a namspace where player controller is stored in
using TMPro; //using statement for UGUI

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab; //short hand way to use serialized field to create new instances of the spawned prefabs 

    [SerializeField]
    private Transform inventoryListScrollViewContent;

    [SerializeField]
    private TextMeshProUGUI descriptionArea, heading;

    [SerializeField]
    private string defaultDescriptionTest = "Select An Object To View More Information"
        + " About It";

    [SerializeField]
    private string defaultHeading = "INVENTORY MENU";



    //in this script we spawn new toggle prefabs 

    private AudioSource audioSource;
    private CanvasGroup canvasGroup;
    private DetectInteractiveObjects detectInteractiveObjects;
    private PlayerController playerController;
    private List<GameObject> menuItemToggle = new List<GameObject>(); //we need to make a list of inventory items to display 
    private InventoryMenuItemToggle selectedToggle;

    public InventoryMenuItemToggle SelectedToggle
    {
        get
        {
            return selectedToggle;
        }
        set
        {
            selectedToggle = value;
            UpdateDescriptionTest();
            UpdateHeadingText();
        }
    }



    private void Start ()
    {

        audioSource = GetComponent<AudioSource>();

        playerController = FindObjectOfType<PlayerController>();
        detectInteractiveObjects = FindObjectOfType<DetectInteractiveObjects>();  //only one object of this type in the scene which is why this works so we could not use it with inventory object for example - it works with the player because theres only onew essential player
        canvasGroup = GetComponent<CanvasGroup>();

        SelectedToggle = null;

        //GameObject.Find is another way to find a game object in a scene if your willing to type in a string name of the object there is also GameObject.FindTag which deos the same thing but throguh a tag 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory Menu"))
        {

            bool isMenuVisable = canvasGroup.alpha > 0; // you should always try and create videos for each condition when you can create a variable do it if only to make it much more readable 

            if(isMenuVisable)
            {
                HideMenu();
              
            }
            else
            {
                ShowMenu();
                
            }
            audioSource.Play();
        }      
       
    }

    private void ShowMenu ()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        //below is another way to do the same thing just not use enabled

        //  detectInteractiveObjects.gameObject.SetActive(false);
        //  playerController.gameObject.SetActive(false);

        detectInteractiveObjects.enabled = false;
        playerController.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;//this is called an enum which is basically a specific data type with lots of choices for differeing states - basically its an abbrevaite dtypoe of project editor 

        GenerateMenuItemToggles();
    }


    private void HideMenu ()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //  detectInteractiveObjects.gameObject.SetActive(true);
        //   playerController.gameObject.SetActive(true);

        playerController.enabled = true;
        detectInteractiveObjects.enabled = true;
        ClearMenuItemToggles();

    }

    private void GenerateMenuItemToggles()
    {

        foreach (InventoryObject inventoryObject in PlayerInventory.InventoryObjects)
        {
            GameObject clone =
            Instantiate(inventoryMenuItemTogglePrefab, inventoryListScrollViewContent);

            InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();

            toggle.AssociatedInventoryObject = inventoryObject;

            menuItemToggle.Add(clone);

        }

        
        
        //method that instantiates a new prefab - creates a new instance of the prefab //this also tells where to instatiate the prefab
    }

    private void ClearMenuItemToggles()
    {
        foreach (GameObject toggle in menuItemToggle)
        {
            Destroy(toggle);
        }
        menuItemToggle.Clear();
    }

    private void UpdateDescriptionTest()
    {
        if (selectedToggle != null)
            descriptionArea.text = selectedToggle.AssociatedInventoryObject.DescriptionText;
        else
            descriptionArea.text = defaultDescriptionTest;
    }
 



    private void UpdateHeadingText()
    {

        if (selectedToggle != null)
            heading.text = selectedToggle.AssociatedInventoryObject.ObjectName.ToUpper();
        else
            heading.text = defaultHeading.ToUpper();

        
    }
}
