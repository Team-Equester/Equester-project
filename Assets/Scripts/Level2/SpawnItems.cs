using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject cans;
    public Transform[] waste;
    public Animator anim;
    public GameObject ActionButton;
    private SpecialPlayerControls playerInventory;
    private UI_Inventory uiInventory;

    private void Awake()
    {
        playerInventory = FindObjectOfType<SpecialPlayerControls>();
        uiInventory = FindObjectOfType<UI_Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawner")
        {
            foreach (Transform child in waste)
            {
                Instantiate(cans, child);
            }
        }
        if(other.tag == "Dustbin" && playerInventory.recallObject() != null)
        {
            Transform Dustbin = other.transform.Find("DustbinCan");
            Dustbin.Find("Plane.006").gameObject.SetActive(true);
            anim = Dustbin.GetComponent<Animator>();
            anim.SetBool("isThrow", true);
            uiInventory.UseItem();
        }
    }
}
