using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferScene : MonoBehaviour {

    public GameObject text;
    TypeWritterEffect checkText;
	// Use this for initialization
	void Start () {
        checkText = text.GetComponent<TypeWritterEffect>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(checkText.done)
        {
            GameObject.FindGameObjectWithTag("SwitchLevel").GetComponent<SwitchLevel>().Switch();
        }
	}
}
