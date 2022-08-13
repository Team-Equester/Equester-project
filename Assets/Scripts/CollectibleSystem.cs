using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollectibleSystem : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI Score;


    void Update()
    {
        Score.text = "Score : " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;
        }   
    }
}
