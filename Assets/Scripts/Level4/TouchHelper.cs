using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchHelper : MonoBehaviour
{
    private TextMeshProUGUI text;

    public AnswerChecker ans;
    private void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void PressEvent()
    {
        gameObject.SetActive(false);
        ans.printAnswer(text.text,(int)gameObject.name[gameObject.name.Length - 1]-48);
    }
}
