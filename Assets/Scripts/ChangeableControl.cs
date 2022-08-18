using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeableControl : MonoBehaviour
{

    public GameObject[] Objects;
    private PlayerControl pc;
    private enum TraverseObjects { First , Second , Third };
    private int index = 0;
    private TraverseObjects TObj = TraverseObjects.First;
    public int length;
    public GameObject OnGameOver;
    private void Awake()
    {
        length = Objects.Length;
        pc = new PlayerControl();
        pc.Special.Enable();
        pc.Special.Change.performed += Change_performed;
    }

    private void Change_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //Debug.Log(obj);
        if (obj.performed)
        {
            Objects[index].GetComponent<Movement>().enabled = false;
            index = TraversalHappens(TObj);
            //Debug.Log(index);
            Objects[index].GetComponent<Movement>().enabled = true;
        }
        //throw new System.NotImplementedException();
    }

    private int TraversalHappens(TraverseObjects obj)
    {
        if (obj == TraverseObjects.First)
        {
            TObj = TraverseObjects.Second;
            return 1;
        }
        if (obj == TraverseObjects.Second)
        {
            TObj = TraverseObjects.Third;
            return 2;
        }
        TObj = TraverseObjects.First;
        return 0;
    }

    public void GameOver()
    {
        length -= 1;
        if (length == 0)
        {
            OnGameOver.SetActive(true);
        }
    }

    public void NextGame()
    {
        Debug.Log("NextGame");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
    }
}
