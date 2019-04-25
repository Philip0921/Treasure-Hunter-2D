using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    float walkSpeed = 4.5f;
    float horizontalmove = 0f;
    float lockPos;
    bool facingright;

    public Rigidbody2D myRb;

    public void Start()
    {
        facingright = true;
        myRb = GetComponent<Rigidbody2D>();
        
    }

    public void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        myRb.velocity = new Vector2(horizontalmove, myRb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        Flip(horizontalmove);
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
    }


    void Flip(float horizontalmove)
    {
        if (horizontalmove > 0 && !facingright || horizontalmove < 0 && facingright)
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
