using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory INSTANCE;
    CollectCoins coins;
    Skull skull;
    public int skulls;
    public int Coins;


    public void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        coins = FindObjectOfType<CollectCoins>();
        skull = FindObjectOfType<Skull>();
    }
}
