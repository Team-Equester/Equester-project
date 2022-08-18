using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HelperScript : MonoBehaviour
{
    public GameObject Message;
    private void OnTriggerEnter(Collider other)
    {
        Message.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Message.SetActive(false);
    }
}
