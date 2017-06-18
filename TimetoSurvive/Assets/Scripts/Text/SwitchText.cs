using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchText : MonoBehaviour {

    public GameObject firstDialog;
    public GameObject secondDialog;
    public GameObject thirdDialog;

    TypeWritterEffect firstText;
    TypeWritterEffect secondText;
    TypeWritterEffect thirdText;

	// Use this for initialization
	void Start () {
        firstText = firstDialog.GetComponent<TypeWritterEffect>();
        secondText = secondDialog.GetComponent<TypeWritterEffect>();
        thirdText = thirdDialog.GetComponent<TypeWritterEffect>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(firstText.done)
        {
            secondDialog.SetActive(true);
        }
        if(secondText.done)
        {
            secondDialog.SetActive(false);
            thirdDialog.SetActive(true);
        }
        if(firstText.done && secondText.done && thirdText.done)
        {
            GameObject.FindGameObjectWithTag("SwitchLevel").GetComponent<SwitchLevel>().Switch();
        }
	}
}
