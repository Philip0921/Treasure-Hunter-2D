using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieAfterTime : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(removeSelf());
    }

    IEnumerator removeSelf()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
