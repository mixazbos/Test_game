using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animation;
    SpriteRenderer sprite;
    Collider2D player_coll;

    [SerializeField]
    int speed, horz;
    [SerializeField]
    int force, bang_force;
    [SerializeField] 
    private LayerMask ground;
    
    public GameObject bang;
    public Transform point;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player_coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        var Move = Input.GetAxis("Horizontal") * speed; // кроссплатформенное управление
        rb.velocity = new Vector2(Move, rb.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
            horz = 1;
            transform.GetChild(0).localPosition = new Vector2(0.234f, -0.039f);
            animation.Play("run");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
            horz = -1;
            transform.GetChild(0).localPosition = new Vector2(-0.234f, -0.039f);
            animation.Play("run");
        }
        else if (player_coll.IsTouchingLayers(ground))
        { 
            animation.Play("idle");
        }

        if (Input.GetButtonDown("Jump") && player_coll.IsTouchingLayers(ground))
        {
            rb.AddForce(new Vector2(0, force * 10));
            animation.Play("jump");
        } 
        
        if (Input.GetButtonDown("Fire1"))
        {
            animation.Play("attack");
            GameObject gm = Instantiate(bang,
                new Vector2(transform.GetChild(0).position.x,
                transform.GetChild(0).position.y), Quaternion.identity);
            gm.GetComponent<Rigidbody2D>().velocity = new Vector2(bang_force * horz, 0);
            
        }
    }
}
