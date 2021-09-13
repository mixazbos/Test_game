using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bang : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().Play("bang_destroy");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
