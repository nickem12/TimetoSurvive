using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour {

    int index;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        index = 1;
	}

    public void Switch()
    {
        SceneManager.LoadScene(index);
        index++;
        Debug.Log(index);
    }
}
