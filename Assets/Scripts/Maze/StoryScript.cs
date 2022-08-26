using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StoryScript : MonoBehaviour
{
    public TextMeshProUGUI msg;

    private void Awake()
    {
        StartCoroutine(MsgActive("Is this pill help me?"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "S1")
        {
            Destroy(other.gameObject);
            StopAllCoroutines();
            StartCoroutine(MsgActive("whether I take the pill or not"));
        }
        else if(other.name == "S2")
        {
            Destroy(other.gameObject);
            StopAllCoroutines();
            StartCoroutine(MsgActive("I am going to take it"));
        }
        else if(other.name == "S3")
        {
            Destroy(other.gameObject);
            StopAllCoroutines();
            StartCoroutine(MsgActive("Ah!!!Its confusing....What should I do?"));
        }
        else if(other.name == "S4")
        {
            Destroy(other.gameObject);
            StopAllCoroutines();
            StartCoroutine(MsgActive("I decided."));
        }
    }

    IEnumerator MsgActive(string message)
    {
        msg.gameObject.SetActive(true);
        msg.text = message;
        yield return new WaitForSeconds(5);
        msg.gameObject.SetActive(false);
    }
}
