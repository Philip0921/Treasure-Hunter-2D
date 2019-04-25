using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public Rigidbody2D rb;

    bool grounded = true;
    public bool jumping = false;
    float jumpspeed = 1.5f;
    float verticalVelocity;
    float increesvelocity;
    float decreesvelocity;
    float gravity;
    float aircontrol;
    float range = 1f;
    public LayerMask ground;
    public PlayerMovement move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = 1.5f;
        jump();
        CheckGround();

    }


    void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && jumping == false)
        {
            verticalVelocity = 5;
            rb.velocity = new Vector2(rb.velocity.x, verticalVelocity) * jumpspeed;
            jumping = true;

            move.animator.SetBool("IsJumping", true);
            grounded = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            //det här kommer vara samma som de andra scriptet, tryck två gånger för att hoppa högre.
            move.animator.SetBool("IsJumping", true);
            verticalVelocity = 6.5f;
            
        }

    }

    void CheckGround()
    {
        verticalVelocity = -Time.deltaTime;

        if (Physics2D.Raycast(rb.transform.position, Vector2.down, range, ground))
        {
            grounded = true;
            jumping = false;
            move.animator.SetBool("IsJumping", false);
        }
        //if raycast towarrds ground check if ground
        //if true set grounded to true and jump to false
        //rb velocity starx över noll negative time.deltatime
    }
}
