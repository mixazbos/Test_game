using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bang")
        {
            StartCoroutine(death());
            animator.Play("enemy_hit");
        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
