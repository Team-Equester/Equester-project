using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlace : MonoBehaviour
{
    public string ObjectNameToCollide;
    public GameObject ObjGroup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clickable" && other.gameObject.name == ObjectNameToCollide)
        {
            other.gameObject.SetActive(false);
            ObjGroup.GetComponent<ChangeableControl>().GameOver();
        }
    }

}
