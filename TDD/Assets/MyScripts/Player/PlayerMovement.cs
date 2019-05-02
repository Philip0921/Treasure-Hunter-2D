using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    float walkSpeed = 4.5f;
    float horizontalmove = 0f;
    float lockPos = 0;
    bool facingright;
    public bool OnLadder;
    PlayerControler dead;

    [SerializeField]
    private float climbSpeed;

    public Rigidbody2D myRb;

    public void Start()
    {
        facingright = true;
        myRb = GetComponent<Rigidbody2D>();
        OnLadder = false;
        dead = FindObjectOfType<PlayerControler>();

    }

    public void Update()
    {

        if (dead.isDead == false)
        {

            horizontalmove = Input.GetAxisRaw("Horizontal");
            float verticalmove = Input.GetAxisRaw("Vertical");
            myRb.velocity = new Vector2(horizontalmove * walkSpeed, myRb.velocity.y);

            animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

            Flip(horizontalmove);
            transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);


            if (OnLadder)
            {
                myRb.velocity = new Vector2(horizontalmove * walkSpeed, verticalmove * climbSpeed);
            }

        }

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
