using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHelper : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void InfoCloser()
    {
        anim.SetBool("isClose", true);
    }
}
