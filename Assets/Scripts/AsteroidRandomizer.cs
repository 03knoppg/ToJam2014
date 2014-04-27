using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AsteroidRandomizer : MonoBehaviour {

	public Mesh[] meshes;
	public Material[] mats;


	void Awake(){
		if(gameObject.GetComponent<MeshFilter>().sharedMesh == null){
			int rand = (int)Random.Range(0,3);

			gameObject.GetComponent<MeshFilter>().sharedMesh = meshes[rand];
			gameObject.renderer.material = mats[rand];

			Vector3 rot = new Vector3(Random.Range(0,360),
			                          Random.Range(0,360),
			                          Random.Range(0,360));

			gameObject.transform.rotation = Quaternion.Euler( rot );
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
