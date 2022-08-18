using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public Button conversation;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueSystem>().getDialogue(dialogue);
        FindObjectOfType<DialogueSystem>().StartDialogue();
    }

    public void TriggerDialogueContinue(Dialogue conversation)
    {
        GameObject[] choice = FindObjectOfType<DialogueSystem>().choiceToChoose;
        for (int i = 0; i < choice.Length; i++)
        {
            choice[i].SetActive(false);
        }
        FindObjectOfType<DialogueSystem>().getDialogue(conversation);
        FindObjectOfType<DialogueSystem>().StartDialogue();
    }

    public void TriggerDialogueExit()
    {
        GameObject[] choice = FindObjectOfType<DialogueSystem>().choiceToChoose;
        for (int i = 0; i < choice.Length; i++)
        {
            choice[i].SetActive(false);
        }
        FindObjectOfType<DialogueSystem>().getDialogue(dialogue);
        FindObjectOfType<DialogueSystem>().StartDialogue();
    }
}
