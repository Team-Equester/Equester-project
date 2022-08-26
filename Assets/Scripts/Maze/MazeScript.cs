using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeScript : MonoBehaviour
{
    public TextMeshProUGUI keyScore;
    private int key;
    // Start is called before the first frame update
    void Start()
    {
        keyScore.text = "Keys : " + key;
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        keyScore.text = "Keys : " + key;
    }

    private void OnCollisionEnter(Collision collision)
    {
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
        else if (key >= 3 && collision.gameObject.tag == "Door")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(closeDoor(collision.gameObject));
            key-=3;
            keyScore.text = "Keys : " + key;
        }
    }

    IEnumerator closeDoor(Object obj)
    {
        yield return new WaitForSeconds(2);
        Destroy(obj);
    }
}
