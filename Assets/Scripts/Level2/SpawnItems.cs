using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject cans;
    public Transform[] waste;
    private Animator anim;
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
            Destroy(other.gameObject);
        }
        if (other.tag == "Dustbin" && playerInventory.recallObject() != null)
        {
            Transform Dustbin = other.transform.Find("DustbinCan");
            Dustbin.Find("Plane.006").gameObject.SetActive(true);
            anim = Dustbin.GetComponent<Animator>();
            anim.SetBool("isThrow", true);
            uiInventory.UseItem();
            StopAllCoroutines();
            StartCoroutine(EndAnim(Dustbin,"Plane.006"));
        }
        if (other.tag == "DustBinP" && playerInventory.recallObject() != null)
        {
            Transform Dustbin = other.transform.Find("TrashPaperBall");
            Dustbin.Find("Sphere").gameObject.SetActive(true);
            anim = Dustbin.GetComponent<Animator>();
            anim.SetBool("isThrow", true);
            uiInventory.UseItem();
            StopAllCoroutines();
            StartCoroutine(EndAnim(Dustbin,"Sphere"));
        }
    }

    IEnumerator EndAnim( Transform Dustbin , string obj)
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("isThrow", false);
        Dustbin.Find(obj).gameObject.SetActive(false);
    }
}
