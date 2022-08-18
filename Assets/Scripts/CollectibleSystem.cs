using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollectibleSystem : MonoBehaviour
{
    public int score = 50;
    public TextMeshProUGUI Score;
    public GameObject Food;
    public GameObject Junk;
    private int totalFood;
    private int totalJunk;
    public GameObject GameOverScreen;

    private void Awake()
    {
        totalFood = Food.transform.childCount;
        totalJunk = Junk.transform.childCount;
        Debug.Log(totalFood + " " + totalJunk);
    }

    void Update()
    {
        Score.text = "Score : " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score += 5;
            totalFood--;
        }
        else if (collision.gameObject.tag == "JunkFood")
        {
            Destroy(collision.gameObject);
            score -= 5;
            totalJunk--;
        }
        if (score == 0 || (totalFood == 0 && totalJunk == 0) || totalFood == 0)
        {
            GameOverScreen.SetActive(true);
        }  
    }
}
