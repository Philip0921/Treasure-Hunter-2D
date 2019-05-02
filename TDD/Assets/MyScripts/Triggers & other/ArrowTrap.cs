using System.Collections;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform ArrowSpawn;
    public Rigidbody2D arrowRB;
    bool inside = false;
    float force = -2f;
    //public float shootRange = 5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = true;
            StartCoroutine(SpawnArrow());
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inside = false;
            StopCoroutine(SpawnArrow());
        }
    }

    IEnumerator SpawnArrow()
    {
        while (inside == true)
        {
            yield return new WaitForSeconds(2);
            GameObject arrow = Instantiate(ArrowPrefab, ArrowSpawn.position, ArrowPrefab.transform.localRotation);

            arrowRB = arrow.GetComponent<Rigidbody2D>();
            arrowRB.velocity = new Vector2(force, 0);

            yield return new WaitForSeconds(4);

        }
    }

}
