using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    PlayerMovement movable;
    // Start is called before the first frame update
    void Start()
    {
        movable = FindObjectOfType<PlayerMovement>();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    } 

    public void GameOver()
    {
        Inventory.INSTANCE.Coins = 0;
        Inventory.INSTANCE.skulls = 0;
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
