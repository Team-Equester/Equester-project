using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<string> choices;
    private Dialogue dialogue;
    public TextMeshProUGUI message;
    //private int isChoiceMet=-1;
    //private int happenChoiceIndex=0;
    //private int choiceIndex=0;
    //public GameObject Choice;
    //public TMPro.TextMeshProUGUI[] ChoicesNum;

    //Question --------
    public GameObject[] choiceToChoose;


    public void getDialogue(Dialogue GetDialogue)
    {
        dialogue = GetDialogue;
    }

    private void Start()
    {
        sentences = new Queue<string>();
        choices = new Queue<string>();
    }

    public void StartDialogue()
    {
        Debug.Log("Started Dialogue");
        sentences.Clear();
        choices.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextMessage();
    }

    public void NextMessage()
    {
        if(sentences.Count == 0)
        {
            AskQuestion();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SmoothingText(sentence));
        //isChoiceMet += 1;
        //Debug.Log(isChoiceMet);
        //if (isChoiceMet == dialogue.happenChoices[happenChoiceIndex])
        //{
        //    happenChoiceIndex += 1;
        //    foreach (string ch in dialogue.choices)
        //    {
        //        choices.Enqueue(ch);
        //    }
            //choiceIndex += 3;
            //DisplayChoices();
        //}
    }

    //private void DisplayChoices()
    //{
    //    Choice.SetActive(true);
    //    ChoicesNum[0].text = choices.Dequeue();
    //    ChoicesNum[1].text = choices.Dequeue();
    //    ChoicesNum[2].text = choices.Dequeue();
    //}

    //Smoothing Text for sentences
    private IEnumerator SmoothingText(string sentence)
    {
        message.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            message.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
    }

    //Ask Question
    private void AskQuestion()
    {
        StopAllCoroutines();
        StartCoroutine(SmoothingText(dialogue.Question));
        GiveChoice(dialogue);
    }

    //Give Choices
    private void GiveChoice(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.choices)
        {
            choices.Enqueue(sentence);
        }
         
        StartCoroutine(SmoothingChoice(dialogue.Question, dialogue.choices.Length));
    }
    
    //Smoothing Text for choices

    private IEnumerator SmoothingChoice(string sentence, int i)
    {
        for(int iter = 0; iter< i; iter++)
        {
            choiceToChoose[iter].SetActive(true);
            choiceToChoose[iter].GetComponent<TextMeshProUGUI>().text = "";
            foreach (char letter in choices.Dequeue().ToCharArray())
            {
                choiceToChoose[iter].GetComponent<TextMeshProUGUI>().text += letter;
                yield return new WaitForSeconds(0.07f);
            }
        }
    }
}
