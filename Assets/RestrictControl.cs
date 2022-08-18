using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictControl : MonoBehaviour
{
    public Transform Player;
    //public Transform MidPoint;
    private float playerRadius;
    private float midPointRadius;

    private void Awake()
    {
        playerRadius = Player.localScale.x * Mathf.PI;
        midPointRadius = 2 * 5f * Mathf.PI;
        Debug.Log(playerRadius + " " + midPointRadius);
    }

    private void Update()
    {
        if(playerRadius > midPointRadius)
        {
            //Player Restrict to previous Movement
        }
    }
}
