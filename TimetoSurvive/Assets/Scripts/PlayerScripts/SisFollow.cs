using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisFollow : MonoBehaviour {

    GameObject player;
	// Use this for initialization
	void Start () {
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + player.GetComponent<PlayerMovement>().sisOffset;
	}
}
