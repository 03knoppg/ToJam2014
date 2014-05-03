using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GameObject path1;

	bool playing;

	// Use this for initialization
	void Start () {
		path1.GetComponent<CameraPathAnimator>().Pause ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if(!playing){
			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "START")){
				path1.GetComponent<CameraPathAnimator>().Play();
				playing = true;
			}
			if(GUI.Button(new Rect(0,0,50,50), "Quit"))
				Application.Quit();
		}

	}
}
