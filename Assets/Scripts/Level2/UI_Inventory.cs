using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private InventoryManager inventory;
    private Transform ItemContainer;
    private Transform ItemPresent;

    public RectTransform itemSlot;

    public GameObject ActionButton;
    private void Awake()
    {
        ItemContainer = transform.Find("UI_ItemContainer");
        ItemPresent = ItemContainer.Find("UI_Item");
    }
    private void Start()
    {
        ItemPresent.gameObject.SetActive(false);
    }
    public void SetInventory(InventoryManager inventory)
    {
        this.inventory = inventory;
        inventory.onListChanged += Inventory_onListChanged;
        RefreshItem();
    }

    private void Inventory_onListChanged(object sender, System.EventArgs e)
    {
        RefreshItem();
    }

    private void RefreshItem()
    {
        string name = ItemPresent.name;
        Item item = inventory.GetItem();
        itemSlot = Instantiate(ItemPresent, ItemContainer).GetComponent<RectTransform>();
        Destroy(ItemPresent.gameObject);
        itemSlot.name = name;
        Image image = itemSlot.GetComponent<Image>();
        image.sprite = item.getSprite();
        itemSlot.gameObject.SetActive(true);
        itemSlot.anchoredPosition = Vector2.zero;
        ItemPresent = itemSlot;
    }

    public void UseItem()
    {
        ItemPresent.gameObject.SetActive(false);
        ItemPresent.GetComponent<Image>().sprite = null;
        ActionButton.SetActive(false);
    }
}
