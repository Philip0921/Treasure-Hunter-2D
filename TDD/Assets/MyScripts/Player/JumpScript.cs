using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public Rigidbody2D rb;

    bool grounded = true;
    public bool jumping = false;
    float jumpspeed = 1.5f;
    int jumpPressed;
    float verticalVelocity;
    float increesvelocity;
    float decreesvelocity;
    float gravity;
    float aircontrol;
    float range = 1f;
    public LayerMask ground;
    public PlayerMovement move;

    int jumpCount;


    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 2;
        rb.gravityScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        jump();
        CheckGround();
    }


    void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount == 0)
            {
                return;
            }

            jumpCount--;

            verticalVelocity = 5;
            rb.velocity = new Vector2(rb.velocity.x, verticalVelocity) * jumpspeed;
            jumping = true;
            move.animator.SetBool("IsJumping", true);
            //FindObjectOfType<AudioManager>().Play("Jump");
            grounded = false;
        }

    }

    void CheckGround()
    {
        verticalVelocity = -Time.deltaTime;

        if (Physics2D.Raycast(rb.transform.position, Vector2.down, range, ground) && rb.velocity.y < 0 && !grounded)
        {
            FindObjectOfType<AudioManager>().Play("Landed");
            grounded = true;
            jumpCount = 2;
            jumping = false;
            move.animator.SetBool("IsJumping", false);

        }
        //if raycast towarrds ground check if ground
        //if true set grounded to true and jump to false
        //rb velocity starx över noll negative time.deltatime
    }

}
