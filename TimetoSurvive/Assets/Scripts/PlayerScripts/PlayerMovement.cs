using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    //Movement

    public float speed;
    public float jump;
    float velocity;
    private bool facingRight = true;
    int jumpCounter = 0;

    public Rigidbody2D soup;
    Vector3 offset;
    Animator anim;
    public Animator sisAnim;

    public Vector3 sisOffset;

    private void Start()
    {
        offset = new Vector3(1.0f, 0, 0);
        sisOffset = new Vector3(-1f, 0f, 0f);
        anim = GetComponent<Animator>();
        DontDestroyOnLoad(this);
    }
    void Update () {
	    if(Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jumpCounter == 0)
            {
                jumpCounter++;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            }
            
        }
        if(Input.GetMouseButtonDown(0))
        {
            SpillSoup();
        }

        velocity = 0;
        anim.SetBool("Walking", false);
        sisAnim.SetBool("Walking", false);

        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            sisOffset = new Vector3(1f, 0f, 0f);
            velocity = -speed;
            offset = new Vector3(-1.0f, 0, 0);
            anim.SetBool("Walking", true);
            sisAnim.SetBool("Walking", true);

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            sisOffset = new Vector3(-1f, 0f, 0f);
            velocity = speed;
            offset = new Vector3(1.0f, 0, 0);
            anim.SetBool("Walking", true);
            sisAnim.SetBool("Walking", true);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
        FlipSprite(velocity);
    }

    void SpillSoup()
    {
        Rigidbody2D rocketClone = (Rigidbody2D)Instantiate(soup, transform.position + offset, transform.rotation);
    }

    void FlipSprite(float dir)
    {
        if(dir<0 && facingRight || dir>0 && !facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = !facingRight;
        }
    }
    void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.gameObject.tag == "Ground")
        {
            jumpCounter = 0;
        }
    }

}
