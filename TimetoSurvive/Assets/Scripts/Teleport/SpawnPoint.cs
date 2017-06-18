using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.transform.position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
