using UnityEngine;
using System.Collections;

public class TestButtons : MonoBehaviour {

	public GameObject exploder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if(GUI.Button(new Rect(500, 5, 50,50), "Explode")){
			GameObject go = (GameObject) GameObject.Instantiate(exploder);
			go.transform.parent = GameObject.Find("Cube").transform;
			go.transform.localPosition = Vector3.zero;
		}
	}
}
