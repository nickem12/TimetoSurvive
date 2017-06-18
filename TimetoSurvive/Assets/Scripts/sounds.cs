using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour {
	public AudioClip[] cliplist;
	public AudioSource myAudioSource;
	public int switchDatSong;
	// Use this for initialization
	void Start () {
		myAudioSource = GetComponent<AudioSource> ();
		myAudioSource.Play ();
	

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!myAudioSource.isPlaying) {
			switchSong (switchDatSong);
		}
	}



	public void  switchSong(int sw){
		switch (sw) {
		case 0:
			myAudioSource.clip = cliplist [0];

			break;
		case 1:
			myAudioSource.clip = cliplist [1];
			break;
		case 2:
			myAudioSource.clip = cliplist [2];
			break;
//		case 3:
//			myAudioSource.clip = cliplist [3];
//			break;
//		case 4:
//			myAudioSource.clip = cliplist [4];
//			break;
//		case 5:
//			myAudioSource.clip = cliplist [5];
//			break;
//		case 6:
//			myAudioSource.clip = cliplist [6];
//			break;
//		case 7:
//			myAudioSource.clip = cliplist [7];
//			break;
//		case 8:
//			myAudioSource.clip = cliplist [8];
//			break;
		}
		switchDatSong++;
		if (switchDatSong > 2) {
			switchDatSong = 0;
		}
		myAudioSource.Play ();
	}

}
