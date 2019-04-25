using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public PlayerControler Player;
    public GameObject spawnPoint;


    public void RespawnPoint()
    {
        Player.Theplayer.transform.position = spawnPoint.transform.position;
    }
}
