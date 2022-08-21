using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerChecker : MonoBehaviour
{
    string answer = "";

    private Transform blockContainer;

    public Transform letterContainer;
    public TextMeshProUGUI message;
    public string finalAnswer;

    int childCount;
    int startCount;
    int[] arr;
    private void Awake()
    {
        blockContainer = GetComponent<Transform>();
        childCount = transform.childCount;
        startCount = 0;
        arr = new int[childCount];
    }

    public void printAnswer(string text,int index)
    {
        answer += text;
        blockContainer.GetChild(startCount).Find("Letter").gameObject.SetActive(true);
        blockContainer.GetChild(startCount).Find("Letter").GetComponent<TextMeshProUGUI>().text = text;
        arr[startCount] = index - 1;
        startCount++;
        if(startCount == 9)
        {
            if (answer == finalAnswer)
                Debug.Log("You Win");
            else Debug.Log("Try Again");
        }
        
    }
    public void printRemovedAnswer()
    {
        if(startCount == 0)
        {
            StopAllCoroutines();
            StartCoroutine(MessageSender("Everything Erased Already"));
            return;
        }
        startCount--;
        answer = answer.Substring(0,startCount);
        blockContainer.GetChild(startCount).Find("Letter").gameObject.SetActive(false);
        letterContainer.GetChild(arr[startCount]).gameObject.SetActive(true);
    }

    public IEnumerator MessageSender(string msg)
    {
        message.text = msg;
        message.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        message.gameObject.SetActive(false);
    }
}
