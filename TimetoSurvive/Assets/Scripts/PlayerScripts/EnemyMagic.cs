﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagic : MonoBehaviour {

    float soupSpeed = 10;
    float dir;
    private GameObject player;

    private int counter = 20;
    public short damage;

    void Start()
    {
       
        dir = transform.parent.transform.localScale.x;
        Debug.Log(dir);
        damage = 10;
    }
    // Update is called once per frame
    void Update()
    {

        counter--;
        if (counter <= 0)
        {
            Destroy(gameObject);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(-dir * soupSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerScript>().SubHealth(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
