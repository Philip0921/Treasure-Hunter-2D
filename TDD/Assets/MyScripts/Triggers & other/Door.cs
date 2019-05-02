using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Text Open;
    bool openDoor = false;

    public void Start()
    {
        Open.text = "Press Enter To Open";
        Open.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Open") && openDoor == true && Inventory.INSTANCE.Coins >= 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Inventory.INSTANCE.Coins < 10)
        {
            Open.text = "Not enough Coins!";
        }
        else
        {
            Open.text = "Press Enter To Open";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            openDoor = true;
            Open.GetComponent<Text>().enabled = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            openDoor = false;
            Open.GetComponent<Text>().enabled = false;
        }
    }
}
