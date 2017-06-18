using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWritterEffect : MonoBehaviour {

    public float delay = 0.1f;
    public string fullText;
    private string currentString = "";
    public bool done;
    bool finishedText;
    float timer = 2f;
	// Use this for initializationS
	void Start () {
        done = false;
        finishedText = false;
        StartCoroutine(ShowText());
	}
	
    IEnumerator ShowText()
    {
        for(int i = 0; i<fullText.Length;i++)
        {
            currentString = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentString;
            yield return new WaitForSeconds(delay);
        }
        finishedText = true;
    }
	// Update is called once per frame
	void Update () {
		
        if(finishedText)
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                done = true;
                transform.gameObject.SetActive(false);
            } 
        }
	}
}
