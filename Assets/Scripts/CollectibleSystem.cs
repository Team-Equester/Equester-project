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
    public TextMeshProUGUI keyScore;
    private int key = 0;

    private void Awake()
    {
        totalFood = Food.transform.childCount;
        totalJunk = Junk.transform.childCount;
        Debug.Log(totalFood + " " + totalJunk);
        keyScore.text = "Keys : " + key;
        key = 0;
    }

    void Update()
    {
        Score.text = "Score : " + score;
        keyScore.text = "Keys : " + key;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Food")
        //{
        //    Destroy(collision.gameObject);
        //    score += 5;
        //    totalFood--;
        //    FindObjectOfType<SoundManager>().Play("Eat");
        //}
        //else if (collision.gameObject.tag == "JunkFood")
        //{
        //    Destroy(collision.gameObject);
        //    score -= 5;
        //    totalJunk--;
        //    FindObjectOfType<SoundManager>().Play("Eat");
        //}
        if (key > 0 && collision.gameObject.tag == "Barrier")
        {
            Destroy(collision.gameObject);
            key--;
        }
        else if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            key++;
            keyScore.text = "Keys : " + key;
        }
        if (score == 0 || (totalFood == 0 && totalJunk == 0) || totalFood == 0)
        {
            GameOverScreen.SetActive(true);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JunkFood")
        {
            Destroy(other.gameObject);
            score -= 5;
            totalJunk--;
            FindObjectOfType<SoundManager>().Play("Eat");
        }
        else if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score += 5;
            totalFood--;
            FindObjectOfType<SoundManager>().Play("Eat");
        }
    }
}
