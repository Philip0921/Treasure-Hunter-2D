using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public GameObject Theplayer;
    public bool isDead = false;
    public PlayerMovement move;
    CollectCoins coins;
    public GameObject bloodEffect;
    public GameObject spawnPoint;

    public void Start()
    {
        coins = FindObjectOfType<CollectCoins>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Trap")
        {
            isDead = true;
            move.animator.SetBool("IsDead", true);
            FindObjectOfType<AudioManager>().Play("Die");
            Inventory.INSTANCE.Coins -= 1;
            Instantiate(bloodEffect, transform.position, transform.rotation.normalized);
            move.myRb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(Respawn());
        }
    }


    public IEnumerator Respawn()
    {

        yield return new WaitForSeconds(1f);

        if (isDead == true)
        {
            Theplayer.transform.position = spawnPoint.transform.position;
            move.myRb.constraints = RigidbodyConstraints2D.None;
            isDead = false;
            move.animator.SetBool("IsDead", false);
        }
    }
}

