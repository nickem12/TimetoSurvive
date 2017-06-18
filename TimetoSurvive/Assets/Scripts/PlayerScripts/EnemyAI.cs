using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    float speed;
    bool atBottom;
    public int health;
    float BossFire = 0;
    public GameObject bullet_Gray_Prefab;
    public GameObject bulletSpwan;
    public float fireRate;
    float nextFire;
    float min;
    public float enemyJump;
    Vector3 position;
    float maxDis;
    float minDis;
    Animator anim;

    public float diference;
    public bool shoot;

    bool facingRight;
    Vector3 offset;

    public int damage;
    // Use this for initialization
    void Start()
    {
        speed = 1.5f;
        //min = 0;
        atBottom = false;
        position = transform.position;
        maxDis = transform.position.x + diference;
        minDis = transform.position.x - diference;
        facingRight = false;
        offset = new Vector3(1f, 0, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BossFire += speed * Time.deltaTime;
        if (BossFire > 3)
        {
            if(shoot)
            {
                ShootABullet();
                BossFire = 0;
            }
        }


        if (!atBottom)
        {
            
            offset = new Vector3(-1f, 0, 0);
            position.x -= speed * Time.deltaTime;
            transform.position = new Vector3(position.x, transform.position.y, 0f);//position;
            if (position.x <= minDis)
            {
                facingRight = false;
                FlipSprite(1f);
                atBottom = true;
            }
        }

        if (atBottom)
        {
            
            offset = new Vector3(1f, 0, 0);
            position.x += speed * Time.deltaTime;
            transform.position = new Vector3(position.x, transform.position.y, 0f);//position;
            if (position.x > maxDis)
            {
                facingRight = true;
                FlipSprite(-1f);
                atBottom = false;
            }

        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.tag == "colliderTag")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, enemyJump));
            //Debug.Log("jump");
            //Destroy(gameObject); 
        }
        if(Col.tag == "Player")
        {
            Col.GetComponent<PlayerScript>().SubHealth(damage);
        }
        //Detect collision between object A and object B

    }

    public void ShootABullet()
    {
        GameObject newbullet = (GameObject)Instantiate(bullet_Gray_Prefab, bulletSpwan.transform.position + offset, bulletSpwan.transform.rotation);
        newbullet.transform.parent = this.transform;
        //
        //		nextFire = fireRate;
        //		Vector3 Offset = new Vector3(-0.5f,0,0);
        //		GameObject newbullet = (GameObject)Instantiate (bullet_Gray_Prefab, bulletSpwan.transform.position, bulletSpwan.transform.rotation);
        //		Debug.Log (bulletSpwan.transform.position);
    }

    void FlipSprite(float dir)
    {
        //Debug.Log("Flip Now");
        if (dir < 0 && facingRight || dir > 0 && !facingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = !facingRight;
            //Debug.Log(transform.localScale);
        }
    }
    public void SubHealth(int amount)
    {
        health -= amount;
    }
}
