using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.FindGameObjectWithTag("Player").gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
