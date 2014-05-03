using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.sharedMaterial.mainTextureOffset -= new Vector2(0,0.005f);
	}
}
