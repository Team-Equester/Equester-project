using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpecialPlayerControls : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;

    private InventoryManager inventory;


    private void Awake()
    {
        inventory = new InventoryManager();
        uiInventory.SetInventory(inventory);
        uiInventory.ActionButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PaperBall" && uiInventory.itemSlot.GetComponent<Image>().sprite == null)
        {
            Destroy(other.gameObject);
            inventory.AddItem(new Item { itemType = Item.ItemType.PaperBall });
            uiInventory.ActionButton.SetActive(true);
        }
        else if (other.gameObject.tag == "Cans" && uiInventory.itemSlot.GetComponent<Image>().sprite == null)
        {
            Destroy(other.gameObject);
            inventory.AddItem(new Item { itemType = Item.ItemType.Cans });
            uiInventory.ActionButton.SetActive(true);
        }
    }
}
